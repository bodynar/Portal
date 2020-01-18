namespace Portal.DataAccess
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Rollback();

        bool Commit();
    }
}