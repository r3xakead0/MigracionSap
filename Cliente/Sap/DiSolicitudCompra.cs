using System;
using BE = MigracionSap.Cliente.Sap.Entidades;
//using SAPbobsCOM;

namespace MigracionSap.Cliente.Sap
{
    public class DiSolicitudCompra
    {

        private Company oCompany = null;

        public DiSolicitudCompra(Company company)
        {
            oCompany = company;
        }

        public string Enviar(BE.SolicitudCompra beSolicitudCompra, out int errCode, out string errMessage)
        {
            string docEntry = "";

            int errCod = 0;
            string errMsg = "";

            try
            {
                /*
                Documents oSolicitudCompra = oCompany.GetBusinessObject(BoObjectTypes.oPurchaseRequest);

                oSolicitudCompra.Series = beSolicitudCompra.Serie;

                if (beSolicitudCompra.Tipo.Equals('I'))
                    oSolicitudCompra.DocType = BoDocumentTypes.dDocument_Items;
                else if (beSolicitudCompra.Tipo.Equals('S'))
                    oSolicitudCompra.DocType = BoDocumentTypes.dDocument_Service;

                oSolicitudCompra.DocDate = beSolicitudCompra.FechaContable;
                oSolicitudCompra.TaxDate = beSolicitudCompra.FechaContable;
                oSolicitudCompra.DocDueDate = beSolicitudCompra.FechaCreacion;

                oSolicitudCompra.ReqType = 12;
                //oSolicitudCompra.Requester = "solpeceh";
                //oSolicitudCompra.RequesterName = beSolicitudCompra.Usuario;
                oSolicitudCompra.Requester = beSolicitudCompra.Usuario;
                oSolicitudCompra.RequriedDate = beSolicitudCompra.FechaNecesita;
                oSolicitudCompra.RequesterBranch = beSolicitudCompra.IdSucursal;
                oSolicitudCompra.RequesterDepartment = beSolicitudCompra.IdArea;

                oSolicitudCompra.Comments = beSolicitudCompra.Comentario;

                int linea = 0;

                if (beSolicitudCompra.Tipo.Equals('I'))
                {
                    foreach (var beSolicitudCompraDetalle in beSolicitudCompra.Detalle)
                    {
                        if (linea > 0)
                            oSolicitudCompra.Lines.Add();

                        oSolicitudCompra.Lines.ItemCode = beSolicitudCompraDetalle.Codigo;

                        oSolicitudCompra.Lines.ItemDescription = beSolicitudCompraDetalle.Descripcion;
                        oSolicitudCompra.Lines.Quantity = beSolicitudCompraDetalle.Cantidad;

                        //oEntradaAlmacen.Lines.Price = beEntradaAlmacenDetalle.Precio;
                        //oEntradaAlmacen.Lines.UnitPrice = beEntradaAlmacenDetalle.Precio;

                        //oEntradaAlmacen.Lines.TaxCode = beEntradaAlmacenDetalle.CodImpuesto;
                        //oEntradaAlmacen.Lines.Currency = beEntradaAlmacenDetalle.CodMoneda;
                        oSolicitudCompra.Lines.RequiredDate = beSolicitudCompra.FechaNecesita;
                        oSolicitudCompra.Lines.WarehouseCode = beSolicitudCompraDetalle.CodAlmacen;

                        //oEntradaAlmacen.Lines.AccountCode = beEntradaAlmacenDetalle.CodCuentaContable;

                        oSolicitudCompra.Lines.CostingCode = beSolicitudCompraDetalle.CodCentroCosto;
                        //oEntradaAlmacen.Lines.ProjectCode = beEntradaAlmacenDetalle.CodProyecto;

                        linea++;
                    }
                }
                else if (beSolicitudCompra.Tipo.Equals('S'))
                {
                    foreach (var beSolicitudCompraDetalle in beSolicitudCompra.Detalle)
                    {
                        if (linea > 0)
                            oSolicitudCompra.Lines.Add();

                        oSolicitudCompra.Lines.UserFields.Fields.Item("U_EXX_SERCOMPR").Value = beSolicitudCompraDetalle.Codigo;

                        oSolicitudCompra.Lines.ItemDescription = beSolicitudCompraDetalle.Descripcion;
                        oSolicitudCompra.Lines.Quantity = beSolicitudCompraDetalle.Cantidad;

                        //oEntradaAlmacen.Lines.Price = beEntradaAlmacenDetalle.Precio;
                        //oEntradaAlmacen.Lines.UnitPrice = beEntradaAlmacenDetalle.Precio;

                        //oEntradaAlmacen.Lines.TaxCode = beEntradaAlmacenDetalle.CodImpuesto;
                        //oEntradaAlmacen.Lines.Currency = beEntradaAlmacenDetalle.CodMoneda;
                        oSolicitudCompra.Lines.RequiredDate = beSolicitudCompra.FechaNecesita;
                        //oSolicitudCompra.Lines.WarehouseCode = beSolicitudCompraDetalle.CodAlmacen;

                        //oEntradaAlmacen.Lines.AccountCode = beEntradaAlmacenDetalle.CodCuentaContable;

                        oSolicitudCompra.Lines.CostingCode = beSolicitudCompraDetalle.CodCentroCosto;
                        //oEntradaAlmacen.Lines.ProjectCode = beEntradaAlmacenDetalle.CodProyecto;

                        linea++;
                    }
                }

                int retCode = oSolicitudCompra.Add();
                if (retCode == 0)
                    docEntry = oCompany.GetNewObjectKey();
                else
                    oCompany.GetLastError(out errCod, out errMsg);
                */

                errCode = errCod;
                errMessage = errMsg;

                return docEntry;
                //return new Random().Next(1000,9999).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
