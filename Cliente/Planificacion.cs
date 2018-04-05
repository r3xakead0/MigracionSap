using System;

namespace MigracionSap.Cliente
{
    public class Planificacion
    {

        public int Id { get; set; } = 0;
        public string Dia { get; set; } = "";
        public TimeSpan Hora { get; set; } = DateTime.Now.TimeOfDay;

    }
}
