using System;

namespace MigracionSap.Cliente.BaseDatos.Entidades
{

    public class Base
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = "";
    }

    public class DocumentoBase
    {
        public Empresa Empresa { get; set; } = null;
        public TipoDocumento TipoDocumento { get; set; } = null;
        public int Serie { get; set; } = 0;
        public string Usuario { get; set; } = "";
        public string Comentario { get; set; } = "";
        public DateTime FechaContable { get; set; } = DateTime.Now;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0.0;
        public string CodSap { get; set; } = "";
    }

    public class DetalleBase
    {
        public int NroLinea { get; set; } = 1;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public double Cantidad { get; set; } = 0.0;
    }
}
