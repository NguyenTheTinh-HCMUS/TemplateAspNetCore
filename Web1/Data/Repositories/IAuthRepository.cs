using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Data.Repositories
{
    public interface IAuthRepository
    {
         Task<bool> IsEmailExit();
        Task<bool> IsUserExit();

    }
}
