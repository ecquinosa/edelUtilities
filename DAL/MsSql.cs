using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
    public class MsSql : IDisposable

    {

        private string ConStr = "";
        private DataTable dtResult; 
        private object objResult;
        private IDataReader _readerResult;
        private string strErrorMessage;

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;

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
        public MsSql(string conStr)
        {
            this.ConStr = conStr;
        }

        public MsSql(string server, string dbName, string user, string password)
        {
            ConStr = string.Concat("Server=", server, ";Database=", dbName, ";User=", user, ";Password=", password);
        }      

        public void ClearAllPools()
        {
            SqlConnection.ClearAllPools();
        }

        private void OpenConnection()
        {
            if (con == null) con = new SqlConnection(ConStr);
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
            SqlDataReader reader = cmd.ExecuteReader();

            _readerResult = reader;
        }

        private void FillDataAdapter(CommandType cmdType)
        {
            cmd.CommandTimeout = 0;
            cmd.CommandType = cmdType;
            da = new SqlDataAdapter(cmd);
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
                cmd = new SqlCommand(strQuery, con);

                FillDataAdapter(CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }

        public bool SelectUBP_Savings_Account(string refId, string pagibigId)
        {
            try
            {
                OpenConnection();                
                cmd = new SqlCommand("SELECT * FROM UBP_Savings_Account WHERE Ref_ID=@Ref_ID AND Pagibig_ID=@Pagibig_ID", con);
                cmd.Parameters.AddWithValue("Ref_ID", refId);
                cmd.Parameters.AddWithValue("Pagibig_ID", pagibigId);
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
                cmd = new SqlCommand(strQuery, con);

                ExecuteNonQuery(cmdType);

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }

        public bool AddSFTP(string mid, DateTime sftpTransferDate, string remark)
        {
            try
            {
                OpenConnection();
                cmd = new SqlCommand("prcAddSFTPv3", con);
                cmd.Parameters.AddWithValue("PagIBIGID", mid);
                cmd.Parameters.AddWithValue("SFTPTransferDate", sftpTransferDate);
                cmd.Parameters.AddWithValue("Remark", remark);

                ExecuteNonQuery(CommandType.StoredProcedure);

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
                cmd = new SqlCommand(strQuery, con);

                _ExecuteScalar(CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                strErrorMessage = ex.Message;
                return false;
            }
        }

        public bool ExecuteScalar(string strQuery, System.Data.CommandType cmdType, string[] sqlParams, object[] sqlValues)
        {
            try
            {
                OpenConnection();
                cmd = new SqlCommand(strQuery, con);

                for (int i = 0; i < sqlParams.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue(sqlParams[i], sqlValues[i]);
                }

                _ExecuteScalar(cmdType);

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
