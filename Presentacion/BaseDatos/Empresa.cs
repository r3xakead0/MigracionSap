using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion.BaseDatos
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

    }
}
