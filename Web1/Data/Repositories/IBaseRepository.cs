using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests.Querries;
using Web1.Contracts.V1.Responses;

namespace Web1.Data.Repositories
{
    public interface IBaseRepository<T> where T: class
    {
        Task<T> Add_Async(T entry);
        Task<List<T>> GetAll_Async();

        Task<T> GetOne_Async(int id);
     Task<PagePagination<T>> GetPagination_Async(PaginationQuerry paginationQuerry = null, Expression<Func<T, bool>> filter = null, string includeProperties = null);


    }
}
