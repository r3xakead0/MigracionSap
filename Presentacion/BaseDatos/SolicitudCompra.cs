using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion.BaseDatos
{
    public class SolicitudCompra
    {

        private string stringConnection = "";

        public SolicitudCompra(string stringConnection)
        {
            this.stringConnection = stringConnection;
        }

        public List<BE.SolicitudCompra> Listar()
        {
            var lstSolicitudCompra = new List<BE.SolicitudCompra>();
            try
            {

                string sp = "SpTbSolicitudCompraListar";

                using (var cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beSolicitudCompra = new BE.SolicitudCompra();

                        beSolicitudCompra.IdSolicitudCompra = int.Parse(reader["idSolicitudCompra"].ToString());
                        beSolicitudCompra.Serie = reader["serie"].ToString();
                        beSolicitudCompra.Tipo = char.Parse(reader["tipo"].ToString());
                        beSolicitudCompra.FechaContable = DateTime.Parse(reader["fechaContable"].ToString());
                        beSolicitudCompra.FechaNecesita = DateTime.Parse(reader["fechaNecesita"].ToString());
                        beSolicitudCompra.Comentario = reader["comentario"].ToString(); 
                        beSolicitudCompra.FechaCreacion = DateTime.Parse(reader["fechaCreacion"].ToString()); 
                        beSolicitudCompra.Total = double.Parse(reader["total"].ToString()); 
                        beSolicitudCompra.Usuario = reader["usuario"].ToString();  
                        beSolicitudCompra.CodSap = int.Parse(reader["codSap"].ToString()); 

                        lstSolicitudCompra.Add(beSolicitudCompra);
                    }

                    cnn.Close();
                }
                   
                return lstSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Insertar(ref List<BE.SolicitudCompra> lstSolicitudCompra)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;

                string spCab = "SpTbSolicitudCompraInsertar";
                string spDet = "SpTbSolicitudCompraDetalleInsertar";

                using (cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    for (int i = 0; i < lstSolicitudCompra.Count; i++)
                    {
                        BE.SolicitudCompra beSolicitudCompra = lstSolicitudCompra[i];

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
                        lstSolicitudCompra[i].IdSolicitudCompra = idSolicitudCompra;

                        for (int j = 0; j < lstSolicitudCompra[i].Detalle.Count; j++)
                        {
                            BE.SolicitudCompraDetalle beSolicitudCompraDetalle = lstSolicitudCompra[i].Detalle[j];

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

                            lstSolicitudCompra[i].Detalle[j].IdSolicitudCompraDetalle = int.Parse(cmd.Parameters["@IDSOLICITUDCOMPRADETALLE"].Value.ToString());
                            lstSolicitudCompra[i].Detalle[j].IdSolicitudCompra = idSolicitudCompra;
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
