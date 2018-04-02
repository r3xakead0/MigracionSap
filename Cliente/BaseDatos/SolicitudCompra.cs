using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class SolicitudCompra
    {

        public bool Insertar(ref BE.SolicitudCompra beSolicitudCompra)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;

                string spCab = "SpTbSolicitudCompraInsertar";
                string spDet = "SpTbSolicitudCompraDetalleInsertar";

                using (cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    cmd = new SqlCommand(spCab, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDSOLICITUDCOMPRA", beSolicitudCompra.IdSolicitudCompra));
                    cmd.Parameters["@IDSOLICITUDCOMPRA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@SERIE", beSolicitudCompra.Serie));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", beSolicitudCompra.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beSolicitudCompra.FechaContable));
                    cmd.Parameters.Add(new SqlParameter("@FECHANECESITA", beSolicitudCompra.FechaNecesita));
                    cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beSolicitudCompra.Comentario));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beSolicitudCompra.FechaCreacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTAL", beSolicitudCompra.Total));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beSolicitudCompra.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@CODSAP", beSolicitudCompra.CodSap));

                    rowsAffected += cmd.ExecuteNonQuery();

                    int idSolicitudCompra = int.Parse(cmd.Parameters["@IDSOLICITUDCOMPRA"].Value.ToString());
                    beSolicitudCompra.IdSolicitudCompra = idSolicitudCompra;

                    for (int i = 0; i < beSolicitudCompra.Detalle.Count; i++)
                    {
                        var beSolicitudCompraDetalle = beSolicitudCompra.Detalle[i];

                        cmd = new SqlCommand(spDet, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDSOLICITUDCOMPRADETALLE", beSolicitudCompraDetalle.IdSolicitudCompraDetalle));
                        cmd.Parameters["@IDSOLICITUDCOMPRADETALLE"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDSOLICITUDCOMPRA", idSolicitudCompra));
                        cmd.Parameters.Add(new SqlParameter("@NROLINEA", beSolicitudCompraDetalle.NroLinea));
                        cmd.Parameters.Add(new SqlParameter("@CODIGO", beSolicitudCompraDetalle.Codigo));
                        cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beSolicitudCompraDetalle.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@CANTIDAD", beSolicitudCompraDetalle.Cantidad));
                        cmd.Parameters.Add(new SqlParameter("@CODALMACEN", beSolicitudCompraDetalle.CodAlmacen));
                        cmd.Parameters.Add(new SqlParameter("@CODCENTROCOSTO", beSolicitudCompraDetalle.CodCentroCosto));
                        cmd.Parameters.Add(new SqlParameter("@CODPROVEEDOR", beSolicitudCompraDetalle.CodProveedor));

                        rowsAffected += cmd.ExecuteNonQuery();

                        beSolicitudCompra.Detalle[i].IdSolicitudCompraDetalle = int.Parse(cmd.Parameters["@IDSOLICITUDCOMPRADETALLE"].Value.ToString());
                        beSolicitudCompra.Detalle[i].IdSolicitudCompra = idSolicitudCompra;
                    }

                    if (tns != null)
                        tns.Commit();

                    cnn.Close();
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }
    }
}
