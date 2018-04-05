using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UI = MigracionSap.Cliente;

namespace MigracionSap.Cliente.BaseDatos
{
    public class Documento
    {
        public List<UI.Documento> ListarDocumentosConError()
        {
            var lstDocumentos = new List<UI.Documento>();
            try
            {

                string sp = "SpListarDocumentosError";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var documento = new UI.Documento();

                        documento.Id = int.Parse(reader["Id"].ToString());
                        documento.Empresa = reader["Empresa"].ToString();
                        documento.Tipo = reader["Tipo"].ToString();
                        documento.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        documento.Usuario = reader["Usuario"].ToString();
                        documento.Estado = reader["Estado"].ToString();
                        documento.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                        documento.FechaEnvio = null;

                        lstDocumentos.Add(documento);
                    }

                    cnn.Close();
                }

                return lstDocumentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
