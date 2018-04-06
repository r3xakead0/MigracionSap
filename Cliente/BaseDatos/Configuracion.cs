using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class Configuracion
    {

        public BE.Configuracion Obtener(int idEmpresa)
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
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", idEmpresa));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beConfiguracion = new BE.Configuracion();

                        beConfiguracion.Id = int.Parse(reader["IdConfiguracion"].ToString());
                        beConfiguracion.Empresa = new Empresa().Obtener(idEmpresa); 
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

        public BE.Configuracion Obtener(BE.Empresa empresa)
        {
            try
            {
                return Obtener(empresa.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Configuracion> Listar()
        {
            var lstBeConfiguracion = new List<BE.Configuracion>();
            try
            {

                string sp = "SpTbConfiguracionListar";
                int idEmpresa = 0;
                var bdEmpresa = new Empresa();

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beConfiguracion = new BE.Configuracion();

                        beConfiguracion.Id = int.Parse(reader["idConfiguracion"].ToString()); 

                        idEmpresa = int.Parse(reader["idEmpresa"].ToString());
                        beConfiguracion.Empresa = bdEmpresa.Obtener(idEmpresa);

                        beConfiguracion.Servidor = reader["servidor"].ToString(); 
                        beConfiguracion.BaseDatos = reader["baseDatos"].ToString(); 
                        beConfiguracion.TipoBD = int.Parse(reader["tipoBD"].ToString()); 
                        beConfiguracion.UsuarioBD = reader["usuarioBD"].ToString(); 
                        beConfiguracion.ClaveBD = reader["claveBD"].ToString(); 
                        beConfiguracion.LicenciaSAP = reader["licenciaSAP"].ToString(); 
                        beConfiguracion.UsuarioSAP = reader["usuarioSAP"].ToString(); 
                        beConfiguracion.ClaveSAP = reader["claveSAP"].ToString();


                        lstBeConfiguracion.Add(beConfiguracion);
                    }

                    cnn.Close();
                }


                return lstBeConfiguracion;
            }
            catch (Exception)
            {

                throw;
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
