using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDavClient.Dialogs
{
    public partial class CreateFolderDialog : Form
    {
        public CreateFolderDialog()
        {
            InitializeComponent();
        }


        public string FolderName()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                return textBox1.Text;
            else
                return "New Folder";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
