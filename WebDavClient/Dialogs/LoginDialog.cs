using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Threading;
using System.Web.UI.WebControls;

namespace WebDavClient.Dialogs
{
    public partial class LoginDialog : Form
    {
        private readonly Interface browser;
        private string serverUri;
        private string userName;
        private string password;
        private string domain;
        private readonly string iniFile;
        public LoginDialog(Interface browser)
        {
            InitializeComponent();
            this.browser = browser;
            Server.SelectedIndex = 0;
            serverUri = "https://webdav.4shared.com";
           // Server.SelectedItem = 0;
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            if (wi != null)
                this.rbDefaultCredentials.Text = "Login as " + wi.Name;
            else
                this.rbDefaultCredentials.Enabled = false;

            iniFile = Path.ChangeExtension(Application.ExecutablePath, "ini");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, "Client");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            iniFile = Path.Combine(path, Path.GetFileName(iniFile));

            if (File.Exists(iniFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(iniFile);
                XmlNodeList nodes = doc.SelectNodes("settings/login/server");
                if (nodes != null && nodes.Count > 0)
                {
                    object Serv = nodes[0].InnerText;
                    serverUri = nodes[0].InnerText;
                    Server.SelectedIndex = Server.FindString(nodes[0].InnerText.Replace("https://webdav.",""));


                }

                nodes = doc.SelectNodes("settings/login/user");
                if (nodes != null && nodes.Count > 0)
                    this.userName = nodes[0].InnerText;
                nodes = doc.SelectNodes("settings/login/password");
                if (nodes != null && nodes.Count > 0)
                    this.tbPassword.Text = nodes[0].InnerText;
                nodes = doc.SelectNodes("settings/login/domain");
                if (nodes != null && nodes.Count > 0)
                    this.domain = nodes[0].InnerText;

                if (!string.IsNullOrEmpty(domain) && !string.IsNullOrEmpty(userName))
                    this.tbUserName.Text = domain + "\\" + userName;
                else
                    this.tbUserName.Text = userName;
            }
            rbDefaultCredentials_CheckedChanged(null, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            tbUserName.Enabled = tbPassword.Enabled = false;
            Application.DoEvents();

            if (rbCustomCredentials.Checked)
            {
                userName = tbUserName.Text;
                password = tbPassword.Text;
            }
            else
            {
                userName = WindowsIdentity.GetCurrent().Name;
                password = null;
            }

            domain = null;

            if (userName != null)
            {
                string separator = GetSeparator(userName);
                if (separator != null)
                {
                    domain = userName.Remove(userName.IndexOf(separator));
                    userName = userName.Substring(userName.IndexOf(separator) + separator.Length);
                }
            }
            ConnectingDialog ConnectDiag = new ConnectingDialog(serverUri, userName);
            ConnectDiag.Show(this);
            ConnectDiag.Update();
            Task<bool> task = browser.Connect(serverUri, userName, password, domain);

            while (!task.IsCompleted)
            {

            }


            if (task.Result)
            {
                XmlDocument doc = new XmlDocument();
                XmlNode root = doc.CreateNode(XmlNodeType.Element, "settings", "");
                XmlNode login = root.AppendChild(doc.CreateNode(XmlNodeType.Element, "login", ""));
                XmlNode node = login.AppendChild(doc.CreateNode(XmlNodeType.Element, "server", ""));
                node.InnerText = serverUri;
                node = login.AppendChild(doc.CreateNode(XmlNodeType.Element, "user", ""));
                node.InnerText = userName ?? tbUserName.Text;
                node = login.AppendChild(doc.CreateNode(XmlNodeType.Element, "password", ""));
                node.InnerText = password ?? tbPassword.Text;
                node = login.AppendChild(doc.CreateNode(XmlNodeType.Element, "domain", ""));
                node.InnerText = domain;
                doc.AppendChild(root);
                doc.Save(iniFile);
                this.Close();
                ConnectDiag.Hide();
            }
            else
            {
                ConnectDiag.Hide();
                // tbServer.Enabled = tbUserName.Enabled = tbPassword.Enabled = true;
                rbDefaultCredentials_CheckedChanged(null, null);
            }
        }

        private static string GetSeparator(string login)
        {
            if (login.Contains("//"))
                return "//";
            if (login.Contains(@"\\"))
                return @"\\";
            if (login.Contains("/"))
                return "/";
            return login.Contains(@"\") ? @"\" : null;
        }

        private void rbDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            tbUserName.Enabled = tbPassword.Enabled = rbCustomCredentials.Checked;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serverUri = "https://webdav." + Server.SelectedItem.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LoginDialog_Shown(object sender, EventArgs e)
        {
        }
    }
}
