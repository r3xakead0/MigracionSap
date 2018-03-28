using System;

namespace MigracionSap
{
    public class Migracion
    {
        public string Empresa { get; set; }
        public string TipoDocumento { get; set; }
        public int Obtenidos { get; set; }
        public int Enviados { get; set; }
        public int Errores { get; set; }
    }
    
}
