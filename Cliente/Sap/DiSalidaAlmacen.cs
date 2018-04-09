using System;
using BE = MigracionSap.Cliente.Sap.Entidades;
//susing SAPbobsCOM;

namespace MigracionSap.Cliente.Sap
{
    public class DiSalidaAlmacen 
    {
        private Company oCompany = null;

        public DiSalidaAlmacen(Company company)
        {
            oCompany = company;
        }

        public string Enviar(BE.SalidaAlmacen beSalidaAlmacen, out int errCode, out string errMessage)
        {
            string docEntry = "";

            int errCod = 0;
            string errMsg = "";

            try
            {
                /*
                Documents oSalidaAlmacen = oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

                oSalidaAlmacen.Series = beSalidaAlmacen.Serie;

                oSalidaAlmacen.DocDate = beSalidaAlmacen.FechaContable;
                oSalidaAlmacen.TaxDate = beSalidaAlmacen.FechaContable;
                oSalidaAlmacen.DocDueDate = beSalidaAlmacen.FechaCreacion;

                oSalidaAlmacen.Comments = beSalidaAlmacen.Comentario;

                oSalidaAlmacen.PaymentGroupCode = -1;

                oSalidaAlmacen.UserFields.Fields.Item("U_EXX_NOMBENEFE").Value = beSalidaAlmacen.Usuario;

                int linea = 0;
                foreach (var beSalidaAlmacenDetalle in beSalidaAlmacen.Detalle)
                {
                    if (linea > 0)
                        oSalidaAlmacen.Lines.Add();

                    oSalidaAlmacen.Lines.ItemCode = beSalidaAlmacenDetalle.Codigo;
                    oSalidaAlmacen.Lines.ItemDescription = beSalidaAlmacenDetalle.Descripcion;
                    oSalidaAlmacen.Lines.Quantity = beSalidaAlmacenDetalle.Cantidad;

                    //oEntradaAlmacen.Lines.Price = beEntradaAlmacenDetalle.Precio;
                    //oEntradaAlmacen.Lines.UnitPrice = beEntradaAlmacenDetalle.Precio;

                    //oEntradaAlmacen.Lines.TaxCode = beEntradaAlmacenDetalle.CodImpuesto;
                    //oEntradaAlmacen.Lines.Currency = beEntradaAlmacenDetalle.CodMoneda;

                    oSalidaAlmacen.Lines.WarehouseCode = beSalidaAlmacenDetalle.CodAlmacen;

                    //oEntradaAlmacen.Lines.AccountCode = beEntradaAlmacenDetalle.CodCuentaContable;

                    oSalidaAlmacen.Lines.CostingCode = beSalidaAlmacenDetalle.CodCentroCosto;
                    //oEntradaAlmacen.Lines.ProjectCode = beEntradaAlmacenDetalle.CodProyecto;

                    linea++;
                }


                int retCode = oSalidaAlmacen.Add();
                if (retCode == 0)
                    docEntry = oCompany.GetNewObjectKey();
                else
                    oCompany.GetLastError(out errCod, out errMsg);

                 */

                errCode = errCod;
                errMessage = errMsg;

                return docEntry;
                //return new Random().Next(1000, 9999).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
