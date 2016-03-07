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
