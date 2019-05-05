using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ProyectoSO.Materia.Dto;

namespace ProyectoSO.Materia
{
    public class MateriaAppService : AsyncCrudAppService<Materia, MateriaDto>
    {
        public MateriaAppService(IRepository<Materia, int> repository) : base(repository)
        {
        }
    }
}