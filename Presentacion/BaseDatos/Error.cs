using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class Error
    {


        public List<BE.Error> Listar(int idTipoDocumento, int idDocumento)
        {
            var lstError = new List<BE.Error>();
            try
            {

                string sp = "SpTbErrorListar";
                int idDoc = 0;
                var bdTipoDocumento = new TipoDocumento();

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", idTipoDocumento));
                    cmd.Parameters.Add(new SqlParameter("@IDDOCUMENTO", idDocumento));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beError = new BE.Error();

                        beError.Id = int.Parse(reader["idError"].ToString());

                        idDoc = int.Parse(reader["idTipoDocumento"].ToString());
                        beError.Documento = bdTipoDocumento.Obtener(idDoc);

                        beError.IdDocumento = int.Parse(reader["idDocumento"].ToString());
                        beError.Mensaje = reader["Mensaje"].ToString();

                        lstError.Add(beError);
                    }

                    cnn.Close();
                }
                   
                return lstError;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(int idTipoDocumento, int idDocumento, string mensaje)
        {
            try
            {
                string sp = "SpTbErrorInsertar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    int id = 0;

                    cmd.Parameters.Add(new SqlParameter("@IDERROR", id));
                    cmd.Parameters["@IDERROR"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", idTipoDocumento));
                    cmd.Parameters.Add(new SqlParameter("@IDDOCUMENTO", idDocumento));
                    cmd.Parameters.Add(new SqlParameter("@MENSAJE", mensaje));

                    rowsAffected = cmd.ExecuteNonQuery();
                    id = int.Parse(cmd.Parameters["@IDERROR"].Value.ToString());
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Error beError)
        {
            try
            {
                string sp = "SpTbErrorInsertar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDERROR", beError.Id));
                    cmd.Parameters["@IDERROR"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", beError.Documento.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDDOCUMENTO", beError.IdDocumento));
                    cmd.Parameters.Add(new SqlParameter("@MENSAJE", beError.Mensaje));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beError.Id = int.Parse(cmd.Parameters["@IDERROR"].Value.ToString());
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
