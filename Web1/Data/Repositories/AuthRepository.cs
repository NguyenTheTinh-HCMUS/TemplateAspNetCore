using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Domain;

namespace Web1.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddEmployee_Async(Employee e)
        {
            await _context.Employees.AddAsync(e);
        }
        

        public async Task AddRefreshToken_Async(RefreshToken rt)
        {
            await _context.RefreshTokens.AddAsync(rt);
            
        }

        public async Task<Employee> GetEmployeeByUserNameOrEmail_Async(string text)
        {
            return await _context.Employees.SingleOrDefaultAsync(e=>e.Username == text || e.Email == text);
            
        }

        public async Task<RefreshToken> GetRefreshTokenByToken_Async(string Token)
        {
            return await _context.RefreshTokens.Include(rf=>rf.Employee).SingleOrDefaultAsync(rt => rt.Token == Token);
        }

        public async Task<bool> IsEmailExit_Async(string email)
        {
            return await _context.Employees.SingleOrDefaultAsync(e => e.Email == email) != null;
        }

        public async Task<bool> IsUsernameExit_Async(string userName)
        {
            return await _context.Employees.SingleOrDefaultAsync(e => e.Username == userName) != null;
        }

        public async Task<int> SaveChange_Async()
        {
            return await _context.SaveChangesAsync();
        }

        public  void UpdateRefreshToken(RefreshToken refreshToken)
        {
             _context.RefreshTokens.Update(refreshToken);
        }

      
    }
}
