﻿using System;
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

        public int InsertEMail

        public List<String> SelectHos(String folderPath)
        {
            
            DataTable dt = new DataTable();
            List<String> list = new List<String>();

            using(SQLiteCommand sqlcmd = sqlConn.CreateCommand())
            {
                sqlcmd.CommandText = "SELECT Name FROM Hospital WHERE Folder=@Folder";

                sqlcmd.Parameters.Add(new SQLiteParameter("@Folder", folderPath));

                using(SQLiteDataReader dr = sqlcmd.ExecuteReader())
                {
                    dt.Load(dr);
                }

                foreach(var row in dt.AsEnumerable())
                {
                    list.Add(row["Name"].ToString());
                }
            }
            return list;
        }
    }
}
