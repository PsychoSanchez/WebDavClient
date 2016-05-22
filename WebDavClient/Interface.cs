using System;
using System.Net;
using WebDavClient.Dialogs;
using System.Web;
using net.kvdb.webdav;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebDAVLibrary.Helpers;
using System.Text;
using System.Net.Http;
using WebDAVLibrary;
using WebDAVLibrary.Model;
using System.IO;

namespace WebDavClient
{
    public class Interface
    {
        public List<string> _files;
        public WebDAVClient c = new WebDAVClient();
        private bool connectSuccess = false;
        IClient client;
        private const string PropFindRequestContent =
            "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
            "<propfind xmlns=\"DAV:\">" +
            "<allprop/>" +
            //"  <propname/>" +
            //"  <prop>" +
            //"    <creationdate/>" +
            //"    <getlastmodified/>" +
            //"    <displayname/>" +
            //"    <getcontentlength/>" +
            //"    <getcontenttype/>" +
            //"    <getetag/>" +
            //"    <resourcetype/>" +
            //"  </prop> " +
            "</propfind>";
        private static readonly HttpMethod Prop = new HttpMethod("PROPFIND");

        public Interface()
        { }

        public async Task<bool> Connect(string url, string username, string passw, string dom)
        {
            client = new Client(new NetworkCredential { UserName = username, Password = passw });
            client.BasePath = "/";
            client.Server = url;
            c.Server = url;
            c.User = username;
            c.Pass = passw;
            c.BasePath = "/";
            try
            {
                IDictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Depth", "0");
                HttpResponseMessage response = null;

                Uri ServerAdress = new Uri(url);
                response = await client.HttpRequest(ServerAdress, Prop, headers, Encoding.UTF8.GetBytes(PropFindRequestContent)).ConfigureAwait(false);
                if (response.StatusCode != (HttpStatusCode)207)
                {
                    connectSuccess = false;
                    WebDAVException ex = new WebDAVException((int)response.StatusCode, string.Format("Не удалось подключиться к серверу (Status Code: {0})", response.StatusCode));
                    throw ex;
                }
                connectSuccess = true;
                //ConnectDiag.Hide();
            }
            catch (WebDAVException ex)
            {
                connectSuccess = false;
                //ConnectDiag.Hide();
                System.Console.WriteLine(ex.ToString());
                Informator.ShowError("Connection failure");
            }
            catch (WebException e)
            {
                //ConnectDiag.Hide();
                connectSuccess = false;
                Informator.ShowError(e.Message);
            }
            catch (Exception e)
            {
                //ConnectDiag.Hide();
                connectSuccess = false;
                Exception ex = e.InnerException ?? e;
                Informator.ShowError("Unable to connect to the remote server.\nReason: " + ex.Message, null);
            }
            return connectSuccess;
        }
        public async Task<IEnumerable<Item>> GetRootFolderItems()
        {
            var files = await client.List();
            return files;
        }
        public async Task<IEnumerable<Item>> GetFolderList(string Path)
        {
            var files = await client.List(Path);
            return files;
        }

        public async Task<bool> uploadFile(string FilePath, string FileName, string CurrentFolder)
        {
            using (var fileStream = File.OpenRead(FilePath))
            {
                var fileUploaded = await client.Upload(CurrentFolder, fileStream, FileName);
                return fileUploaded;
            }
        }

        public async Task<bool> CreateDir(string remotePath, string DirName)
        {
            var IsFolderCreated = await client.CreateDir(remotePath, DirName);
            return IsFolderCreated;
        }

        public async Task DownloadFile(string FileName, string FilePath)
        {
            var file = await client.Download(FileName);
            using (var FilStream = File.OpenWrite(FilePath))
                await file.CopyToAsync(FilStream);
        }
        public async Task<Stream> FilePreviewDownload(string FileName)
        {
            var file = await client.FilePreviewDownload(FileName);
            return file;
        }

        private string EncodeUrl(string Path)
        {
            string[] FilePath = Path.Split('/');
            string NewPath = "";
            for (int i = 0; i < FilePath.Length; i++)
            {
                FilePath[i] = System.Web.HttpUtility.UrlEncode(FilePath[i]);
                NewPath += FilePath[i];
                NewPath += "/";
            }
            NewPath= NewPath.Remove(NewPath.Length - 1, 1);
            return NewPath;
        }
        public async Task<bool> MoveFile(string srcFilePath, string destFilePath)
        {
            //srcFilePath = EncodeUrl(srcFilePath);
            //destFilePath = EncodeUrl(destFilePath);
            var bIsFileMoved = await client.MoveFile(srcFilePath, destFilePath);
            return bIsFileMoved;
        }
        public async Task<bool> MoveFolder(string srcFolderPath, string destFolderPath)
        {
            //srcFolderPath = EncodeUrl(srcFolderPath);
            //destFolderPath = EncodeUrl(destFolderPath);
            var bIsFileMoved = await client.MoveFolder(srcFolderPath, destFolderPath);
            return bIsFileMoved;
        }
        public async Task DeleteFIle(string FilePath)
        {
            await client.DeleteFile(FilePath);
        }
        public async Task DeleteFolder(string FolderPath)
        {
            await client.DeleteFolder(FolderPath);
        }
        public bool ConnectSuccess()
        {
            return connectSuccess;
        }
        internal static string DecodeUrl(string name)
        {
            return HttpUtility.UrlDecode(name.Replace("+", HttpUtility.UrlEncode("+"))); // + request.Url.Fragment
        }
        public void ShowConnectionDialog()
        {
            LoginDialog dialog = new LoginDialog(this);
            dialog.ShowDialog();
        }

        public async Task<Item> GetFolderInfo(string v)
        {
            var info = await client.GetFolder(v);
            return info;
        }

    }
}
