namespace MigracionSap.Cliente.BaseDatos.Entidades
{
    public class Configuracion
    {
        public int Id { get; set; } = 0;
        public Empresa Empresa { get; set; } = null;
        public string Servidor { get; set; } = "";
        public string BaseDatos { get; set; } = "";
        public int TipoBD { get; set; } = 6; //SQL SERVER 2008
        public string UsuarioBD { get; set; } = "";
        public string ClaveBD { get; set; } = "";
        public string LicenciaSAP { get; set; } = "";
        public string UsuarioSAP { get; set; } = "";
        public string ClaveSAP { get; set; } = "";
    }
}
