using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Abp.Events.Bus.Handlers;
using ProyectoSO.Grupo;

namespace ProyectoSO.Alumno
{
    public class Alumno : Entity
    {
        public string Nombre { get; set; }
        
        public string ApellidoPaterno { get; set; }
        
        public string ApellidoMaterno { get; set; }
        
        public List<MateriaInscrita> MateriasInscritas { get; set; }

        public static Alumno Crear(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            return new Alumno
            {
                Nombre = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                MateriasInscritas = new List<MateriaInscrita>()
            };
        }
        
        public void InscribirMateria(int grupoId, int materiaId)
        {
            MateriasInscritas.Add(new MateriaInscrita {GrupoId = grupoId, MateriaId = materiaId});
        }

        public void RecibirCalificacion(int grupoId, int calificacion)
        {
            var grupo = MateriasInscritas.Single(x => x.GrupoId == grupoId);
            grupo.Calificacion = calificacion;
        }
    }
}