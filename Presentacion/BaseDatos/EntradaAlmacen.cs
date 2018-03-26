using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion.BaseDatos
{
    public class EntradaAlmacen
    {

        private string stringConnection = "";

        public EntradaAlmacen(string stringConnection)
        {
            this.stringConnection = stringConnection;
        }

        public List<BE.EntradaAlmacen> Listar()
        {
            var lstEntradaAlmacen = new List<BE.EntradaAlmacen>();
            try
            {

                string sp = "SpTbSalidaAlmaceListar";

                using (var cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beEntradaAlmacen = new BE.EntradaAlmacen();

                        beEntradaAlmacen.IdEntradaAlmacen = int.Parse(reader["idEntradaAlmacen"].ToString());
                        beEntradaAlmacen.Serie = reader["serie"].ToString();
                        beEntradaAlmacen.FechaContable = DateTime.Parse(reader["fechaContable"].ToString());
                        beEntradaAlmacen.Comentario = reader["comentario"].ToString(); 
                        beEntradaAlmacen.FechaCreacion = DateTime.Parse(reader["fechaCreacion"].ToString()); 
                        beEntradaAlmacen.Total = double.Parse(reader["total"].ToString()); 
                        beEntradaAlmacen.Usuario = reader["usuario"].ToString();  
                        beEntradaAlmacen.CodSap = int.Parse(reader["codSap"].ToString());
                        beEntradaAlmacen.refSap = reader["refSap"].ToString();

                        lstEntradaAlmacen.Add(beEntradaAlmacen);
                    }

                    cnn.Close();
                }
                   
                return lstEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Insertar(ref List<BE.EntradaAlmacen> lstEntradaAlmacen)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;

                string spCab = "SpTbEntradaAlmacenInsertar";
                string spDet = "SpTbEntradaAlmacenDetalleInsertar";

                using (cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    for (int i = 0; i < lstEntradaAlmacen.Count; i++)
                    {
                        BE.EntradaAlmacen beEntradaAlmacen = lstEntradaAlmacen[i];

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
                        lstEntradaAlmacen[i].IdEntradaAlmacen = idEntradaAlmacen;

                        for (int j = 0; j < lstEntradaAlmacen[i].Detalle.Count; j++)
                        {
                            BE.EntradaAlmacenDetalle beEntradaAlmacenDetalle = lstEntradaAlmacen[i].Detalle[j];

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
                            cmd.Parameters.Add(new SqlParameter("@NROCUENTACONTABLE", beEntradaAlmacenDetalle.NroCuentaContable));
                            cmd.Parameters.Add(new SqlParameter("@CODPROYECTO", beEntradaAlmacenDetalle.CodProyecto));
                            cmd.Parameters.Add(new SqlParameter("@CODCENTROCOSTO", beEntradaAlmacenDetalle.CodCentroCosto));

                            rowsAffected += cmd.ExecuteNonQuery();

                            lstEntradaAlmacen[i].Detalle[j].IdEntradaAlmacenDetalle = int.Parse(cmd.Parameters["@IDENTRADAALMACENDETALLE"].Value.ToString());
                            lstEntradaAlmacen[i].Detalle[j].IdEntradaAlmacen = idEntradaAlmacen;
                        }

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
