using System;
using BE = MigracionSap.Cliente.Sap.Entidades;
using SAPbobsCOM;

namespace MigracionSap.Cliente.Sap
{
    public class DiEntradaAlmacen 
    {
        private Company oCompany = null;

        public DiEntradaAlmacen(Company company)
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
                Documents oEntradaAlmacen = oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);

                oEntradaAlmacen.Series = beEntradaAlmacen.Serie;

                oEntradaAlmacen.DocDate = beEntradaAlmacen.FechaContable;
                oEntradaAlmacen.TaxDate = beEntradaAlmacen.FechaContable;
                oEntradaAlmacen.DocDueDate = beEntradaAlmacen.FechaCreacion;

                oEntradaAlmacen.Comments = beEntradaAlmacen.Comentario;

                oEntradaAlmacen.PaymentGroupCode = -1;

                oEntradaAlmacen.UserFields.Fields.Item("U_EXX_NOMBENEFE").Value = beEntradaAlmacen.Usuario;

                int linea = 0;
                foreach (var beEntradaAlmacenDetalle in beEntradaAlmacen.Detalle)
                {
                    if (linea > 0)
                        oEntradaAlmacen.Add();

                    oEntradaAlmacen.Lines.ItemCode = beEntradaAlmacenDetalle.Codigo;
                    oEntradaAlmacen.Lines.ItemDescription = beEntradaAlmacenDetalle.Descripcion;
                    oEntradaAlmacen.Lines.Quantity = beEntradaAlmacenDetalle.Cantidad;

                    //oEntradaAlmacen.Lines.Price = beEntradaAlmacenDetalle.Precio;
                    //oEntradaAlmacen.Lines.UnitPrice = beEntradaAlmacenDetalle.Precio;

                    //oEntradaAlmacen.Lines.TaxCode = beEntradaAlmacenDetalle.CodImpuesto;
                    //oEntradaAlmacen.Lines.Currency = beEntradaAlmacenDetalle.CodMoneda;

                    oEntradaAlmacen.Lines.WarehouseCode = beEntradaAlmacenDetalle.CodAlmacen;

                    //oEntradaAlmacen.Lines.AccountCode = beEntradaAlmacenDetalle.CodCuentaContable;

                    oEntradaAlmacen.Lines.CostingCode = beEntradaAlmacenDetalle.CodCentroCosto;
                    //oEntradaAlmacen.Lines.ProjectCode = beEntradaAlmacenDetalle.CodProyecto;

                    linea++;
                }


                int retCode = oEntradaAlmacen.Add();
                if (retCode == 0)
                    docEntry = oCompany.GetNewObjectKey();
                else
                    oCompany.GetLastError(out errCod, out errMsg);

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
