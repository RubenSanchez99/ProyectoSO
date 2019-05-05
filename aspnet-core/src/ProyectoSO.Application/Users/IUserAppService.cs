using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ProyectoSO.Roles.Dto;
using ProyectoSO.Users.Dto;

namespace ProyectoSO.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
