using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Values;

namespace ProyectoSO.Alumno
{
    public class MateriaInscrita : Entity
    {
        public int MateriaId { get; set; }
        
        public Materia.Materia Materia { get; set; }
        
        public int GrupoId { get; set; }
        
        public Grupo.Grupo Grupo { get; set; }
        
        [NotMapped]
        public string Horario { get; set; }
        
        public int? Calificacion { get; set; }
    }
}