using System;
using System.Collections.Generic;

namespace MigracionSap.Presentacion.ServicioWeb.Json
{
    public class SalidaAlmacen
    {
        public string comentario { get; set; }
        public string usuario { get; set; }
        public string total { get; set; }
        public string FechaContable { get; set; }
        public string FechaCreacion { get; set; }
        public List<SalidaAlmacenDetalle> detalle { get; set; } = new List<SalidaAlmacenDetalle>();
    }

    public class SalidaAlmacenDetalle
    {
        public string codArticulo { get; set; }
        public string descripcion { get; set; }
        public string cantidad { get; set; }
        public string codAlmacen { get; set; }
        public string codImpuesto { get; set; }
        public string codCentroCosto { get; set; }
    }
}
