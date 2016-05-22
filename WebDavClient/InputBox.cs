using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDavClient
{
    public partial class InputBox : Form
    {
        Size lbltextoriginalsize;
        Size pnlwhiteoroginalsize;

        public InputBox(string text, string defaultvalue, string caption)
        {
            InitializeComponent();
            this.pnlWhite.Resize += new System.EventHandler(this.pnlWhite_Resize);
            this.lblText.Resize += new System.EventHandler(this.lblText_Resize);
            picIcon.Image = SystemIcons.Question.ToBitmap();
            lbltextoriginalsize = lblText.Size;
            pnlwhiteoroginalsize = pnlWhite.Size;
            this.lblText.Text = text;
            this.UserName.Text = "UserName";
            this.Password.Text = "Password";
            this.Text = caption;
        }

        private void lblText_Resize(object sender, EventArgs e)
        {
            pnlWhite.Size += lblText.Size - lbltextoriginalsize;
        }

        private void pnlWhite_Resize(object sender, EventArgs e)
        {
            this.Size += pnlWhite.Size - pnlwhiteoroginalsize;
        }

        public string  Value
        {
            get { return UserName.Text;}
        }
        public InputBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        public void GetPassAndLogin(out String UserName, out String Password)
        {
            UserName = this.UserName.Text;
            Password = this.Password.Text;
        }
    }
    public static class InputBoxForm
    {
        public static DialogResult Show(string text, out string result)
        {
            return ShowCore(null, text, null, null, out result);
        }
        public static DialogResult Show(IWin32Window owner, string text, out string result)
        {
            return ShowCore(owner, text, null, null, out result);
        }
        public static DialogResult Show(string text, string defaultValue, out string result)
        {
            return ShowCore(null, text, defaultValue, null, out result);
        }
        public static DialogResult Show(IWin32Window owner, string text, string defaultValue, out string result)
        {
            return ShowCore(owner, text, defaultValue, null, out result);
        }
        public static DialogResult Show(string text, string defaultValue, string caption, out string result)
        {
            return ShowCore(null, text, defaultValue, caption, out result);
        }
        public static DialogResult Show(IWin32Window owner, string text, string defaultValue, string caption, out string result)
        {
            return ShowCore(owner, text, defaultValue, caption, out result);
        }

        private static DialogResult ShowCore(IWin32Window owner, string text, string defaultValue, string caption, out string result)
        {
            InputBox box = new InputBox(text, defaultValue, caption);
            DialogResult retval = box.ShowDialog(owner);
            result = box.Value;
            return retval;
        }
    }
}
