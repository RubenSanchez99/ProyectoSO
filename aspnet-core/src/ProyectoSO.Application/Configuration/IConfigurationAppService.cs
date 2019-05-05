using System.Threading.Tasks;
using ProyectoSO.Configuration.Dto;

namespace ProyectoSO.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
