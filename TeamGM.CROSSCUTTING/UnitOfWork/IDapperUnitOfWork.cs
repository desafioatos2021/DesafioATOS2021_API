

namespace TeamGM.CROSSCUTTING.UnitOfWork
{
    public interface IUnitOfWork
    {
        public DbSession Session { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
