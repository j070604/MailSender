using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common; // for use DbConnectionStringBuilder
using System.IO;

namespace MailSender
{
    class DBHandler
    {
        public void CreateDB(string fileName) //DB 파일이 없을 경우 생성해주는 함수
        {
            //1.
            //string conStr = @"data source=\\fileserver1\기술지원부\05_PS Team\점검 사용 프로그램\MailSender\MailSender.db";
            string connstring = "data source=\"\\\\fileserver1\\기술지원부\\05_PS Team\\점검 사용 프로그램\\MailSender\\MailSender.db\";" +
                                       "Version=3;FailIfMissing=False;";
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.ConnectionString = "data source=\\\\fileserver1\\기술지원부\\05_PS Team\\점검 사용 프로그램\\MailSender\\MailSender.db;" +
                                       "Version=3;FailIfMissing=False;";
            //builder.Add("Version", "3");
            //builder.Add("FailIfMissing", "false");

            using (SQLiteConnection conn = new SQLiteConnection(connstring))
            {
                conn.Open();
            }
 
        }

        public void InitHospitalDB()//병원정보 있는 엑셀파일이랑 메일정보 있는 엑셀파일이랑 2개가 있음.
        {
            Array exData;
            List<String> excelList;
            String strServCheck = @"\\fileserver1\기술지원부\05_PS Team\유지보수 월별통계\2016-03_점검통계.xlsx";

            using(ExcelAccess servCheck = new ExcelAccess(strServCheck))
            {
                servCheck.SelectSheet("병원");
                exData = servCheck.GetRange("E2", "G386");
                excelList = ConvertArrayToList(exData);
            }
    
            List<string> hosFolderList = new List<String>();
            String fsFolderPath = GetFolderList(hosFolderList);
            for (int i = 0; i < excelList.Count; i++)
            {
                for(int j = 0; j < hosFolderList.Count; j++)
                {
                    //if()
                }
            }
            
        }

        private List<String> ConvertArrayToList(Array array)
        {
            List<String> excelList = new List<String>();
            for (int i = 1; i <= array.Length; i++)
            {
                if (array.GetValue(i, 1) == null)
                    continue;
                if ((String)array.GetValue(i, 3) == "매월")
                    continue;
                else
                    excelList.Add(array.GetValue(i, 1).ToString());
            }
            return excelList;
        }

        private string GetFolderList(List<String> hosFolderList)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            string fsRootFolder = @"\\Fileserver1\TechHeim\TH\병원";
            if (Directory.Exists(fsRootFolder))
                folderDialog.SelectedPath = fsRootFolder;

            folderDialog.ShowDialog();
            string path = folderDialog.SelectedPath;
            System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(path);
            if (Info.Exists)
            {
                System.IO.DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.DirectoryInfo info in CInfo)
                {
                    hosFolderList.Add(info.Name);
                }
            }
            return path;
        }


    }
}
