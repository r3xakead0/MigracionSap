using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class EntradaAlmacen
    {

        public bool Insertar(ref BE.EntradaAlmacen beEntradaAlmacen)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;

                string spCab = "SpTbEntradaAlmacenInsertar";
                string spDet = "SpTbEntradaAlmacenDetalleInsertar";

                using (cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    cmd = new SqlCommand(spCab, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDENTRADAALMACEN", beEntradaAlmacen.IdEntradaAlmacen));
                    cmd.Parameters["@IDENTRADAALMACEN"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@SERIE", beEntradaAlmacen.Serie));
                    cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beEntradaAlmacen.FechaContable));
                    cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beEntradaAlmacen.Comentario));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beEntradaAlmacen.FechaCreacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTAL", beEntradaAlmacen.Total));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beEntradaAlmacen.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@CODSAP", beEntradaAlmacen.CodSap));
                    cmd.Parameters.Add(new SqlParameter("@REFSAP", beEntradaAlmacen.refSap));

                    rowsAffected += cmd.ExecuteNonQuery();

                    int idEntradaAlmacen = int.Parse(cmd.Parameters["@IDENTRADAALMACEN"].Value.ToString());
                    beEntradaAlmacen.IdEntradaAlmacen = idEntradaAlmacen;

                    for (int i = 0; i < beEntradaAlmacen.Detalle.Count; i++)
                    {
                        var beEntradaAlmacenDetalle = beEntradaAlmacen.Detalle[i];

                        cmd = new SqlCommand(spDet, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDENTRADAALMACENDETALLE", beEntradaAlmacenDetalle.IdEntradaAlmacenDetalle));
                        cmd.Parameters["@IDENTRADAALMACENDETALLE"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDENTRADAALMACEN", idEntradaAlmacen));
                        cmd.Parameters.Add(new SqlParameter("@NROLINEA", beEntradaAlmacenDetalle.NroLinea));
                        cmd.Parameters.Add(new SqlParameter("@CODARTICULO", beEntradaAlmacenDetalle.Codigo));
                        cmd.Parameters.Add(new SqlParameter("@DSCARTICULO", beEntradaAlmacenDetalle.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@CANTIDAD", beEntradaAlmacenDetalle.Cantidad));
                        cmd.Parameters.Add(new SqlParameter("@CODALMACEN", beEntradaAlmacenDetalle.CodAlmacen));
                        cmd.Parameters.Add(new SqlParameter("@CODIMPUESTO", beEntradaAlmacenDetalle.CodImpuesto));
                        cmd.Parameters.Add(new SqlParameter("@CODCUENTACONTABLE", beEntradaAlmacenDetalle.CodCuentaContable));
                        cmd.Parameters.Add(new SqlParameter("@CODPROYECTO", beEntradaAlmacenDetalle.CodProyecto));
                        cmd.Parameters.Add(new SqlParameter("@CODCENTROCOSTO", beEntradaAlmacenDetalle.CodCentroCosto));

                        rowsAffected += cmd.ExecuteNonQuery();

                        beEntradaAlmacen.Detalle[i].IdEntradaAlmacenDetalle = int.Parse(cmd.Parameters["@IDENTRADAALMACENDETALLE"].Value.ToString());
                        beEntradaAlmacen.Detalle[i].IdEntradaAlmacen = idEntradaAlmacen;
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
