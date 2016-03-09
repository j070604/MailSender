namespace MailSender
{
    partial class InitDB
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.HosName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.tBoxMsg = new System.Windows.Forms.TextBox();
            this.tBoxFolderPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HosName,
            this.FolderName});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(583, 315);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // HosName
            // 
            this.HosName.Text = "HosName";
            this.HosName.Width = 200;
            // 
            // FolderName
            // 
            this.FolderName.Text = "FolderName";
            this.FolderName.Width = 200;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(12, 330);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(70, 12);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Message : ";
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Location = new System.Drawing.Point(12, 359);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(73, 12);
            this.lblFolderPath.TabIndex = 2;
            this.lblFolderPath.Text = "FolderPath :";
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.Location = new System.Drawing.Point(91, 327);
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.ReadOnly = true;
            this.tBoxMsg.Size = new System.Drawing.Size(504, 21);
            this.tBoxMsg.TabIndex = 3;
            // 
            // tBoxFolderPath
            // 
            this.tBoxFolderPath.Location = new System.Drawing.Point(91, 356);
            this.tBoxFolderPath.Name = "tBoxFolderPath";
            this.tBoxFolderPath.Size = new System.Drawing.Size(504, 21);
            this.tBoxFolderPath.TabIndex = 4;
            // 
            // InitDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 479);
            this.Controls.Add(this.tBoxFolderPath);
            this.Controls.Add(this.tBoxMsg);
            this.Controls.Add(this.lblFolderPath);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.listView1);
            this.Name = "InitDB";
            this.Text = "InitDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader HosName;
        private System.Windows.Forms.ColumnHeader FolderName;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.TextBox tBoxMsg;
        private System.Windows.Forms.TextBox tBoxFolderPath;
    }
}