using System;
using System.Collections.Generic;

namespace MigracionSap.Presentacion.ServicioWeb.Json
{
    public class SolicitudCompra
    {
        public string idSolicitud { get; set; }
        public string serie { get; set; }
        public string tipo { get; set; }
        public string FechaContable { get; set; }
        public string FechaNecesita { get; set; }
        public string FechaCreacion { get; set; }
        public string comentario { get; set; }
        public string usuario { get; set; }
        public string idSucursal { get; set; }
        public string idArea { get; set; }
        public List<SolicitudCompraDetalle> items { get; set; } = new List<SolicitudCompraDetalle>();
    }

    public class SolicitudCompraDetalle
    {
        public string id_item_solpe { get; set; }
        public string id_solpe { get; set; }
        public string codArticulo { get; set; }
        public string descripcion { get; set; }
        public string cantidad { get; set; }
        public string codAlmacen { get; set; }
        public string codCentroCosto { get; set; }
        public string codProveedor { get; set; }
    }
}
