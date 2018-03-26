using System;
using System.Collections.Generic;

namespace MigracionSap.Presentacion.BaseDatos.Entidades
{
    public class DocumentoBase
    {
        public string Serie { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaContable { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Total { get; set; }
        public int CodSap { get; set; }
    }

    public class DetalleBase
    {
        public int NroLinea { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
    }
}
