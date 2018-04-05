using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BD = MigracionSap.Cliente.BaseDatos;

namespace MigracionSap.Cliente
{
    public partial class FrmSolicitudCompra : Form
    {

        #region "Patron Singleton"

        private static FrmSolicitudCompra frmInstance = null;

        public static FrmSolicitudCompra Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmSolicitudCompra();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private List<DetalleCompra> lsUitDetalleCompra = new List<DetalleCompra>();

        public FrmSolicitudCompra()
        {
            InitializeComponent();
        }
      
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void FrmSolicitudCompra_Load(object sender, EventArgs e)
        {

        }

        public void Cargar(int idSolicitudCompra)
        {
            try
            {
                var beSolicitudCompra = new BD.SolicitudCompra().Obtener(idSolicitudCompra);
                if (beSolicitudCompra != null)
                {
                    this.txtUsuarioC.Text = beSolicitudCompra.Usuario;
                    this.txtEmpresa.Text = beSolicitudCompra.Usuario;
                    this.dtpFechaDocumento.Value = beSolicitudCompra.FechaContable;
                    this.txtComentario.Text = beSolicitudCompra.Comentario;

                    this.lsUitDetalleCompra = new List<DetalleCompra>();
                    foreach (var beDetalle in beSolicitudCompra.Detalle)
                    {
                        var uiDetalle = new DetalleCompra();

                        uiDetalle.NroLinea = beDetalle.NroLinea;
                        uiDetalle.Codigo = beDetalle.Codigo;
                        uiDetalle.Descripcion = beDetalle.Descripcion;
                        uiDetalle.Cantidad = beDetalle.Cantidad;
                        uiDetalle.CodAlmacen = beDetalle.CodAlmacen;
                        uiDetalle.DscAlmacen = "";
                        uiDetalle.DscImpuesto = "";
                        uiDetalle.CodCuentaContable = "";
                        uiDetalle.DscCuentaContable = "";
                        uiDetalle.CodProyecto = beDetalle.CodProyecto;
                        uiDetalle.DscProyecto = "";
                        uiDetalle.CodCentroCosto = beDetalle.CodCentroCosto;
                        uiDetalle.DscCentroCosto = "";
                        uiDetalle.CodProyecto = beDetalle.CodProveedor;
                        uiDetalle.DscProyecto = "";

                        this.lsUitDetalleCompra.Add(uiDetalle);
                    }

                    this.dgvDetalle.DataSource = this.lsUitDetalleCompra;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatDetalle()
        {
            try
            {
                General.FormatDatagridview(ref this.dgvDetalle);

                for (int i = 0; i < this.dgvDetalle.Columns.Count; i++)
                    this.dgvDetalle.Columns[i].Visible = false;

                this.dgvDetalle.Columns["NroLinea"].Visible = true;
                this.dgvDetalle.Columns["NroLinea"].HeaderText = "Nro. Linea";
                this.dgvDetalle.Columns["NroLinea"].Width = 100;
                this.dgvDetalle.Columns["NroLinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvDetalle.Columns["Codigo"].Visible = true;
                this.dgvDetalle.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvDetalle.Columns["Codigo"].Width = 150;
                this.dgvDetalle.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvDetalle.Columns["Descripcion"].Visible = true;
                this.dgvDetalle.Columns["Descripcion"].HeaderText = "Descripcion";
                this.dgvDetalle.Columns["Descripcion"].Width = 200;
                this.dgvDetalle.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDetalle.Columns["Cantidad"].Visible = true;
                this.dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
                this.dgvDetalle.Columns["Cantidad"].Width = 100;
                this.dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "N2";

                this.dgvDetalle.Columns["DscCentroCosto"].Visible = true;
                this.dgvDetalle.Columns["DscCentroCosto"].HeaderText = "Centro Costo";
                this.dgvDetalle.Columns["DscCentroCosto"].Width = 200;
                this.dgvDetalle.Columns["DscCentroCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                General.AutoWidthColumn(ref this.dgvDetalle, "Descripcion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
