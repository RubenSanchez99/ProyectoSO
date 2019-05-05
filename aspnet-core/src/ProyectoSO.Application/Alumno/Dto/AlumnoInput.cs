using Abp.AutoMapper;

namespace ProyectoSO.Alumno.Dto
{
    public class AlumnoInput
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        
        public string ApellidoPaterno { get; set; }
        
        public string ApellidoMaterno { get; set; }
    }
}