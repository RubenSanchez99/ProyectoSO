using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Json;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using ProyectoSO.Alumno;
using ProyectoSO.Alumno.Dto;
using ProyectoSO.Grupo.Dto;

namespace ProyectoSO.Grupo
{
    public class GrupoAppService : ApplicationService, IGrupoAppService
    {
        private readonly IRepository<Grupo> _grupoRepository;
        private readonly IRepository<Alumno.Alumno> _alumnoRepository;
        private readonly IRepository<Materia.Materia> _materiaRepository;

        public GrupoAppService(IRepository<Grupo> grupoRepository, IRepository<Alumno.Alumno> alumnoRepository, IRepository<Materia.Materia> materiaRepository)
        {
            _grupoRepository = grupoRepository;
            _alumnoRepository = alumnoRepository;
            _materiaRepository = materiaRepository;
        }

        public async Task<GetGruposOutput> AbrirGrupo(GrupoInput grupo)
        {
            var tGrupo = await _grupoRepository.InsertAsync(Grupo.Abrir(grupo.MateriaId, grupo.Capacidad, grupo.Horario));
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GetGruposOutput
            {
                Id = tGrupo.Id,
                Capacidad = tGrupo.Capacidad,
                Finalizado = tGrupo.Finalizado,
                Materia = _materiaRepository.Get(tGrupo.MateriaId).Nombre,
                Horario = tGrupo.Horario.ToString(),
                AlumnosInscritos = tGrupo.AlumnosInscritos.Count
            };
        }

        public async Task<GetGruposOutput> InscribirAlumno(InscribirAlumnoInput input)
        {
            var grupo = await _grupoRepository.GetAllIncluding(x => x.Materia, x => x.AlumnosInscritos).SingleAsync(x => x.Id == input.GrupoId);
            var alumno = await _alumnoRepository.GetAllIncluding(x => x.MateriasInscritas).SingleAsync(x => x.Id == input.AlumnoMatricula);
            var materia = await _materiaRepository.GetAllIncluding(x => x.MateriaRequisito).SingleAsync(x => x.Id == grupo.MateriaId);

            if (alumno.MateriasInscritas == null)
            {
                alumno.MateriasInscritas = new List<MateriaInscrita>();
            }
            
            foreach (var materiaInscrita in alumno.MateriasInscritas)
            {
                materiaInscrita.Materia = _materiaRepository.Get(materiaInscrita.MateriaId);
                materiaInscrita.Grupo = _grupoRepository.Get(materiaInscrita.GrupoId);
                materiaInscrita.Horario = materiaInscrita.Grupo.Horario.ToString();
            }

            if (grupo.AlumnosInscritos.Any(x => x.Matricula == alumno.Id))
            {
                throw new UserFriendlyException("El alumno ya está inscrito en el grupo.");
            }

            if (alumno.MateriasInscritas.Count(x => x.Calificacion == null) >= 6)
            {
                throw new UserFriendlyException("El alumno no puede tener más de seis materias inscritas.");
            }

            if (materia.MateriaRequisitoId != null && !alumno.MateriasInscritas.Any(x =>
                    x.MateriaId == materia.MateriaRequisitoId && x.Calificacion != null && x.Calificacion >= 70))
            {
                throw new UserFriendlyException($"El alumno no cumple con el requisito de la materia ({materia.MateriaRequisito.Nombre}).");
            }

            var empalmadas =
                alumno.MateriasInscritas.Where(x => x.Calificacion == null && x.Grupo.Horario.Empalma(grupo.Horario)).ToList();

            if (empalmadas.Any())
            {
                throw new UserFriendlyException($"El horario de la materia se empalma con otro grupo inscrito ({empalmadas.First().Materia.Nombre}).");
            }

            grupo.InscribirAlumno(alumno.Id, string.Join(' ', alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno));
            alumno.InscribirMateria(input.GrupoId, materia.Id);
                
            return new GetGruposOutput
            {
                Id = grupo.Id,
                Capacidad = grupo.Capacidad,
                Finalizado = grupo.Finalizado,
                Materia = grupo.Materia.Nombre,
                Horario = grupo.Horario.ToString(),
                AlumnosInscritos = grupo.AlumnosInscritos.Count
            };
            
        }

        public async Task<GetGruposOutput> CalificarGrupo(CalificarGrupoInput input)
        {
            var grupo = await _grupoRepository.GetAllIncluding(x => x.Materia, x => x.AlumnosInscritos).SingleAsync(x => x.Id == input.GrupoId);
            grupo.CalificarAlumnos(input.Calificaciones);

            foreach (var calificacion in input.Calificaciones)
            {
                var alumno = await _alumnoRepository.GetAllIncluding(x => x.MateriasInscritas).SingleAsync(x => x.Id == calificacion.Key);
                var materiaInscrita = alumno.MateriasInscritas.Last(x => x.GrupoId == input.GrupoId);
                materiaInscrita.Calificacion = calificacion.Value;
            }
            
            return new GetGruposOutput
            {
                Id = grupo.Id,
                Capacidad = grupo.Capacidad,
                Finalizado = grupo.Finalizado,
                Materia = _materiaRepository.Get(grupo.MateriaId).Nombre,
                Horario = grupo.Horario.ToString(),
                AlumnosInscritos = grupo.AlumnosInscritos?.Count ?? 0
            };
        }

        public async Task<GetGruposOutput> FinalizarGrupo(int grupoId)
        {
            var grupo = await _grupoRepository.SingleAsync(x => x.Id == grupoId);
            grupo.Finalizar();
            
            return new GetGruposOutput
            {
                Id = grupo.Id,
                Capacidad = grupo.Capacidad,
                Finalizado = grupo.Finalizado,
                Materia = _materiaRepository.Get(grupo.MateriaId).Nombre,
                Horario = grupo.Horario.ToString(),
                AlumnosInscritos = grupo.AlumnosInscritos?.Count ?? 0
            };
        }

        public PagedResultDto<GetGruposOutput> GetGrupos()
        {
            var result = _grupoRepository.GetAll().Include(x => x.Materia).Include(x => x.AlumnosInscritos);
            var newResult = from tGrupo in result
                join tMateria in _materiaRepository.GetAll() on tGrupo.MateriaId equals tMateria.Id
                select new GetGruposOutput
                {
                    Id = tGrupo.Id,
                    Capacidad = tGrupo.Capacidad,
                    Finalizado = tGrupo.Finalizado,
                    Materia = tMateria.Nombre,
                    Horario = tGrupo.Horario.ToString(),
                    AlumnosInscritos = tGrupo.AlumnosInscritos.Count
                };
            
            var getGruposOutputs = newResult.OrderBy(x => x.Id).ToList();
            return new PagedResultDto<GetGruposOutput>(
                getGruposOutputs.Count(),
                getGruposOutputs
            );
        }

        public async Task<Grupo> GetGrupo(int id)
        {
            var grupo = await _grupoRepository.GetAllIncluding(x => x.Materia, x => x.AlumnosInscritos).SingleAsync(x => x.Id == id);
            grupo.AlumnosInscritos = grupo.AlumnosInscritos.OrderBy(x => x.Nombre).ToList();
            return grupo;
        }
    }
}