using System;
using SE = MigracionSap.Cliente.Sap.Entidades;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;
using System.Collections.Generic;

namespace MigracionSap.Cliente.Traductor
{
    public class SeToBe
    {

        public static BE.SalidaAlmacen SalidaAlmacen(SE.SalidaAlmacen seSalidaAlmacen)
        {
            BE.SalidaAlmacen beSalidaAlmacen = null;
            try
            {
                if (seSalidaAlmacen != null)
                {
                    beSalidaAlmacen = new BE.SalidaAlmacen();

                    beSalidaAlmacen.Empresa = null;
                    beSalidaAlmacen.TipoDocumento = null;
                    beSalidaAlmacen.Serie = seSalidaAlmacen.Serie;
                    beSalidaAlmacen.Usuario = seSalidaAlmacen.Usuario;
                    beSalidaAlmacen.Comentario = seSalidaAlmacen.Comentario;
                    beSalidaAlmacen.FechaContable = seSalidaAlmacen.FechaContable;
                    beSalidaAlmacen.FechaCreacion = seSalidaAlmacen.FechaCreacion;
                    beSalidaAlmacen.Total = 0.0;
                    beSalidaAlmacen.CodSap = seSalidaAlmacen.DocEntry;

                    beSalidaAlmacen.Detalle = new List<BE.SalidaAlmacenDetalle>();

                    foreach (var sapDetalle in seSalidaAlmacen.Detalle)
                    {
                        var bdDetalle = new BE.SalidaAlmacenDetalle();

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

                        beSalidaAlmacen.Detalle.Add(bdDetalle);
                    }
                    
                }

                return beSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BE.EntradaAlmacen EntradaAlmacen(SE.EntradaAlmacen sapEntradaAlmacen)
        {
            BE.EntradaAlmacen bdEntradaAlmacen = null;
            try
            {
                if (sapEntradaAlmacen != null)
                {
                    bdEntradaAlmacen = new BE.EntradaAlmacen();

                    bdEntradaAlmacen.Serie = sapEntradaAlmacen.Serie;
                    bdEntradaAlmacen.Usuario = sapEntradaAlmacen.Usuario;
                    bdEntradaAlmacen.Comentario = sapEntradaAlmacen.Comentario;
                    bdEntradaAlmacen.FechaContable = sapEntradaAlmacen.FechaContable;
                    bdEntradaAlmacen.FechaCreacion = sapEntradaAlmacen.FechaCreacion;
                    bdEntradaAlmacen.Total = 0.0;
                    bdEntradaAlmacen.CodSap = sapEntradaAlmacen.DocEntry;
                    bdEntradaAlmacen.refSap = sapEntradaAlmacen.refSap;

                    bdEntradaAlmacen.Detalle = new List<BE.EntradaAlmacenDetalle>();

                    foreach (var sapDetalle in sapEntradaAlmacen.Detalle)
                    {
                        var bdDetalle = new BE.EntradaAlmacenDetalle();

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
                        bdDetalle.refLineaSap = sapDetalle.refLineaSap;

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


        public static BE.SolicitudCompra SolicitudCompra(SE.SolicitudCompra sapSolicitudCompra)
        {
            BE.SolicitudCompra bdSolicitudCompra = null;
            try
            {
                if (sapSolicitudCompra != null)
                {
                    bdSolicitudCompra = new BE.SolicitudCompra();

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

                    bdSolicitudCompra.Detalle = new List<BE.SolicitudCompraDetalle>();

                    foreach (var sapDetalle in sapSolicitudCompra.Detalle)
                    {
                        var bdDetalle = new BE.SolicitudCompraDetalle();

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
