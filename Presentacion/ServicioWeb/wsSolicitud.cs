﻿using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using JS = MigracionSap.Presentacion.ServicioWeb.Json;

namespace MigracionSap.Presentacion.ServicioWeb
{
    public class wsSolicitud
    {

        private string endPoint = "";

        public wsSolicitud()
        {
            this.endPoint = "https://sap-solpe.herokuapp.com/php/ws_solicitud.php";
        }

        public List<JS.SolicitudCompra> Obtener()
        {
            var lstSolicitudCompra = new List<JS.SolicitudCompra>();

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

                        var objSolicitudCompra = new JS.SolicitudCompra();

                        objSolicitudCompra.idSolicitud = propCab.Value["idSolicitud"].ToString();
                        objSolicitudCompra.serie = propCab.Value["serie"].ToString();
                        objSolicitudCompra.tipo = propCab.Value["tipo"].ToString();
                        objSolicitudCompra.FechaContable = propCab.Value["FechaContable"].ToString();
                        objSolicitudCompra.FechaNecesita = propCab.Value["FechaNecesita"].ToString();
                        objSolicitudCompra.FechaCreacion = propCab.Value["FechaCreacion"].ToString();
                        objSolicitudCompra.comentario = propCab.Value["comentario"].ToString();
                        objSolicitudCompra.usuario = propCab.Value["usuario"].ToString();
                        objSolicitudCompra.idSucursal = propCab.Value["idSucursal"].ToString();
                        objSolicitudCompra.idArea = propCab.Value["idArea"].ToString();

                        var jsonDetalle = propCab.Value["items"].ToString();
                        JObject joDet = JObject.Parse(jsonDetalle);
                        foreach (JToken jtDet in joDet.Children())
                        {
                            var propDet = jtDet as JProperty;

                            var objobjSolicitudCompraDetalle = new JS.SolicitudCompraDetalle();

                            objobjSolicitudCompraDetalle.id_item_solpe = propDet.Value["id_item_solpe"].ToString();
                            objobjSolicitudCompraDetalle.id_solpe = propDet.Value["id_solpe"].ToString();
                            objobjSolicitudCompraDetalle.codArticulo = propDet.Value["codArticulo"].ToString();
                            objobjSolicitudCompraDetalle.descripcion = propDet.Value["descripcion"].ToString();
                            objobjSolicitudCompraDetalle.cantidad = propDet.Value["cantidad"].ToString();
                            objobjSolicitudCompraDetalle.codAlmacen = propDet.Value["codAlmacen"].ToString();
                            objobjSolicitudCompraDetalle.codCentroCosto = propDet.Value["codCentroCosto"].ToString();
                            objobjSolicitudCompraDetalle.codProveedor = propDet.Value["codProveedor"].ToString();

                            objSolicitudCompra.items.Add(objobjSolicitudCompraDetalle);
                        }

                        lstSolicitudCompra.Add(objSolicitudCompra);
                    }
                }

                return lstSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}