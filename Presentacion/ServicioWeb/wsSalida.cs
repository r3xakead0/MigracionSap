using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using JS = MigracionSap.Presentacion.ServicioWeb.Json;

namespace MigracionSap.Presentacion.ServicioWeb
{
    public class wsSalida
    {

        private string endPoint = "";

        public wsSalida()
        {
            this.endPoint = "https://sap-solpe.herokuapp.com/php/ws_salida.php";
        }

        public List<JS.SalidaAlmacen> Obtener(DateTime fechaHora, int idEmpresa)
        {
            var lstSalidaAlmacen = new List<JS.SalidaAlmacen>();

            try
            {

                var client = new RestClient(this.endPoint);

                var request = new RestRequest(Method.POST);
                request.AddParameter("datetime", fechaHora.ToString("yyyy-MM-ddTHH:mm:ss"));
                request.AddParameter("sociedad", idEmpresa.ToString());

                var task = client.ExecuteTaskAsync(request);
                task.Wait();

                string jsonCabecera = task.Result.Content;
                JObject joCab = JObject.Parse(jsonCabecera);
                foreach (JToken jtCab in joCab.Children())
                {
                    if (jtCab is JProperty)
                    {
                        var propCab = jtCab as JProperty;

                        var objSalidaAlmacen = new JS.SalidaAlmacen();

                        objSalidaAlmacen.FechaContable = propCab.Value["FechaContable"].ToString();
                        objSalidaAlmacen.comentario = propCab.Value["comentario"].ToString();
                        objSalidaAlmacen.FechaCreacion = propCab.Value["FechaCreacion"].ToString();
                        objSalidaAlmacen.total = propCab.Value["total"].ToString();
                        objSalidaAlmacen.usuario = propCab.Value["usuario"].ToString();

                        var jsonDetalle = propCab.Value["detalle"].ToString();
                        JObject joDet = JObject.Parse(jsonDetalle);
                        foreach (JToken jtDet in joDet.Children())
                        {
                            var propDet = jtDet as JProperty;

                            var objSalidaAlmacenDetalle = new JS.SalidaAlmacenDetalle();

                            objSalidaAlmacenDetalle.codArticulo = propDet.Value["codArticulo"].ToString();
                            objSalidaAlmacenDetalle.descripcion = propDet.Value["descripcion"].ToString();
                            objSalidaAlmacenDetalle.cantidad = propDet.Value["cantidad"].ToString();
                            objSalidaAlmacenDetalle.codAlmacen = propDet.Value["codAlmacen"].ToString();
                            objSalidaAlmacenDetalle.codImpuesto = propDet.Value["codImpuesto"].ToString();
                            objSalidaAlmacenDetalle.codCentroCosto = propDet.Value["codCentroCosto"].ToString();

                            objSalidaAlmacen.detalle.Add(objSalidaAlmacenDetalle);
                        }

                        lstSalidaAlmacen.Add(objSalidaAlmacen);
                    }
                }

                return lstSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
