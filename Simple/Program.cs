using System;
using System.Globalization;
using DI = MigracionSap.Simple.Sap;
using WS = MigracionSap.Simple.ServicioWeb;
using BD = MigracionSap.Simple.BaseDatos;
using TD = MigracionSap.Simple.Traductor;

namespace MigracionSap.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (DateTime.Now.Month > 4)
                    return;

                DateTime fechaHora = new DateTime(2018, 2, 2, 0, 0, 0);
                int idEmpresa = 13;

                Console.Write($"Ingrese la fecha y hora (dd/MM/yyyy HH:mm:ss) : ");
                string strFechahora = Console.ReadLine();

                bool fechaValida = DateTime.TryParseExact(strFechahora, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaHora);
                while (fechaValida == false)
                {
                    Console.WriteLine("Fecha ingresada incorrectamente, vuelva a intentarlo");
                    Console.Write($"Ingrese la fecha y hora (dd/MM/yyyy HH:mm:ss) : ");
                    strFechahora = Console.ReadLine();
                    fechaValida = DateTime.TryParseExact(strFechahora, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaHora);
                }

                Console.Write($"Ingrese el codigo de la sociendad : ");
                string strIdEmpresa = Console.ReadLine();
                if (int.TryParse(strIdEmpresa, out idEmpresa) == false)
                    idEmpresa = 0;

                var beConfiguracion = new BD.Configuracion().Obtener(idEmpresa);
                while (beConfiguracion == null)
                {
                    Console.WriteLine("Codigo de sociedad incorrecta, vuelva a intentarlo");
                    Console.Write($"Ingrese el codigo de la sociendad : ");
                    strIdEmpresa = Console.ReadLine();
                    if (int.TryParse(strIdEmpresa, out idEmpresa) == false)
                        idEmpresa = 0;
                    beConfiguracion = new BD.Configuracion().Obtener(idEmpresa);
                }


                string server = beConfiguracion.Servidor;
                string licenseServer = beConfiguracion.LicenciaSAP;
                string companyDB = beConfiguracion.BaseDatos;
                string dbUserName = beConfiguracion.UsuarioBD;
                string dbPassword = beConfiguracion.ClaveBD;
                string userName = beConfiguracion.UsuarioSAP;
                string password = beConfiguracion.ClaveSAP;

                string strRpta = "";

                Console.WriteLine($"Conectando a SBO");

                var sbo = new DI.DiConexion(server, licenseServer, companyDB,
                                                    dbUserName, dbPassword,
                                                    userName, password);

                var sapBd = new BD.Sap(server, companyDB, dbUserName, dbPassword);

                Console.Write($"Sincronizar SALIDAS DE ALMACEN (SI o NO) : ");
                strRpta = Console.ReadLine().ToUpper();
                if (strRpta.Equals("SI"))
                {

                    var salidaWs = new WS.WsSalida();
                    var salidaDi = new DI.DiSalidaAlmacen(sbo.oCompany);

                    var lstSalidasJson = salidaWs.Obtener(fechaHora, idEmpresa);
                    Console.WriteLine($"Cantidad de Documentos : { lstSalidasJson.Count }");

                    foreach (var salidaJson in lstSalidasJson)
                    {
                        var salidaBe = TD.JsonToSap.SalidaAlmacen(salidaJson);

                        salidaBe.Serie = sapBd.ObtenerSerieSalidaAlmacen("2018");
                        for (int i = 0; i < salidaBe.Detalle.Count; i++)
                        {
                            salidaBe.Detalle[i].CodAlmacen = sapBd.ObtenerCodigoAlmacen(salidaBe.Detalle[i].Codigo);
                        }

                        int errCode = 0;
                        string errMessage = "";
                        string docEntry = salidaDi.Enviar(salidaBe, out errCode, out errMessage);

                        if (docEntry.Length == 0)
                            Console.WriteLine($"Error : { errMessage }");
                        else
                            Console.WriteLine($"DocEntry : { docEntry }");
                    }

                }
                Console.WriteLine();

                Console.Write($"Sincronizar ENTRADAS DE ALMACEN (SI o NO) : ");
                strRpta = Console.ReadLine().ToUpper();
                if (strRpta.Equals("SI"))
                {
                    var entradaWs = new WS.WsEntrada();
                    var entradaDi = new DI.DiEntradaAlmacenPorCompra(sbo.oCompany);

                    var lstEntradaJson = entradaWs.Obtener(fechaHora, idEmpresa);
                    Console.WriteLine($"Cantidad de Documentos : { lstEntradaJson.Count }");

                    foreach (var entradaJson in lstEntradaJson)
                    {
                        var entradaBe = TD.JsonToSap.EntradaAlmacen(entradaJson);

                        entradaBe.Serie = sapBd.ObtenerSerieEntradaAlmacenPorCompra("2018");
                        entradaBe.refSap = entradaJson.docEntryOrden;

                        for (int i = 0; i < entradaBe.Detalle.Count; i++)
                        {
                            //entradaBe.Detalle[i].Precio = 9.9406;
                            entradaBe.Detalle[i].CodAlmacen = sapBd.ObtenerCodigoAlmacen(entradaBe.Detalle[i].Codigo);
                            //entradaBe.Detalle[i].CodImpuesto = "IGV";
                            //entradaBe.Detalle[i].CodMoneda = "SOL";
                            //entradaBe.Detalle[i].CodCuentaContable = "_SYS00000003579";
                            //entradaBe.Detalle[i].CodProyecto = "";
                            //entradaBe.Detalle[i].CodCentroCosto = "6.03.003";
                        }

                        int errCode = 0;
                        string errMessage = "";
                        string docEntry = entradaDi.Enviar(entradaBe, out errCode, out errMessage);

                        if (docEntry.Length == 0)
                            Console.WriteLine($"Error : { errMessage }");
                        else
                            Console.WriteLine($"DocEntry : { docEntry }");
                    }
                }
                Console.WriteLine();

                Console.Write($"Sincronizar SOLICITUD DE COMPRA (SI o NO) : ");
                strRpta = Console.ReadLine().ToUpper();
                if (strRpta.Equals("SI"))
                {
                    var solicitudWs = new WS.WsSolicitud();
                    var solicitudDi = new DI.DiSolicitudCompra(sbo.oCompany);

                    var lstSolicitudJson = solicitudWs.Obtener(fechaHora, idEmpresa);
                    Console.WriteLine($"Cantidad de Documentos : { lstSolicitudJson.Count }");

                    foreach (var solicitudJson in lstSolicitudJson)
                    {
                        var solicitudBe = TD.JsonToSap.SolicitudCompra(solicitudJson);

                        solicitudBe.Serie = sapBd.ObtenerSerieSolicitudCompra("2018");
                        for (int i = 0; i < solicitudBe.Detalle.Count; i++)
                        {
                            //solicitudBe.Detalle[i].Precio = 9.9406;
                            solicitudBe.Detalle[i].CodAlmacen = sapBd.ObtenerCodigoAlmacen(solicitudBe.Detalle[i].Codigo);
                            //solicitudBe.Detalle[i].CodProveedor = "";
                            //solicitudBe.Detalle[i].CodProyecto = "";
                            //solicitudBe.Detalle[i].CodCentroCosto = "6.03.003";
                        }

                        int errCode = 0;
                        string errMessage = "";
                        string docEntry = solicitudDi.Enviar(solicitudBe, out errCode, out errMessage);

                        if (docEntry.Length == 0)
                            Console.WriteLine($"Error : { errMessage }");
                        else
                            Console.WriteLine($"DocEntry : { docEntry }");
                    }
                }
                Console.WriteLine();

                Console.WriteLine($"Desconectando de SBO");
                sbo.Desconectar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
