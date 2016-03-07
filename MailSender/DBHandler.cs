using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common; // for use DbConnectionStringBuilder

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

        public void InitDB()//병원정보 있는 엑셀파일이랑 메일정보 있는 엑셀파일이랑 2개가 있음.
        {
            String strServCheck = @"\\fileserver1\기술지원부\05_PS Team\유지보수 월별통계\2016-03_점검통계.xlsx";
            ExcelAccess servCheck = new ExcelAccess(strServCheck);
            servCheck.SelectSheet("병원");
            Array exData = servCheck.GetRange("E2", "G386");
        }


    }
}
