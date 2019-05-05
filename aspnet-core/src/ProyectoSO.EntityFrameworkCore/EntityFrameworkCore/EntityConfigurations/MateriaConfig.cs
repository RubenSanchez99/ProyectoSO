using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoSO.EntityFrameworkCore.EntityConfigurations
{
    public class MateriaConfig : IEntityTypeConfiguration<Materia.Materia>
    {
        public void Configure(EntityTypeBuilder<Materia.Materia> builder)
        {
            builder.HasData(
                new Materia.Materia { Id = 1, Semestre = 1, Nombre  = "Matemáticas 1", MateriaRequisitoId = null },
                new Materia.Materia { Id = 2, Semestre = 1, Nombre  = "Matemáticas 2", MateriaRequisitoId = null },
                new Materia.Materia { Id = 3, Semestre = 1, Nombre  = "Principios de Arquitectura Computacional", MateriaRequisitoId = null },
                new Materia.Materia { Id = 4, Semestre = 1, Nombre  = "Programación Orientada a Objetos", MateriaRequisitoId = null },
                new Materia.Materia { Id = 5, Semestre = 1, Nombre  = "Administración", MateriaRequisitoId = null },
                new Materia.Materia { Id = 6, Semestre = 1, Nombre  = "Metodología de la Programación", MateriaRequisitoId = null },
                new Materia.Materia { Id = 7, Semestre = 1, Nombre  = "Aplicación de las Tecnologías de la Información", MateriaRequisitoId = null },
                new Materia.Materia { Id = 8, Semestre = 1, Nombre  = "Competencia Comunicativa", MateriaRequisitoId = null },
                
                new Materia.Materia { Id = 9, Semestre = 2, Nombre  = "Matemáticas 3", MateriaRequisitoId = 2 },
                new Materia.Materia { Id = 10, Semestre = 2, Nombre  = "Matemáticas 4", MateriaRequisitoId = 2 },
                new Materia.Materia { Id = 11, Semestre = 2, Nombre  = "Física", MateriaRequisitoId = 2 },
                new Materia.Materia { Id = 12, Semestre = 2, Nombre  = "Programación I", MateriaRequisitoId = 4 },
                new Materia.Materia { Id = 13, Semestre = 2, Nombre  = "Comportamiento Organizacional", MateriaRequisitoId = 5 },
                new Materia.Materia { Id = 14, Semestre = 2, Nombre  = "Teleinformática", MateriaRequisitoId = 3 },
                new Materia.Materia { Id = 15, Semestre = 2, Nombre  = "Apreciación a las Artes", MateriaRequisitoId = null },
                
                new Materia.Materia { Id = 16, Semestre = 3, Nombre  = "Matemáticas Discretas", MateriaRequisitoId = 10 },
                new Materia.Materia { Id = 17, Semestre = 3, Nombre  = "Análisis de Sistemas I", MateriaRequisitoId = null },
                new Materia.Materia { Id = 18, Semestre = 3, Nombre  = "Sistemas Electróncios", MateriaRequisitoId = 11 },
                new Materia.Materia { Id = 19, Semestre = 3, Nombre  = "Programación II", MateriaRequisitoId = 12 },
                new Materia.Materia { Id = 20, Semestre = 3, Nombre  = "Procesamiento de Imágenes, Audio y Diálogos", MateriaRequisitoId = null },
                new Materia.Materia { Id = 21, Semestre = 3, Nombre  = "Estructura de datos", MateriaRequisitoId = 12 },
                new Materia.Materia { Id = 22, Semestre = 3, Nombre  = "Teoría de Autómatas", MateriaRequisitoId = 10 },
                new Materia.Materia { Id = 23, Semestre = 3, Nombre  = "Cultura de Calidad", MateriaRequisitoId = null },
                
                new Materia.Materia { Id = 24, Semestre = 4, Nombre  = "Ecuaciones Diferenciales", MateriaRequisitoId = 16 },
                new Materia.Materia { Id = 25, Semestre = 4, Nombre  = "Circuitos Digitales", MateriaRequisitoId = 18 },
                new Materia.Materia { Id = 26, Semestre = 4, Nombre  = "Bioinformática", MateriaRequisitoId = 21 },
                new Materia.Materia { Id = 27, Semestre = 4, Nombre  = "Base de Datos", MateriaRequisitoId = 21 },
                new Materia.Materia { Id = 28, Semestre = 4, Nombre  = "Interconectividad de Redes", MateriaRequisitoId = 14 },
                new Materia.Materia { Id = 29, Semestre = 4, Nombre  = "Ambiente y Sustentabilidad", MateriaRequisitoId = null },
                
                new Materia.Materia { Id = 30, Semestre = 5, Nombre  = "Estadística I", MateriaRequisitoId = 24 },
                new Materia.Materia { Id = 31, Semestre = 5, Nombre  = "Análisis Numérico", MateriaRequisitoId = 24 },
                new Materia.Materia { Id = 32, Semestre = 5, Nombre  = "Microprocesadores", MateriaRequisitoId = 25, },
                new Materia.Materia { Id = 33, Semestre = 5, Nombre  = "Arquitecturas Avanzadas de Computadoras", MateriaRequisitoId = null },
                new Materia.Materia { Id = 34, Semestre = 5, Nombre  = "Contexto Social de la Profesión", MateriaRequisitoId = null },
                
                new Materia.Materia { Id = 35, Semestre = 6, Nombre  = "Sistemas Embebidos I", MateriaRequisitoId = 32 },
                new Materia.Materia { Id = 36, Semestre = 6, Nombre  = "Estadística II", MateriaRequisitoId = 30 },
                new Materia.Materia { Id = 37, Semestre = 6, Nombre  = "Sistemas Operativos", MateriaRequisitoId = 32 },
                new Materia.Materia { Id = 38, Semestre = 6, Nombre  = "Seguridad en Informática", MateriaRequisitoId = null },
                new Materia.Materia { Id = 39, Semestre = 6, Nombre  = "Competencia Comunicativa en Inglés", MateriaRequisitoId = null },
                new Materia.Materia { Id = 40, Semestre = 6, Nombre  = "Cultura Regional", MateriaRequisitoId = null },
                
                new Materia.Materia { Id = 41, Semestre = 7, Nombre  = "Investigación de Operaciones", MateriaRequisitoId = 36 },
                new Materia.Materia { Id = 42, Semestre = 7, Nombre  = "Rendimiento de Sistemas", MateriaRequisitoId = 37 },
                new Materia.Materia { Id = 43, Semestre = 7, Nombre  = "Minería de Datos", MateriaRequisitoId = null },
                new Materia.Materia { Id = 44, Semestre = 7, Nombre  = "Ética, Sociedad y Profesión", MateriaRequisitoId = null },
                new Materia.Materia { Id = 45, Semestre = 7, Nombre  = "Metodología Científica", MateriaRequisitoId = null },
                new Materia.Materia { Id = 46, Semestre = 7, Nombre  = "Formación de Emprendedores", MateriaRequisitoId = null }
            );
        }
    }
}