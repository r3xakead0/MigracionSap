using System;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion.BaseDatos
{
    public class Migracion
    {


        public BE.Configuracion Obtener(BE.Empresa empresa)
        {
            BE.Configuracion beConfiguracion = null;
            try
            {

                string sp = "SpTbConfiguracionObtener";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", empresa.Id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beConfiguracion = new BE.Configuracion();

                        beConfiguracion.Id = int.Parse(reader["IdConfiguracion"].ToString());
                        beConfiguracion.Empresa = empresa;
                        beConfiguracion.Servidor = reader["servidor"].ToString();
                        beConfiguracion.BaseDatos = reader["baseDatos"].ToString();
                        beConfiguracion.TipoBD = int.Parse(reader["tipoBD"].ToString());
                        beConfiguracion.UsuarioBD = reader["usuarioBD"].ToString();
                        beConfiguracion.ClaveBD = reader["claveBD"].ToString();
                        beConfiguracion.LicenciaSAP = reader["licenciaSAP"].ToString();
                        beConfiguracion.UsuarioSAP = reader["usuarioSAP"].ToString();
                        beConfiguracion.ClaveSAP = reader["claveSAP"].ToString();
                    }

                    cnn.Close();
                }
                   
                return beConfiguracion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Configuracion configuracion)
        {
            try
            {
                string sp = "SpTbConfiguracionInsertar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCONFIGURACION", configuracion.Id));
                    cmd.Parameters["@IDCONFIGURACION"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", configuracion.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@SERVIDOR", configuracion.Servidor));
                    cmd.Parameters.Add(new SqlParameter("@BASEDATOS", configuracion.BaseDatos));
                    cmd.Parameters.Add(new SqlParameter("@TIPOBD", configuracion.TipoBD));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOBD", configuracion.UsuarioBD));
                    cmd.Parameters.Add(new SqlParameter("@CLAVEBD", configuracion.ClaveBD));
                    cmd.Parameters.Add(new SqlParameter("@LICENCIASAP", configuracion.LicenciaSAP));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOSAP", configuracion.UsuarioSAP));
                    cmd.Parameters.Add(new SqlParameter("@CLAVESAP", configuracion.ClaveSAP));

                    rowsAffected = cmd.ExecuteNonQuery();
                    configuracion.Id = int.Parse(cmd.Parameters["@IDCONFIGURACION"].Value.ToString());
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Configuracion configuracion)
        {
            try
            {
                string sp = "SpTbConfiguracionActualizar";
                int rowsAffected = 0;


                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCONFIGURACION", configuracion.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", configuracion.Empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@SERVIDOR", configuracion.Servidor));
                    cmd.Parameters.Add(new SqlParameter("@BASEDATOS", configuracion.BaseDatos));
                    cmd.Parameters.Add(new SqlParameter("@TIPOBD", configuracion.TipoBD));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOBD", configuracion.UsuarioBD));
                    cmd.Parameters.Add(new SqlParameter("@CLAVEBD", configuracion.ClaveBD));
                    cmd.Parameters.Add(new SqlParameter("@LICENCIASAP", configuracion.LicenciaSAP));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOSAP", configuracion.UsuarioSAP));
                    cmd.Parameters.Add(new SqlParameter("@CLAVESAP", configuracion.ClaveSAP));

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
