using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests.Querries;
using Web1.Contracts.V1.Responses;
using Web1.Domain;

namespace Web1.Services
{
    public interface IDepartmnetService
    {
        public Task<List<Department>> GetAll_Async();
        public Task<Department> GetOne_Async(int id);
        public Task<Department> Create_Async(Department department);
        Task<PagePagination<Department>> GetPagination_Async(PaginationQuerry paginationQuerry = null, Expression<Func<Department, bool>> filter = null, string includeProperties = null);


    }
}
