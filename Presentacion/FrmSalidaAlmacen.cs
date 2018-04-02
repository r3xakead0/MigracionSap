using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Cliente.BaseDatos;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente
{
    public partial class FrmSalidaAlmacen : Form
    {

        #region "Patron Singleton"

        private static FrmSalidaAlmacen frmInstance = null;

        public static FrmSalidaAlmacen Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmSalidaAlmacen();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private string cnxStrBD = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        private List<DetalleAlmacen> lstDetalle = new List<DetalleAlmacen>();

        public FrmSalidaAlmacen()
        {
            InitializeComponent();
        }

        private void FrmSalidaAlmacen_Load(object sender, EventArgs e)
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
                    this.txtUsuario.Text = beSalidaAlmacen.Usuario;
                    this.txtEmpresa.Text = beSalidaAlmacen.Usuario;
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
