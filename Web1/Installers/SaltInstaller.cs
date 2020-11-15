using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Helpers;
using Web1.Options;

namespace Web1.Installers
{
    public class SaltInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            SaltPassword saltPass = new SaltPassword();
            configuration.GetSection(nameof(SaltPassword)).Bind(saltPass);
            services.AddSingleton(saltPass);
            services.AddSingleton(new Hash(saltPass));
        }
    }
}
