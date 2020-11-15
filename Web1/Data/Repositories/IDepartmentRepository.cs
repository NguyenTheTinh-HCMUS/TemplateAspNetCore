using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests.Querries;
using Web1.Contracts.V1.Responses;
using Web1.Domain;

namespace Web1.Data.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetAll_Async_Repo();
        public Task<Department> GetOne_Async_Repo(int id);
        public Task<Department> Add_Async_Repo(Department entry);
        Task<PagePagination<Department>> GetPagination_Async_repo(PaginationQuerry paginationQuerry = null, Expression<Func<Department, bool>> filter = null, string includeProperties = null);





    }
}
