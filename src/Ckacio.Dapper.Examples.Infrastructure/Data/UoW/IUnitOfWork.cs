using System.Data;

namespace Ckacio.Dapper.Examples.Infrastructure.Data.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        Guid Id { get; }

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        int CommandTimeout { get; } 

        void BeginTransaction();
        
        void Commit();

        void Rollback();

    }
}
