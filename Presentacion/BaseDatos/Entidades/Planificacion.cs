using System;

namespace MigracionSap.Cliente.BaseDatos.Entidades
{
    public class Planificacion
    {
        public int Id { get; set; } = 0;
        public int Dia { get; set; } = 0;
        public DateTime Hora { get; set; } = DateTime.Now;

    }
}
