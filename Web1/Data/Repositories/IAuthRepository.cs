using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Domain;

namespace Web1.Data.Repositories
{
    public interface IAuthRepository
    {
         Task<bool> IsEmailExit_Async(string email);
         Task<bool> IsUsernameExit_Async(string useName);
        Task AddEmployee_Async(Employee e);
        Task AddRefreshToken_Async(RefreshToken rt);
        Task<int> SaveChange_Async();
        Task<Employee> GetEmployeeByUserNameOrEmail_Async(string text);
        Task<RefreshToken> GetRefreshTokenByToken_Async(string Token);
        void UpdateRefreshToken(RefreshToken refreshToken);
    }
}
