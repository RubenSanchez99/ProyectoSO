using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Values;

namespace ProyectoSO.Grupo
{
    public class AlumnoInscrito : Entity
    {   
        public int Matricula { get; set; }
        
        public string Nombre { get; set; }
        
        public int? Calificacion { get; set; }
        
        public AlumnoInscrito() {}
        
    }
}