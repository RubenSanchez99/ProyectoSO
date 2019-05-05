using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ProyectoSO.MultiTenancy.Dto;

namespace ProyectoSO.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

