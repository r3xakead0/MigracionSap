﻿using System;
using System.Collections.Generic;

namespace MigracionSap.Presentacion.BaseDatos.Entidades
{
    public class EntradaAlmacen : DocumentoBase
    {
        public int IdEntradaAlmacen { get; set; }
        public string refSap { get; set; }
        public List<EntradaAlmacenDetalle> Detalle = new List<EntradaAlmacenDetalle>();
    }

    public class EntradaAlmacenDetalle : DetalleBase
    {
        public int IdEntradaAlmacenDetalle { get; set; }
        public int IdEntradaAlmacen { get; set; }
        public string CodAlmacen { get; set; }
        public string CodImpuesto { get; set; }
        public string NroCuentaContable { get; set; }
        public string CodProyecto { get; set; }
        public string CodCentroCosto { get; set; }
    }
}