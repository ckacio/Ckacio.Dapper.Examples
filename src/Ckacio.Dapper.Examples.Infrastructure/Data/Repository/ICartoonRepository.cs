using Ckacio.Dapper.Examples.Infrastructure.Data.Result;


namespace Ckacio.Dapper.Examples.Infrastructure.Data.Repository
{
    public interface ICartoonRepository
    {
        Task<SearchCartoonByIdResult> SearchCartoonByIdExample1(int id);

        Task<SearchCartoonByIdResult> SearchCartoonByIdExample2(int id);

    }
}
