using Ckacio.Dapper.Examples.Infrastructure.Data.Result;
using Ckacio.Dapper.Examples.Infrastructure.Data.UoW;
using Dapper;


namespace Ckacio.Dapper.Examples.Infrastructure.Data.Repository
{
    public class CartoonRepository : ICartoonRepository
    {
        private readonly IUnitOfWork _unitOfWork = null;

        public CartoonRepository()
        {
        }

        public CartoonRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SearchCartoonByIdResult> SearchCartoonByIdExample1(int id)
        {
            var query = $@" SELECT  Cartoon_Id as CartoonId, 
                                    Name_Cartoon as NameCartoon, 
                                    Country 
                            FROM    Cartoon 
                            WHERE   Cartoon_Id = @Id";

            var result = await _unitOfWork.Connection.QueryAsync<SearchCartoonByIdResult>(
                sql: query,
                param: new { id },
                transaction: _unitOfWork.Transaction,
                commandTimeout: _unitOfWork.CommandTimeout,
                commandType: System.Data.CommandType.Text
                );

            return result!.FirstOrDefault();

        }

        public Task<SearchCartoonByIdResult> SearchCartoonByIdExample2(int id)
        {
            var query = $@" SELECT  Cartoon_Id, 
                                    Name_Cartoon, 
                                    Country 
                            FROM    Cartoon 
                            WHERE   Cartoon_Id = @Id";

            var results = _unitOfWork.Connection.QueryAsync<dynamic>(
                sql: query,
                param: new { id },
                transaction: _unitOfWork.Transaction,
                commandTimeout: _unitOfWork.CommandTimeout
                )
                .Result.Select(item => new SearchCartoonByIdResult()
                {
                    CartoonId = item.Cartoon_Id,
                    NameCartoon = item.Name_Cartoon,
                    Country = item.Country
                }).First();

            return Task.FromResult(results);
                
        }


    }
}
