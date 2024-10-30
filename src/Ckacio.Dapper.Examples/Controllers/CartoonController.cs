using Ckacio.Dapper.Examples.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ckacio.Dapper.Examples.Controllers
{
    [ApiController]
    [Route("api/v1/ckacio-dapper-examples")]
    public class CartoonController : Controller
    {
        private readonly ICartoonService _cartoonService;

        public CartoonController(ICartoonService cartoonService)
        {
            _cartoonService = cartoonService;
        }

        [HttpGet]
        [Route("searchcartoon1")]
        [SwaggerResponse(StatusCodes.Status200OK,"string", typeof(string))]
        public string SearchCartoon1([FromQuery] int id)
        {
           return  _cartoonService.SearchCartoon1(id);
        }

        [HttpGet]
        [Route("searchcartoon2")]
        [SwaggerResponse(StatusCodes.Status200OK, "string", typeof(string))]
        public string SearchCartoon2([FromQuery] int id)
        {
            return _cartoonService.SearchCartoon2(id);
        }

    }
}
