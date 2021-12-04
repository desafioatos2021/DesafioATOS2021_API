

namespace TeamGM.CROSSCUTTING.UnitOfWork
{
    public interface IDapperUnitOfWork
    {
        public DbSession Session { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
