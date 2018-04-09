using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using DI = MigracionSap.Cliente.Sap;
using SE = MigracionSap.Cliente.Sap.Entidades;
using WS = MigracionSap.Cliente.ServicioWeb;
using BD = MigracionSap.Cliente.BaseDatos;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;
using TD = MigracionSap.Cliente.Traductor;
using System.Threading.Tasks;

namespace MigracionSap.Cliente
{
    public partial class FrmMigracionDocumentos : Form
    {

        #region "Patron Singleton"

        private static FrmMigracionDocumentos frmInstance = null;

        public static FrmMigracionDocumentos Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmMigracionDocumentos();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private const string ERROR = "Error";

        private const int SALIDA = 1;
        private const int ENTRADA = 2;
        private const int SOLICITUD =3;

        private string serie = "";

        private DateTime UltimaFecha = DateTime.Now;
        private List<Documento> lstUiDocumentosError = null;
        private List<Documento> lstHistorial = null;

        private List<WS.Json.EntradaAlmacen> lstWsEntradas = null;
        private List<WS.Json.SalidaAlmacen> lstWsSalidas = null;
        private List<WS.Json.SolicitudCompra> lstWsSolicitudes = null;

        public FrmMigracionDocumentos()
        {
            InitializeComponent();
        }

        private void FrmMigracionDocumentos_Load(object sender, EventArgs e)
        {
            try
            {

                this.serie = DateTime.Now.Year.ToString();

                this.stlMensaje.Text = string.Empty;

                this.ObtenerUltimaSincronizacion();

                this.CargarDocumentosError();
                this.FormatoDocumentosError();

                this.CargarHistorial();
                this.FormatoHistorial();

                this.dtpInicio.Value = DateTime.Now;
                this.dtpFin.Value = DateTime.Now;

                this.CargarSociedades();

                this.CargarTiposDocumentos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ObtenerSalidasWs(DateTime fechaHora, int idEmpresa)
        {
            this.lstWsSalidas = new WS.WsSalida().Obtener(fechaHora, idEmpresa);
            return this.lstWsSalidas.Count > 0;
        }

        private bool ObtenerEntradasWs(DateTime fechaHora, int idEmpresa)
        {
            this.lstWsEntradas = new WS.WsEntrada().Obtener(fechaHora, idEmpresa);
            return this.lstWsEntradas.Count > 0;
        }

        private bool ObtenerSolicitudesWs(DateTime fechaHora, int idEmpresa)
        {
            this.lstWsSolicitudes = new WS.WsSolicitud().Obtener(fechaHora, idEmpresa);
            return this.lstWsSolicitudes.Count > 0;
        }

        private bool RegistrarSalidaBD(ref BD.Sap bdSap, BE.Empresa beEmpresa)
        {
            bool rpta = false;

            var beTipoSalida = new BD.TipoDocumento().Obtener(SALIDA);

            var bdSalida = new BD.SalidaAlmacen();

            foreach (var salidaJson in this.lstWsSalidas)
            {
                var salidaSe = TD.JsonToSe.SalidaAlmacen(salidaJson);

                salidaSe.Serie = bdSap.ObtenerSerieSalidaAlmacen(this.serie);
                for (int i = 0; i < salidaSe.Detalle.Count; i++)
                {
                    salidaSe.Detalle[i].CodAlmacen = bdSap.ObtenerCodigoAlmacen(salidaSe.Detalle[i].Codigo);
                }

                var beSalida = TD.SeToBe.SalidaAlmacen(salidaSe);
                beSalida.Empresa = beEmpresa;
                beSalida.TipoDocumento = beTipoSalida;

                var flag = bdSalida.Insertar(ref beSalida);
            }

            return rpta;
        }

        private void EnviarSalidasSap(ref DI.DiConexion diConexion, BE.Empresa beEmpresa)
        {
            int errCode = 0;
            string errMessage = "";

            try
            {

                var beTipoSalida = new BD.TipoDocumento().Obtener(SALIDA);

                var bdSap = new BD.Sap(diConexion.Server, diConexion.CompanyDB, diConexion.DbUserName, diConexion.DbPassword);
                var bdError = new BD.Error();

                var diSalida = new DI.DiSalidaAlmacen(diConexion.oCompany);
                var bdSalida = new BD.SalidaAlmacen();

                foreach (var salidaJson in this.lstWsSalidas)
                {
                    var salidaSe = TD.JsonToSe.SalidaAlmacen(salidaJson);

                    salidaSe.Serie = bdSap.ObtenerSerieSalidaAlmacen(this.serie);
                    for (int i = 0; i < salidaSe.Detalle.Count; i++)
                    {
                        salidaSe.Detalle[i].CodAlmacen = bdSap.ObtenerCodigoAlmacen(salidaSe.Detalle[i].Codigo);
                    }

                    string docEntry = diSalida.Enviar(salidaSe, out errCode, out errMessage);
                    if (docEntry.Length > 0)
                        salidaSe.DocEntry = int.Parse(docEntry);

                    var beSalida = TD.SeToBe.SalidaAlmacen(salidaSe);
                    beSalida.Empresa = beEmpresa;
                    beSalida.TipoDocumento = beTipoSalida;

                    var rpta = bdSalida.Insertar(ref beSalida);
                    if (rpta == true && docEntry.Length == 0)
                        this.RegistrarErrorSap(SALIDA, beSalida.IdSalidaAlmacen, errMessage);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void EnviarEntradasSap(ref DI.DiConexion diConexion, BE.Empresa beEmpresa)
        {
            int errCode = 0;
            string errMessage = "";

            try
            {

                var beTipoEntrada = new BD.TipoDocumento().Obtener(ENTRADA);

                var bdSap = new BD.Sap(diConexion.Server, diConexion.CompanyDB, diConexion.DbUserName, diConexion.DbPassword);
                var bdError = new BD.Error();

                var diEntrada = new DI.DiEntradaAlmacenPorCompra(diConexion.oCompany);
                var bdEntrada = new BD.EntradaAlmacen();

                foreach (var EntradaJson in this.lstWsEntradas)
                {
                    var EntradaSe = TD.JsonToSe.EntradaAlmacen(EntradaJson);

                    EntradaSe.Serie = bdSap.ObtenerSerieEntradaAlmacenPorCompra(this.serie);
                    for (int i = 0; i < EntradaSe.Detalle.Count; i++)
                    {
                        EntradaSe.Detalle[i].CodAlmacen = bdSap.ObtenerCodigoAlmacen(EntradaSe.Detalle[i].Codigo);
                    }

                    string docEntry = diEntrada.Enviar(EntradaSe, out errCode, out errMessage);
                    if (docEntry.Length > 0)
                        EntradaSe.DocEntry = int.Parse(docEntry);

                    var beEntrada = TD.SeToBe.EntradaAlmacen(EntradaSe);
                    beEntrada.Empresa = beEmpresa;
                    beEntrada.TipoDocumento = beTipoEntrada;

                    var rpta = bdEntrada.Insertar(ref beEntrada);
                    if (rpta == true && docEntry.Length == 0)
                        this.RegistrarErrorSap(ENTRADA, beEntrada.IdEntradaAlmacen, errMessage);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void EnviarSolicitudesSap(ref DI.DiConexion diConexion, BE.Empresa beEmpresa)
        {
            int errCode = 0;
            string errMessage = "";

            try
            {

                var beTipoSolicitud = new BD.TipoDocumento().Obtener(SOLICITUD);

                var bdSap = new BD.Sap(diConexion.Server, diConexion.CompanyDB, diConexion.DbUserName, diConexion.DbPassword);
                var bdError = new BD.Error();

                var diSolicitud = new DI.DiSolicitudCompra(diConexion.oCompany);
                var bdSolicitud = new BD.SolicitudCompra();

                foreach (var SolicitudJson in this.lstWsSolicitudes)
                {
                    var Solicitudese = TD.JsonToSe.SolicitudCompra(SolicitudJson);

                    Solicitudese.Serie = bdSap.ObtenerSerieSolicitudCompra(this.serie);
                    for (int i = 0; i < Solicitudese.Detalle.Count; i++)
                    {
                        Solicitudese.Detalle[i].CodAlmacen = bdSap.ObtenerCodigoAlmacen(Solicitudese.Detalle[i].Codigo);
                    }

                    string docEntry = diSolicitud.Enviar(Solicitudese, out errCode, out errMessage);
                    if (docEntry.Length > 0)
                        Solicitudese.DocEntry = int.Parse(docEntry);

                    var beSolicitud = TD.SeToBe.SolicitudCompra(Solicitudese);
                    beSolicitud.Empresa = beEmpresa;
                    beSolicitud.TipoDocumento = beTipoSolicitud;

                    var rpta = bdSolicitud.Insertar(ref beSolicitud);
                    if (rpta == true && docEntry.Length == 0)
                        this.RegistrarErrorSap(SOLICITUD, beSolicitud.IdSolicitudCompra, errMessage);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            this.btnSincronizar.Enabled = false;
            this.stlMensaje.Text = string.Empty;

            try
            {

                #region Tipo de Documentos

                var bdTipoDocumento = new BD.TipoDocumento();

                var beTipoSalida = bdTipoDocumento.Obtener(SALIDA);
                var beTipoEntrada = bdTipoDocumento.Obtener(ENTRADA);
                var beTipoSsolicitud = bdTipoDocumento.Obtener(SOLICITUD);

                #endregion

                DateTime recepcion = this.UltimaFecha;

                var lstBeConfiguracion = new List<BE.Configuracion>();
                if (this.cboSociedades.SelectedIndex == 0)
                    lstBeConfiguracion = new BD.Configuracion().Listar();
                else
                {
                    var beEmpresa = (BE.Empresa)this.cboSociedades.SelectedItem;
                    var beConfiguracion = new BD.Configuracion().Obtener(beEmpresa);
                    if (beConfiguracion != null)
                        lstBeConfiguracion.Add(beConfiguracion);
                    else
                        General.CriticalMessage("La sociedad seleccionada no tiene configuración");
                }


                foreach (var beConfiguracion in lstBeConfiguracion)
                {

                    bool existeDatosSalida = false;
                    bool existeDatosEntrada = false;
                    bool existeDatosSolicitud = false;

                    #region Obtener Datos de WS

                    this.stlMensaje.Text = $"Obteniendo los datos de la sociedad { beConfiguracion.Empresa.Nombre } del Servicio Web";

                    int idEmpresa = beConfiguracion.Empresa.Id;
                    var tasksWs = new[]
                    {
                        Task<bool>.Factory.StartNew(() => ObtenerSalidasWs(recepcion, idEmpresa)),
                        Task<bool>.Factory.StartNew(() => ObtenerEntradasWs(recepcion, idEmpresa)),
                        Task<bool>.Factory.StartNew(() => ObtenerSolicitudesWs(recepcion, idEmpresa))
                    };
                    Task.WaitAll(tasksWs);

                    existeDatosSalida = tasksWs[0].Result;
                    existeDatosEntrada = tasksWs[1].Result;
                    existeDatosSolicitud = tasksWs[2].Result;

                    #endregion

                    #region Registrar en BD

                    #endregion

                    #region Enviar Datos a SAP

                    this.stlMensaje.Text = $"Enviado los datos de la sociedad { beConfiguracion.Empresa.Nombre } al SAP";

                    #region Conectar a SAP

                    string server = beConfiguracion.Servidor;
                    string licenseServer = beConfiguracion.LicenciaSAP;
                    string companyDB = beConfiguracion.BaseDatos;
                    string dbUserName = beConfiguracion.UsuarioBD;
                    string dbPassword = beConfiguracion.ClaveBD;
                    string userName = beConfiguracion.UsuarioSAP;
                    string password = beConfiguracion.ClaveSAP;

                    var diConexion = new DI.DiConexion(server, licenseServer, companyDB,
                                                         dbUserName, dbPassword,
                                                         userName, password);

                    #endregion

                    var tasksSap = new[]
                    {
                        Task.Factory.StartNew(() => EnviarSalidasSap(ref diConexion, beConfiguracion.Empresa)),
                        Task.Factory.StartNew(() => EnviarEntradasSap(ref diConexion, beConfiguracion.Empresa)),
                        Task.Factory.StartNew(() => EnviarSolicitudesSap(ref diConexion, beConfiguracion.Empresa))
                    };
                    Task.WaitAll(tasksSap);

                    #region Desconectar a SAP

                    diConexion.Desconectar();

                    #endregion

                    #endregion

                }

                this.stlMensaje.Text = "Sincronización Completada";

                this.ObtenerUltimaSincronizacion();
                this.CargarDocumentosError();

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
            finally
            {
                this.btnSincronizar.Enabled = true;
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvHistorial.CurrentRow != null)
                {
                    var documento = (Documento)this.dgvDocumentosError.CurrentRow.DataBoundItem;

                    switch (documento.TipoId)
                    {
                        case SALIDA: //"Salida de Almacen"
                            var salida = FrmSalidaAlmacen.Instance();
                            salida.Cargar(documento.Id);
                            salida.Show();
                            break;
                        case ENTRADA: // "Entrada de Almacen"
                            var entrada = FrmEntradaAlmacen.Instance();
                            entrada.Cargar(documento.Id);
                            entrada.Show();
                            break;
                        case SOLICITUD: // "Solicitud de Compra"
                            var solicitud = FrmSolicitudCompra.Instance();
                            solicitud.Cargar(documento.Id);
                            solicitud.Show();
                            break;
                        default:
                            break;
                    }
  
                }
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                var beTipoDocumento = (BE.TipoDocumento)this.cboTiposDocumentos.SelectedItem;
                if (beTipoDocumento == null)
                {
                    this.cboTiposDocumentos.Focus();
                    General.CriticalMessage("Seleccione un Tipo de Documento");
                    return;
                }

                if (this.dtpInicio.Value.Date > this.dtpFin.Value.Date)
                {
                    this.dtpInicio.Focus();
                    General.CriticalMessage("La Fecha Inicial es mayor a la Fecha Final");
                    return;
                }

                #endregion

                int idTipoDocumento = beTipoDocumento.Id;
                DateTime fechaInicio = this.dtpInicio.Value;
                DateTime fechaFin = this.dtpFin.Value;

                this.CargarHistorial(idTipoDocumento, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void btnErrores_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocumentosError.CurrentRow != null)
                {
                    var uiDocumento = (Documento)this.dgvDocumentosError.CurrentRow.DataBoundItem;

                    if (uiDocumento.Estado != ERROR)
                        return;

                    var error = FrmErrorList.Instance();
                    error.Show();

                    switch (uiDocumento.TipoId)
                    {
                        case SALIDA: // "Salida de Almacen":
                            error.Cargar(uiDocumento.TipoId, uiDocumento.Id);
                            break;
                        case ENTRADA: // "Entrada de Almacen":
                            error.Cargar(uiDocumento.TipoId, uiDocumento.Id);
                            break;
                        case SOLICITUD: // "Solicitud de Compra":
                            error.Cargar(uiDocumento.TipoId, uiDocumento.Id);
                            break;
                        default:
                            break;
                    }
 
                }
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnEnviar.Enabled = false;
                this.stlMensaje.Text = string.Empty;

                if (this.dgvDocumentosError.CurrentRow == null)
                    return;

                var uiDocumento = (Documento)this.dgvDocumentosError.CurrentRow.DataBoundItem;
                if (uiDocumento.Estado != ERROR)
                    return;

                int errCode = 0;
                string errMessage = "";

                var beEmpresa = new BD.Empresa().Obtener(uiDocumento.EmpresaId);
                var beConfiguracion = new BD.Configuracion().Obtener(beEmpresa);

                string server = beConfiguracion.Servidor;
                string licenseServer = beConfiguracion.LicenciaSAP;
                string companyDB = beConfiguracion.BaseDatos;
                string dbUserName = beConfiguracion.UsuarioBD;
                string dbPassword = beConfiguracion.ClaveBD;
                string userName = beConfiguracion.UsuarioSAP;
                string password = beConfiguracion.ClaveSAP;

                this.stlMensaje.Text = $"Conectando al SBO de la compañia { beConfiguracion.Empresa.Nombre }";

                using (var sbo = new DI.DiConexion(server, licenseServer, companyDB,
                                                    dbUserName, dbPassword,
                                                    userName, password))
                {

                    var sapBd = new BD.Sap(server, companyDB, dbUserName, dbPassword);
                    var errorBd = new BD.Error();

                    switch (uiDocumento.TipoId)
                    {
                        case SALIDA: // "Salida de Almacen":
                            var bdSalida = new BD.SalidaAlmacen();
                            var beSalida = bdSalida.Obtener(uiDocumento.Id);
                            if (beSalida != null)
                            {

                                var seSalida = TD.BeToSe.SalidaAlmacen(beSalida);

                                this.stlMensaje.Text = $"Enviando Salida de Almacen";

                                string docEntry = new DI.DiSalidaAlmacen(sbo.oCompany).Enviar(seSalida, out errCode, out errMessage);
                                if (docEntry.Length > 0)
                                    beSalida.CodSap = int.Parse(docEntry);

                                var rpta = bdSalida.Actualizar(beSalida);
                                if (rpta == true && errCode != 0)
                                    this.RegistrarErrorSap(SALIDA, beSalida.IdSalidaAlmacen, errMessage);

                            }
                            break;
                        case ENTRADA: // "Entrada de Almacen":
                            var bdEntrada = new BD.EntradaAlmacen();
                            var beEntrada = bdEntrada.Obtener(uiDocumento.Id);
                            if (beEntrada != null)
                            {

                                var seEntrada = TD.BeToSe.EntradaAlmacen(beEntrada);

                                this.stlMensaje.Text = $"Enviando Entrada de Almacen";

                                string docEntry = new DI.DiEntradaAlmacenPorCompra(sbo.oCompany).Enviar(seEntrada, out errCode, out errMessage);
                                if (docEntry.Length > 0)
                                    beEntrada.CodSap = int.Parse(docEntry);

                                var rpta = bdEntrada.Actualizar(beEntrada);
                                if (rpta == true && errCode != 0)
                                    this.RegistrarErrorSap(SALIDA, beEntrada.IdEntradaAlmacen, errMessage);

                            }
                            break;
                        case SOLICITUD: // "Solicitud de Compra":
                            var bdSolicitud = new BD.SolicitudCompra();
                            var beSolicitud = bdSolicitud.Obtener(uiDocumento.Id);
                            if (beSolicitud != null)
                            {

                                var seSolicitud = TD.BeToSe.SolicitudCompra(beSolicitud);

                                this.stlMensaje.Text = $"Enviando Solicitud de Compra";

                                string docEntry = new DI.DiSolicitudCompra(sbo.oCompany).Enviar(seSolicitud, out errCode, out errMessage);
                                if (docEntry.Length > 0)
                                    beSolicitud.CodSap = int.Parse(docEntry);

                                var rpta = bdSolicitud.Actualizar(beSolicitud);
                                if (rpta == true && errCode != 0)
                                    this.RegistrarErrorSap(SOLICITUD, beSolicitud.IdSolicitudCompra, errMessage);

                            }
                            break;
                        default:
                            break;
                    }
                }

                this.stlMensaje.Text = "Sincronización Completada";
                this.CargarDocumentosError();
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
            finally
            {
                this.btnEnviar.Enabled = true;
            }
        }


        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocumentosError.CurrentRow == null)
                    return;

                var uiDocumento = (Documento)this.dgvDocumentosError.CurrentRow.DataBoundItem;
                if (uiDocumento.Estado != ERROR)
                    return;

                switch (uiDocumento.TipoId)
                {
                    case SALIDA: // "Salida de Almacen":
                        var frmSalida = FrmSalidaAlmacen.Instance();
                        frmSalida.Cargar(uiDocumento.Id);
                        frmSalida.Show();
                        break;
                    case ENTRADA: // "Entrada de Almacen":
                        
                        break;
                    case SOLICITUD: // "Solicitud de Compra":
                        
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
           
        }

        private void tsmConfigurarSociedades_Click(object sender, EventArgs e)
        {
            try
            {
                var frmConfiguracion = FrmConfiguracion.Instance();
                frmConfiguracion.StartPosition = FormStartPosition.CenterScreen;
                frmConfiguracion.Show();
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void tsmConfigurarPlanes_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPlan = FrmPlanificacion.Instance();
                frmPlan.StartPosition = FormStartPosition.CenterScreen;
                frmPlan.Show();
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void FrmMigracionDocumentos_Resize(object sender, EventArgs e)
        {
            try
            {
                General.AutoWidthColumn(ref this.dgvDocumentosError, "Empresa");
                General.AutoWidthColumn(ref this.dgvHistorial, "Empresa");

                this.stlMensaje.Width = this.Width - 50;
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void ObtenerUltimaSincronizacion()
        {
            try
            {
                this.UltimaFecha = new BD.Documento().ObtenerUltimaFecha();
                this.txtUltimaSincronizacion.Text = this.UltimaFecha.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDocumentosError()
        {
            try
            {
                this.lstUiDocumentosError = new BD.Documento().ListarDocumentosConError();
                this.dgvDocumentosError.DataSource = this.lstUiDocumentosError;

                this.txtDocumentosError.Text = this.lstUiDocumentosError.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoDocumentosError()
        {
            try
            {
                General.FormatDatagridview(ref this.dgvDocumentosError);

                for (int i = 0; i < this.dgvDocumentosError.Columns.Count; i++)
                    this.dgvDocumentosError.Columns[i].Visible = false;

                this.dgvDocumentosError.Columns["Empresa"].Visible = true;
                this.dgvDocumentosError.Columns["Empresa"].HeaderText = "Empresa";
                this.dgvDocumentosError.Columns["Empresa"].Width = 200;
                this.dgvDocumentosError.Columns["Empresa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDocumentosError.Columns["Tipo"].Visible = true;
                this.dgvDocumentosError.Columns["Tipo"].HeaderText = "Documento";
                this.dgvDocumentosError.Columns["Tipo"].Width = 200;
                this.dgvDocumentosError.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDocumentosError.Columns["Fecha"].Visible = true;
                this.dgvDocumentosError.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvDocumentosError.Columns["Fecha"].Width = 100;
                this.dgvDocumentosError.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDocumentosError.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvDocumentosError.Columns["Usuario"].Visible = true;
                this.dgvDocumentosError.Columns["Usuario"].HeaderText = "Usuario";
                this.dgvDocumentosError.Columns["Usuario"].Width = 150;
                this.dgvDocumentosError.Columns["Usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvDocumentosError.Columns["Estado"].Visible = true;
                this.dgvDocumentosError.Columns["Estado"].HeaderText = "Estado";
                this.dgvDocumentosError.Columns["Estado"].Width = 100;
                this.dgvDocumentosError.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                General.AutoWidthColumn(ref this.dgvDocumentosError, "Empresa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarHistorial(int idTipoDocumento = 0, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                this.lstHistorial = new List<Documento>();
                this.dgvHistorial.DataSource = this.lstHistorial;

                this.txtHistorial.Text = this.lstHistorial.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoHistorial()
        {
            try
            {
                General.FormatDatagridview(ref this.dgvHistorial);

                for (int i = 0; i < this.dgvHistorial.Columns.Count; i++)
                    this.dgvHistorial.Columns[i].Visible = false;

                this.dgvHistorial.Columns["Empresa"].Visible = true;
                this.dgvHistorial.Columns["Empresa"].HeaderText = "Empresa";
                this.dgvHistorial.Columns["Empresa"].Width = 200;
                this.dgvHistorial.Columns["Empresa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHistorial.Columns["Tipo"].Visible = true;
                this.dgvHistorial.Columns["Tipo"].HeaderText = "Documento";
                this.dgvHistorial.Columns["Tipo"].Width = 200;
                this.dgvHistorial.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHistorial.Columns["Fecha"].Visible = true;
                this.dgvHistorial.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvHistorial.Columns["Fecha"].Width = 100;
                this.dgvHistorial.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHistorial.Columns["Usuario"].Visible = true;
                this.dgvHistorial.Columns["Usuario"].HeaderText = "Usuario";
                this.dgvHistorial.Columns["Usuario"].Width = 150;
                this.dgvHistorial.Columns["Usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHistorial.Columns["Estado"].Visible = true;
                this.dgvHistorial.Columns["Estado"].HeaderText = "Estado";
                this.dgvHistorial.Columns["Estado"].Width = 100;
                this.dgvHistorial.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                General.AutoWidthColumn(ref this.dgvHistorial, "Empresa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarSociedades()
        {
            try
            {
                var lstBeEmpresas = new BD.Empresa().Listar();

                var beEmpresa = new BE.Empresa();
                beEmpresa.Id = 0;
                beEmpresa.Nombre = "Todos";
                lstBeEmpresas.Insert(0, beEmpresa);

                this.cboSociedades.DataSource = lstBeEmpresas;
                this.cboSociedades.DisplayMember = "Nombre";
                this.cboSociedades.ValueMember = "Id";

                this.cboSociedades.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposDocumentos()
        {
            try
            {
                var lstBeTiposDocumentos = new BD.TipoDocumento().Listar();

                var beTipoDocumento = new BE.TipoDocumento();
                beTipoDocumento.Id = 0;
                beTipoDocumento.Nombre = "Todos";
                lstBeTiposDocumentos.Insert(0, beTipoDocumento);

                this.cboTiposDocumentos.DataSource = lstBeTiposDocumentos;
                this.cboTiposDocumentos.DisplayMember = "Nombre";
                this.cboTiposDocumentos.ValueMember = "Id";

                this.cboTiposDocumentos.SelectedIndex = 0;

                var beTipoDocumento2 = new List<BE.TipoDocumento>(lstBeTiposDocumentos);

                this.cboDocumentos.DataSource = beTipoDocumento2;
                this.cboDocumentos.DisplayMember = "Nombre";
                this.cboDocumentos.ValueMember = "Id";

                this.cboDocumentos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RegistrarErrorSap(int idTipoDocumento, int idDocumento, string mensaje)
        {
            try
            {
                var bdError = new BD.Error();
                bool rpta = bdError.Insertar(idTipoDocumento, idDocumento, mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
