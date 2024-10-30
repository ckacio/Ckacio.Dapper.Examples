using System.Data;
using System.Reflection;

namespace Ckacio.Dapper.Examples.Infrastructure.Data.UoW
{
    public sealed class UnitOfWork: IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private int _commandTimeout = 0;
        private Guid _id = Guid.Empty;
        private Dictionary<string, object> _repository = new Dictionary<string, object>();

        internal UnitOfWork(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }

        internal UnitOfWork(IDbConnection connection, int commandTimeout)
        {
            _id = Guid.NewGuid();
            _connection = connection;
            _commandTimeout = commandTimeout;
        }

        IDbConnection IUnitOfWork.Connection { get { return _connection; } }
        
        IDbTransaction IUnitOfWork.Transaction { get { return _transaction; } }
        
        Guid IUnitOfWork.Id { get { return _id; } }

        public int CommandTimeout { get { return _commandTimeout; } }

        public void SetRepository(object repository) 
        { 
            if(!_repository.ContainsKey(repository.ToString()))
                  _repository.Add(repository.ToString(), repository);
        }

        public T GetRepository<T>()
        {
            var instance = CreateInstance<T>();
            return (T)_repository[instance.ToString()];
        }

        private object CreateInstance<T>()
        {
            Assembly objAssembly = Assembly.GetAssembly(typeof(T));
            return objAssembly.CreateInstance(typeof(T).FullName, false);
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if(_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }
    }
}
