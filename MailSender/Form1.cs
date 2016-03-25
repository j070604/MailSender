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
        DBHandler dbHandler = DBHandler.GetInstance();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormStringInit();
            FormUIInit();
            FormDataInit();
        }

        private void FormStringInit()
        {
            tBoxYear.Text = DateTime.Now.Year.ToString();
        }

        private void FormUIInit()
        {
            cBoxMonth.SelectedIndex = Convert.ToInt32(DateTime.Now.Month.ToString()) - 1;

            lViewHosList.Columns.Add("선택", 50); // Header Init
            lViewHosList.Columns.Add("병원명", 400);
            lViewHosList.Columns.Add("이번달 발송여부", 140);
            lViewHosList.Columns.Add("발송가능여부", 100);

            lViewSendList.Columns.Add("선택", 50);
            lViewSendList.Columns.Add("병원명", 400);
            lViewSendList.Columns.Add("이번달 발송여부", 140);
            lViewSendList.Columns.Add("발송가능여부", 100);
        }

        private void FormDataInit()
        {
            List<lvData> sentLogList = dbHandler.SelectSentHosList(tBoxYear.Text, cBoxMonth.Text);
            
            String year = tBoxYear.Text;
            String month = cBoxMonth.Text;
            for(int i = 0; i < sentLogList.Count; i++)
            {
                String filePath = sentLogList[i].fileFormat.Replace("yyyy", year).Replace("mm", month);
                if (System.IO.File.Exists(filePath))
                    sentLogList[i].sendable = "O";
                else
                    sentLogList[i].sendable = "X";

                String[] lvi = { null, sentLogList[i].hosName, sentLogList[i].sendAlready, sentLogList[i].sendable};
                lViewHosList.Items.Add(new ListViewItem(lvi));
            }
        }

        private void rBtnInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnExclude.Checked == true)
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

        private void button1_Click(object sender, EventArgs e)
        {
            InitDB initDB = new InitDB();
            initDB.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lViewHosList.Columns.Count; i++)
            {
                //중복발송 허용 x -> 
                if(rBtnExclude.Checked == true)
                    lViewHosList.Items.sub
            }
        }

        private void btnSelectMine_Click(object sender, EventArgs e)
        {

        }
    }
}

