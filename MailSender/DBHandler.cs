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
        static private DBHandler dbHandler;

        private SQLiteConnection sqlConn;
        //private SQLiteCommand sql_cmd;
        
        private DBHandler()
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.Add("data source", @"C:\Users\JYC\Documents\Visual Studio 2013\Projects\MailSender\MailSender\MailSender.db");
            builder.Add("version", "3");

            sqlConn = new SQLiteConnection(builder.ConnectionString);
        }

        static public DBHandler GetInstance()
        {
            if(dbHandler == null)
            { dbHandler = new DBHandler();}

            return dbHandler;
        }

        public void InsertHospital(HospitalData hosData)
        {
            sqlConn.Open();
            using (SQLiteCommand sqlcmd = sqlConn.CreateCommand())
            {
                sqlcmd.CommandText = "INSERT INTO Hospital (Name, Folder, FileFormat) Values (@Name, @Folder, @FileFormat)";
                //sqlcmd.Parameters.Add("@Name", System.Data.DbType.String, 200, hosData.Name);
                //sqlcmd.Parameters.Add("@Folder", System.Data.DbType.String, 200, hosData.Folder);
                //sqlcmd.Parameters.Add("@FileFormat", System.Data.DbType.String, 200, hosData.FileFormat);
                sqlcmd.Parameters.Add(new SQLiteParameter("@Name", hosData.Name));
                sqlcmd.Parameters.Add(new SQLiteParameter("@Folder", hosData.Folder));
                sqlcmd.Parameters.Add(new SQLiteParameter("@FileFormat", hosData.FileFormat));

                int result = sqlcmd.ExecuteNonQuery();
            }
            sqlConn.Close();
        }
    }
}
