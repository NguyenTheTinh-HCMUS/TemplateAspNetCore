using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests.Querries;
using Web1.Contracts.V1.Responses;

namespace Web1.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        protected readonly DataContext _context;
        internal DbSet<T> dbSet;
        public BaseRepository(DataContext dataContext)
        {
            _context = dataContext;
            this.dbSet = _context.Set<T>();
        }
        public virtual async Task<T> Add_Async(T entry)
        {
            await dbSet.AddAsync(entry);
            return await _context.SaveChangesAsync() > 0 ? entry : null;
        }

        public virtual async Task<List<T>> GetAll_Async()
        {
            return await dbSet.ToListAsync<T>();
        }

        public async Task<T> GetOne_Async(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<PagePagination<T>> GetPagination_Async(PaginationQuerry  paginationQuerry=null,Expression<Func<T,bool>> filter=null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }
            query = (paginationQuerry.pageNumber != null && paginationQuerry.pageSize != null) ? query.Skip((paginationQuerry.pageNumber.GetValueOrDefault() - 1) * paginationQuerry.pageSize.GetValueOrDefault()).Take(paginationQuerry.pageSize.GetValueOrDefault()) : query;

            if (!string.IsNullOrEmpty(paginationQuerry.sortColum))
            {
                if (paginationQuerry.sortOrder == null || paginationQuerry.sortOrder.ToLower() == "asc")
                    query = query.OrderBy($"{paginationQuerry.sortColum} ASC");
                else
                    query = query.OrderBy($"{paginationQuerry.sortColum} DESC");
            }

          
            int totalItems = query.Count();
            return new PagePagination<T> { 
                data=await query.ToListAsync(),
                pageNumber=paginationQuerry.pageNumber.GetValueOrDefault(),
                pageSize=paginationQuerry.pageSize.GetValueOrDefault(),
                sortColum=paginationQuerry.sortColum,
                sortOrder=paginationQuerry.sortOrder,
                totalRows=totalItems
            };
            
        }
    }
}
