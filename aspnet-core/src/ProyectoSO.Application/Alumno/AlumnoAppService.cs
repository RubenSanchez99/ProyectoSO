using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using ProyectoSO.Alumno.Dto;
using System.Linq;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSO.Alumno
{
    public class AlumnoAppService : ApplicationService, IAlumnoAppService
    {
        private readonly IRepository<Alumno> _alumnoRepository;
        private readonly IRepository<Materia.Materia> _materiaRepository;

        public AlumnoAppService(IRepository<Alumno> alumnoRepository, IRepository<Materia.Materia> materiaRepository)
        {
            _alumnoRepository = alumnoRepository;
            _materiaRepository = materiaRepository;
        }

        public async Task<GetAlumnosOutput> RegistrarAlumno(AlumnoInput alumno)
        {
            var tAlumno = await _alumnoRepository.InsertAsync(Alumno.Crear(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno));
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GetAlumnosOutput
            {
                Matricula = tAlumno.Id,
                Nombre = string.Join(' ', tAlumno.Nombre, tAlumno.ApellidoPaterno, tAlumno.ApellidoMaterno),
                MateriasEnCurso = tAlumno.MateriasInscritas.Count(x => x.Calificacion != null)
            };
        }

        public async Task<GetAlumnosOutput> ActualizarInfoDeAlumno(AlumnoInput alumno)
        {
            var alumnoPorActualizar = await _alumnoRepository.GetAllIncluding(x => x.MateriasInscritas).SingleAsync(x => x.Id == alumno.Id.GetValueOrDefault());
            alumnoPorActualizar.Nombre = alumno.Nombre;
            alumnoPorActualizar.ApellidoPaterno = alumno.ApellidoPaterno;
            alumnoPorActualizar.ApellidoMaterno = alumno.ApellidoMaterno;
            return new GetAlumnosOutput
            {
                Matricula = alumnoPorActualizar.Id,
                Nombre = String.Join(' ', alumnoPorActualizar.Nombre, alumnoPorActualizar.ApellidoPaterno, alumnoPorActualizar.ApellidoMaterno),
                MateriasEnCurso = alumnoPorActualizar.MateriasInscritas.Count(x => x.Calificacion != null)
            };
        }

        public async Task<Alumno> GetAlumno(int id)
        {
            var alumno = await _alumnoRepository.GetAllIncluding(x => x.MateriasInscritas).SingleAsync(x => x.Id == id);
            foreach (var materiaInscrita in alumno.MateriasInscritas)
            {
                materiaInscrita.Materia = _materiaRepository.Get(materiaInscrita.MateriaId);
            }

            return alumno;
        }

        public PagedResultDto<GetAlumnosOutput> GetAlumnos()
        {
            var result = _alumnoRepository.GetAllIncluding(x => x.MateriasInscritas);
            var newResult = from tAlumno in result
                select new GetAlumnosOutput
                {
                    Matricula = tAlumno.Id,
                    Nombre = String.Join(' ', tAlumno.Nombre, tAlumno.ApellidoPaterno, tAlumno.ApellidoMaterno),
                    MateriasEnCurso = tAlumno.MateriasInscritas.Count(x => x.Calificacion == null)
                };
            var getAlumnosOutputs = newResult.ToList();
            return new PagedResultDto<GetAlumnosOutput>(
                getAlumnosOutputs.Count(),
                getAlumnosOutputs
            );
        }
    }
}