using System;
using System.Collections.Generic;

namespace MigracionSap.Simple.Sap.Entidades
{
    public class SolicitudCompra
    {

        public char Tipo { get; set; }
        public int Serie { get; set; } = 0;
        public string Usuario { get; set; } = "";
        public string Comentario { get; set; } = "";
        public DateTime FechaContable { get; set; } = DateTime.Now;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaNecesita { get; set; } = DateTime.Now;
        public int IdSucursal { get; set; } = 0;
        public int IdArea { get; set; } = 0;
        public int DocEntry { get; set; } = 0;

        public List<SolicitudCompraDetalle> Detalle = new List<SolicitudCompraDetalle>();
    }

    public class SolicitudCompraDetalle
    {
        public int NroLinea { get; set; } = 1;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public double Cantidad { get; set; } = 0.0;
        public double Precio { get; set; } = 0.0;
        public string CodAlmacen { get; set; }
        public string CodProveedor { get; set; }
        public string CodProyecto { get; set; }
        public string CodCentroCosto { get; set; }
    }
}
