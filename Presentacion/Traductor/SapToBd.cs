using System;
using SAP = MigracionSap.Cliente.Sap.Entidades;
using BD = MigracionSap.Cliente.BaseDatos.Entidades;
using System.Collections.Generic;

namespace MigracionSap.Cliente.Traductor
{
    public class SapToBd
    {

        public static BD.SalidaAlmacen SalidaAlmacen(SAP.SalidaAlmacen sapSalidaAlmacen)
        {
            BD.SalidaAlmacen bdSalidaAlmacen = null;
            try
            {
                if (sapSalidaAlmacen != null)
                {
                    bdSalidaAlmacen = new BD.SalidaAlmacen();

                    bdSalidaAlmacen.Empresa = null;
                    bdSalidaAlmacen.TipoDocumento = null;
                    bdSalidaAlmacen.Serie = sapSalidaAlmacen.Serie;
                    bdSalidaAlmacen.Usuario = sapSalidaAlmacen.Usuario;
                    bdSalidaAlmacen.Comentario = sapSalidaAlmacen.Comentario;
                    bdSalidaAlmacen.FechaContable = sapSalidaAlmacen.FechaContable;
                    bdSalidaAlmacen.FechaCreacion = sapSalidaAlmacen.FechaCreacion;
                    bdSalidaAlmacen.Total = 0.0;
                    bdSalidaAlmacen.CodSap = sapSalidaAlmacen.DocEntry;

                    bdSalidaAlmacen.Detalle = new List<BD.SalidaAlmacenDetalle>();

                    foreach (var sapDetalle in sapSalidaAlmacen.Detalle)
                    {
                        var bdDetalle = new BD.SalidaAlmacenDetalle();

                        bdDetalle.NroLinea = sapDetalle.NroLinea;
                        bdDetalle.Codigo = sapDetalle.Codigo;
                        bdDetalle.Descripcion = sapDetalle.Descripcion;
                        bdDetalle.Cantidad = sapDetalle.Cantidad;
                        bdDetalle.CodAlmacen = sapDetalle.CodAlmacen;
                        bdDetalle.CodImpuesto = sapDetalle.CodImpuesto;
                        bdDetalle.CodMoneda = sapDetalle.CodMoneda;
                        bdDetalle.CodCuentaContable = sapDetalle.CodCuentaContable;
                        bdDetalle.CodProyecto = sapDetalle.CodProyecto;
                        bdDetalle.CodCentroCosto = sapDetalle.CodCentroCosto;

                        bdSalidaAlmacen.Detalle.Add(bdDetalle);
                    }
                    
                }

                return bdSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BD.EntradaAlmacen EntradaAlmacen(SAP.EntradaAlmacen sapEntradaAlmacen)
        {
            BD.EntradaAlmacen bdEntradaAlmacen = null;
            try
            {
                if (sapEntradaAlmacen != null)
                {
                    bdEntradaAlmacen = new BD.EntradaAlmacen();

                    bdEntradaAlmacen.Serie = sapEntradaAlmacen.Serie;
                    bdEntradaAlmacen.Usuario = sapEntradaAlmacen.Usuario;
                    bdEntradaAlmacen.Comentario = sapEntradaAlmacen.Comentario;
                    bdEntradaAlmacen.FechaContable = sapEntradaAlmacen.FechaContable;
                    bdEntradaAlmacen.FechaCreacion = sapEntradaAlmacen.FechaCreacion;
                    bdEntradaAlmacen.Total = 0.0;
                    bdEntradaAlmacen.CodSap = sapEntradaAlmacen.DocEntry;
                    bdEntradaAlmacen.refSap = sapEntradaAlmacen.refSap;

                    bdEntradaAlmacen.Detalle = new List<BD.EntradaAlmacenDetalle>();

                    foreach (var sapDetalle in sapEntradaAlmacen.Detalle)
                    {
                        var bdDetalle = new BD.EntradaAlmacenDetalle();

                        bdDetalle.NroLinea = sapDetalle.NroLinea;
                        bdDetalle.Codigo = sapDetalle.Codigo;
                        bdDetalle.Descripcion = sapDetalle.Descripcion ;
                        bdDetalle.Cantidad = sapDetalle.Cantidad;
                        bdDetalle.CodAlmacen = sapDetalle.CodAlmacen;
                        bdDetalle.CodImpuesto = sapDetalle.CodImpuesto;
                        bdDetalle.CodMoneda = sapDetalle.CodMoneda;
                        bdDetalle.CodCuentaContable = sapDetalle.CodCuentaContable;
                        bdDetalle.CodProyecto = sapDetalle.CodProyecto;
                        bdDetalle.CodCentroCosto = sapDetalle.CodCentroCosto;

                        bdEntradaAlmacen.Detalle.Add(bdDetalle);
                    }

                }

                return bdEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static BD.SolicitudCompra SolicitudCompra(SAP.SolicitudCompra sapSolicitudCompra)
        {
            BD.SolicitudCompra bdSolicitudCompra = null;
            try
            {
                if (sapSolicitudCompra != null)
                {
                    bdSolicitudCompra = new BD.SolicitudCompra();

                    bdSolicitudCompra.Serie = sapSolicitudCompra.Serie;
                    bdSolicitudCompra.Tipo = sapSolicitudCompra.Tipo;
                    bdSolicitudCompra.Usuario = sapSolicitudCompra.Usuario;
                    bdSolicitudCompra.Comentario = sapSolicitudCompra.Comentario;
                    bdSolicitudCompra.FechaContable = sapSolicitudCompra.FechaContable;
                    bdSolicitudCompra.FechaCreacion = sapSolicitudCompra.FechaCreacion;
                    bdSolicitudCompra.FechaNecesita = sapSolicitudCompra.FechaNecesita;
                    bdSolicitudCompra.IdSucursal = sapSolicitudCompra.IdSucursal;
                    bdSolicitudCompra.IdArea = sapSolicitudCompra.IdArea;
                    bdSolicitudCompra.CodSap = sapSolicitudCompra.DocEntry;

                    bdSolicitudCompra.Detalle = new List<BD.SolicitudCompraDetalle>();

                    foreach (var sapDetalle in sapSolicitudCompra.Detalle)
                    {
                        var bdDetalle = new BD.SolicitudCompraDetalle();

                        bdDetalle.NroLinea = sapDetalle.NroLinea;
                        bdDetalle.Codigo = sapDetalle.Codigo;
                        bdDetalle.Descripcion = sapDetalle.Descripcion;
                        bdDetalle.Cantidad = sapDetalle.Cantidad;
                        bdDetalle.CodAlmacen = sapDetalle.CodAlmacen;
                        bdDetalle.CodProyecto = sapDetalle.CodProyecto;
                        bdDetalle.CodCentroCosto = sapDetalle.CodCentroCosto;
                        bdDetalle.CodProveedor = sapDetalle.CodProveedor;

                        bdSolicitudCompra.Detalle.Add(bdDetalle);
                    }

                }

                return bdSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
