using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Presentacion.BaseDatos;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion
{
    public partial class FrmEntradaAlmacen : Form
    {

        #region "Patron Singleton"

        private static FrmEntradaAlmacen frmInstance = null;

        public static FrmEntradaAlmacen Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmEntradaAlmacen();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private string cnxStrBD = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        private List<DetalleAlmacen> lstDetalle = new List<DetalleAlmacen>();

        public FrmEntradaAlmacen()
        {
            InitializeComponent();
        }

        private void FrmEntradaAlmacen_Load(object sender, EventArgs e)
        {
            try
            {

                this.lstDetalle = new List<DetalleAlmacen>();
                this.dgvDetalle.DataSource = this.lstDetalle;
                this.FormatDetalle();

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        public void Cargar(int idSalidaAlmacen)
        {
            try
            {
                var beSalidaAlmacen = new BD.SalidaAlmacen().Obtener(idSalidaAlmacen);
                if (beSalidaAlmacen != null)
                {
                    this.txtUsuarioCodigo.Text = beSalidaAlmacen.Usuario;
                    this.txtUsuarioNombre.Text = beSalidaAlmacen.Usuario;
                    this.dtpFechaDocumento.Value = beSalidaAlmacen.FechaContable;
                    this.txtComentario.Text = beSalidaAlmacen.Comentario;

                    this.lstDetalle = new List<DetalleAlmacen>();
                    foreach (var beDetalle in beSalidaAlmacen.Detalle)
                    {
                        var detalle = new DetalleAlmacen();

                        detalle.NroLinea = beDetalle.NroLinea;
                        detalle.Codigo = beDetalle.Codigo;
                        detalle.Descripcion = beDetalle.Descripcion;
                        detalle.Cantidad = beDetalle.Cantidad;
                        detalle.CodAlmacen = beDetalle.CodAlmacen;
                        detalle.DscAlmacen = "";
                        detalle.CodImpuesto = beDetalle.CodImpuesto;
                        detalle.DscImpuesto = "";
                        detalle.CodCuentaContable = "";
                        detalle.DscCuentaContable = "";
                        detalle.NroCuentaContable = beDetalle.CodCuentaContable;
                        detalle.CodProyecto = beDetalle.CodProyecto;
                        detalle.DscProyecto = "";
                        detalle.CodCentroCosto = beDetalle.CodCentroCosto;
                        detalle.DscCentroCosto = "";

                        this.lstDetalle.Add(detalle);
                    }

                    this.dgvDetalle.DataSource = this.lstDetalle;
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
    }
}
