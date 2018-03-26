using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Presentacion.BaseDatos;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;
using WS = MigracionSap.Presentacion.ServicioWeb;

namespace MigracionSap.Presentacion
{
    public partial class FrmMigracionDocumentos : Form
    {

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
                this.dgvSincronizar.DataSource = this.lstMigracion;
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

        private List<BE.SalidaAlmacen> ObtenerSalidasAlmacen()
        {
            var lstSalidaAlmacen = new List<BE.SalidaAlmacen>();
            try
            {

                string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";

                var lstSalidaAlmacenJson = new WS.wsSalida().Obtener();

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
                        beSalidaAlmacenDetalle.NroCuentaContable = "";
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

        private List<BE.EntradaAlmacen> ObtenerEntradasAlmacen()
        {
            var lstEntradaAlmacen = new List<BE.EntradaAlmacen>();
            try
            {

                string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";

                var lstEntradaAlmacenJson = new WS.wsEntrada().Obtener();

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

        private List<BE.SolicitudCompra> ObtenerSolicitudCompra()
        {
            var lstSolicitudCompra = new List<BE.SolicitudCompra>();
            try
            {

                string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";

                var lstSolicitudCompraJson = new WS.wsSolicitud().Obtener();

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
                this.btnRecibir.Enabled = false;

                bool rpta = false;
                var lstMigracion = new List<Documento>();

                var lstSalidaAlmacen = this.ObtenerSalidasAlmacen();
                rpta = new BD.SalidaAlmacen(this.cnxStrBD).Insertar(ref lstSalidaAlmacen);
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

                var lstEntradaAlmacen = this.ObtenerEntradasAlmacen();
                rpta = new BD.EntradaAlmacen(this.cnxStrBD).Insertar(ref lstEntradaAlmacen);
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

                var lstSolicitudCompra = this.ObtenerSolicitudCompra();
                rpta = new BD.SolicitudCompra(this.cnxStrBD).Insertar(ref lstSolicitudCompra);
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

                this.dgvSincronizar.DataSource = lstMigracion;


                this.btnRecibir.Enabled = true;
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
                if (this.lstMigracion.Count == 0)
                    return;



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
                General.FormatDatagridview(ref this.dgvSincronizar);

                for (int i = 0; i < this.dgvSincronizar.Columns.Count; i++)
                    this.dgvSincronizar.Columns[i].Visible = false;

                this.dgvSincronizar.Columns["Empresa"].Visible = true;
                this.dgvSincronizar.Columns["Empresa"].HeaderText = "Empresa";
                this.dgvSincronizar.Columns["Empresa"].Width = 200;
                this.dgvSincronizar.Columns["Empresa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSincronizar.Columns["Tipo"].Visible = true;
                this.dgvSincronizar.Columns["Tipo"].HeaderText = "Documento";
                this.dgvSincronizar.Columns["Tipo"].Width = 200;
                this.dgvSincronizar.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSincronizar.Columns["Numeracion"].Visible = true;
                this.dgvSincronizar.Columns["Numeracion"].HeaderText = "Numeracion";
                this.dgvSincronizar.Columns["Numeracion"].Width = 150;
                this.dgvSincronizar.Columns["Numeracion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvSincronizar.Columns["Fecha"].Visible = true;
                this.dgvSincronizar.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvSincronizar.Columns["Fecha"].Width = 100;
                this.dgvSincronizar.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvSincronizar.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvSincronizar.Columns["Estado"].Visible = true;
                this.dgvSincronizar.Columns["Estado"].HeaderText = "Estado";
                this.dgvSincronizar.Columns["Estado"].Width = 100;
                this.dgvSincronizar.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                General.AutoWidthColumn(ref this.dgvSincronizar, "Empresa");
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

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }
    }
}
