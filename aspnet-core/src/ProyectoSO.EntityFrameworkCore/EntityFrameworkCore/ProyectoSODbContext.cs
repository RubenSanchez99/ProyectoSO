using Abp.Localization;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ProyectoSO.Authorization.Roles;
using ProyectoSO.Authorization.Users;
using ProyectoSO.EntityFrameworkCore.EntityConfigurations;
using ProyectoSO.MultiTenancy;

namespace ProyectoSO.EntityFrameworkCore
{
    public class ProyectoSODbContext : AbpZeroDbContext<Tenant, Role, User, ProyectoSODbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<Grupo.Grupo> Grupos { get; set; }
        public DbSet<Alumno.Alumno> Alumnos { get; set; }
        public DbSet<Materia.Materia> Materias { get; set; }
        
        public ProyectoSODbContext(DbContextOptions<ProyectoSODbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    	
            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760

            modelBuilder.ApplyConfiguration(new MateriaConfig());
            modelBuilder.ApplyConfiguration(new GrupoConfig());
        }
    }
}
