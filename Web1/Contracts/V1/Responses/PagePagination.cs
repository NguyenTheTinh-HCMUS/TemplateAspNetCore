using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1.Responses
{
    public class PagePagination<T> where T : class
    {
       
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        // asc or desc
        public string sortOrder { get; set; }
        public string sortColum { get; set; }

        public int totalRows { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
