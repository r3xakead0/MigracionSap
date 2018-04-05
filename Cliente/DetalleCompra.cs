namespace MigracionSap.Cliente
{
    public class DetalleCompra
    {
        public int NroLinea { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }

        public string CodAlmacen { get; set; }
        public string DscAlmacen { get; set; }

        public string CodImpuesto { get; set; }
        public string DscImpuesto { get; set; }

        public string CodCuentaContable { get; set; }
        public string DscCuentaContable { get; set; }
        public string NroCuentaContable { get; set; }

        public string CodProyecto { get; set; }
        public string DscProyecto { get; set; }

        public string CodCentroCosto { get; set; }
        public string DscCentroCosto { get; set; }

        public string CodProveedor { get; set; }
        public string DscProveedor { get; set; }
    }
    
}
