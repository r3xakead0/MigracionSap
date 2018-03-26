using System;
using System.Collections.Generic;

namespace MigracionSap.Presentacion.BaseDatos.Entidades
{
    public class SolicitudCompra : DocumentoBase
    {
        public int IdSolicitudCompra { get; set; }
        public char Tipo { get; set; }
        public DateTime FechaNecesita { get; set; }
        public List<SolicitudCompraDetalle> Detalle = new List<SolicitudCompraDetalle>();
    }

    public class SolicitudCompraDetalle : DetalleBase
    {
        public int IdSolicitudCompraDetalle { get; set; }
        public int IdSolicitudCompra { get; set; }
        public string CodAlmacen { get; set; }
        public string CodProveedor { get; set; }
        public string CodCentroCosto { get; set; }
    }
}
