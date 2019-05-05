using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProyectoSO.Authorization;

namespace ProyectoSO
{
    [DependsOn(
        typeof(ProyectoSOCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProyectoSOApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProyectoSOAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProyectoSOApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
