using Abp.Domain.Entities;

namespace ProyectoSO.Materia
{
    public class Materia : Entity
    {
        public int Semestre { get; set; }
        
        public string Nombre { get; set; }
        
        public int? MateriaRequisitoId { get; set; }
        
        public Materia MateriaRequisito { get; set; }
    }
}