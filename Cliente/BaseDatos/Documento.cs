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

        public DateTime ObtenerUltimaFecha()
        {
            DateTime ultimaFecha = new DateTime(2018,1,1);
            try
            {

                string sp = "SpObtenerDocumentosUltimaFecha";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var strFechaHora = cmd.ExecuteScalar().ToString();
                    if (strFechaHora.Length > 0)
                        ultimaFecha = DateTime.Parse(strFechaHora);

                    cnn.Close();
                }

                return ultimaFecha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Limpiar()
        {
            try
            {

                string sp = "SpLimpiarDocumentos";

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
