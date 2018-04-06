using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class SalidaAlmacen
    {

        public BE.SalidaAlmacen Obtener(int idSalidaAlmacen, bool detalle = true)
        {
            BE.SalidaAlmacen beSalidaAlmacen = null;
            try
            {

                string sp = "SpTbSalidaAlmacenObtener";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACEN", idSalidaAlmacen));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beSalidaAlmacen = new BE.SalidaAlmacen();

                        beSalidaAlmacen.IdSalidaAlmacen = int.Parse(reader["idSalidaAlmacen"].ToString());

                        int idEmpresa = int.Parse(reader["idEmpresa"].ToString());
                        beSalidaAlmacen.Empresa = new Empresa().Obtener(idEmpresa);

                        int idTipoDocumento = int.Parse(reader["idTipoDocumento"].ToString());
                        beSalidaAlmacen.TipoDocumento = new TipoDocumento().Obtener(idTipoDocumento);

                        beSalidaAlmacen.Serie = int.Parse(reader["serie"].ToString());
                        beSalidaAlmacen.FechaContable = DateTime.Parse(reader["fechaContable"].ToString());
                        beSalidaAlmacen.Comentario = reader["comentario"].ToString();
                        beSalidaAlmacen.FechaCreacion = DateTime.Parse(reader["fechaCreacion"].ToString());
                        beSalidaAlmacen.Total = double.Parse(reader["total"].ToString());
                        beSalidaAlmacen.Usuario = reader["usuario"].ToString();
                        beSalidaAlmacen.CodSap = int.Parse(reader["codSap"].ToString());

                        if (detalle)
                            beSalidaAlmacen.Detalle = this.Detalle(idSalidaAlmacen);

                    }

                    cnn.Close();
                }

                return beSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.SalidaAlmacenDetalle> Detalle(int idSalidaAlmacen)
        {
            var lstSalidaAlmacenDetalle = new List<BE.SalidaAlmacenDetalle>();
            try
            {

                string sp = "SpTbSalidaAlmacenDetalleListar";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACEN", idSalidaAlmacen));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beSalidaAlmacenDetalle = new BE.SalidaAlmacenDetalle();

                        beSalidaAlmacenDetalle.IdSalidaAlmacenDetalle = int.Parse(reader["idSalidaAlmacenDetalle"].ToString());
                        beSalidaAlmacenDetalle.IdSalidaAlmacen = int.Parse(reader["idSalidaAlmacen"].ToString());
                        beSalidaAlmacenDetalle.NroLinea = int.Parse(reader["nroLinea"].ToString());
                        beSalidaAlmacenDetalle.Codigo = reader["codArticulo"].ToString();
                        beSalidaAlmacenDetalle.Descripcion = reader["dscArticulo"].ToString();
                        beSalidaAlmacenDetalle.Cantidad = double.Parse(reader["cantidad"].ToString());
                        beSalidaAlmacenDetalle.CodAlmacen = reader["codAlmacen"].ToString();
                        beSalidaAlmacenDetalle.CodImpuesto = reader["codImpuesto"].ToString();
                        beSalidaAlmacenDetalle.CodCuentaContable = reader["codCuentaContable"].ToString();
                        beSalidaAlmacenDetalle.CodProyecto = reader["codProyecto"].ToString();
                        beSalidaAlmacenDetalle.CodCentroCosto = reader["codCentroCosto"].ToString();

                        lstSalidaAlmacenDetalle.Add(beSalidaAlmacenDetalle);
                    }

                    cnn.Close();
                }

                return lstSalidaAlmacenDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.SalidaAlmacen beSalidaAlmacen)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;

                string spCab = "SpTbSalidaAlmacenInsertar";
                string spDet = "SpTbSalidaAlmacenDetalleInsertar";

                using (cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    cmd = new SqlCommand(spCab, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACEN", beSalidaAlmacen.IdSalidaAlmacen));
                    cmd.Parameters["@IDSALIDAALMACEN"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beSalidaAlmacen.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beSalidaAlmacen.TipoDocumento.Id));
                    cmd.Parameters.Add(new SqlParameter("@SERIE", beSalidaAlmacen.Serie));
                    cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beSalidaAlmacen.FechaContable));
                    cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beSalidaAlmacen.Comentario));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beSalidaAlmacen.FechaCreacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTAL", beSalidaAlmacen.Total));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beSalidaAlmacen.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@CODSAP", beSalidaAlmacen.CodSap));

                    rowsAffected += cmd.ExecuteNonQuery();

                    int idSalidaAlmacen = int.Parse(cmd.Parameters["@IDSALIDAALMACEN"].Value.ToString());
                    beSalidaAlmacen.IdSalidaAlmacen = idSalidaAlmacen;

                    for (int i = 0; i < beSalidaAlmacen.Detalle.Count; i++)
                    {
                        var beSalidaAlmacenDetalle = beSalidaAlmacen.Detalle[i];

                        cmd = new SqlCommand(spDet, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACENDETALLE", beSalidaAlmacenDetalle.IdSalidaAlmacenDetalle));
                        cmd.Parameters["@IDSALIDAALMACENDETALLE"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACEN", idSalidaAlmacen));
                        cmd.Parameters.Add(new SqlParameter("@NROLINEA", beSalidaAlmacenDetalle.NroLinea));
                        cmd.Parameters.Add(new SqlParameter("@CODARTICULO", beSalidaAlmacenDetalle.Codigo));
                        cmd.Parameters.Add(new SqlParameter("@DSCARTICULO", beSalidaAlmacenDetalle.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@CANTIDAD", beSalidaAlmacenDetalle.Cantidad));
                        cmd.Parameters.Add(new SqlParameter("@CODALMACEN", beSalidaAlmacenDetalle.CodAlmacen));
                        cmd.Parameters.Add(new SqlParameter("@CODIMPUESTO", beSalidaAlmacenDetalle.CodImpuesto));
                        cmd.Parameters.Add(new SqlParameter("@CODCUENTACONTABLE", beSalidaAlmacenDetalle.CodCuentaContable));
                        cmd.Parameters.Add(new SqlParameter("@CODPROYECTO", beSalidaAlmacenDetalle.CodProyecto));
                        cmd.Parameters.Add(new SqlParameter("@CODCENTROCOSTO", beSalidaAlmacenDetalle.CodCentroCosto));

                        rowsAffected += cmd.ExecuteNonQuery();

                        beSalidaAlmacen.Detalle[i].IdSalidaAlmacenDetalle = int.Parse(cmd.Parameters["@IDSALIDAALMACENDETALLE"].Value.ToString());
                        beSalidaAlmacen.Detalle[i].IdSalidaAlmacen = idSalidaAlmacen;
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

        public bool Actualizar(BE.SalidaAlmacen beSalidaAlmacen)
        {
            try
            {
                string sp = "SpTbSalidaAlmacenActualizar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACEN", beSalidaAlmacen.IdSalidaAlmacen));
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beSalidaAlmacen.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beSalidaAlmacen.TipoDocumento.Id));
                    cmd.Parameters.Add(new SqlParameter("@SERIE", beSalidaAlmacen.Serie));
                    cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beSalidaAlmacen.FechaContable));
                    cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beSalidaAlmacen.Comentario));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beSalidaAlmacen.FechaCreacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTAL", beSalidaAlmacen.Total));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beSalidaAlmacen.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@CODSAP", beSalidaAlmacen.CodSap));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
