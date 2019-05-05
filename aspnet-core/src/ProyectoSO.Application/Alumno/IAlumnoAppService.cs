using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ProyectoSO.Alumno.Dto;

namespace ProyectoSO.Alumno
{
    public interface IAlumnoAppService : IApplicationService
    {
        Task<GetAlumnosOutput> RegistrarAlumno(AlumnoInput alumno);

        Task<GetAlumnosOutput> ActualizarInfoDeAlumno(AlumnoInput alumno);

        Task<Alumno> GetAlumno(int id);

        PagedResultDto<GetAlumnosOutput> GetAlumnos();
    }
}