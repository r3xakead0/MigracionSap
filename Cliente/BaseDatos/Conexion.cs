using System.Configuration;

namespace MigracionSap.Cliente.BaseDatos
{
    public static class Conexion
    {
        public static string strCnxBD = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
    }
}
