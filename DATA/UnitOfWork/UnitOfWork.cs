using TeamGM.CROSSCUTTING.UnitOfWork;

namespace TeamGM.DATA.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _session;
        DbSession IUnitOfWork.Session => _session;

        public UnitOfWork(DbSession session)
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

