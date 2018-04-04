using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class TipoDocumento
    {

        public BE.TipoDocumento Obtener(int id)
        {
            BE.TipoDocumento beTipoDocumento = null;
            try
            {

                string sp = "SpTbTipoDocumentoObtener";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beTipoDocumento = new BE.TipoDocumento();

                        beTipoDocumento.Id = int.Parse(reader["idTipoDocumento"].ToString());
                        beTipoDocumento.IdObjectoSap = int.Parse(reader["IdObjectoSap"].ToString());
                        beTipoDocumento.Nombre = reader["nombre"].ToString();
                        beTipoDocumento.Descripcion = reader["descripcion"].ToString();

                    }

                    cnn.Close();
                }

                return beTipoDocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
