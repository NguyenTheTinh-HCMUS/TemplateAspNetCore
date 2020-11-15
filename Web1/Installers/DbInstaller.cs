using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Data;
using Web1.Data.Repositories;
using Web1.Options;
using Web1.Services;

namespace Web1.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                                       options.UseSqlServer(
                                           configuration.GetConnectionString("DefaultConnection")));

           

            // Repositories
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAuthRepository,AuthRepository>();


            // services
            services.AddScoped<IDepartmnetService, DepartmnetService>();
            services.AddScoped<IAuthService,AuthService>();
        }
    }
}
