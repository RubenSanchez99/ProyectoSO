using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ProyectoSO.Materia.Dto
{
    [AutoMapFrom(typeof(Materia))]
    public class MateriaDto : IEntityDto<int>
    {
        public int Id { get; set; }
        
        public int Semestre { get; set; }
        
        public string Nombre { get; set; }
        
        public int? RequisitoId { get; set; }
        
        public MateriaDto MateriaRequisito { get; set; }
    }
}