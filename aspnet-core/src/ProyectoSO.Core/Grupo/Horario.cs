using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Values;

namespace ProyectoSO.Grupo
{
    public class Horario : ValueObject
    {
        public bool Lunes { get; set; }
        
        public bool Martes { get; set; }
        
        public bool Miercoles { get; set; }
        
        public bool Jueves { get; set; }
        
        public bool Viernes { get; set; }
        
        public int Hora { get; set; }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Lunes;
            yield return Martes;
            yield return Miercoles;
            yield return Jueves;
            yield return Viernes;
            yield return Hora;
        }

        public bool Empalma(Horario horario)
        {
            return Hora == horario.Hora &&
                   Lunes == horario.Lunes ||
                   Martes == horario.Martes ||
                   Miercoles == horario.Miercoles ||
                   Jueves == horario.Jueves ||
                   Viernes == horario.Viernes;
        }

        public override string ToString()
        {
            var daysList = new List<string>();
            
            if (Lunes) daysList.Add("L");
            if (Martes) daysList.Add("M");
            if (Miercoles) daysList.Add("X");
            if (Jueves) daysList.Add("J");
            if (Viernes) daysList.Add("V");
            
            var days = string.Join('-',
                daysList);

            return string.Join(' ', days, GetHora(Hora));
        }

        private string GetHora(int hora)
        {
            var dict = new Dictionary<int, string>
            {
                { 1, "7:00-8:00" },
                { 2, "8:00-9:00" },
                { 3, "9:00-10:00" },
                { 4, "10:00-11:00" },
                { 5, "11:00-12:00" },
                { 6, "12:00-13:00" },
                { 7, "13:00-14:00" },
                { 8, "14:00-15:00" },
                { 9, "15:00-16:00" },
                { 10, "16:00-17:00" },
                { 11, "17:00-18:00" },
                { 12, "18:00-19:00" },
                { 13, "19:00-20:00" },
                { 14, "20:00-21:00" },
                { 15, "21:00-22:00" }
            };

            return dict[hora];
        }
    }
}