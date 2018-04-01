using System;
using System.Collections.Generic;

namespace MigracionSap.Simple.ServicioWeb.Json
{
    public class EntradaAlmacen
    {
        public string docEntryOrden { get; set; }
        public string comentario { get; set; }
        public string usuario { get; set; }
        public string total { get; set; }
        public string FechaContable { get; set; }
        public string FechaCreacion { get; set; }
        public List<EntradaAlmacenDetalle> detalle { get; set; } = new List<EntradaAlmacenDetalle>();
    }

    public class EntradaAlmacenDetalle
    {
        public string codArticulo { get; set; }
        public string descripcion { get; set; }
        public string cantidad { get; set; }
        public string codAlmacen { get; set; }
        public string codImpuesto { get; set; }
        public string codCentroCosto { get; set; }
    }
}
