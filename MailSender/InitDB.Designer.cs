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
            this.FileFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.tBoxMsg = new System.Windows.Forms.TextBox();
            this.tBoxFolderName = new System.Windows.Forms.TextBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnEMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HosName,
            this.FolderName,
            this.FileFormat});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(583, 315);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
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
            // FileFormat
            // 
            this.FileFormat.Text = "FileFormat";
            this.FileFormat.Width = 179;
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
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(12, 359);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(82, 12);
            this.lblFolderName.TabIndex = 2;
            this.lblFolderName.Text = "FolderName :";
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.Location = new System.Drawing.Point(91, 327);
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.ReadOnly = true;
            this.tBoxMsg.Size = new System.Drawing.Size(504, 21);
            this.tBoxMsg.TabIndex = 3;
            // 
            // tBoxFolderName
            // 
            this.tBoxFolderName.Location = new System.Drawing.Point(100, 356);
            this.tBoxFolderName.Name = "tBoxFolderName";
            this.tBoxFolderName.Size = new System.Drawing.Size(504, 21);
            this.tBoxFolderName.TabIndex = 4;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(610, 330);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 7;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(610, 354);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 8;
            this.btnInput.Text = "Input";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnEMail
            // 
            this.btnEMail.Location = new System.Drawing.Point(610, 383);
            this.btnEMail.Name = "btnEMail";
            this.btnEMail.Size = new System.Drawing.Size(75, 23);
            this.btnEMail.TabIndex = 9;
            this.btnEMail.Text = "EMail";
            this.btnEMail.UseVisualStyleBackColor = true;
            this.btnEMail.Click += new System.EventHandler(this.btnEMail_Click);
            // 
            // InitDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 479);
            this.Controls.Add(this.btnEMail);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.tBoxFolderName);
            this.Controls.Add(this.tBoxMsg);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.listView1);
            this.Name = "InitDB";
            this.Text = "InitDB";
            this.Load += new System.EventHandler(this.InitDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader HosName;
        private System.Windows.Forms.ColumnHeader FolderName;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.TextBox tBoxMsg;
        private System.Windows.Forms.TextBox tBoxFolderName;
        private System.Windows.Forms.ColumnHeader FileFormat;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnEMail;
    }
}