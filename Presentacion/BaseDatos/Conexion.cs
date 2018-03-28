using System.Configuration;

namespace MigracionSap.Presentacion.BaseDatos
{
    public static class Conexion
    {

        public static string strCnxBD = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        public static string strCnxSAP = ConfigurationManager.ConnectionStrings["ConexionSAP"].ConnectionString;

    }
}
