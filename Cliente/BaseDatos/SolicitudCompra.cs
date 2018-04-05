using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class SolicitudCompra
    {

        public BE.SolicitudCompra Obtener(int idSolicitudCompra, bool detalle = true)
        {
            BE.SolicitudCompra beSolicitudCompra = null;
            try
            {

                string sp = "SpTbSolicitudCompraObtener";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSOLICITUDCOMPRA", idSolicitudCompra));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beSolicitudCompra = new BE.SolicitudCompra();

                        int idEmpresa = int.Parse(reader["idEmpresa"].ToString());
                        beSolicitudCompra.Empresa = new Empresa().Obtener(idEmpresa);

                        int idTipoDocumento = int.Parse(reader["idTipoDocumento"].ToString());
                        beSolicitudCompra.TipoDocumento = new TipoDocumento().Obtener(idTipoDocumento);

                        beSolicitudCompra.IdSolicitudCompra = int.Parse(reader["idSolicitudCompra"].ToString());
                        beSolicitudCompra.Serie = int.Parse(reader["serie"].ToString());
                        beSolicitudCompra.Tipo = char.Parse(reader["idSolicitudCompra"].ToString());
                        beSolicitudCompra.FechaContable = DateTime.Parse(reader["fechaContable"].ToString());
                        beSolicitudCompra.FechaNecesita = DateTime.Parse(reader["fechaNecesita"].ToString());
                        beSolicitudCompra.Comentario = reader["comentario"].ToString();
                        beSolicitudCompra.FechaCreacion = DateTime.Parse(reader["fechaCreacion"].ToString());
                        beSolicitudCompra.Total = double.Parse(reader["total"].ToString());
                        beSolicitudCompra.Usuario = reader["usuario"].ToString();
                        beSolicitudCompra.CodSap = int.Parse(reader["codSap"].ToString());

                        if (detalle)
                            beSolicitudCompra.Detalle = this.Detalle(idSolicitudCompra);

                    }

                    cnn.Close();
                }

                return beSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.SolicitudCompraDetalle> Detalle(int idSolicitudCompra)
        {
            var lstSolicitudCompraDetalle = new List<BE.SolicitudCompraDetalle>();
            try
            {

                string sp = "SpTbSolicitudCompraDetalleListar";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSOLICITUDCOMPRA", idSolicitudCompra));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beSolicitudCompraDetalle = new BE.SolicitudCompraDetalle();

                        beSolicitudCompraDetalle.IdSolicitudCompraDetalle = int.Parse(reader["idSolicitudCompraDetalle"].ToString());
                        beSolicitudCompraDetalle.IdSolicitudCompra = int.Parse(reader["idSolicitudCompra"].ToString());
                        beSolicitudCompraDetalle.NroLinea = int.Parse(reader["nroLinea"].ToString());
                        beSolicitudCompraDetalle.Codigo = reader["codigo"].ToString();
                        beSolicitudCompraDetalle.Descripcion = reader["descripcion"].ToString();
                        beSolicitudCompraDetalle.Cantidad = double.Parse(reader["cantidad"].ToString());
                        beSolicitudCompraDetalle.CodAlmacen = reader["codAlmacen"].ToString();
                        //beSolicitudCompraDetalle.CodProyecto = reader["codProyecto"].ToString();
                        beSolicitudCompraDetalle.CodCentroCosto = reader["codCentroCosto"].ToString();
                        beSolicitudCompraDetalle.CodProveedor = reader["CodProveedor"].ToString();

                        lstSolicitudCompraDetalle.Add(beSolicitudCompraDetalle);
                    }

                    cnn.Close();
                }

                return lstSolicitudCompraDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beSolicitudCompra.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beSolicitudCompra.TipoDocumento.Id));
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

        public bool Actualizar(BE.SolicitudCompra beSolicitudCompra)
        {
            try
            {
                string sp = "SpTbSolicitudCompraActualizar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDSOLICITUDCOMPRA", beSolicitudCompra.IdSolicitudCompra));
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beSolicitudCompra.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beSolicitudCompra.TipoDocumento.Id));
                    cmd.Parameters.Add(new SqlParameter("@SERIE", beSolicitudCompra.Serie));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", beSolicitudCompra.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beSolicitudCompra.FechaContable));
                    cmd.Parameters.Add(new SqlParameter("@FECHANECESITA", beSolicitudCompra.FechaNecesita));
                    cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beSolicitudCompra.Comentario));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beSolicitudCompra.FechaCreacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTAL", beSolicitudCompra.Total));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beSolicitudCompra.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@CODSAP", beSolicitudCompra.CodSap));

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
