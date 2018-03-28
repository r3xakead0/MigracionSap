using System;
using System.Collections.Generic;

namespace MigracionSap.Presentacion.BaseDatos.Entidades
{
    public class SalidaAlmacen : DocumentoBase
    {
        public int IdSalidaAlmacen { get; set; }
        public List<SalidaAlmacenDetalle> Detalle = new List<SalidaAlmacenDetalle>();
    }

    public class SalidaAlmacenDetalle : DetalleBase
    {
        public int IdSalidaAlmacenDetalle { get; set; }
        public int IdSalidaAlmacen { get; set; }
        public string CodAlmacen { get; set; }
        public string CodImpuesto { get; set; }
        public string CodMoneda { get; set; }
        public string CodCuentaContable { get; set; }
        public string CodProyecto { get; set; }
        public string CodCentroCosto { get; set; }
    }
}
