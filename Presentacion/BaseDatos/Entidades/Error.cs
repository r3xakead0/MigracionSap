namespace MigracionSap.Cliente.BaseDatos.Entidades
{
    public class Error
    {

        public int Id { get; set; } = 0;
        public TipoDocumento Documento { get; set; } = null;
        public int IdDocumento { get; set; } = 0;
        public string Mensaje { get; set; } = "";

    }
}
