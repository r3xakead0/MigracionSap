using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion.BaseDatos
{
    public class SalidaAlmacen
    {

        private string stringConnection = "";

        public SalidaAlmacen(string stringConnection)
        {
            this.stringConnection = stringConnection;
        }

        public List<BE.SalidaAlmacen> Listar()
        {
            var lstSalidaAlmacen = new List<BE.SalidaAlmacen>();
            try
            {

                string sp = "SpTbSalidaAlmacenListar";

                using (var cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beSalidaAlmacen = new BE.SalidaAlmacen();

                        beSalidaAlmacen.IdSalidaAlmacen = int.Parse(reader["idSalidaAlmacen"].ToString());
                        beSalidaAlmacen.Serie = reader["serie"].ToString();
                        beSalidaAlmacen.FechaContable = DateTime.Parse(reader["fechaContable"].ToString());
                        beSalidaAlmacen.Comentario = reader["comentario"].ToString(); 
                        beSalidaAlmacen.FechaCreacion = DateTime.Parse(reader["fechaCreacion"].ToString()); 
                        beSalidaAlmacen.Total = double.Parse(reader["total"].ToString()); 
                        beSalidaAlmacen.Usuario = reader["usuario"].ToString();  
                        beSalidaAlmacen.CodSap = int.Parse(reader["codSap"].ToString()); 

                        lstSalidaAlmacen.Add(beSalidaAlmacen);
                    }

                    cnn.Close();
                }
                   
                return lstSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Insertar(ref List<BE.SalidaAlmacen> lstSalidaAlmacen)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;

                string spCab = "SpTbSalidaAlmacenInsertar";
                string spDet = "SpTbSalidaAlmacenDetalleInsertar";

                using (cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    for (int i = 0; i < lstSalidaAlmacen.Count; i++)
                    {
                        BE.SalidaAlmacen beSalidaAlmacen = lstSalidaAlmacen[i];

                        cmd = new SqlCommand(spCab, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDSALIDAALMACEN", beSalidaAlmacen.IdSalidaAlmacen));
                        cmd.Parameters["@IDSALIDAALMACEN"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@SERIE", beSalidaAlmacen.Serie));
                        cmd.Parameters.Add(new SqlParameter("@FECHACONTABLE", beSalidaAlmacen.FechaContable));
                        cmd.Parameters.Add(new SqlParameter("@COMENTARIO", beSalidaAlmacen.Comentario));
                        cmd.Parameters.Add(new SqlParameter("@FECHACREACION", beSalidaAlmacen.FechaCreacion));
                        cmd.Parameters.Add(new SqlParameter("@TOTAL", beSalidaAlmacen.Total));
                        cmd.Parameters.Add(new SqlParameter("@USUARIO", beSalidaAlmacen.Usuario));
                        cmd.Parameters.Add(new SqlParameter("@CODSAP", beSalidaAlmacen.CodSap));

                        rowsAffected += cmd.ExecuteNonQuery();

                        int idSalidaAlmacen = int.Parse(cmd.Parameters["@IDSALIDAALMACEN"].Value.ToString());
                        lstSalidaAlmacen[i].IdSalidaAlmacen = idSalidaAlmacen;

                        for (int j = 0; j < lstSalidaAlmacen[i].Detalle.Count; j++)
                        {
                            BE.SalidaAlmacenDetalle beSalidaAlmacenDetalle = lstSalidaAlmacen[i].Detalle[j];

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
                            cmd.Parameters.Add(new SqlParameter("@NROCUENTACONTABLE", beSalidaAlmacenDetalle.NroCuentaContable));
                            cmd.Parameters.Add(new SqlParameter("@CODPROYECTO", beSalidaAlmacenDetalle.CodProyecto));
                            cmd.Parameters.Add(new SqlParameter("@CODCENTROCOSTO", beSalidaAlmacenDetalle.CodCentroCosto));

                            rowsAffected += cmd.ExecuteNonQuery();

                            lstSalidaAlmacen[i].Detalle[j].IdSalidaAlmacenDetalle = int.Parse(cmd.Parameters["@IDSALIDAALMACENDETALLE"].Value.ToString());
                            lstSalidaAlmacen[i].Detalle[j].IdSalidaAlmacen = idSalidaAlmacen;
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
