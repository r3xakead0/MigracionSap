using System;
using SE = MigracionSap.Cliente.Sap.Entidades;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;
using System.Collections.Generic;

namespace MigracionSap.Cliente.Traductor
{
    public class BeToSe
    {

        public static SE.SalidaAlmacen SalidaAlmacen(BE.SalidaAlmacen beSalidaAlmacen)
        {
            SE.SalidaAlmacen seSalidaAlmacen = null;
            try
            {
                if (beSalidaAlmacen != null)
                {
                    seSalidaAlmacen = new SE.SalidaAlmacen();

                    seSalidaAlmacen.Serie = beSalidaAlmacen.Serie;
                    seSalidaAlmacen.Usuario = beSalidaAlmacen.Usuario;
                    seSalidaAlmacen.Comentario = beSalidaAlmacen.Comentario;
                    seSalidaAlmacen.FechaContable = beSalidaAlmacen.FechaContable;
                    seSalidaAlmacen.FechaCreacion = beSalidaAlmacen.FechaCreacion;
                    seSalidaAlmacen.DocEntry = beSalidaAlmacen.CodSap;

                    seSalidaAlmacen.Detalle = new List<SE.SalidaAlmacenDetalle>();

                    foreach (var beDetalle in beSalidaAlmacen.Detalle)
                    {
                        var seDetalle = new SE.SalidaAlmacenDetalle();

                        seDetalle.NroLinea = beDetalle.NroLinea;
                        seDetalle.Codigo = beDetalle.Codigo;
                        seDetalle.Descripcion = beDetalle.Descripcion;
                        seDetalle.Cantidad = beDetalle.Cantidad;
                        seDetalle.CodAlmacen = beDetalle.CodAlmacen;
                        seDetalle.CodImpuesto = beDetalle.CodImpuesto;
                        seDetalle.CodMoneda = beDetalle.CodMoneda;
                        seDetalle.CodCuentaContable = beDetalle.CodCuentaContable;
                        seDetalle.CodProyecto = beDetalle.CodProyecto;
                        seDetalle.CodCentroCosto = beDetalle.CodCentroCosto;

                        seSalidaAlmacen.Detalle.Add(seDetalle);
                    }

                }

                return seSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static SE.EntradaAlmacen EntradaAlmacen(BE.EntradaAlmacen beEntradaAlmacen)
        {
            SE.EntradaAlmacen seEntradaAlmacen = null;
            try
            {
                if (beEntradaAlmacen != null)
                {
                    seEntradaAlmacen = new SE.EntradaAlmacen();

                    seEntradaAlmacen.Serie = beEntradaAlmacen.Serie;
                    seEntradaAlmacen.Usuario = beEntradaAlmacen.Usuario;
                    seEntradaAlmacen.Comentario = beEntradaAlmacen.Comentario;
                    seEntradaAlmacen.FechaContable = beEntradaAlmacen.FechaContable;
                    seEntradaAlmacen.FechaCreacion = beEntradaAlmacen.FechaCreacion;
                    seEntradaAlmacen.DocEntry = beEntradaAlmacen.CodSap;
                    seEntradaAlmacen.refSap = beEntradaAlmacen.refSap;

                    seEntradaAlmacen.Detalle = new List<SE.EntradaAlmacenDetalle>();

                    foreach (var beDetalle in beEntradaAlmacen.Detalle)
                    {
                        var seDetalle = new SE.EntradaAlmacenDetalle();

                        seDetalle.NroLinea = beDetalle.NroLinea;
                        seDetalle.Codigo = beDetalle.Codigo;
                        seDetalle.Descripcion = beDetalle.Descripcion;
                        seDetalle.Cantidad = beDetalle.Cantidad;
                        seDetalle.CodAlmacen = beDetalle.CodAlmacen;
                        seDetalle.CodImpuesto = beDetalle.CodImpuesto;
                        seDetalle.CodMoneda = beDetalle.CodMoneda;
                        seDetalle.CodCuentaContable = beDetalle.CodCuentaContable;
                        seDetalle.CodProyecto = beDetalle.CodProyecto;
                        seDetalle.CodCentroCosto = beDetalle.CodCentroCosto;
                        seDetalle.refLineaSap = beDetalle.refLineaSap;

                        seEntradaAlmacen.Detalle.Add(seDetalle);
                    }

                }

                return seEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static SE.SolicitudCompra SolicitudCompra(BE.SolicitudCompra beSolicitudCompra)
        {
            SE.SolicitudCompra seSolicitudCompra = null;
            try
            {
                if (beSolicitudCompra != null)
                {
                    seSolicitudCompra = new SE.SolicitudCompra();

                    seSolicitudCompra.Serie = beSolicitudCompra.Serie;
                    seSolicitudCompra.Tipo = beSolicitudCompra.Tipo;
                    seSolicitudCompra.Usuario = beSolicitudCompra.Usuario;
                    seSolicitudCompra.Comentario = beSolicitudCompra.Comentario;
                    seSolicitudCompra.FechaContable = beSolicitudCompra.FechaContable;
                    seSolicitudCompra.FechaCreacion = beSolicitudCompra.FechaCreacion;
                    seSolicitudCompra.FechaNecesita = beSolicitudCompra.FechaNecesita;
                    seSolicitudCompra.IdSucursal = beSolicitudCompra.IdSucursal;
                    seSolicitudCompra.IdArea = beSolicitudCompra.IdArea;
                    seSolicitudCompra.DocEntry = beSolicitudCompra.CodSap;

                    seSolicitudCompra.Detalle = new List<SE.SolicitudCompraDetalle>();

                    foreach (var beDetalle in beSolicitudCompra.Detalle)
                    {
                        var seDetalle = new SE.SolicitudCompraDetalle();

                        seDetalle.NroLinea = beDetalle.NroLinea;
                        seDetalle.Codigo = beDetalle.Codigo;
                        seDetalle.Descripcion = beDetalle.Descripcion;
                        seDetalle.Cantidad = beDetalle.Cantidad;
                        seDetalle.CodAlmacen = beDetalle.CodAlmacen;
                        seDetalle.CodProyecto = beDetalle.CodProyecto;
                        seDetalle.CodCentroCosto = beDetalle.CodCentroCosto;
                        seDetalle.CodProveedor = beDetalle.CodProveedor;

                        seSolicitudCompra.Detalle.Add(seDetalle);
                    }

                }

                return seSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
