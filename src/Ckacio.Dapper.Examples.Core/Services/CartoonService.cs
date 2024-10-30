using Ckacio.Dapper.Examples.Core.Interfaces;
using Ckacio.Dapper.Examples.Infrastructure.Data.Repository;
using Ckacio.Dapper.Examples.Infrastructure.Data.UoW.Services;

namespace Ckacio.Dapper.Examples.Core.Services
{
    public class CartoonService : ICartoonService
    {

        public string SearchCartoon1(int id)
        {
            var response = "";

            try
            {
                using (var uow = CartoonServiceUnitOfWork.GetUnitOfWork()) 
                {
                    var searchCartoonById = uow.GetRepository<CartoonRepository>().SearchCartoonByIdExample1(id);

                    if (searchCartoonById != null) 
                    {
                        response = searchCartoonById.Result.NameCartoon;
                    }

                    return response;
                }
            }
            catch(Exception ex) 
            {
                return response;
            }
        }

        public string SearchCartoon2(int id)
        {
            var response = "";

            try
            {
                using (var uow = CartoonServiceUnitOfWork.GetUnitOfWork())
                {
                    var searchCartoonById = uow.GetRepository<CartoonRepository>().SearchCartoonByIdExample2(id);

                    if (searchCartoonById != null)
                    {
                        response = searchCartoonById.Result.NameCartoon;
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                return response;
            }
        }

    }
}
