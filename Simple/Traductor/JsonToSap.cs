using System;
using System.Globalization;
using System.Collections.Generic;
using JS = MigracionSap.Simple.ServicioWeb.Json;
using BE = MigracionSap.Simple.Sap.Entidades;

namespace MigracionSap.Simple.Traductor
{
    public class JsonToSap
    {

        private static string formatDate = "yyyy-MM-dd HH:mm:ss";

        private static DateTime ParseStringToDatetime(string dateString)
        {
            return DateTime.ParseExact(dateString, formatDate, CultureInfo.InvariantCulture);
        }

        private static double ParseStringToDouble(string doubleString)
        {
            double doubleReturn = 0.0;

            double doubleOut = 0.0;
            if (double.TryParse(doubleString, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleOut) == true)
                doubleReturn = doubleOut;

            return doubleReturn;
        }

        private static int ParseStringToInt(string intString)
        {
            int intReturn = 0;

            int intOut = 0;
            if (int.TryParse(intString, out intOut) == true)
                intReturn = intOut;

            return intReturn;
        }


        public static BE.SalidaAlmacen SalidaAlmacen(JS.SalidaAlmacen jsSalidaAlmacen)
        {
            BE.SalidaAlmacen beSalidaAlmacen = null;
            try
            {
                if (jsSalidaAlmacen != null)
                {
                    beSalidaAlmacen = new BE.SalidaAlmacen();

                    beSalidaAlmacen.Serie = 0;
                    beSalidaAlmacen.Usuario = jsSalidaAlmacen.usuario;
                    beSalidaAlmacen.Comentario = jsSalidaAlmacen.comentario;
                    beSalidaAlmacen.FechaContable = ParseStringToDatetime(jsSalidaAlmacen.FechaContable);
                    beSalidaAlmacen.FechaCreacion = ParseStringToDatetime(jsSalidaAlmacen.FechaCreacion);
                    beSalidaAlmacen.DocEntry = 0;

                    beSalidaAlmacen.Detalle = new List<BE.SalidaAlmacenDetalle>();

                    int nroLinea = 1;
                    foreach (var jsDetalle in jsSalidaAlmacen.detalle)
                    {
                        var beDetalle = new BE.SalidaAlmacenDetalle();

                        beDetalle.NroLinea = nroLinea;
                        beDetalle.Codigo = jsDetalle.codArticulo;
                        beDetalle.Descripcion = jsDetalle.descripcion;
                        beDetalle.Cantidad = ParseStringToDouble(jsDetalle.cantidad);
                        beDetalle.Precio = 0.0;
                        beDetalle.CodAlmacen = jsDetalle.codAlmacen;
                        beDetalle.CodImpuesto = jsDetalle.codImpuesto;
                        beDetalle.CodMoneda = "";
                        beDetalle.CodCuentaContable = "";
                        beDetalle.CodProyecto = "";
                        beDetalle.CodCentroCosto = jsDetalle.codCentroCosto;

                        beSalidaAlmacen.Detalle.Add(beDetalle);

                        nroLinea++;
                    }
                    
                }

                return beSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BE.EntradaAlmacen EntradaAlmacen(JS.EntradaAlmacen jsEntradaAlmacen)
        {
            BE.EntradaAlmacen beEntradaAlmacen = null;
            try
            {
                if (jsEntradaAlmacen != null)
                {
                    beEntradaAlmacen = new BE.EntradaAlmacen();

                    beEntradaAlmacen.Serie = 0;
                    beEntradaAlmacen.Usuario = jsEntradaAlmacen.usuario;
                    beEntradaAlmacen.Comentario = jsEntradaAlmacen.comentario;
                    beEntradaAlmacen.FechaContable = ParseStringToDatetime(jsEntradaAlmacen.FechaContable);
                    beEntradaAlmacen.FechaCreacion = ParseStringToDatetime(jsEntradaAlmacen.FechaCreacion);
                    beEntradaAlmacen.DocEntry = 0;
                    beEntradaAlmacen.refSap = jsEntradaAlmacen.docEntryOrden;

                    beEntradaAlmacen.Detalle = new List<BE.EntradaAlmacenDetalle>();

                    int nroLinea = 1;
                    foreach (var jsDetalle in jsEntradaAlmacen.detalle)
                    {
                        var beDetalle = new BE.EntradaAlmacenDetalle();

                        beDetalle.NroLinea = nroLinea;
                        beDetalle.Codigo = jsDetalle.codArticulo;
                        beDetalle.Descripcion = jsDetalle.descripcion;
                        beDetalle.Cantidad = ParseStringToDouble(jsDetalle.cantidad);
                        beDetalle.Precio = 0.0;
                        beDetalle.CodAlmacen = jsDetalle.codAlmacen;
                        beDetalle.CodImpuesto = jsDetalle.codImpuesto;
                        beDetalle.CodMoneda = "";
                        beDetalle.CodCuentaContable = "";
                        beDetalle.CodProyecto = "";
                        beDetalle.CodCentroCosto = jsDetalle.codCentroCosto;

                        beEntradaAlmacen.Detalle.Add(beDetalle);

                        nroLinea++;
                    }

                }

                return beEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static BE.SolicitudCompra SolicitudCompra(JS.SolicitudCompra jsSolicitudCompra)
        {
            BE.SolicitudCompra beSolicitudCompra = null;
            try
            {
                if (jsSolicitudCompra != null)
                {
                    beSolicitudCompra = new BE.SolicitudCompra();

                    beSolicitudCompra.Serie = 0;
                    beSolicitudCompra.Tipo = char.Parse(jsSolicitudCompra.tipo);
                    beSolicitudCompra.Usuario = jsSolicitudCompra.usuario;
                    beSolicitudCompra.Comentario = jsSolicitudCompra.comentario;
                    beSolicitudCompra.FechaContable = ParseStringToDatetime(jsSolicitudCompra.FechaContable);
                    beSolicitudCompra.FechaCreacion = ParseStringToDatetime(jsSolicitudCompra.FechaCreacion);
                    beSolicitudCompra.FechaNecesita = ParseStringToDatetime(jsSolicitudCompra.FechaNecesita);
                    beSolicitudCompra.IdSucursal = ParseStringToInt(jsSolicitudCompra.idSucursal);
                    beSolicitudCompra.IdArea = ParseStringToInt(jsSolicitudCompra.idArea);
                    beSolicitudCompra.DocEntry = 0;

                    beSolicitudCompra.Detalle = new List<BE.SolicitudCompraDetalle>();

                    int nroLinea = 1;
                    foreach (var jsDetalle in jsSolicitudCompra.items)
                    {
                        var beDetalle = new BE.SolicitudCompraDetalle();

                        beDetalle.NroLinea = nroLinea;
                        beDetalle.Codigo = jsDetalle.codArticulo;
                        beDetalle.Descripcion = jsDetalle.descripcion;
                        beDetalle.Cantidad = ParseStringToDouble(jsDetalle.cantidad);
                        beDetalle.Precio = 0.0;
                        beDetalle.CodAlmacen = jsDetalle.codAlmacen;
                        beDetalle.CodProyecto = "";
                        beDetalle.CodCentroCosto = jsDetalle.codCentroCosto;
                        beDetalle.CodProveedor = jsDetalle.codProveedor;

                        beSolicitudCompra.Detalle.Add(beDetalle);

                        nroLinea++;
                    }

                }

                return beSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
