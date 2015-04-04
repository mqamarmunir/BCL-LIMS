using System;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DataLayer
{
    /// <summary>
    /// Summary description for clsdbconnection.
    /// </summary>
    public class clsdbconnection
    {
        public clsdbconnection()
        {
        }

        MySqlConnection Conn;
        private bool disposed = false;

        #region Enumerations

        public enum ConnectionType
        {
            MySQL = 1,
            SQLSERVER = 2
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Get SQL Server Connection
        /// </summary>
        public MySqlConnection Odbc_SQL_Connection
        {
            get { return Dbconnection(clsdbconnection.ConnectionType.MySQL); }
        }

        #endregion

        #region "Connection String"

        private MySqlConnection Dbconnection(ConnectionType ConnectToDB)
        {
            string StrConnection = null;
            AppSettingsReader con = new AppSettingsReader();
   //         string connectionString = ConfigurationSettings.AppSettings.Get("ConnectionString");
          //  StrConnection = "User Id=" + con.GetValue("susername", "".GetType()).ToString() + "; PWD =" + con.GetValue("spassword", "".GetType()).ToString() + "; Server=" + con.GetValue("sserver", "".GetType()).ToString() + ";Port=3306;Database=" + con.GetValue("sdb", "".GetType()).ToString() + ";respect binary flags = false";
          //  StrConnection = "dsn=saps";
            StrConnection = "User Id=" + con.GetValue("susername", "".GetType()).ToString() + "; PWD =" + con.GetValue("spassword", "".GetType()).ToString() + "; Server=" + con.GetValue("sserver", "".GetType()).ToString() + ";Port=3306;Database=" + con.GetValue("sdb", "".GetType()).ToString() + ";Allow Zero Datetime=True;Convert Zero Datetime=True;respect binary flags = false";
        
            try
            {
                Conn = new MySqlConnection(StrConnection);
                Conn.Open();
                return Conn;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return null; 
            }
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
            //Conn.Close();
            //Conn.Dispose();

        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.

                //Conn.Close();
                //Conn.Dispose();
                //Conn = null;

                GC.Collect();

            }
            disposed = true;
        }

    }
}