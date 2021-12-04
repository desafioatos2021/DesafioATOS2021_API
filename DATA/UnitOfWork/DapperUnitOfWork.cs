using TeamGM.CROSSCUTTING.UnitOfWork;

namespace TeamGM.DATA.UnitOfWork
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private readonly DbSession _session;
        DbSession IDapperUnitOfWork.Session => _session;

        public DapperUnitOfWork(DbSession session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
}

