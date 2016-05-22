namespace WebDavClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переместитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.Свойства = new System.Windows.Forms.GroupBox();
            this.SizePropLabel = new System.Windows.Forms.Label();
            this.TypePropLabel = new System.Windows.Forms.Label();
            this.LastModifiedPropLabel = new System.Windows.Forms.Label();
            this.CreationDatePropLabel = new System.Windows.Forms.Label();
            this.NamePropLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UploadFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StepUpButton = new System.Windows.Forms.ToolStripButton();
            this.PathLabel = new System.Windows.Forms.ToolStripLabel();
            this.StatusPanel = new System.Windows.Forms.StatusStrip();
            this.StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.переместитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ПереместитьСюда = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuListBox.SuspendLayout();
            this.Свойства.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 471);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.treeFolders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 424);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // treeFolders
            // 
            this.treeFolders.AllowDrop = true;
            this.treeFolders.ContextMenuStrip = this.contextMenuStrip1;
            this.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolders.ImageIndex = 0;
            this.treeFolders.ImageList = this.ImageListIcons;
            this.treeFolders.Location = new System.Drawing.Point(3, 3);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.SelectedImageIndex = 0;
            this.treeFolders.Size = new System.Drawing.Size(194, 418);
            this.treeFolders.StateImageList = this.ImageListIcons;
            this.treeFolders.TabIndex = 0;
            this.treeFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFolders_NodeMouseClick);
            this.treeFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFolders_NodeMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.создатьПапкуToolStripMenuItem,
            this.переместитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.свойстваToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // создатьПапкуToolStripMenuItem
            // 
            this.создатьПапкуToolStripMenuItem.Name = "создатьПапкуToolStripMenuItem";
            this.создатьПапкуToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.создатьПапкуToolStripMenuItem.Text = "Создать папку";
            this.создатьПапкуToolStripMenuItem.Click += new System.EventHandler(this.создатьПапкуToolStripMenuItem_Click);
            // 
            // переместитьToolStripMenuItem
            // 
            this.переместитьToolStripMenuItem.Name = "переместитьToolStripMenuItem";
            this.переместитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.переместитьToolStripMenuItem.Text = "Переместить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click_1);
            // 
            // свойстваToolStripMenuItem
            // 
            this.свойстваToolStripMenuItem.Name = "свойстваToolStripMenuItem";
            this.свойстваToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.свойстваToolStripMenuItem.Text = "Свойства";
            this.свойстваToolStripMenuItem.Click += new System.EventHandler(this.свойстваToolStripMenuItem_Click);
            // 
            // ImageListIcons
            // 
            this.ImageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListIcons.ImageStream")));
            this.ImageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListIcons.Images.SetKeyName(0, "normal_folder.png");
            this.ImageListIcons.Images.SetKeyName(1, "folder-open-icon.png");
            this.ImageListIcons.Images.SetKeyName(2, "mp3logo.png");
            this.ImageListIcons.Images.SetKeyName(3, "ts-2221.png");
            this.ImageListIcons.Images.SetKeyName(4, "defaulticon.png");
            this.ImageListIcons.Images.SetKeyName(5, "WAV.png");
            this.ImageListIcons.Images.SetKeyName(6, "Word.svg.png");
            this.ImageListIcons.Images.SetKeyName(7, "webm.jpeg");
            this.ImageListIcons.Images.SetKeyName(8, "png.jpg");
            this.ImageListIcons.Images.SetKeyName(9, "rar.png");
            this.ImageListIcons.Images.SetKeyName(10, "txt.png");
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.Свойства);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(203, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 418);
            this.panel2.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.ContextMenuStrip = this.contextMenuListBox;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList2;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(694, 303);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DragLeave += new System.EventHandler(this.listView1_DragLeave);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // contextMenuListBox
            // 
            this.contextMenuListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьToolStripMenuItem,
            this.переместитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem1});
            this.contextMenuListBox.Name = "contextMenuListBox";
            this.contextMenuListBox.Size = new System.Drawing.Size(147, 70);
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            this.скачатьToolStripMenuItem.Click += new System.EventHandler(this.скачатьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "normal_folder.png");
            this.imageList2.Images.SetKeyName(1, "folder-open-icon.png");
            this.imageList2.Images.SetKeyName(2, "mp3logo.png");
            this.imageList2.Images.SetKeyName(3, "ts-2221.png");
            this.imageList2.Images.SetKeyName(4, "upload-file-icon-png-28.png");
            this.imageList2.Images.SetKeyName(5, "WAV_file_icon.png");
            this.imageList2.Images.SetKeyName(6, "Word_2013_file_icon.svg.png");
            this.imageList2.Images.SetKeyName(7, "красивые-картинки-песочница-мем-мемы-1940978.jpeg");
            this.imageList2.Images.SetKeyName(8, "скачанные файлы.jpg");
            this.imageList2.Images.SetKeyName(9, "rar.png");
            this.imageList2.Images.SetKeyName(10, "txt.png");
            this.imageList2.Images.SetKeyName(11, "application-x-ms-dos-executable.png");
            // 
            // Свойства
            // 
            this.Свойства.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Свойства.Controls.Add(this.SizePropLabel);
            this.Свойства.Controls.Add(this.TypePropLabel);
            this.Свойства.Controls.Add(this.LastModifiedPropLabel);
            this.Свойства.Controls.Add(this.CreationDatePropLabel);
            this.Свойства.Controls.Add(this.NamePropLabel);
            this.Свойства.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Свойства.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Свойства.Location = new System.Drawing.Point(0, 303);
            this.Свойства.Name = "Свойства";
            this.Свойства.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Свойства.Size = new System.Drawing.Size(694, 115);
            this.Свойства.TabIndex = 4;
            this.Свойства.TabStop = false;
            this.Свойства.Text = "Свойства";
            // 
            // SizePropLabel
            // 
            this.SizePropLabel.AutoSize = true;
            this.SizePropLabel.Location = new System.Drawing.Point(6, 64);
            this.SizePropLabel.Name = "SizePropLabel";
            this.SizePropLabel.Size = new System.Drawing.Size(49, 13);
            this.SizePropLabel.TabIndex = 4;
            this.SizePropLabel.Text = ":Размер";
            // 
            // TypePropLabel
            // 
            this.TypePropLabel.AutoSize = true;
            this.TypePropLabel.Location = new System.Drawing.Point(6, 40);
            this.TypePropLabel.Name = "TypePropLabel";
            this.TypePropLabel.Size = new System.Drawing.Size(29, 13);
            this.TypePropLabel.TabIndex = 3;
            this.TypePropLabel.Text = ":Тип";
            // 
            // LastModifiedPropLabel
            // 
            this.LastModifiedPropLabel.AutoSize = true;
            this.LastModifiedPropLabel.Location = new System.Drawing.Point(340, 39);
            this.LastModifiedPropLabel.Name = "LastModifiedPropLabel";
            this.LastModifiedPropLabel.Size = new System.Drawing.Size(157, 13);
            this.LastModifiedPropLabel.TabIndex = 2;
            this.LastModifiedPropLabel.Text = ":Дата последнего изменения";
            // 
            // CreationDatePropLabel
            // 
            this.CreationDatePropLabel.AutoSize = true;
            this.CreationDatePropLabel.Location = new System.Drawing.Point(340, 16);
            this.CreationDatePropLabel.Name = "CreationDatePropLabel";
            this.CreationDatePropLabel.Size = new System.Drawing.Size(87, 13);
            this.CreationDatePropLabel.TabIndex = 1;
            this.CreationDatePropLabel.Text = ":Дата создания";
            // 
            // NamePropLabel
            // 
            this.NamePropLabel.AutoSize = true;
            this.NamePropLabel.Location = new System.Drawing.Point(6, 16);
            this.NamePropLabel.Name = "NamePropLabel";
            this.NamePropLabel.Size = new System.Drawing.Size(67, 13);
            this.NamePropLabel.TabIndex = 0;
            this.NamePropLabel.Text = ":Имя файла";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadFile,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.StepUpButton,
            this.PathLabel,
            this.ПереместитьСюда});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UploadFile
            // 
            this.UploadFile.Image = global::WebDavClient.Properties.Resources.document_upload128x128;
            this.UploadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UploadFile.Name = "UploadFile";
            this.UploadFile.Size = new System.Drawing.Size(117, 22);
            this.UploadFile.Text = "Отправить файл";
            this.UploadFile.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::WebDavClient.Properties.Resources.Connect32;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton2.Text = "Скачать файл";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::WebDavClient.Properties.Resources.w128h1281384699841folderadd3;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(105, 22);
            this.toolStripButton3.Text = "Создать папку";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::WebDavClient.Properties.Resources.w256h2561372342427folderdelete256;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(71, 22);
            this.toolStripButton4.Text = "Удалить";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::WebDavClient.Properties.Resources.gtk_refresh_9395;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton5.Text = "Обновить";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // StepUpButton
            // 
            this.StepUpButton.Image = global::WebDavClient.Properties.Resources.Up32;
            this.StepUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StepUpButton.Name = "StepUpButton";
            this.StepUpButton.Size = new System.Drawing.Size(58, 22);
            this.StepUpButton.Text = "Вверх";
            this.StepUpButton.Click += new System.EventHandler(this.StepUpButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PathLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PathLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(29, 22);
            this.PathLabel.Text = "root";
            // 
            // StatusPanel
            // 
            this.StatusPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusProgressBar,
            this.StatusText});
            this.StatusPanel.Location = new System.Drawing.Point(0, 473);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(900, 22);
            this.StatusPanel.TabIndex = 1;
            this.StatusPanel.Text = "statusStrip1";
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(138, 17);
            this.StatusText.Text = "Waiting for connection...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "FIle";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // переместитьToolStripMenuItem1
            // 
            this.переместитьToolStripMenuItem1.Name = "переместитьToolStripMenuItem1";
            this.переместитьToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.переместитьToolStripMenuItem1.Text = "Переместить";
            this.переместитьToolStripMenuItem1.Click += new System.EventHandler(this.переместитьToolStripMenuItem1_Click);
            // 
            // ПереместитьСюда
            // 
            this.ПереместитьСюда.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ПереместитьСюда.Image = ((System.Drawing.Image)(resources.GetObject("ПереместитьСюда.Image")));
            this.ПереместитьСюда.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ПереместитьСюда.Name = "ПереместитьСюда";
            this.ПереместитьСюда.Size = new System.Drawing.Size(114, 22);
            this.ПереместитьСюда.Text = "Переместить сюда";
            this.ПереместитьСюда.Visible = false;
            this.ПереместитьСюда.Click += new System.EventHandler(this.ПереместитьСюда_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 495);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainForm";
            this.Text = "WebDAVClient Aronov 13-PRI";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuListBox.ResumeLayout(false);
            this.Свойства.ResumeLayout(false);
            this.Свойства.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.StatusStrip StatusPanel;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton UploadFile;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripProgressBar StatusProgressBar;
        private System.Windows.Forms.GroupBox Свойства;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NamePropLabel;
        private System.Windows.Forms.Label CreationDatePropLabel;
        private System.Windows.Forms.Label LastModifiedPropLabel;
        private System.Windows.Forms.Label TypePropLabel;
        private System.Windows.Forms.Label SizePropLabel;
        private System.Windows.Forms.ImageList ImageListIcons;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переместитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel PathLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton StepUpButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuListBox;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem создатьПапкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переместитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton ПереместитьСюда;
    }
}

