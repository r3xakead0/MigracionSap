using System.Configuration;

namespace MigracionSap.Simple.BaseDatos
{
    public static class Conexion
    {
        public static string strCnxBD = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
    }
}
