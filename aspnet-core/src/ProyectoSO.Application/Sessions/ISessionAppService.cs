using System.Threading.Tasks;
using Abp.Application.Services;
using ProyectoSO.Sessions.Dto;

namespace ProyectoSO.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
