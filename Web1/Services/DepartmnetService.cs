using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests.Querries;
using Web1.Contracts.V1.Responses;
using Web1.Data.Repositories;
using Web1.Domain;

namespace Web1.Services
{
    public class DepartmnetService:IDepartmnetService
    {
        private readonly IDepartmentRepository _repo;
        public DepartmnetService(IDepartmentRepository departmentRepository)
        {
            _repo = departmentRepository;
        }

        public async Task<Department> Create_Async(Department department)
        {
            return await _repo.Add_Async_Repo(department);
        }

        public async Task<List<Department>> GetAll_Async()
        {
            return await _repo.GetAll_Async_Repo();
        }

        public async Task<Department> GetOne_Async(int id)
        {
            return await _repo.GetOne_Async_Repo(id);
        }

        public async Task<PagePagination<Department>> GetPagination_Async(PaginationQuerry paginationQuerry = null, Expression<Func<Department, bool>> filter = null, string includeProperties = null)
        {
           return await _repo.GetPagination_Async_repo(paginationQuerry , filter ,  includeProperties );
        }
    }
}
