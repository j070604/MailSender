namespace MailSender
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cBoxYear = new System.Windows.Forms.ComboBox();
            this.cBoxMonth = new System.Windows.Forms.ComboBox();
            this.tBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblHosList = new System.Windows.Forms.Label();
            this.lblSendList = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectMine = new System.Windows.Forms.Button();
            this.btnStartSend = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rBtnExclude = new System.Windows.Forms.RadioButton();
            this.rBtnInclude = new System.Windows.Forms.RadioButton();
            this.lViewHosList = new System.Windows.Forms.ListView();
            this.lViewSendList = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(12, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 12);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "년 : ";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(174, 9);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(29, 12);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "월 : ";
            // 
            // cBoxYear
            // 
            this.cBoxYear.FormattingEnabled = true;
            this.cBoxYear.Location = new System.Drawing.Point(47, 6);
            this.cBoxYear.Name = "cBoxYear";
            this.cBoxYear.Size = new System.Drawing.Size(121, 20);
            this.cBoxYear.TabIndex = 2;
            // 
            // cBoxMonth
            // 
            this.cBoxMonth.FormattingEnabled = true;
            this.cBoxMonth.Location = new System.Drawing.Point(209, 6);
            this.cBoxMonth.Name = "cBoxMonth";
            this.cBoxMonth.Size = new System.Drawing.Size(121, 20);
            this.cBoxMonth.TabIndex = 3;
            // 
            // tBoxSearch
            // 
            this.tBoxSearch.Location = new System.Drawing.Point(458, 6);
            this.tBoxSearch.Name = "tBoxSearch";
            this.tBoxSearch.Size = new System.Drawing.Size(242, 21);
            this.tBoxSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(706, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblHosList
            // 
            this.lblHosList.AutoSize = true;
            this.lblHosList.Location = new System.Drawing.Point(12, 42);
            this.lblHosList.Name = "lblHosList";
            this.lblHosList.Size = new System.Drawing.Size(53, 12);
            this.lblHosList.TabIndex = 6;
            this.lblHosList.Text = "병원목록";
            // 
            // lblSendList
            // 
            this.lblSendList.AutoSize = true;
            this.lblSendList.Location = new System.Drawing.Point(12, 363);
            this.lblSendList.Name = "lblSendList";
            this.lblSendList.Size = new System.Drawing.Size(53, 12);
            this.lblSendList.TabIndex = 7;
            this.lblSendList.Text = "발송목록";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(311, 352);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(417, 352);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(787, 57);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(135, 90);
            this.btnSelectAll.TabIndex = 12;
            this.btnSelectAll.Text = "모든 발송가능\r\n\r\n목록 선택";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnSelectMine
            // 
            this.btnSelectMine.Location = new System.Drawing.Point(787, 153);
            this.btnSelectMine.Name = "btnSelectMine";
            this.btnSelectMine.Size = new System.Drawing.Size(135, 90);
            this.btnSelectMine.TabIndex = 13;
            this.btnSelectMine.Text = "모든 내가 점검한 \r\n\r\n목록 선택\r\n";
            this.btnSelectMine.UseVisualStyleBackColor = true;
            // 
            // btnStartSend
            // 
            this.btnStartSend.Location = new System.Drawing.Point(787, 580);
            this.btnStartSend.Name = "btnStartSend";
            this.btnStartSend.Size = new System.Drawing.Size(135, 90);
            this.btnStartSend.TabIndex = 15;
            this.btnStartSend.Text = "발송 시작";
            this.btnStartSend.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.rBtnExclude);
            this.panel.Controls.Add(this.rBtnInclude);
            this.panel.Location = new System.Drawing.Point(787, 249);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(135, 90);
            this.panel.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "중복 발송 허용여부";
            // 
            // rBtnExclude
            // 
            this.rBtnExclude.AutoSize = true;
            this.rBtnExclude.Checked = true;
            this.rBtnExclude.Location = new System.Drawing.Point(3, 55);
            this.rBtnExclude.Name = "rBtnExclude";
            this.rBtnExclude.Size = new System.Drawing.Size(31, 16);
            this.rBtnExclude.TabIndex = 1;
            this.rBtnExclude.TabStop = true;
            this.rBtnExclude.Text = "X";
            this.rBtnExclude.UseVisualStyleBackColor = true;
            this.rBtnExclude.CheckedChanged += new System.EventHandler(this.rBtnExclude_CheckedChanged);
            // 
            // rBtnInclude
            // 
            this.rBtnInclude.AutoSize = true;
            this.rBtnInclude.Font = new System.Drawing.Font("굴림", 9F);
            this.rBtnInclude.Location = new System.Drawing.Point(3, 34);
            this.rBtnInclude.Name = "rBtnInclude";
            this.rBtnInclude.Size = new System.Drawing.Size(32, 16);
            this.rBtnInclude.TabIndex = 0;
            this.rBtnInclude.Text = "O";
            this.rBtnInclude.UseVisualStyleBackColor = true;
            this.rBtnInclude.CheckedChanged += new System.EventHandler(this.rBtnInclude_CheckedChanged);
            // 
            // lViewHosList
            // 
            this.lViewHosList.CheckBoxes = true;
            this.lViewHosList.Location = new System.Drawing.Point(12, 57);
            this.lViewHosList.Name = "lViewHosList";
            this.lViewHosList.Size = new System.Drawing.Size(769, 289);
            this.lViewHosList.TabIndex = 18;
            this.lViewHosList.UseCompatibleStateImageBehavior = false;
            // 
            // lViewSendList
            // 
            this.lViewSendList.CheckBoxes = true;
            this.lViewSendList.Location = new System.Drawing.Point(12, 381);
            this.lViewSendList.Name = "lViewSendList";
            this.lViewSendList.Size = new System.Drawing.Size(769, 289);
            this.lViewSendList.TabIndex = 19;
            this.lViewSendList.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(787, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 682);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lViewSendList);
            this.Controls.Add(this.lViewHosList);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnStartSend);
            this.Controls.Add(this.btnSelectMine);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSendList);
            this.Controls.Add(this.lblHosList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tBoxSearch);
            this.Controls.Add(this.cBoxMonth);
            this.Controls.Add(this.cBoxYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cBoxYear;
        private System.Windows.Forms.ComboBox cBoxMonth;
        private System.Windows.Forms.TextBox tBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblHosList;
        private System.Windows.Forms.Label lblSendList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectMine;
        private System.Windows.Forms.Button btnStartSend;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rBtnExclude;
        private System.Windows.Forms.RadioButton rBtnInclude;
        private System.Windows.Forms.ListView lViewHosList;
        private System.Windows.Forms.ListView lViewSendList;
        private System.Windows.Forms.Button button1;
    }
}

