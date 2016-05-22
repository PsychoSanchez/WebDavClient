using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
//using WebDAVClient;
//using net.kvdb.webdav;


namespace WebDavClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServicePointManager.DefaultConnectionLimit = 100;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Run(new MainForm());
            //WebDAVClient c = new WebDAVClient();
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show((ex.InnerException ?? ex).ToString());
        }
        //private static async Task MainAsync()
        //{
        //    // Basic authentication required
        //    IClient c = new Client(new NetworkCredential { UserName = "aronov.aleks@yandex.ru", Password = "Aleks2311" });
        //    c.Server = "https://webdav.4shared.com";
        //    c.BasePath = "/";

        //    // List items in the root folder
        //    var files = await c.List();
        //    // Find first folder in the root folder
        //    var folder = files.FirstOrDefault(f => f.Href.EndsWith("/Test/"));
        //    // Load a specific folder
        //    var folderReloaded = await c.GetFolder(folder.Href);

        //    // List items in the folder
        //    var folderFiles = await c.List(folderReloaded.Href);
        //    // Find a file in the folder
        //    var folderFile = folderFiles.FirstOrDefault(f => f.IsCollection == false);

        //    var tempFileName = Path.GetTempFileName();

        //    // Download item into a temporary file
        //    using (var tempFile = File.OpenWrite(tempFileName))
        //    using (var stream = await c.Download(folderFile.Href))
        //        await stream.CopyToAsync(tempFile);

        //    // Update file back to webdav
        //    var tempName = Path.GetRandomFileName();
        //    using (var fileStream = File.OpenRead(tempFileName))
        //    {
        //        var fileUploaded = await c.Upload(folder.Href, fileStream, tempName);
        //    }

        //    // Create a folder
        //    var tempFolderName = Path.GetRandomFileName();
        //    var isfolderCreated = await c.CreateDir("/", tempFolderName);

        //    // Delete created folder
        //    var folderCreated = await c.GetFolder("/" + tempFolderName);
        //    await c.DeleteFolder(folderCreated.Href);
        //}
    }
}
