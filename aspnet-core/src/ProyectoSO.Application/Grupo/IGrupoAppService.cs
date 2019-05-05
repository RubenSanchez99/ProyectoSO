using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ProyectoSO.Alumno.Dto;
using ProyectoSO.Grupo.Dto;

namespace ProyectoSO.Grupo
{
    public interface IGrupoAppService : IApplicationService
    {
        Task<GetGruposOutput> AbrirGrupo(GrupoInput grupo);

        Task<GetGruposOutput> InscribirAlumno(InscribirAlumnoInput input);

        Task<GetGruposOutput> CalificarGrupo(CalificarGrupoInput input);

        Task<GetGruposOutput> FinalizarGrupo(int grupoId);

        PagedResultDto<GetGruposOutput> GetGrupos();

        Task<Grupo> GetGrupo(int id);
    }
}