using System;

namespace MigracionSap.Presentacion.BaseDatos.Entidades
{
    public class Migracion
    {

        public int Id { get; set; } = 0;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Empresa Empresa { get; set; } = null;
        public TipoDocumento TipoDocumento { get; set; } = null;
        public int Obtenidos { get; set; } = 0;
        public int Enviados { get; set; } = 0;
        public int Errores { get; set; } = 0;

    }
}
