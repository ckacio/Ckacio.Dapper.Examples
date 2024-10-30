using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckacio.Dapper.Examples.Infrastructure.Data.Result
{
    public class SearchCartoonByIdResult
    {
        public int CartoonId { get; set; }
        public string NameCartoon { get; set; }
        public string Country { get; set; }
    }
}
