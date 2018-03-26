using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using JS = MigracionSap.Presentacion.ServicioWeb.Json;

namespace MigracionSap.Presentacion.ServicioWeb
{
    public class wsEntrada
    {

        private string endPoint = "";

        public wsEntrada()
        {
            this.endPoint = "https://sap-solpe.herokuapp.com/php/ws_entrada.php";
        }

        public List<JS.EntradaAlmacen> Obtener()
        {
            var lstEntradaAlmacen = new List<JS.EntradaAlmacen>();

            try
            {

                var client = new RestClient(this.endPoint);

                //var request = new RestRequest("resource/{id}", Method.POST);
                //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
                //IRestResponse response = client.Execute(request);

                var task = client.ExecuteTaskAsync(new RestRequest());
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
