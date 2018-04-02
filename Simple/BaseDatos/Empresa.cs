using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Simple.BaseDatos.Entidades;

namespace MigracionSap.Simple.BaseDatos
{
    public class Empresa
    {


        public List<BE.Empresa> Listar()
        {
            var lstEmpresa = new List<BE.Empresa>();
            try
            {

                string sp = "SpTbEmpresaListar";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beEmpresa = new BE.Empresa();

                        beEmpresa.Id = int.Parse(reader["idEmpresa"].ToString());
                        beEmpresa.Nombre = reader["nombre"].ToString();
                        beEmpresa.Descripcion = reader["descripcion"].ToString();

                        lstEmpresa.Add(beEmpresa);
                    }

                    cnn.Close();
                }
                   
                return lstEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Empresa Obtener(int id)
        {
            BE.Empresa beEmpresa = null;
            try
            {

                string sp = "SpTbEmpresaObtener";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beEmpresa = new BE.Empresa();

                        beEmpresa.Id = int.Parse(reader["idEmpresa"].ToString());
                        beEmpresa.Nombre = reader["nombre"].ToString();
                        beEmpresa.Descripcion = reader["descripcion"].ToString();

                    }

                    cnn.Close();
                }

                return beEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Empresa empresa)
        {
            try
            {
                string sp = "SpTbEmpresaInsertar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", empresa.Id));
                    cmd.Parameters["@IDEMPRESA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", empresa.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", empresa.Descripcion));

                    rowsAffected = cmd.ExecuteNonQuery();
                    empresa.Id = int.Parse(cmd.Parameters["@IDEMPRESA"].Value.ToString());
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Empresa empresa)
        {
            try
            {
                string sp = "SpTbEmpresaActualizar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", empresa.Id));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", empresa.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", empresa.Descripcion));

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
