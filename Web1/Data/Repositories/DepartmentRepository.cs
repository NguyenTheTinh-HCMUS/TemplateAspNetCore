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
   public class DepartmentRepository :  BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext dataContext):base(dataContext)
        {
            
        }

        public async Task<Department> Add_Async_Repo(Department entry)
        {
            return await this.Add_Async(entry);
        }

        public Task<List<Department>> GetAll_Async_Repo()
        {
            return this.GetAll_Async();
        }

        public async Task<Department> GetOne_Async_Repo(int id)
        {
            return await this.GetOne_Async(id);

        }

        public async Task<PagePagination<Department>> GetPagination_Async_repo(PaginationQuerry paginationQuerry = null, Expression<Func<Department, bool>> filter = null, string includeProperties = null)
        {
            return await this.GetPagination_Async(paginationQuerry , filter, includeProperties);
        }
    }
}
