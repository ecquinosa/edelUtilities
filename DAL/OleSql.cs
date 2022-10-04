﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
    public class OleSql : IDisposable

    {

        private string ConStr = "";
        private DataTable dtResult; 
        private object objResult;
        private IDataReader _readerResult;
        private string strErrorMessage;

        private OleDbConnection con;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;

        public string ErrorMessage
        {
            get { return strErrorMessage; }
        }
        public DataTable TableResult
        {
            get { return dtResult; }
        }

        public object ObjectResult
        {
            get { return objResult; }
        }
        public OleSql(string conStr)
        {
            this.ConStr = conStr;
        }

        public OleSql(string server, string dbName, string user, string password)
        {
            ConStr = string.Concat("Server=", server, ";Database=", dbName, ";User=", user, ";Password=", password);
        }      

        public void ClearAllPools()
        {
            OleDbConnection.ReleaseObjectPool();
        }

        private void OpenConnection()
        {
            if (con == null) con = new OleDbConnection(ConStr);
        }

        private void CloseConnection()
        {
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();
            if (_readerResult != null)
            {
                _readerResult.Close();
                _readerResult.Dispose();
            }
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            ClearAllPools();
        }

        private void ExecuteNonQuery(CommandType cmdType)
        {
            cmd.CommandType = cmdType;
         
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.ExecuteNonQuery();            
        }

        private void _ExecuteScalar(CommandType cmdType)
        {
            cmd.CommandType = cmdType;
           
            if (con.State == ConnectionState.Closed) con.Open();
            object _obj;
            _obj = cmd.ExecuteScalar();           

            objResult = _obj;
        }

        private void _ExecuteReader(CommandType cmdType)
        {
            cmd.CommandType = cmdType;
           
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            _readerResult = reader;
        }

        private void FillDataAdapter(CommandType cmdType)
        {
            cmd.CommandTimeout = 0;
            cmd.CommandType = cmdType;
            da = new OleDbDataAdapter(cmd);
            DataTable _dt = new DataTable();
            da.Fill(_dt);
            dtResult = _dt;
        }

        public bool IsConnectionOK(string strConString = "")
        {
            try
            {
                if (strConString != "") ConStr = strConString;
                OpenConnection();

                con.Open();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }

        public bool SelectQuery(string strQuery)
        {
            try
            {
                OpenConnection();
                cmd = new OleDbCommand(strQuery, con);

                FillDataAdapter(CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }      

        public bool ExecuteQuery(string strQuery, CommandType cmdType = CommandType.Text)
        {
            try
            {
                OpenConnection();
                cmd = new OleDbCommand(strQuery, con);

                ExecuteNonQuery(cmdType);

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }      

        public bool ExecuteScalar(string strQuery)
        {
            try
            {
                OpenConnection();
                cmd = new OleDbCommand(strQuery, con);

                _ExecuteScalar(CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }       

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    CloseConnection();
                }

                // Note disposing has been done.
                disposed = true;
            }
        }

    }
}