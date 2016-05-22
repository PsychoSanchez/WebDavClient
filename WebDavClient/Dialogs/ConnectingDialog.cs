using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDavClient.Dialogs
{
    public partial class ConnectingDialog : Form
    {
        private string server, LoginAs;

        public ConnectingDialog()
        {
            InitializeComponent();
        }
        public ConnectingDialog(string serverUri, string login)
        {
            server = serverUri;
            LoginAs = login;
            InitializeComponent();
            Connecting_to.Text = "Connecting to " + server;
            as_person.Text = "as " + LoginAs;
        }
        public void ConnectClose()
        {
            if (this.Visible)
                this.Close();
        }

        private void ConnectingDialog_Shown(object sender, EventArgs e)
        {
            Connecting_to.Text = "Connecting to " + server;
            as_person.Text = "as " + LoginAs;
        }
    }
}
