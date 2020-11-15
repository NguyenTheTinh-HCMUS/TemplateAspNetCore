using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1.Requests.Querries
{
    public class PaginationQuerry
    {
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
        // asc or desc
        public string sortOrder { get; set; }

        public string sortColum { get; set; }
    }
}
