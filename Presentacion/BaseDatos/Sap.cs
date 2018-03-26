using System;
using System.Data;
using System.Data.SqlClient;

namespace MigracionSap.Presentacion.BaseDatos
{
    public class Sap
    {
        private const int SALIDAALMACEN = 60;
        private const int ENTRADAALMACEN = 59;
        private const int SOLICITUDCOMPRA = 1470000113;

        private string stringConnection = "";

        public Sap(string stringConnection)
        {
            this.stringConnection = stringConnection;
        }

        /// <summary>
        /// Obtener la serie de numeracion por documento
        /// </summary>
        /// <param name="serie">Numero de Serie</param>
        /// <param name="idDocumento">Id de Documento</param>
        /// <returns></returns>
        private string ObtenerNumeracion(string serie, int idDocumento)
        {
            string numero = "";
            try
            {
                string sql = $"SELECT TOP 1 T0.SERIES FROM NNM1 T0 WHERE T0.OBJECTCODE = { idDocumento.ToString() } AND T0.SERIESNAME = '{ serie }'";

                using (SqlConnection cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    numero = cmd.ExecuteScalar().ToString();

                    cnn.Close();
                }

                return numero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerNumeracionSalidaAlmacen(string serie)
        {
            return this.ObtenerNumeracion(serie, SALIDAALMACEN);
        }

        public string ObtenerNumeracionEntradaAlmacen(string serie)
        {
            return this.ObtenerNumeracion(serie, ENTRADAALMACEN);
        }

        public string ObtenerNumeracionSolicitudDocumento(string serie)
        {
            return this.ObtenerNumeracion(serie, SOLICITUDCOMPRA);
        }

        public bool ObtenerDatosAdministrativos(out string codMoneda, out string codAlmacen, out string codImpuesto)
        {
            bool rpta = false;

            string codMonedaTmp = "";
            string codAlmacenTmp = "";
            string codImpuestoTmp = "";

            try
            {
                string sql = $"SELECT TOP 1 MainCurncy, DfltWhs, TaxCodeCst FROM OAD";

                using (SqlConnection cnn = new SqlConnection(this.stringConnection))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        codMonedaTmp = reader["MainCurncy"].ToString();
                        codAlmacenTmp = reader["DfltWhs"].ToString();
                        codImpuestoTmp = reader["TaxCodeCst"].ToString();
                    }

                    cnn.Close();
                }

                codMoneda = codMonedaTmp;
                codAlmacen = codAlmacenTmp;
                codImpuesto = codImpuestoTmp;

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
