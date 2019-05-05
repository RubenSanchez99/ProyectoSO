using System.Threading.Tasks;
using Abp.Application.Services;
using ProyectoSO.Authorization.Accounts.Dto;

namespace ProyectoSO.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
