using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using JS = MigracionSap.Cliente.ServicioWeb.Json;
using System.Configuration;

namespace MigracionSap.Cliente.ServicioWeb
{
    public class WsEntrada
    {
        private string endPoint = ConfigurationManager.AppSettings["wsEntrada"].ToString();

        public WsEntrada()
        {
            
        }

        public List<JS.EntradaAlmacen> Obtener(DateTime fechaHora, int idEmpresa)
        {
            var lstEntradaAlmacen = new List<JS.EntradaAlmacen>();

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

                        var objEntradaAlmacen = new JS.EntradaAlmacen();

                        objEntradaAlmacen.docEntryOrden = propCab.Value["docEntryOrden"].ToString();
                        objEntradaAlmacen.comentario = propCab.Value["comentario"].ToString();
                        objEntradaAlmacen.usuario = propCab.Value["usuario"].ToString();
                        objEntradaAlmacen.total = propCab.Value["total"].ToString();
                        objEntradaAlmacen.FechaContable = propCab.Value["FechaContable"].ToString();
                        objEntradaAlmacen.FechaCreacion = propCab.Value["FechaCreacion"].ToString();

                        var jsonDetalle = propCab.Value["detalle"].ToString();
                        JObject joDet = JObject.Parse(jsonDetalle);
                        foreach (JToken jtDet in joDet.Children())
                        {
                            var propDet = jtDet as JProperty;

                            var objEntradaAlmacenDetalle = new JS.EntradaAlmacenDetalle();

                            objEntradaAlmacenDetalle.codArticulo = propDet.Value["codArticulo"].ToString();
                            objEntradaAlmacenDetalle.descripcion = propDet.Value["descripcion"].ToString();
                            objEntradaAlmacenDetalle.cantidad = propDet.Value["cantidad"].ToString();
                            objEntradaAlmacenDetalle.codAlmacen = propDet.Value["codAlmacen"].ToString();
                            objEntradaAlmacenDetalle.codImpuesto = propDet.Value["codImpuesto"].ToString();
                            objEntradaAlmacenDetalle.codCentroCosto = propDet.Value["codCentroCosto"].ToString();

                            objEntradaAlmacen.detalle.Add(objEntradaAlmacenDetalle);
                        }

                        lstEntradaAlmacen.Add(objEntradaAlmacen);
                    }
                }

                return lstEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
