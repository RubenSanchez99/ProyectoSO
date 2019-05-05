using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Abp.Events.Bus;
using Abp.UI;

namespace ProyectoSO.Grupo
{
    public class Grupo : AggregateRoot
    {
        public int MateriaId { get; protected set; }
        
        public Materia.Materia Materia { get; protected set; }
        
        public int Capacidad { get; protected set; }
        
        public Horario Horario { get; protected set; }
        
        public bool Finalizado { get; protected set; }

        public List<AlumnoInscrito>  AlumnosInscritos { get; set; }
        
        protected Grupo()
        {
        }

        public static Grupo Abrir(int materiaId, int capacidad, Horario horario)
        {
            return new Grupo
            {
                MateriaId = materiaId,
                Capacidad = capacidad,
                Horario = horario,
                Finalizado = false,
                AlumnosInscritos = new List<AlumnoInscrito>()
            };
        }

        public void InscribirAlumno(int matricula, string alumnoNombre)
        {
            AssertLugarDisponible();
            
            if (AlumnosInscritos == null) AlumnosInscritos = new List<AlumnoInscrito>();

            AlumnosInscritos.Add(
                new AlumnoInscrito {Matricula = matricula, Nombre = alumnoNombre, Calificacion = null});    
        }

        public void CalificarAlumnos(IList<KeyValuePair<int, int>> calificaciones)
        {
            if (AlumnosInscritos == null) throw new UserFriendlyException("No hay alumnos inscritos en este grupo");
            
            foreach (var calificacion in calificaciones)
            {
                var alumno = AlumnosInscritos.Single(x => x.Matricula == calificacion.Key);

                alumno.Calificacion = calificacion.Value;
            }
        }

        public void Finalizar()
        {
            Finalizado = true;
        }

        private bool LugarDisponible()
        {
            var numAlumnosInscritos = (AlumnosInscritos?.Count ?? 0);
            return numAlumnosInscritos < Capacidad;
        }

        private void AssertLugarDisponible()
        {
            if (!LugarDisponible())
            {
                throw new UserFriendlyException("El grupo ya no acepta más alumnos");
            }
        }
    }
}