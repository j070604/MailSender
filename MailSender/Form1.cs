using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MailSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = @"\\fileserver1\기술지원부\05_PS Team\점검 사용 프로그램\MailSender\MailSender.db";
        }

        private void rBtnInclude_CheckedChanged(object sender, EventArgs e)
        {
            if(rBtnExclude.Checked == true)
            {
                rBtnExclude.Checked = false;
                rBtnInclude.Checked = true;
            }
        }

        private void rBtnExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnInclude.Checked == true)
            {
                rBtnInclude.Checked = false;
                rBtnExclude.Checked = true;
            }  
        }

        
    }
}
