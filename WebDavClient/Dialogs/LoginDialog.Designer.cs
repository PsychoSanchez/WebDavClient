namespace WebDavClient.Dialogs
{
    partial class LoginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbCustomCredentials = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.Server = new System.Windows.Forms.ComboBox();
            this.rbDefaultCredentials = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbCustomCredentials
            // 
            this.rbCustomCredentials.AutoSize = true;
            this.rbCustomCredentials.Checked = true;
            this.rbCustomCredentials.Location = new System.Drawing.Point(7, 61);
            this.rbCustomCredentials.Name = "rbCustomCredentials";
            this.rbCustomCredentials.Size = new System.Drawing.Size(114, 17);
            this.rbCustomCredentials.TabIndex = 12;
            this.rbCustomCredentials.TabStop = true;
            this.rbCustomCredentials.Text = "Specify credentials";
            this.rbCustomCredentials.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Server:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(108, 110);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(176, 20);
            this.tbPassword.TabIndex = 16;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(108, 84);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(176, 20);
            this.tbUserName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Login:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(209, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(128, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Server
            // 
            this.Server.BackColor = System.Drawing.SystemColors.Menu;
            this.Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Server.FormattingEnabled = true;
            this.Server.Items.AddRange(new object[] {
            "4shared.com",
            "yandex.ru",
            "cloud.mail.ru"});
            this.Server.Location = new System.Drawing.Point(59, 11);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(225, 21);
            this.Server.TabIndex = 21;
            this.Server.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // rbDefaultCredentials
            // 
            this.rbDefaultCredentials.AutoSize = true;
            this.rbDefaultCredentials.Location = new System.Drawing.Point(7, 38);
            this.rbDefaultCredentials.Name = "rbDefaultCredentials";
            this.rbDefaultCredentials.Size = new System.Drawing.Size(77, 17);
            this.rbDefaultCredentials.TabIndex = 11;
            this.rbDefaultCredentials.Text = "Login as ...";
            this.rbDefaultCredentials.UseVisualStyleBackColor = true;
            this.rbDefaultCredentials.CheckedChanged += new System.EventHandler(this.rbDefaultCredentials_CheckedChanged);
            // 
            // LoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(289, 165);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.rbCustomCredentials);
            this.Controls.Add(this.rbDefaultCredentials);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(305, 204);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(305, 204);
            this.Name = "LoginDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Login Dialog";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.LoginDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCustomCredentials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox Server;
        private System.Windows.Forms.RadioButton rbDefaultCredentials;
    }
}