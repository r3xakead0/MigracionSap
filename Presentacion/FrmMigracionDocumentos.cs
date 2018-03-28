using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
//using SAPbobsCOM;
using BD = MigracionSap.Presentacion.BaseDatos;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;
using WS = MigracionSap.Presentacion.ServicioWeb;

namespace MigracionSap.Presentacion
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

        private string cnxStrBD = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

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

        private List<BE.SalidaAlmacen> ObtenerSalidasAlmacen(DateTime fechaHora, int idEmpresa)
        {
            var lstSalidaAlmacen = new List<BE.SalidaAlmacen>();
            try
            {

                string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";

                var lstSalidaAlmacenJson = new WS.wsSalida().Obtener(fechaHora, idEmpresa);

                foreach (var salidaAlmacenJson in lstSalidaAlmacenJson)
                {
                    var beSalidaAlmacen = new BE.SalidaAlmacen();

                    beSalidaAlmacen.IdSalidaAlmacen = 0;
                    beSalidaAlmacen.Serie = "";
                    beSalidaAlmacen.Comentario = salidaAlmacenJson.comentario;
                    beSalidaAlmacen.Usuario = salidaAlmacenJson.usuario;
                    beSalidaAlmacen.Total = double.Parse(salidaAlmacenJson.total);
                    beSalidaAlmacen.FechaContable = General.ParseStringToDatetime(salidaAlmacenJson.FechaContable, formatoFechaHora);
                    beSalidaAlmacen.FechaCreacion = General.ParseStringToDatetime(salidaAlmacenJson.FechaCreacion, formatoFechaHora);
                    beSalidaAlmacen.CodSap = 0;

                    int nroLinea = 1;
                    foreach (var salidaAlmacenDetalleJson in salidaAlmacenJson.detalle)
                    {
                        var beSalidaAlmacenDetalle = new BE.SalidaAlmacenDetalle();

                        beSalidaAlmacenDetalle.IdSalidaAlmacenDetalle = 0;
                        beSalidaAlmacenDetalle.IdSalidaAlmacen =  0;
                        beSalidaAlmacenDetalle.NroLinea = nroLinea;
                        beSalidaAlmacenDetalle.Codigo = salidaAlmacenDetalleJson.codArticulo;
                        beSalidaAlmacenDetalle.Descripcion = salidaAlmacenDetalleJson.descripcion;
                        beSalidaAlmacenDetalle.Cantidad = double.Parse(salidaAlmacenDetalleJson.cantidad);
                        beSalidaAlmacenDetalle.CodAlmacen = salidaAlmacenDetalleJson.codAlmacen;
                        beSalidaAlmacenDetalle.CodImpuesto = salidaAlmacenDetalleJson.codImpuesto;
                        beSalidaAlmacenDetalle.CodCuentaContable = "";
                        beSalidaAlmacenDetalle.CodProyecto = "";
                        beSalidaAlmacenDetalle.CodCentroCosto = salidaAlmacenDetalleJson.codCentroCosto;

                        beSalidaAlmacen.Detalle.Add(beSalidaAlmacenDetalle);

                        nroLinea += 1;
                    }

                    lstSalidaAlmacen.Add(beSalidaAlmacen);
                }

                return lstSalidaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.EntradaAlmacen> ObtenerEntradasAlmacen(DateTime fechaHora, int idEmpresa)
        {
            var lstEntradaAlmacen = new List<BE.EntradaAlmacen>();
            try
            {

                string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";

                var lstEntradaAlmacenJson = new WS.wsEntrada().Obtener(fechaHora, idEmpresa);

                foreach (var EntradaAlmacenJson in lstEntradaAlmacenJson)
                {
                    var beEntradaAlmacen = new BE.EntradaAlmacen();

                    beEntradaAlmacen.IdEntradaAlmacen = 0;
                    beEntradaAlmacen.Serie = "";
                    beEntradaAlmacen.Comentario = EntradaAlmacenJson.comentario;
                    beEntradaAlmacen.Usuario = EntradaAlmacenJson.usuario;
                    beEntradaAlmacen.Total = double.Parse(EntradaAlmacenJson.total);
                    beEntradaAlmacen.FechaContable = General.ParseStringToDatetime(EntradaAlmacenJson.FechaContable, formatoFechaHora);
                    beEntradaAlmacen.FechaCreacion = General.ParseStringToDatetime(EntradaAlmacenJson.FechaCreacion, formatoFechaHora);
                    beEntradaAlmacen.CodSap = 0;
                    beEntradaAlmacen.refSap = EntradaAlmacenJson.docEntryOrden;

                    int nroLinea = 1;
                    foreach (var EntradaAlmacenDetalleJson in EntradaAlmacenJson.detalle)
                    {
                        var beEntradaAlmacenDetalle = new BE.EntradaAlmacenDetalle();

                        beEntradaAlmacenDetalle.IdEntradaAlmacenDetalle = 0;
                        beEntradaAlmacenDetalle.IdEntradaAlmacen = 0;
                        beEntradaAlmacenDetalle.NroLinea = nroLinea;
                        beEntradaAlmacenDetalle.Codigo = EntradaAlmacenDetalleJson.codArticulo;
                        beEntradaAlmacenDetalle.Descripcion = EntradaAlmacenDetalleJson.descripcion;
                        beEntradaAlmacenDetalle.Cantidad = double.Parse(EntradaAlmacenDetalleJson.cantidad);
                        beEntradaAlmacenDetalle.CodAlmacen = EntradaAlmacenDetalleJson.codAlmacen;
                        beEntradaAlmacenDetalle.CodImpuesto = EntradaAlmacenDetalleJson.codImpuesto;
                        beEntradaAlmacenDetalle.NroCuentaContable = "";
                        beEntradaAlmacenDetalle.CodProyecto = "";
                        beEntradaAlmacenDetalle.CodCentroCosto = EntradaAlmacenDetalleJson.codCentroCosto;

                        beEntradaAlmacen.Detalle.Add(beEntradaAlmacenDetalle);

                        nroLinea += 1;
                    }

                    lstEntradaAlmacen.Add(beEntradaAlmacen);
                }

                return lstEntradaAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.SolicitudCompra> ObtenerSolicitudCompra(DateTime fechaHora, int idEmpresa)
        {
            var lstSolicitudCompra = new List<BE.SolicitudCompra>();
            try
            {

                string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";

                var lstSolicitudCompraJson = new WS.wsSolicitud().Obtener(fechaHora, idEmpresa);

                foreach (var SolicitudCompraJson in lstSolicitudCompraJson)
                {
                    var beSolicitudCompra = new BE.SolicitudCompra();

                    beSolicitudCompra.IdSolicitudCompra = 0;
                    beSolicitudCompra.Serie = "";
                    beSolicitudCompra.Tipo = char.Parse(SolicitudCompraJson.tipo);
                    beSolicitudCompra.Comentario = SolicitudCompraJson.comentario;
                    beSolicitudCompra.Usuario = SolicitudCompraJson.usuario;
                    beSolicitudCompra.Total = 0;
                    beSolicitudCompra.FechaContable = General.ParseStringToDatetime(SolicitudCompraJson.FechaContable, formatoFechaHora);
                    beSolicitudCompra.FechaNecesita = General.ParseStringToDatetime(SolicitudCompraJson.FechaNecesita, formatoFechaHora);
                    beSolicitudCompra.FechaCreacion = General.ParseStringToDatetime(SolicitudCompraJson.FechaCreacion, formatoFechaHora);
                    beSolicitudCompra.CodSap = 0;

                    int nroLinea = 1;
                    foreach (var SolicitudCompraDetalleJson in SolicitudCompraJson.items)
                    {
                        var beSolicitudCompraDetalle = new BE.SolicitudCompraDetalle();

                        beSolicitudCompraDetalle.IdSolicitudCompraDetalle = 0;
                        beSolicitudCompraDetalle.IdSolicitudCompra = 0;
                        beSolicitudCompraDetalle.NroLinea = nroLinea;
                        beSolicitudCompraDetalle.Codigo = SolicitudCompraDetalleJson.codArticulo;
                        beSolicitudCompraDetalle.Descripcion = SolicitudCompraDetalleJson.descripcion;
                        beSolicitudCompraDetalle.Cantidad = double.Parse(SolicitudCompraDetalleJson.cantidad);
                        beSolicitudCompraDetalle.CodAlmacen = SolicitudCompraDetalleJson.codAlmacen;
                        beSolicitudCompraDetalle.CodCentroCosto = SolicitudCompraDetalleJson.codCentroCosto;
                        beSolicitudCompraDetalle.CodProveedor = SolicitudCompraDetalleJson.codProveedor;

                        beSolicitudCompra.Detalle.Add(beSolicitudCompraDetalle);

                        nroLinea += 1;
                    }

                    lstSolicitudCompra.Add(beSolicitudCompra);
                }

                return lstSolicitudCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSincronizar.Enabled = false;

                bool rpta = false;
                var lstMigracion = new List<Documento>();

                DateTime fechaHora = new DateTime(2018, 2, 2, 0, 0, 0);
                int idEmpresa = 0;

                var lstSalidaAlmacen = this.ObtenerSalidasAlmacen(fechaHora, idEmpresa);
                rpta = new BD.SalidaAlmacen().Insertar(ref lstSalidaAlmacen);
                if (rpta)
                {
                    foreach (var objSalidaAlmacen in lstSalidaAlmacen)
                    {
                        var objMigracion = new Documento();

                        objMigracion.Empresa = "CORPORACION MAYO";
                        objMigracion.Tipo = "Salida de Almacen";
                        objMigracion.Numeracion = "";
                        objMigracion.Fecha = objSalidaAlmacen.FechaContable;
                        objMigracion.Estado = "Pendiente";
                        objMigracion.FechaMigracion = null;

                        lstMigracion.Add(objMigracion);
                    }
                }

                var lstEntradaAlmacen = this.ObtenerEntradasAlmacen(fechaHora, idEmpresa);
                rpta = new BD.EntradaAlmacen().Insertar(ref lstEntradaAlmacen);
                if (rpta)
                {
                    foreach (var objEntradaAlmacen in lstEntradaAlmacen)
                    {
                        var objMigracion = new Documento();

                        objMigracion.Empresa = "CORPORACION MAYO";
                        objMigracion.Tipo = "Entrada de Almacen";
                        objMigracion.Numeracion = "";
                        objMigracion.Fecha = objEntradaAlmacen.FechaContable;
                        objMigracion.Estado = "Pendiente";
                        objMigracion.FechaMigracion = null;

                        lstMigracion.Add(objMigracion);
                    }
                }

                var lstSolicitudCompra = this.ObtenerSolicitudCompra(fechaHora, idEmpresa);
                rpta = new BD.SolicitudCompra().Insertar(ref lstSolicitudCompra);
                if (rpta)
                {
                    foreach (var objSolicitudCompra in lstSolicitudCompra)
                    {
                        var objMigracion = new Documento();

                        objMigracion.Empresa = "CORPORACION MAYO";
                        objMigracion.Tipo = "Solicitud de Compra";
                        objMigracion.Numeracion = "";
                        objMigracion.Fecha = objSolicitudCompra.FechaContable;
                        objMigracion.Estado = "Pendiente";
                        objMigracion.FechaMigracion = null;

                        lstMigracion.Add(objMigracion);
                    }
                }

                this.dgvMigraciones.DataSource = lstMigracion;


                this.btnSincronizar.Enabled = true;
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private Company ConexionSAP(BE.Configuracion beConfiguracion)
        {
            try
            {
                var oCompany = new Company();

                oCompany.Server = beConfiguracion.Servidor;
                oCompany.LicenseServer = beConfiguracion.LicenciaSAP;
                oCompany.CompanyDB = beConfiguracion.BaseDatos;
                oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2008; //configuracion.TipoBD
                oCompany.DbUserName = beConfiguracion.UsuarioBD;
                oCompany.DbPassword = beConfiguracion.ClaveBD;
                oCompany.UserName = beConfiguracion.UsuarioSAP;
                oCompany.Password = beConfiguracion.ClaveSAP;
                oCompany.language = BoSuppLangs.ln_Spanish_La; //Español

                int retCode = oCompany.Connect();
                if (retCode != 0)
                {
                    int codErr = 0;
                    string msgErr = "";
                    oCompany.GetLastError(out codErr, out msgErr);
                    throw new Exception($"{codErr} - {msgErr}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SalidaAlmacen(BE.SalidaAlmacen beSalidaAlmacen, Company oCompany)
        {
            string docEntry = "";

            try
            {
                Documents oSalidaAlmacen = oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

                oSalidaAlmacen.Series = beSalidaAlmacen.Serie;

                oSalidaAlmacen.DocDate = beSalidaAlmacen.FechaContable;
                oSalidaAlmacen.TaxDate = beSalidaAlmacen.FechaContable;
                oSalidaAlmacen.DocDueDate = beSalidaAlmacen.FechaCreacion;

                oSalidaAlmacen.Comments = beSalidaAlmacen.Comentario;

                oSalidaAlmacen.PaymentGroupCode = -1;

                oSalidaAlmacen.UserFields.Fields.Item("U_EXX_NOMBENEFE").Value = beSalidaAlmacen.Usuario;

                int linea = 0;
                foreach (var beSalidaAlmacenDetalle in beSalidaAlmacen.Detalle)
                {
                    if (linea > 0)
                        oSalidaAlmacen.Add();

                    oSalidaAlmacen.Lines.ItemCode = beSalidaAlmacenDetalle.Codigo;
                    oSalidaAlmacen.Lines.ItemDescription = beSalidaAlmacenDetalle.Descripcion;
                    oSalidaAlmacen.Lines.Quantity = beSalidaAlmacenDetalle.Cantidad;

                    oSalidaAlmacen.Lines.Price = beSalidaAlmacenDetalle.Precio;
                    oSalidaAlmacen.Lines.UnitPrice = beSalidaAlmacenDetalle.Precio;

                    oSalidaAlmacen.Lines.TaxCode = beSalidaAlmacenDetalle.CodImpuesto;
                    oSalidaAlmacen.Lines.Currency = beSalidaAlmacenDetalle.CodMoneda;

                    oSalidaAlmacen.Lines.WarehouseCode = beSalidaAlmacenDetalle.CodAlmacen;

                    oSalidaAlmacen.Lines.AccountCode = beSalidaAlmacenDetalle.CodCuentaContable;

                    oSalidaAlmacen.Lines.CostingCode = beSalidaAlmacenDetalle.CodCentroCosto;
                    //oSalidaAlmacen.Lines.ProjectCode = beSalidaAlmacenDetalle.CodProyecto;
                }


                int retCode = oSalidaAlmacen.Add();
                if (retCode != 0)
                {
                    int codErr = 0;
                    string msgErr = "";
                    oCompany.GetLastError(out codErr, out msgErr);
                    throw new Exception($"{codErr} - {msgErr}");
                }

                docEntry = oCompany.GetNewObjectKey();

                return docEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string EntradaAlmacen(BE.EntradaAlmacen beEntradaAlmacen, Company oCompany)
        {
            string docEntry = "";

            try
            {
                Documents oSalidaAlmacen = oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

                oSalidaAlmacen.Series = beEntradaAlmacen.Serie;

                oSalidaAlmacen.DocDate = beEntradaAlmacen.FechaContable;
                oSalidaAlmacen.TaxDate = beEntradaAlmacen.FechaContable;
                oSalidaAlmacen.DocDueDate = beEntradaAlmacen.FechaCreacion;

                oSalidaAlmacen.Comments = beEntradaAlmacen.Comentario;

                oSalidaAlmacen.PaymentGroupCode = -1;

                oSalidaAlmacen.UserFields.Fields.Item("U_EXX_NOMBENEFE").Value = beEntradaAlmacen.Usuario;

                int linea = 0;
                foreach (var beSalidaAlmacenDetalle in beEntradaAlmacen.Detalle)
                {
                    if (linea > 0)
                        oSalidaAlmacen.Add();

                    oSalidaAlmacen.Lines.ItemCode = beSalidaAlmacenDetalle.Codigo;
                    oSalidaAlmacen.Lines.ItemDescription = beSalidaAlmacenDetalle.Descripcion;
                    oSalidaAlmacen.Lines.Quantity = beSalidaAlmacenDetalle.Cantidad;

                    oSalidaAlmacen.Lines.Price = beSalidaAlmacenDetalle.Precio;
                    oSalidaAlmacen.Lines.UnitPrice = beSalidaAlmacenDetalle.Precio;

                    oSalidaAlmacen.Lines.TaxCode = beSalidaAlmacenDetalle.CodImpuesto;
                    oSalidaAlmacen.Lines.Currency = beSalidaAlmacenDetalle.CodMoneda;

                    oSalidaAlmacen.Lines.WarehouseCode = beSalidaAlmacenDetalle.CodAlmacen;

                    oSalidaAlmacen.Lines.AccountCode = beSalidaAlmacenDetalle.CodCuentaContable;

                    oSalidaAlmacen.Lines.CostingCode = beSalidaAlmacenDetalle.CodCentroCosto;
                    //oSalidaAlmacen.Lines.ProjectCode = beSalidaAlmacenDetalle.CodProyecto;
                }


                int retCode = oSalidaAlmacen.Add();
                if (retCode != 0)
                {
                    int codErr = 0;
                    string msgErr = "";
                    oCompany.GetLastError(out codErr, out msgErr);
                    throw new Exception($"{codErr} - {msgErr}");
                }

                docEntry = oCompany.GetNewObjectKey();

                return docEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstMigracion.Count == 0)
                    return;


                /*
                var oCompany = new Company();

                oCompany.Server = "SRVMAYO1";
                oCompany.LicenseServer = "192.168.1.10:30000";
                oCompany.CompanyDB = "SBO_PRUEBACMAYO19072017";
                oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                oCompany.DbUserName = "sa";
                oCompany.DbPassword = "Sapb1admin";
                oCompany.UserName = "manager";
                oCompany.Password = "m1r1";
                oCompany.language = BoSuppLangs.ln_Spanish_La;

                int retCode = oCompany.Connect();
                if (retCode != 0)
                {
                    int codErr = 0;
                    string msgErr = "";
                    oCompany.GetLastError(out codErr, out msgErr);
                    throw new Exception(msgErr);
                }

                //var lstSalidaAlmacen = new BD.SalidaAlmacen(this.cnxStrBD).Listar();

                Documents oSalidaAlmacen = oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                oSalidaAlmacen.Series = 266;
                oSalidaAlmacen.DocDate = DateTime.Now;
                oSalidaAlmacen.TaxDate = DateTime.Now;
                oSalidaAlmacen.DocDueDate = DateTime.Now;
                oSalidaAlmacen.Comments = "Prueba Directa";
                oSalidaAlmacen.PaymentGroupCode = -1;

                oSalidaAlmacen.Lines.ItemCode = "OBR00000021";
                oSalidaAlmacen.Lines.ItemDescription = "PETROLEO DB5";
                oSalidaAlmacen.Lines.Quantity = 7.585;
                oSalidaAlmacen.Lines.Price = 9.940600;
                oSalidaAlmacen.Lines.UnitPrice = 9.940600;
                oSalidaAlmacen.Lines.TaxCode = "IGV";
                oSalidaAlmacen.Lines.Currency = "SOL";
                oSalidaAlmacen.Lines.WarehouseCode = "01";
                oSalidaAlmacen.Lines.AccountCode = "_SYS00000003579";
                oSalidaAlmacen.Lines.CostingCode = "6.03.003";

                retCode = oSalidaAlmacen.Add();
                if (retCode != 0)
                {
                    int codErr = 0;
                    string msgErr = "";
                    oCompany.GetLastError(out codErr, out msgErr);
                    throw new Exception(msgErr);
                }
                else
                {
                    string docEntry = oCompany.GetNewObjectKey();
                }
                */

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
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
