namespace WebDavClient.Dialogs
{
    partial class ConnectingDialog
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
            this.Connecting_to = new System.Windows.Forms.Label();
            this.as_person = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connecting_to
            // 
            this.Connecting_to.AutoSize = true;
            this.Connecting_to.Location = new System.Drawing.Point(12, 9);
            this.Connecting_to.Name = "Connecting_to";
            this.Connecting_to.Size = new System.Drawing.Size(73, 13);
            this.Connecting_to.TabIndex = 0;
            this.Connecting_to.Text = "Connecting to";
            // 
            // as_person
            // 
            this.as_person.AutoSize = true;
            this.as_person.Location = new System.Drawing.Point(12, 25);
            this.as_person.Name = "as_person";
            this.as_person.Size = new System.Drawing.Size(18, 13);
            this.as_person.TabIndex = 1;
            this.as_person.Text = "as";
            // 
            // ConnectingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 47);
            this.Controls.Add(this.as_person);
            this.Controls.Add(this.Connecting_to);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectingDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = " ";
            this.Shown += new System.EventHandler(this.ConnectingDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Connecting_to;
        private System.Windows.Forms.Label as_person;
    }
}