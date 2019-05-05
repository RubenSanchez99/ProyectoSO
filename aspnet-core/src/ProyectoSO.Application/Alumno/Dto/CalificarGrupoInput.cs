using System.Collections.Generic;

namespace ProyectoSO.Alumno.Dto
{
    public class CalificarGrupoInput
    {
        public int GrupoId { get; set; }
        public List<KeyValuePair<int, int>> Calificaciones { get; set; }
    }
}