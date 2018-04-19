using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Cliente.BaseDatos;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente
{
    public partial class FrmErrores : Form
    {

        #region "Patron Singleton"

        private static FrmErrores frmInstance = null;

        public static FrmErrores Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmErrores();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private List<Error> lstError = null;

        public FrmErrores()
        {
            InitializeComponent();
        }

        private void FrmErrorList_Load(object sender, EventArgs e)
        {
            try
            {
                this.lstError = new List<Error>();
                this.dgvErrores.DataSource = this.lstError;
                this.FormatoErrores();
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        public void Cargar(int idTipoDocumento, int idDocumento)
        {
            try
            {
                var lstBeError = new BD.Error().Listar(idTipoDocumento, idDocumento);

                this.lstError = new List<Error>();
                foreach (var beError in lstBeError)
                {
                    var error = new Error();
                    error.Id = beError.Id;
                    error.Mensaje = beError.Mensaje;
                    this.lstError.Add(error);
                }

                this.dgvErrores.DataSource = this.lstError;
                this.txtNroRegistros.Text = this.lstError.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoErrores()
        {
            try
            {
                General.FormatDatagridview(ref this.dgvErrores);

                for (int i = 0; i < this.dgvErrores.Columns.Count; i++)
                    this.dgvErrores.Columns[i].Visible = false;

                this.dgvErrores.Columns["Mensaje"].Visible = true;
                this.dgvErrores.Columns["Mensaje"].HeaderText = "Mensaje";
                this.dgvErrores.Columns["Mensaje"].Width = 200;
                this.dgvErrores.Columns["Mensaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                General.AutoWidthColumn(ref this.dgvErrores, "Mensaje");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmErrorList_Resize(object sender, EventArgs e)
        {
            try
            {
                General.AutoWidthColumn(ref this.dgvErrores, "Mensaje");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
