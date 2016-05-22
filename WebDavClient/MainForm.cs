using System;
using System.IO;
using System.Windows.Forms;
using WebDavClient.Dialogs;
using WebDAVLibrary.Helpers;
using WebDAVLibrary.Model;

namespace WebDavClient
{

    public partial class MainForm : Form
    {
        Interface ControlInterface = new Interface();
        private System.Collections.Generic.List<Item> _items = new System.Collections.Generic.List<Item>();
        Timer timer1 = new Timer();
        string MoveFrom = "";
        string MovingName;
        bool IsMovingFolder = false;

        public MainForm()
        {
            InitializeComponent();
            listView1.DragEnter += new DragEventHandler(listView1_DragEnter);
            listView1.DragDrop += new DragEventHandler(listView1_DragDrop);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))

                e.Effect = DragDropEffects.Move;
            StatusText.Text = "Отпустите, чтобы загрузить файлы на сервер";
        }

        private async void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                TreeNode SelectedNode = treeFolders.SelectedNode;
                // В objects хранятся пути к папкам и файлам
                for (int i = 0; i < objects.Length; i++)
                {
                    timer1.Tick += new EventHandler(Timer_Tick);
                    timer1.Start();
                    int? filescount = objects.Length - i;
                    if (i > 1)
                    {

                        StatusText.Text = "Загрузка " + filescount + " файлов на сервер...";
                    }
                    else
                    {
                        StatusText.Text = "Загрузка " + filescount + " файла на сервер...";
                    }
                    string[] Path = objects[i].Split('\\');
                    Console.WriteLine(Path[Path.Length - 1]);
                    treeFolders.SelectedNode = SelectedNode;
                    await ControlInterface.uploadFile(objects[i], Path[Path.Length - 1], ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()));
                    treeFolders.SelectedNode = SelectedNode;
                    UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                }
            }
            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// При появлении окна запускает диалог подключения, в случае выхода из диалога приложение закрывается
        /// В случае успеха подключения загружается корневой список папок;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            StatusProgressBar.Visible = false;
            treeFolders.Nodes.Add("root", "Корневая папка");
            Свойства.Visible = false;
            this.Opacity = 0.9;
            ControlInterface.ShowConnectionDialog();
            if (!ControlInterface.ConnectSuccess())
            {
                Application.Exit();
            }
            else
            {
                //Настраиваем приложение и выводим сообщение в статусбар
                this.Opacity = 1;
                StatusProgressBar.Visible = true;
                timer1.Tick += new EventHandler(Timer_Tick);
                timer1.Start();
                StatusText.Text = "Подключение прошло успешно. Загрузка списка папок с сервера...";

                var result = treeFolders.Nodes.Find("root", false);
                treeFolders.SelectedNode = result[0];
                UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
            }
        }

        /// <summary>
        /// Таймер для прогрессбара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (StatusProgressBar.Value < 100)
            {
                StatusProgressBar.Value += 1;
            }
            else
            {
                StatusProgressBar.Value = 0;
            }
        }
        /// <summary>
        /// Подгрузка списка файлов и папок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Очистка списка подпапок и файлов
            treeFolders.BeginUpdate();
            listView1.Clear();

            //Записываем выбранный кликнутый нод в переменную, чтобы после получения списка мы добавили дочернии папки именно ему (Избегаем ошибки с несуществующим путем) Bug: не обрабатывается, если папку удалили на сервере)
            TreeNode SelectedNode = treeFolders.SelectedNode;
            treeFolders.SelectedNode.Nodes.Clear();

            //Сообщения в статус баре
            StatusProgressBar.Value = 0;
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
            StatusText.Text = "Обновление и загрузка списка подпапок и файлов с сервера...";


            // Обновляем список файлов и папок
            string FullPath = treeFolders.SelectedNode.FullPath.ToString();
            UpdateFileList(FullPath);
        }


        /// <summary>
        /// Загрузка файла
        /// Функция загрузки файла на сервер. Получает путь из openfiledialog и передает его функции 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string ServerFullPath = treeFolders.SelectedNode.FullPath.ToString();
            ServerFullPath = ServerFullPath.Replace("Корневая папка", "");
            ServerFullPath = ServerFullPath.Replace("\\", "/");
            ServerFullPath += "/";
            //Сообщения в статус баре
            StatusProgressBar.Value = 0;
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
            StatusText.Text = "Загрузка файла на сервер...";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            else
            {
                if (treeFolders.SelectedNode != null)
                    await ControlInterface.uploadFile(openFileDialog1.FileName, openFileDialog1.SafeFileName, ServerFullPath);
            }
            listView1.Clear();
            UpdateFileList(ServerFullPath);
        }
        /// <summary>
        /// Загрузка фвйла с сервера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                if (listView1.SelectedItems.Count > 0)
                {
                    FolderBrowserDialog SaveFile = new FolderBrowserDialog();
                    saveFileDialog1.FileName = listView1.SelectedItems[0].Text;
                    //Сообщения в статус баре
                    StatusProgressBar.Value = 0;
                    timer1.Tick += new EventHandler(Timer_Tick);
                    timer1.Start();
                    StatusText.Text = "Загрузка файла c сервера...";
                    string ServerFullPath = treeFolders.SelectedNode.FullPath.ToString();

                    //Парсим путь до папки на сервере
                    ServerFullPath = ServerFullPath.Replace("Корневая папка", "");
                    ServerFullPath = ServerFullPath.Replace("\\", "/");
                    ServerFullPath += "/";
                    ServerFullPath += listView1.SelectedItems[0].Text;
                    ServerFullPath += "/";

                    if (SaveFile.ShowDialog() != DialogResult.OK) return;
                    else
                    {
                        foreach (Item item in _items)
                        {
                            if (!item.IsCollection)
                            {
                                if (item.DisplayName.Equals(listView1.SelectedItems[0].Text))
                                {
                                    await ControlInterface.DownloadFile(ServerFullPath, SaveFile.SelectedPath + "\\" + listView1.SelectedItems[0].Text);
                                    break;
                                }

                            }
                        }
                    }
                    UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                }
            }

        }
        /// <summary>
        /// Создание папки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripButton3_Click(object sender, EventArgs e)
        {
            CreateFolderDialog Dialog = new CreateFolderDialog();

            string ServerFullPath = treeFolders.SelectedNode.FullPath.ToString();

            //Парсим путь до папки на сервере
            ServerFullPath = ServerFullPath.Replace("Корневая папка", "");
            ServerFullPath = ServerFullPath.Replace("\\", "/");
            ServerFullPath += "/";
            if (Dialog.ShowDialog() != DialogResult.OK) return;
            else
            {
                // Сообщения в статус баре
                StatusProgressBar.Value = 0;
                timer1.Tick += new EventHandler(Timer_Tick);
                timer1.Start();
                StatusText.Text = "Создание папки на сервере...";
                var IsFolderCreaterd = await ControlInterface.CreateDir(ServerFullPath, Dialog.FolderName());
                if (IsFolderCreaterd == false)
                {
                    MessageBox.Show(this, "Ошибка при создании папки");
                }
                UpdateFileList(ServerFullPath);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //ControlInterface.Delete(treeFolders.SelectedNode.FullPath.ToString() + listView1.SelectedItems[0].Text);
            }
            else
            {
                //ControlInterface.Delete(treeFolders.SelectedNode.FullPath.ToString());
            }
        }
        /// <summary>
        /// Ивент обновления списка файлов и папок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Сообщения в статус баре
            StatusProgressBar.Value = 0;
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
            StatusText.Text = "Обновление и синхронизация данных с сервером...";
            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
        }
        /// <summary>
        /// Обновление выбранного нода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeFolders.SelectedNode = e.Node;
        }
        /// <summary>
        /// О программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog A = new AboutDialog();
            A.ShowDialog();
        }
        /// <summary>
        /// Смена сервачка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
            ControlInterface.ShowConnectionDialog();
            treeFolders.Nodes.Clear();
            listView1.Clear();
            this.Opacity = 1;
            StatusProgressBar.Visible = true;

            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
            StatusText.Text = "Подключение прошло успешно. Загрузка списка папок с сервера...";
            //            var RootFolder = await ControlInterface.GetRootFolderItems();

            TreeNode Root = treeFolders.Nodes.Add("root", "Корневая папка");
            treeFolders.SelectedNode = Root;
            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());

        }
        /// <summary>
        /// Подгрузка списка файлов и папок, присвоение иконок и добавление
        /// </summary>
        /// <param name="ServerFullPath"></param>
        private async void UpdateFileList(string ServerFullPath)
        {
            TreeNode SelectedNode;
            //Записываем выбранный кликнутый нод в переменную, чтобы после получения списка мы добавили дочернии папки именно ему (Избегаем ошибки с несуществующим путем) Bug: не обрабатывается, если папку удалили на сервере)
            if (treeFolders.SelectedNode != null)
            {
                SelectedNode = treeFolders.SelectedNode;
            }
            else
            {
                var root = treeFolders.Nodes.Find("Корневая папка", false);
                SelectedNode = root[0];
            }

            //Парсим путь до папки на сервере
            ServerFullPath = ServerFullPath.Replace("Корневая папка", "");
            ServerFullPath = ServerFullPath.Replace("\\", "/");
            ServerFullPath += "/";
            bool resultOk = true;
            try
            {
                await ControlInterface.GetFolderList(ServerFullPath);
            }
            catch (WebDAVException)
            {
                resultOk = false;
            }
            if (resultOk)
            {
                var files = await ControlInterface.GetFolderList(ServerFullPath);
                listView1.Clear();
                treeFolders.SelectedNode.Nodes.Clear();
                treeFolders.SelectedNode = SelectedNode;

                foreach (Item item in files)
                {
                    if (!item.IsCollection)
                    {
                        if (!_items.Contains(item))
                            _items.Add(item);
                        var FileName = item.DisplayName.Split('.');
                        //var previewfile = await ControlInterface.FilePreviewDownload(ServerFullPath + item.DisplayName);
                        switch (FileName[1])
                        {
                            case "doc":
                            case "docx":
                                listView1.Items.Add(item.DisplayName, 6);
                                break;
                            case "xslx":
                                listView1.Items.Add(item.DisplayName, 6);
                                break;
                            case "rar":
                                listView1.Items.Add(item.DisplayName, 9);
                                break;
                            case "zip":
                                listView1.Items.Add(item.DisplayName, 9);
                                break;
                            case "png":
                                listView1.Items.Add(item.DisplayName, 8);
                                break;
                            case "jpg":
                                listView1.Items.Add(item.DisplayName, 8);
                                break;
                            case "jpeg":
                                listView1.Items.Add(item.DisplayName, 8);
                                break;
                            case "bmp":
                                listView1.Items.Add(item.DisplayName, 8);
                                break;
                            case "gif":
                                listView1.Items.Add(item.DisplayName, 8);
                                break;
                            case "exe":
                                listView1.Items.Add(item.DisplayName, 11);
                                break;
                            case "webm":
                                listView1.Items.Add(item.DisplayName, 7);
                                break;
                            case "mp3":
                            case "waw":
                                listView1.Items.Add(item.DisplayName, 5);
                                break;
                            case "txt":
                                listView1.Items.Add(item.DisplayName, 10);
                                break;
                            default:
                                listView1.Items.Add(item.DisplayName, 4);
                                break;
                        }
                    }
                    else
                    {
                        if (!_items.Contains(item))
                            _items.Add(item);
                        listView1.Items.Add(item.DisplayName, 0);
                        treeFolders.SelectedNode.Nodes.Add(item.Href, item.DisplayName);
                    }
                }
                treeFolders.SelectedNode.ImageIndex = 1;
                PathLabel.Text = treeFolders.SelectedNode.FullPath.ToString();
                //Обновляем дерево и список, выводим нужные сообщения в статус
                treeFolders.Update();
                listView1.Update();
                Свойства.Visible = false;
                treeFolders.ExpandAll();
                timer1.Stop();
                StatusProgressBar.Value = 100;
                StatusText.Text = "Готово";
                treeFolders.EndUpdate();
            }
        }
        /// <summary>
        /// Показывает свойства выбранного файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (Item item in _items)
                {
                    if (!item.IsCollection)
                    {
                        if (item.DisplayName.Equals(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text))
                        {
                            UpdateProperties(item);
                            break;
                        }

                    }
                    Свойства.Visible = false;
                }

            }
            else
                Свойства.Visible = false;
        }
        /// <summary>
        /// Фукция получения свойств файла
        /// </summary>
        /// <param name="item"></param>
        private void UpdateProperties(Item item)
        {
            Свойства.Visible = true;
            if (item.IsCollection == false)
            {
                var FileName = item.DisplayName.Split('.');
                NamePropLabel.Text = "Имя файла: " + FileName[0];
                if (FileName[1] != null)
                    TypePropLabel.Text = "Тип: " + FileName[1];
                else TypePropLabel.Text = "Тип: Неизвестно";
                CreationDatePropLabel.Text = "Дата создания: " + item.CreationDate.ToString();
                LastModifiedPropLabel.Text = "Последнее изменение: " + item.LastModified.ToString();
                if (item.ContentLength > 1024)
                {
                    int? FileSize;
                    if (item.ContentLength > 1024000)
                    {
                        FileSize = item.ContentLength / 1024000;
                        SizePropLabel.Text = "Размер: " + FileSize.ToString() + " МБайт";
                    }
                    else
                    {
                        FileSize = item.ContentLength / 1024;
                        SizePropLabel.Text = "Размер: " + FileSize.ToString() + " КБайт";
                    }
                }
                else
                {
                    SizePropLabel.Text = "Размер: " + item.ContentLength.ToString() + " Байт";
                }
            }
            else
            {
                var FileName = item.DisplayName.Split('.');
                NamePropLabel.Text = "Имя папки: " + FileName[0];
                TypePropLabel.Text = "Тип: Папка";
                CreationDatePropLabel.Text = "Дата создания: " + item.CreationDate.ToString();
                LastModifiedPropLabel.Text = "Последнее изменение: " + item.LastModified.ToString();
                SizePropLabel.Text = "";
            }
        }
        /// <summary>
        /// Свойства папки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void свойстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Item item in _items)
            {
                if (item.IsCollection)
                {
                    if (item.DisplayName.Equals(treeFolders.SelectedNode.Text))
                    {
                        UpdateProperties(item);
                        break;
                    }

                }
                Свойства.Visible = false;
            }
        }

        private string ParseServerFolderPath(string ServerFullPath)
        {
            ServerFullPath = ServerFullPath.Replace("Корневая папка", "");
            ServerFullPath = ServerFullPath.Replace("\\", "/");
            return ServerFullPath;
        }
        private string ParseServerFilePath(string ServerFullPath)
        {
            ServerFullPath = ServerFullPath.Replace("Корневая папка", "");
            ServerFullPath = ServerFullPath.Replace("\\", "/");
            ServerFullPath += "/";
            return ServerFullPath;
        }

        private async void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeFolders.SelectedNode;
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
            StatusText.Text = "Удаление директории и подветвей...";
            var FolderInfo = await ControlInterface.GetFolderInfo(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
            await ControlInterface.DeleteFolder(FolderInfo.Href);
            if (SelectedNode.Parent != null)
                treeFolders.SelectedNode = SelectedNode.Parent;
            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (Item item in _items)
                {
                    if (item.IsCollection)
                    {
                        timer1.Tick += new EventHandler(Timer_Tick);
                        timer1.Start();
                        StatusText.Text = "Обновление и загрузка списка подпапок и файлов с сервера...";
                        string decoded = System.Web.HttpUtility.UrlDecode(item.Href);
                        if (decoded.Equals(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text + "/"))
                        {
                            var SelectedNode = treeFolders.Nodes.Find(item.Href, true);
                            treeFolders.SelectedNode = SelectedNode[0];
                            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                            break;
                        }
                    }
                    else
                    {
                        if (item.DisplayName.Equals(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text))
                        {
                            toolStripButton2_Click(null, null);
                            break;
                        }
                    }
                }
            }
        }

        private void StepUpButton_Click(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
            StatusText.Text = "Обновление и загрузка списка подпапок и файлов с сервера...";
            if (treeFolders.SelectedNode.Parent != null)
            {
                treeFolders.SelectedNode = treeFolders.SelectedNode.Parent;
            }
            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeFolders_NodeMouseDoubleClick(null, null);
        }

        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (Item item in _items)
                {
                    if (item.IsCollection)
                    {
                        //Декодируем ссылку
                        string decoded = System.Web.HttpUtility.UrlDecode(item.Href);
                        if (decoded.Equals(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text + "/"))
                        {
                            var SelectedNode = treeFolders.Nodes.Find(item.Href, true);
                            treeFolders.SelectedNode = SelectedNode[0];
                            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                            break;
                        }
                    }
                    else
                    {
                        if (item.DisplayName.Equals(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text))
                        {
                            toolStripButton2_Click(null, null);
                            break;
                        }
                    }
                }
            }
        }

        private async void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    timer1.Tick += new EventHandler(Timer_Tick);
                    timer1.Start();
                    int filescount = listView1.SelectedItems.Count - i;
                    StatusText.Text = "Удаление " + filescount + " элементов...";
                    foreach (Item item in _items)
                    {
                        //Console.WriteLine(_items.IndexOf(item));
                        //Console.WriteLine(_items.Count);
                        if (item.IsCollection)
                        {
                            string decoded = System.Web.HttpUtility.UrlDecode(item.Href);
                            if (decoded.Equals(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + listView1.SelectedItems[i].Text + "/"))
                            {

                                timer1.Tick += new EventHandler(Timer_Tick);
                                timer1.Start();
                                StatusText.Text = "Удаление директории и подветвей...";



                                var SelectedNode = treeFolders.Nodes.Find(item.Href, true);
                                treeFolders.SelectedNode = SelectedNode[0];
                                var FolderInfo = await ControlInterface.GetFolderInfo(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
                                await ControlInterface.DeleteFolder(FolderInfo.Href);
                                //await ControlInterface.DeleteFolder(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
                                //await ControlInterface.DeleteFIle(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
                                if (SelectedNode[0].Parent != null)
                                {
                                    treeFolders.SelectedNode = SelectedNode[0].Parent;
                                }
                                UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                                break;
                            }
                        }
                        else
                        {
                            if (item.DisplayName.Equals(listView1.SelectedItems[i].Text))
                            {
                                await ControlInterface.DeleteFIle(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + item.DisplayName);
                                UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                                break;
                            }
                        }
                    }
                }
                //foreach (Item item in _items)
                //{
                //    if (item.IsCollection)
                //    {
                //        string decoded = System.Web.HttpUtility.UrlDecode(item.Href);
                //        if (decoded.Equals(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text + "/"))
                //        {

                //            timer1.Tick += new EventHandler(Timer_Tick);
                //            timer1.Start();
                //            StatusText.Text = "Удаление директории и подветвей...";



                //            var SelectedNode = treeFolders.Nodes.Find(item.Href, true);
                //            treeFolders.SelectedNode = SelectedNode[0];
                //            var FolderInfo = await ControlInterface.GetFolderInfo(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
                //            await ControlInterface.DeleteFolder(FolderInfo.Href);
                //            //await ControlInterface.DeleteFolder(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
                //            //await ControlInterface.DeleteFIle(ParseServerFolderPath(treeFolders.SelectedNode.FullPath.ToString()));
                //            if (SelectedNode[0].Parent != null)
                //            {
                //                treeFolders.SelectedNode = SelectedNode[0].Parent;
                //            }
                //            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                //            break;
                //        }
                //    }
                //    else
                //    {
                //        if (item.DisplayName.Equals(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text))
                //        {
                //            await ControlInterface.DeleteFIle(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + item.DisplayName);
                //            UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
                //            break;
                //        }
                //    }
                //}
            }
        }

        private void создатьПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(null, null);
        }

        private void listView1_DragLeave(object sender, EventArgs e)
        {
            StatusText.Text = "Перетащите файлы, чтобы загрузить их на сервер.";
        }

        private void переместитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                foreach (Item item in _items)
                {
                    //Console.WriteLine(_items.IndexOf(item));
                    //Console.WriteLine(_items.Count);
                    if (item.IsCollection)
                    {
                        string decoded = System.Web.HttpUtility.UrlDecode(item.Href);
                        if (decoded.Equals(ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + listView1.SelectedItems[0].Text + "/"))
                        {
                            StatusText.Text = "Ожидание завершения перемещения папки...";
                            MoveFrom = ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString());
                            MovingName = listView1.SelectedItems[0].Text;
                            Console.WriteLine(MoveFrom);
                            ПереместитьСюда.Visible = true;
                            IsMovingFolder = true;
                            break;
                        }
                    }
                    else
                    {
                        if (item.DisplayName.Equals(listView1.SelectedItems[0].Text))
                        {
                            StatusText.Text = "Ожидание завершения перемещения файла...";
                            MoveFrom = ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString());
                            MovingName = listView1.SelectedItems[0].Text;
                            Console.WriteLine(MoveFrom);
                            ПереместитьСюда.Visible = true;
                            IsMovingFolder = false;
                            break;
                        }
                    }
                }
            }
        }

        private async void ПереместитьСюда_Click(object sender, EventArgs e)
        {
            ПереместитьСюда.Visible = false;
            if (IsMovingFolder)
            {
                timer1.Tick += new EventHandler(Timer_Tick);
                timer1.Start();
                StatusText.Text = "Перемещение папки...";
                try
                {
                    await ControlInterface.MoveFolder(MoveFrom + MovingName, ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + MovingName);
                }
                catch(WebDAVException)
                {
                    StatusText.Text = "Ошибка при перемещении.";
                }
                UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
            }
            else
            {
                timer1.Tick += new EventHandler(Timer_Tick);
                timer1.Start();
                StatusText.Text = "Перемещение файла...";
                try
                {
                    await ControlInterface.MoveFile(MoveFrom + MovingName, ParseServerFilePath(treeFolders.SelectedNode.FullPath.ToString()) + MovingName);
                }
                catch (WebDAVException)
                {
                    StatusText.Text = "Ошибка при перемещении.";
                }
                UpdateFileList(treeFolders.SelectedNode.FullPath.ToString());
            }
        }

        //private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        //{
        //}

        //private async void listView1_DragDrop_1(object sender, DragEventArgs e)
        //{

        //}

        //private void listView1_DragOver(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Copy;
        //    Console.WriteLine((string[])e.Data.GetData(DataFormats.FileDrop));
        //}

        //private async void listView1_MouseDown(object sender, MouseEventArgs e)
        //{


        //}

        //private async void listView1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (listView1.SelectedItems.Count > 0)
        //    {
        //        string serverfilePath = treeFolders.SelectedNode.FullPath.ToString();
        //        string filename = listView1.SelectedItems[0].Text;
        //        serverfilePath = serverfilePath.Replace("Корневая папка", "");
        //        serverfilePath = serverfilePath.Replace("\\", "/");
        //        serverfilePath += "/";
        //        serverfilePath += listView1.SelectedItems[0].Text;
        //        serverfilePath += "/";
        //        Stream Filesaved = await ControlInterface.DragAndDropDownload(serverfilePath);
        //        string Folder = Path.GetTempPath();
        //        using (var FilStream = File.OpenWrite(Folder + filename))
        //            await Filesaved.CopyToAsync(FilStream);
        //        Folder += "/";
        //        Folder += listView1.SelectedItems[0].Text;
        //        listView1.DoDragDrop(new DataObject(DataFormats.FileDrop, Folder), DragDropEffects.Copy);
        //    }
        //}
    }



}
