using System;
using System.Globalization;
using System.Collections.Generic;
using WE = MigracionSap.Cliente.ServicioWeb.Json;
using SE = MigracionSap.Cliente.Sap.Entidades;

namespace MigracionSap.Cliente.Traductor
{
    public class JsonToSe
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


        public static SE.SalidaAlmacen SalidaAlmacen(WE.SalidaAlmacen weSalidaAlmacen)
        {
            SE.SalidaAlmacen seSalidaAlmacen = null;
            try
            {
                if (weSalidaAlmacen != null)
                {
                    seSalidaAlmacen = new SE.SalidaAlmacen();

                    seSalidaAlmacen.Serie = 0;
                    seSalidaAlmacen.Usuario = weSalidaAlmacen.usuario;
                    seSalidaAlmacen.Comentario = weSalidaAlmacen.comentario;
                    seSalidaAlmacen.FechaContable = ParseStringToDatetime(weSalidaAlmacen.FechaContable);
                    seSalidaAlmacen.FechaCreacion = ParseStringToDatetime(weSalidaAlmacen.FechaCreacion);
                    seSalidaAlmacen.DocEntry = 0;

                    seSalidaAlmacen.Detalle = new List<SE.SalidaAlmacenDetalle>();

                    int nroLinea = 1;
                    foreach (var jsDetalle in weSalidaAlmacen.detalle)
                    {
                        var beDetalle = new SE.SalidaAlmacenDetalle();

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

                        seSalidaAlmacen.Detalle.Add(beDetalle);

                        nroLinea++;
                    }
                    
                }

                return seSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SE.EntradaAlmacen EntradaAlmacen(WE.EntradaAlmacen weEntradaAlmacen)
        {
            SE.EntradaAlmacen seEntradaAlmacen = null;
            try
            {
                if (weEntradaAlmacen != null)
                {
                    seEntradaAlmacen = new SE.EntradaAlmacen();

                    seEntradaAlmacen.Serie = 0;
                    seEntradaAlmacen.Usuario = weEntradaAlmacen.usuario;
                    seEntradaAlmacen.Comentario = weEntradaAlmacen.comentario;
                    seEntradaAlmacen.FechaContable = ParseStringToDatetime(weEntradaAlmacen.FechaContable);
                    seEntradaAlmacen.FechaCreacion = ParseStringToDatetime(weEntradaAlmacen.FechaCreacion);
                    seEntradaAlmacen.DocEntry = 0;
                    seEntradaAlmacen.refSap = int.Parse(weEntradaAlmacen.docEntryOrden);

                    seEntradaAlmacen.Detalle = new List<SE.EntradaAlmacenDetalle>();

                    int nroLinea = 1;
                    foreach (var jsDetalle in weEntradaAlmacen.detalle)
                    {
                        var beDetalle = new SE.EntradaAlmacenDetalle();

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
                        beDetalle.refLineaSap = int.Parse(jsDetalle.lineNumSap);

                        seEntradaAlmacen.Detalle.Add(beDetalle);

                        nroLinea++;
                    }

                }

                return seEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static SE.SolicitudCompra SolicitudCompra(WE.SolicitudCompra wsSolicitudCompra)
        {
            SE.SolicitudCompra seSolicitudCompra = null;
            try
            {
                if (wsSolicitudCompra != null)
                {
                    seSolicitudCompra = new SE.SolicitudCompra();

                    seSolicitudCompra.Serie = 0;
                    seSolicitudCompra.Tipo = char.Parse(wsSolicitudCompra.tipo);
                    seSolicitudCompra.Usuario = wsSolicitudCompra.usuario;
                    seSolicitudCompra.Comentario = wsSolicitudCompra.comentario;
                    seSolicitudCompra.FechaContable = ParseStringToDatetime(wsSolicitudCompra.FechaContable);
                    seSolicitudCompra.FechaCreacion = ParseStringToDatetime(wsSolicitudCompra.FechaCreacion);
                    seSolicitudCompra.FechaNecesita = ParseStringToDatetime(wsSolicitudCompra.FechaNecesita);
                    seSolicitudCompra.IdSucursal = ParseStringToInt(wsSolicitudCompra.idSucursal);
                    seSolicitudCompra.IdArea = ParseStringToInt(wsSolicitudCompra.idArea);
                    seSolicitudCompra.DocEntry = 0;

                    seSolicitudCompra.Detalle = new List<SE.SolicitudCompraDetalle>();

                    int nroLinea = 1;
                    foreach (var jsDetalle in wsSolicitudCompra.items)
                    {
                        var beDetalle = new SE.SolicitudCompraDetalle();

                        beDetalle.NroLinea = nroLinea;
                        beDetalle.Codigo = jsDetalle.codArticulo;
                        beDetalle.Descripcion = jsDetalle.descripcion;
                        beDetalle.Cantidad = ParseStringToDouble(jsDetalle.cantidad);
                        beDetalle.Precio = 0.0;
                        beDetalle.CodAlmacen = jsDetalle.codAlmacen;
                        beDetalle.CodProyecto = "";
                        beDetalle.CodCentroCosto = jsDetalle.codCentroCosto;
                        beDetalle.CodProveedor = jsDetalle.codProveedor;

                        seSolicitudCompra.Detalle.Add(beDetalle);

                        nroLinea++;
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
