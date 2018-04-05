using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Cliente.BaseDatos;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente
{
    public partial class FrmEmpresa : Form
    {

        #region "Patron Singleton"

        private static FrmEmpresa frmInstance = null;

        public static FrmEmpresa Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmEmpresa();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private BE.Empresa beEmpresa = null;

        public FrmEmpresa()
        {
            InitializeComponent();

            this.beEmpresa = new BE.Empresa();
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            try
            {

                this.txtCodigo.Clear();
                this.txtNombre.Clear();
                this.txtDescripcion.Clear();

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.beEmpresa == null)
                    this.beEmpresa = new BE.Empresa();

                #region Validaciones

                if (this.txtCodigo.Text.Trim().Length == 0)
                {
                    this.txtCodigo.Focus();
                    General.CriticalMessage("Ingrese una Codigo");
                    return;
                }

                int idEmpresa = 0;
                if (int.TryParse(this.txtCodigo.Text.Trim(), out idEmpresa) == false)
                {
                    this.txtCodigo.Focus();
                    General.CriticalMessage("El Codigo debe ser un valor númerico");
                    return;
                }

                if (this.txtNombre.Text.Trim().Length == 0)
                {
                    this.txtNombre.Focus();
                    General.CriticalMessage("Ingrese una Nombre");
                    return;
                }

                #endregion

                this.beEmpresa.Id = idEmpresa;
                this.beEmpresa.Nombre = this.txtNombre.Text.Trim();
                this.beEmpresa.Descripcion = this.txtDescripcion.Text.Trim();

                bool rpta = false;

                var bdEmpresa = new BD.Empresa();
                if (bdEmpresa.Obtener(idEmpresa) == null)
                {
                    rpta = bdEmpresa.Insertar(this.beEmpresa);
                }
                else
                {
                    rpta = bdEmpresa.Actualizar(this.beEmpresa);
                }

                if (rpta)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }
    }
}
