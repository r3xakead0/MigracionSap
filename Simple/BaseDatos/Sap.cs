using System;
using System.Data;
using System.Data.SqlClient;

namespace MigracionSap.Simple.BaseDatos
{
    public class Sap
    {
        private const int SALIDAALMACEN = 60;
        private const int ENTRADAALMACEN = 59;
        private const int SOLICITUDCOMPRA = 1470000113;

        private string strCnxBD = @"Data Source=SRVMAYO1;Initial Catalog=SBO_PRUEBACMAYO19072017;User id=sa;Password=Sapb1admin;";

        /// <summary>
        /// Obtener la serie de numeracion por documento
        /// </summary>
        /// <param name="serie">Numero de Serie</param>
        /// <param name="idDocumento">Id de Documento</param>
        /// <returns></returns>
        private int ObtenerSerie(string serie, int idDocumento)
        {
            int numero = 0;
            try
            {
                string sql = $"SELECT TOP 1 T0.SERIES FROM NNM1 T0 WHERE T0.OBJECTCODE = { idDocumento.ToString() } AND T0.SERIESNAME = '{ serie }'";

                using (SqlConnection cnn = new SqlConnection(strCnxBD))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    numero = int.Parse(cmd.ExecuteScalar().ToString());

                    cnn.Close();
                }

                return numero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ObtenerSerieSalidaAlmacen(string serie)
        {
            return this.ObtenerSerie(serie, SALIDAALMACEN);
        }

        public int ObtenerSerieEntradaAlmacen(string serie)
        {
            return this.ObtenerSerie(serie, ENTRADAALMACEN);
        }

        public int ObtenerSerieSolicitudCompra(string serie)
        {
            return this.ObtenerSerie(serie, SOLICITUDCOMPRA);
        }

        public  string ObtenerCodigoAlmacen(string codArticulo)
        {
            string codAlmacen = "";
            try
            {
                string sql = $"SELECT TOP 1 T0.DfltWH FROM OITM T0 WHERE T0.ITEMCODE = '{ codArticulo }'";

                using (SqlConnection cnn = new SqlConnection(strCnxBD))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        codAlmacen = reader["DfltWH"].ToString();
                        if (codAlmacen.Length == 0)
                            codAlmacen = ObtenerCodigoAlmacen();
                    }

                    cnn.Close();
                }

                return codAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerCodigoAlmacen()
        {
            string codAlmacen = "";
            try
            {
                string sql = $"SELECT TOP 1 T0.DfltWhs FROM OADM T0";

                using (SqlConnection cnn = new SqlConnection(strCnxBD))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        codAlmacen = reader["DfltWhs"].ToString();
                    }

                    cnn.Close();
                }

                return codAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
