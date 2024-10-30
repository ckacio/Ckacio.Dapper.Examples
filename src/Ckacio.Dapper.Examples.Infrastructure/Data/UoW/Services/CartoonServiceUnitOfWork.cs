using Ckacio.Dapper.Examples.Infrastructure.Data.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Ckacio.Dapper.Examples.Infrastructure.Data.UoW.Services
{
    public sealed class CartoonServiceUnitOfWork : IDisposable
    {
        private static string ConnectionStingName = "Cartoon";
        private static IDbConnection _connection = null;
        private static UnitOfWork _unitOfWork = null;

        public static UnitOfWork GetUnitOfWork()
        {
            if(_unitOfWork == null) 
            {
                _connection = new SqlConnection(UnitOfWorkConnectionStringPool.GetConnectionString(ConnectionStingName));
                _connection.Open();

                _unitOfWork = new UnitOfWork(_connection, UnitOfWorkConnectionStringPool.GetCommandTimeout(ConnectionStingName));
                _unitOfWork.SetRepository(new CartoonRepository(_unitOfWork));
            }
            return _unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}
