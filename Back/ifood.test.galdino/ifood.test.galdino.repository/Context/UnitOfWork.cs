using System;
using System.Data;

namespace ifood.test.galdino.repository.Context
{
    public class UnitOfWork
    {
        #region .::Constructor
        private readonly DbContext context;

        internal IDbTransaction Transaction { get; set; }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        } 
        #endregion

        #region .::Methods
        public void BeginTrans()
        {
            Transaction = context.Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction == null) return;
            try
            {
                Transaction.Commit();
            }
            catch (Exception)
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void Rollback()
        {
            if (Transaction == null) return;

            try
            {
                Transaction.Rollback();
            }
            finally
            {
                Transaction.Dispose();
                Transaction = null;
            }
        } 
        #endregion
    }
}
