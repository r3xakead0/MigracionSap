using System;
using System.Collections.Generic;

namespace MigracionSap.Cliente.BaseDatos.Entidades
{
    public class SolicitudCompra : DocumentoBase
    {
        public int IdSolicitudCompra { get; set; }
        public char Tipo { get; set; } // I = Articulos | S = Servicios
        public DateTime FechaNecesita { get; set; }
        public int IdSucursal { get; set; }
        public int IdArea { get; set; }
        public List<SolicitudCompraDetalle> Detalle = new List<SolicitudCompraDetalle>();
    }

    public class SolicitudCompraDetalle : DetalleBase
    {
        public int IdSolicitudCompraDetalle { get; set; }
        public int IdSolicitudCompra { get; set; }
        public string CodAlmacen { get; set; }
        public string CodProveedor { get; set; }
        public string CodProyecto { get; set; }
        public string CodCentroCosto { get; set; }
    }
}
