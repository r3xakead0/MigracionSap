using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class EntradaAlmacen
    {

        public BE.EntradaAlmacen Obtener(int idEntradaAlmacen, bool detalle = true)
        {
            BE.EntradaAlmacen beEntradaAlmacen = null;
            try
            {

                string sp = "SpTbEntradaAlmacenObtener";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDENTRADAALMACEN", idEntradaAlmacen));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beEntradaAlmacen = new BE.EntradaAlmacen();

                        int idEmpresa = int.Parse(reader["idEmpresa"].ToString());
                        beEntradaAlmacen.Empresa = new Empresa().Obtener(idEmpresa);

                        int idTipoDocumento = int.Parse(reader["idTipoDocumento"].ToString());
                        beEntradaAlmacen.TipoDocumento = new TipoDocumento().Obtener(idTipoDocumento);

                        beEntradaAlmacen.IdEntradaAlmacen = int.Parse(reader["idEntradaAlmacen"].ToString());
                        beEntradaAlmacen.Serie = int.Parse(reader["serie"].ToString());
                        beEntradaAlmacen.FechaContable = DateTime.Parse(reader["fechaContable"].ToString());
                        beEntradaAlmacen.Comentario = reader["comentario"].ToString();
                        beEntradaAlmacen.FechaCreacion = DateTime.Parse(reader["fechaCreacion"].ToString());
                        beEntradaAlmacen.Total = double.Parse(reader["total"].ToString());
                        beEntradaAlmacen.Usuario = reader["usuario"].ToString();
                        beEntradaAlmacen.CodSap = int.Parse(reader["codSap"].ToString());
                        beEntradaAlmacen.refSap = int.Parse(reader["refSap"].ToString());

                        if (detalle)
                            beEntradaAlmacen.Detalle = this.Detalle(idEntradaAlmacen);

                    }

                    cnn.Close();
                }

                return beEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.EntradaAlmacenDetalle> Detalle(int idEntradaAlmacen)
        {
            var lstEntradaAlmacenDetalle = new List<BE.EntradaAlmacenDetalle>();
            try
            {

                string sp = "SpTbEntradaAlmacenDetalleListar";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDENTRADAALMACEN", idEntradaAlmacen));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beEntradaAlmacenDetalle = new BE.EntradaAlmacenDetalle();

                        beEntradaAlmacenDetalle.IdEntradaAlmacenDetalle = int.Parse(reader["idEntradaAlmacenDetalle"].ToString());
                        beEntradaAlmacenDetalle.IdEntradaAlmacen = int.Parse(reader["idEntradaAlmacen"].ToString());
                        beEntradaAlmacenDetalle.NroLinea = int.Parse(reader["nroLinea"].ToString());
                        beEntradaAlmacenDetalle.Codigo = reader["codArticulo"].ToString();
                        beEntradaAlmacenDetalle.Descripcion = reader["dscArticulo"].ToString();
                        beEntradaAlmacenDetalle.Cantidad = double.Parse(reader["cantidad"].ToString());
                        beEntradaAlmacenDetalle.CodAlmacen = reader["codAlmacen"].ToString();
                        beEntradaAlmacenDetalle.CodImpuesto = reader["codImpuesto"].ToString();
                        beEntradaAlmacenDetalle.CodCuentaContable = reader["codCuentaContable"].ToString();
                        beEntradaAlmacenDetalle.CodProyecto = reader["codProyecto"].ToString();
                        beEntradaAlmacenDetalle.CodCentroCosto = reader["codCentroCosto"].ToString();
                        beEntradaAlmacenDetalle.refLineaSap = int.Parse(reader["REFLINEASAP"].ToString());

                        lstEntradaAlmacenDetalle.Add(beEntradaAlmacenDetalle);
                    }

                    cnn.Close();
                }

                return lstEntradaAlmacenDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beEntradaAlmacen.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beEntradaAlmacen.TipoDocumento.Id));
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
                        cmd.Parameters.Add(new SqlParameter("@REFLINEASAP", beEntradaAlmacenDetalle.refLineaSap));

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

        public bool Actualizar(BE.EntradaAlmacen beEntradaAlmacen)
        {
            try
            {
                string sp = "SpTbEntradaAlmacenActualizar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDENTRADAALMACEN", beEntradaAlmacen.IdEntradaAlmacen));
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beEntradaAlmacen.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beEntradaAlmacen.TipoDocumento.Id));
                    cmd.Parameters.Add(new SqlParameter("@SERIE", beEntradaAlmacen.Serie));
                    cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beEntradaAlmacen.FechaContable));
                    cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beEntradaAlmacen.Comentario));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beEntradaAlmacen.FechaCreacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTAL", beEntradaAlmacen.Total));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beEntradaAlmacen.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@CODSAP", beEntradaAlmacen.CodSap));
                    cmd.Parameters.Add(new SqlParameter("@REFSAP", beEntradaAlmacen.refSap));

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
