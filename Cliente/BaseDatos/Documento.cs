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
            var lstUiDocumentos = new List<UI.Documento>();
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
                        var uiDocumento = new UI.Documento();

                        uiDocumento.Id = int.Parse(reader["Id"].ToString());
                        uiDocumento.EmpresaId = int.Parse(reader["EmpresaId"].ToString());
                        uiDocumento.Empresa = reader["Empresa"].ToString();
                        uiDocumento.TipoId = int.Parse(reader["TipoId"].ToString());
                        uiDocumento.Tipo = reader["Tipo"].ToString();
                        uiDocumento.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        uiDocumento.Usuario = reader["Usuario"].ToString();
                        uiDocumento.Estado = reader["Estado"].ToString();
                        uiDocumento.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                        uiDocumento.FechaEnvio = null;

                        lstUiDocumentos.Add(uiDocumento);
                    }

                    cnn.Close();
                }

                return lstUiDocumentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
