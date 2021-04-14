using System;
using System.Data;
using System.Diagnostics;

namespace ifood.test.galdino.repository.Context
{
    public class DbContext
    {
        #region .::Constructor
        public IDbConnection Connection { get; private set; }

        public DbContext(IDbConnection connection)
        {
            Connection = connection;
            OpenConnectionService(connection);
        } 
        #endregion

        #region .::Methods
        private static IDbConnection OpenConnectionService(IDbConnection conn)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return conn;
        } 
        #endregion
    }
}
