using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProyectoSO.Configuration;

namespace ProyectoSO.Web.Host.Startup
{
    [DependsOn(
       typeof(ProyectoSOWebCoreModule))]
    public class ProyectoSOWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ProyectoSOWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProyectoSOWebHostModule).GetAssembly());
        }
    }
}
