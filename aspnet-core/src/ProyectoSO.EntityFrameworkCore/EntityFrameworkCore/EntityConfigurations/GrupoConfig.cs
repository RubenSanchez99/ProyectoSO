using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoSO.Grupo;

namespace ProyectoSO.EntityFrameworkCore.EntityConfigurations
{
    public class GrupoConfig : IEntityTypeConfiguration<Grupo.Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo.Grupo> builder)
        {
            builder.OwnsOne(x => x.Horario);
        }
    }
}