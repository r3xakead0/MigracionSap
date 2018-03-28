using System;
using System.Windows.Forms;

namespace MigracionSap.Presentacion
{
    public partial class FrmSolicitudCompra : Form
    {
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
