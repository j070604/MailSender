using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
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

        public int InsertHospital(HospitalData hosData)
        {
            int result = 1;
            sqlConn.Open();
            using (SQLiteCommand sqlcmd = sqlConn.CreateCommand())
            {
                sqlcmd.CommandText = "INSERT INTO Hospital (Name, Folder, FileFormat) Values (@Name, @Folder, @FileFormat)";
                sqlcmd.Parameters.Add(new SQLiteParameter("@Name", hosData.Name));
                sqlcmd.Parameters.Add(new SQLiteParameter("@Folder", hosData.Folder));
                sqlcmd.Parameters.Add(new SQLiteParameter("@FileFormat", hosData.FileFormat));

                try 
                {
                    result = sqlcmd.ExecuteNonQuery();
                }
                catch
                {
                    result = -1;
                } 
            }
            sqlConn.Close();
            return result;
        }

        public int InsertEMail(EMailData data)
        {
            int result = 0;
            sqlConn.Open();
            using(SQLiteTransaction transaction = sqlConn.BeginTransaction())
            { 
                using (SQLiteCommand sqlcmd = sqlConn.CreateCommand())
                {
                    for (int i = 0; i < data.mailList.Count; i++)
                    {
                        sqlcmd.CommandText = "INSERT INTO EMail (Name, Mail) Values (@Name, @Mail);";
                        sqlcmd.Parameters.Add(new SQLiteParameter("@Name", data.name));
                        sqlcmd.Parameters.Add(new SQLiteParameter("@Mail", data.mailList[i]));

                        try
                        {
                            result += sqlcmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            result += -1;
                        }
                    }
                }
                transaction.Commit();
            }
            sqlConn.Close();
            return 0;
        }

        public List<String> SelectHos(String folderPath)
        {
            
            DataTable dt = new DataTable();
            List<String> list = new List<String>();

            sqlConn.Open();
            using(SQLiteCommand sqlcmd = sqlConn.CreateCommand())
            {
                sqlcmd.CommandText = "SELECT Name FROM Hospital WHERE Folder=@folder";
                sqlcmd.Parameters.Add(new SQLiteParameter("@Folder", folderPath));

                using (SQLiteDataReader dr = sqlcmd.ExecuteReader())
                {
                    dt.Load(dr);
                }

                foreach(var row in dt.AsEnumerable())
                {
                    list.Add(row["Name"].ToString());
                }
            }
            sqlConn.Close();
            return list;
        }

    }
}
