using System;
using BE = MigracionSap.Simple.Sap.Entidades;
using SAPbobsCOM;

namespace MigracionSap.Simple.Sap
{
    public class DiEntradaAlmacenPorCompra 
    {
        private Company oCompany = null;

        public DiEntradaAlmacenPorCompra(Company company)
        {
            oCompany = company;
        }

        public string Enviar(BE.EntradaAlmacen beEntradaAlmacen, out int errCode, out string errMessage)
        {
            string docEntry = "";

            int errCod = 0;
            string errMsg = "";

            try
            {
                Documents oOrdenCompra = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);

                int docNumOC = int.Parse(beEntradaAlmacen.refSap);
                if(oOrdenCompra.GetByKey(docNumOC))
                {

                    Documents oEntradaAlmacenPorCompra = oCompany.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);

                    oEntradaAlmacenPorCompra.CardCode = oOrdenCompra.CardCode;
                    oEntradaAlmacenPorCompra.CardName = oOrdenCompra.CardName;

                    oEntradaAlmacenPorCompra.Series = beEntradaAlmacen.Serie;

                    oEntradaAlmacenPorCompra.DocDate = beEntradaAlmacen.FechaContable;
                    oEntradaAlmacenPorCompra.TaxDate = beEntradaAlmacen.FechaContable;
                    oEntradaAlmacenPorCompra.DocDueDate = beEntradaAlmacen.FechaCreacion;

                    oEntradaAlmacenPorCompra.Comments = beEntradaAlmacen.Comentario;

                    oEntradaAlmacenPorCompra.PaymentGroupCode = -1;

                    oEntradaAlmacenPorCompra.UserFields.Fields.Item("U_EXX_NOMBENEFE").Value = beEntradaAlmacen.Usuario;

                    int linea = 0;
                    foreach (var beEntradaAlmacenDetalle in beEntradaAlmacen.Detalle)
                    {
                        if (linea > 0)
                            oEntradaAlmacenPorCompra.Lines.Add();

                        oEntradaAlmacenPorCompra.Lines.ItemCode = beEntradaAlmacenDetalle.Codigo;
                        oEntradaAlmacenPorCompra.Lines.ItemDescription = beEntradaAlmacenDetalle.Descripcion;
                        oEntradaAlmacenPorCompra.Lines.Quantity = beEntradaAlmacenDetalle.Cantidad;

                        oEntradaAlmacenPorCompra.Lines.BaseType = int.Parse(oOrdenCompra.DocObjectCodeEx); // If I comment out this and the next two lines the document will add
                        oEntradaAlmacenPorCompra.Lines.BaseEntry = oOrdenCompra.DocEntry;
                        oEntradaAlmacenPorCompra.Lines.BaseLine = beEntradaAlmacenDetalle.refLineaSap;

                        //oEntradaAlmacen.Lines.Price = beEntradaAlmacenDetalle.Precio;
                        //oEntradaAlmacen.Lines.UnitPrice = beEntradaAlmacenDetalle.Precio;

                        //oEntradaAlmacen.Lines.TaxCode = beEntradaAlmacenDetalle.CodImpuesto;
                        //oEntradaAlmacen.Lines.Currency = beEntradaAlmacenDetalle.CodMoneda;

                        oEntradaAlmacenPorCompra.Lines.WarehouseCode = beEntradaAlmacenDetalle.CodAlmacen;

                        //oEntradaAlmacen.Lines.AccountCode = beEntradaAlmacenDetalle.CodCuentaContable;

                        oEntradaAlmacenPorCompra.Lines.CostingCode = beEntradaAlmacenDetalle.CodCentroCosto;
                        //oEntradaAlmacen.Lines.ProjectCode = beEntradaAlmacenDetalle.CodProyecto;

                        linea++;
                    }


                    int retCode = oEntradaAlmacenPorCompra.Add();
                    if (retCode == 0)
                        docEntry = oCompany.GetNewObjectKey();
                    else
                        oCompany.GetLastError(out errCod, out errMsg);

                }
                else
                {
                    errCod = -1;
                    errMsg = "No existe la orden de compra";
                }

                errCode = errCod;
                errMessage = errMsg;

                return docEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
