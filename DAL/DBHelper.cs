﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DBHelper
    {
        public  const int WRITEDATA_ERROR = -1;

        private static OleDbConnection conn = null;

        private static string connString;

        private static bool connOpen = false;

        public static void SetConnString(string conn)
        {
            connString = conn;
        }
        public static bool OpenConnection()
        {
            if (connOpen)
                return true;

            try
            {
                OleDbConnection connection = new OleDbConnection(connString);
                connection.Open();
                conn = connection;
                connOpen = true;
                return true;
            }
            catch (OleDbException e)
            {
                return false;
            }
        }
        public static OleDbDataReader ReadData(string sql)
        {
            try
            {
                if (!connOpen)
                {
                    if (!OpenConnection())
                        return null;
                }
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                return rd;
            }
            catch
            {
                return null;
            }
        }
        public static int WriteData(string sql)
        {
            try
            {
                if (!connOpen)
                {
                    if (!OpenConnection())
                        return WRITEDATA_ERROR;
                }
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                return rd.RecordsAffected;
            }
            catch (OleDbException e)
            {
                return WRITEDATA_ERROR;
            }
        }
        public static int InsertWithAutoNumKey(string sql)
        {
            if (!connOpen)
            {
                if (!OpenConnection())
                    return WRITEDATA_ERROR;
            }
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader rd = cmd.ExecuteReader();

                if (rd != null && rd.RecordsAffected == 1)
                {
                    //Create a new command for retrieving the new ID
                    //It MUST use the SAME connection!!!!
                    cmd = new OleDbCommand(@"SELECT @@Identity", conn);
                    rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        //The new ID will be on the first (and only) column
                        return (int)rd[0];
                    }
                }
            }
            catch
            {
                return WRITEDATA_ERROR;
            }
            return WRITEDATA_ERROR;
        }
        public static void CloseConnection()
        {
            if (connOpen)
            {
                conn.Close();
                connOpen = false;
            }
        }
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                string query = sql;
                DataTable dataTable = new DataTable();
                OleDbDataReader reader = ReadData(sql);
                if (reader == null)
                    return null;
                dataTable.Load(reader);

                return dataTable;
            }
            catch (OleDbException e)
            {
                return null;
            }
        }
        public static DataSet GetDataSet(string[] sql)
        {
            if (!connOpen)
            {
                OpenConnection();
            }

            DataSet ds = new DataSet();
            for (int i = 0; i > sql.Length; i++)
            {
                ds.Tables.Add(GetDataTable(sql[i]));
            }
            if (ds != null)
                return ds;
            else
                return null;
        }
    }
}