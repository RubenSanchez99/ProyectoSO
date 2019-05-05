namespace ProyectoSO.Grupo.Dto
{
    public class GetGruposOutput
    {
        public int Id { get; set; }
        
        public string Materia { get; set; }
        
        public int Capacidad { get; set; }
        
        public string Horario { get; set; }
        
        public bool Finalizado { get; set; }
        
        public int AlumnosInscritos { get; set; }
    }
}