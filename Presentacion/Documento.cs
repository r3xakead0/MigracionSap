using System;

namespace MigracionSap
{
    public class Documento
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Tipo { get; set; }
        public string Numeracion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public DateTime? FechaMigracion { get; set; } = null;
    }
    
}
