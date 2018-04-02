using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using DI = MigracionSap.Cliente.Sap;
using WS = MigracionSap.Cliente.ServicioWeb;
using BD = MigracionSap.Cliente.BaseDatos;
using TD = MigracionSap.Cliente.Traductor;

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

        private List<Documento> lstMigracion = null;
        private List<Documento> lstHistorial = null;

        public FrmMigracionDocumentos()
        {
            InitializeComponent();
        }

        private void FrmMigracionDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                this.lstMigracion = new List<Documento>();
                this.dgvMigraciones.DataSource = this.lstMigracion;
                this.FormatoSincronizar();

                this.lstHistorial = new List<Documento>();
                this.dgvHistorial.DataSource = this.lstHistorial;
                this.FormatoHistorial();

                this.dtpInicio.Value = DateTime.Now;
                this.dtpFisn.Value = DateTime.Now;

                this.cboTiposDocumentos.Items.Clear();
                this.cboTiposDocumentos.Items.Add("Todos");
                this.cboTiposDocumentos.Items.Add("Entrada de Almacen");
                this.cboTiposDocumentos.Items.Add("Salida de Almacen");
                this.cboTiposDocumentos.Items.Add("Solicitud de Almacen");
                this.cboTiposDocumentos.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SincronizarSalidasAlmacen()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            this.btnSincronizar.Enabled = false;

            try
            {
                string serieName = DateTime.Now.Year.ToString();
                int errCode = 0;
                string errMessage = "";

                var bdTipoDocumento = new BD.TipoDocumento();

                var beTipoSalida = bdTipoDocumento.Obtener(1);
                var beTipoEntrada = bdTipoDocumento.Obtener(2);
                var beTipoSsolicitud = bdTipoDocumento.Obtener(3);

                DateTime fechaHora = new DateTime(2018, 2, 2, 0, 0, 0);
                int idEmpresa = 13;

                var lstBeConfiguracion = new BD.Configuracion().Listar();
                foreach (var beConfiguracion in lstBeConfiguracion)
                {
                    string server = beConfiguracion.Servidor;
                    string licenseServer = beConfiguracion.LicenciaSAP;
                    string companyDB = beConfiguracion.BaseDatos;
                    string dbUserName = beConfiguracion.UsuarioBD;
                    string dbPassword = beConfiguracion.ClaveBD;
                    string userName = beConfiguracion.UsuarioSAP;
                    string password = beConfiguracion.ClaveSAP;

                    using (var sbo = new DI.DiConexion(server, licenseServer, companyDB, 
                                                        dbUserName, dbPassword,
                                                        userName, password))
                    { 

                        var sapBd = new BD.Sap(server, companyDB, dbUserName, dbPassword);

                        var salidaWs = new WS.WsSalida();
                        var salidaDi = new DI.DiSalidaAlmacen(sbo.oCompany);
                        var salidaBd = new BD.SalidaAlmacen();

                        var lstSalidasJson = salidaWs.Obtener(fechaHora, idEmpresa);

                        foreach (var salidaJson in lstSalidasJson)
                        {
                            var salidaBe = TD.JsonToSap.SalidaAlmacen(salidaJson);

                            salidaBe.Serie = sapBd.ObtenerSerieSalidaAlmacen(serieName);
                            for (int i = 0; i < salidaBe.Detalle.Count; i++)
                            {
                                salidaBe.Detalle[i].CodAlmacen = sapBd.ObtenerCodigoAlmacen(salidaBe.Detalle[i].Codigo);
                            }

                            string docEntry = salidaDi.Enviar(salidaBe, out errCode, out errMessage);

                            if (docEntry.Length == 0)
                            {
                                salidaBe.DocEntry = "";
                                //Error
                            }
                            else
                            {
                                salidaBe.DocEntry = docEntry;

                                var salidaBD = TD.SapToBd.SalidaAlmacen(salidaBe);
                                salidaBD.Empresa = beConfiguracion.Empresa;
                                salidaBD.TipoDocumento = beTipoSalida;
                                salidaBd.Insertar(ref salidaBD);
                            }
                        }


                        var entradaWs = new WS.WsEntrada();
                        var entradaDi = new DI.DiEntradaAlmacen(sbo.oCompany);
                        var entradaBd = new BD.EntradaAlmacen();

                        var lstEntradasJson = entradaWs.Obtener(fechaHora, idEmpresa);

                        foreach (var entradaJson in lstEntradasJson)
                        {
                            var entradaBe = TD.JsonToSap.EntradaAlmacen(entradaJson);

                            entradaBe.Serie = sapBd.ObtenerSerieEntradaAlmacen(serieName);
                            for (int i = 0; i < entradaBe.Detalle.Count; i++)
                            {
                                entradaBe.Detalle[i].CodAlmacen = sapBd.ObtenerCodigoAlmacen(entradaBe.Detalle[i].Codigo);
                            }

                            string docEntry = entradaDi.Enviar(entradaBe, out errCode, out errMessage);

                            if (docEntry.Length == 0)
                            {
                                entradaBe.DocEntry = "";
                                //Error
                            }
                            else
                            {
                                entradaBe.DocEntry = docEntry;

                                var entradaBD = TD.SapToBd.EntradaAlmacen(entradaBe);
                                entradaBD.Empresa = beConfiguracion.Empresa;
                                entradaBD.TipoDocumento = beTipoEntrada;
                                entradaBd.Insertar(ref entradaBD);
                            }
                        }


                        var solicitudWs = new WS.WsSolicitud();
                        var solicitudDi = new DI.DiSolicitudCompra(sbo.oCompany);
                        var solicitudBd = new BD.SolicitudCompra();

                        var lstSolicitudJson = solicitudWs.Obtener(fechaHora, idEmpresa);

                        foreach (var solicitudJson in lstSolicitudJson)
                        {
                            var solicitudBe = TD.JsonToSap.SolicitudCompra(solicitudJson);

                            solicitudBe.Serie = sapBd.ObtenerSerieSolicitudCompra(serieName);
                            for (int i = 0; i < solicitudBe.Detalle.Count; i++)
                            {
                                solicitudBe.Detalle[i].CodAlmacen = sapBd.ObtenerCodigoAlmacen(solicitudBe.Detalle[i].Codigo);
                            }

                            string docEntry = solicitudDi.Enviar(solicitudBe, out errCode, out errMessage);

                            if (docEntry.Length == 0)
                            {
                                solicitudBe.DocEntry = "";
                                //Error
                            }
                            else
                            {
                                solicitudBe.DocEntry = docEntry;

                                var solicitudBD = TD.SapToBd.SolicitudCompra(solicitudBe);
                                solicitudBD.Empresa = beConfiguracion.Empresa;
                                solicitudBD.TipoDocumento = beTipoSsolicitud;
                                solicitudBd.Insertar(ref solicitudBD);
                            }
                        }
                    }
                }


                
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

        private void FormatoSincronizar()
        {
            try
            {
                General.FormatDatagridview(ref this.dgvMigraciones);

                for (int i = 0; i < this.dgvMigraciones.Columns.Count; i++)
                    this.dgvMigraciones.Columns[i].Visible = false;

                this.dgvMigraciones.Columns["Empresa"].Visible = true;
                this.dgvMigraciones.Columns["Empresa"].HeaderText = "Empresa";
                this.dgvMigraciones.Columns["Empresa"].Width = 200;
                this.dgvMigraciones.Columns["Empresa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvMigraciones.Columns["Tipo"].Visible = true;
                this.dgvMigraciones.Columns["Tipo"].HeaderText = "Documento";
                this.dgvMigraciones.Columns["Tipo"].Width = 200;
                this.dgvMigraciones.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvMigraciones.Columns["Numeracion"].Visible = true;
                this.dgvMigraciones.Columns["Numeracion"].HeaderText = "Numeracion";
                this.dgvMigraciones.Columns["Numeracion"].Width = 150;
                this.dgvMigraciones.Columns["Numeracion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvMigraciones.Columns["Fecha"].Visible = true;
                this.dgvMigraciones.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvMigraciones.Columns["Fecha"].Width = 100;
                this.dgvMigraciones.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvMigraciones.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvMigraciones.Columns["Estado"].Visible = true;
                this.dgvMigraciones.Columns["Estado"].HeaderText = "Estado";
                this.dgvMigraciones.Columns["Estado"].Width = 100;
                this.dgvMigraciones.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                General.AutoWidthColumn(ref this.dgvMigraciones, "Empresa");
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

                this.dgvHistorial.Columns["Numeracion"].Visible = true;
                this.dgvHistorial.Columns["Numeracion"].HeaderText = "Numeracion";
                this.dgvHistorial.Columns["Numeracion"].Width = 150;
                this.dgvHistorial.Columns["Numeracion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHistorial.Columns["Fecha"].Visible = true;
                this.dgvHistorial.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvHistorial.Columns["Fecha"].Width = 100;
                this.dgvHistorial.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHistorial.Columns["FechaMigracion"].Visible = true;
                this.dgvHistorial.Columns["FechaMigracion"].HeaderText = "Fecha y Hora Migracion";
                this.dgvHistorial.Columns["FechaMigracion"].Width = 200;
                this.dgvHistorial.Columns["FechaMigracion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHistorial.Columns["FechaMigracion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                General.AutoWidthColumn(ref this.dgvHistorial, "Empresa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvHistorial.CurrentRow != null)
                {
                    var documento = (Documento)this.dgvMigraciones.CurrentRow.DataBoundItem;

                    switch (documento.Tipo)
                    {
                        case "Salida de Almacen":
                            var salida = FrmSalidaAlmacen.Instance();
                            salida.Cargar(documento.Id);
                            salida.Show();
                            break;
                        case "Entrada de Almacen":
                            var entrada = FrmEntradaAlmacen.Instance();
                            entrada.Cargar(documento.Id);
                            entrada.Show();
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

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }
    }
}
