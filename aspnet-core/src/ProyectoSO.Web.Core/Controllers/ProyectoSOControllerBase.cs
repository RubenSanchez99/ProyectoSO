using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ProyectoSO.Controllers
{
    public abstract class ProyectoSOControllerBase: AbpController
    {
        protected ProyectoSOControllerBase()
        {
            LocalizationSourceName = ProyectoSOConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
