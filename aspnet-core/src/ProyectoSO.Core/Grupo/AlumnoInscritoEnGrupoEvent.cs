using Abp.Events.Bus;
using Abp.Events.Bus.Entities;

namespace ProyectoSO.Grupo
{
    public class AlumnoInscritoEnGrupoEvent : EventData
    {
        public AlumnoInscritoEnGrupoEvent(int grupoId)
        {
            GrupoId = grupoId;
        }

        public int GrupoId { get; private set; }
    }
}