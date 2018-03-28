using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Presentacion.BaseDatos;
using BE = MigracionSap.Presentacion.BaseDatos.Entidades;

namespace MigracionSap.Presentacion
{
    public partial class FrmConfiguracion : Form
    {

        #region "Patron Singleton"

        private static FrmConfiguracion frmInstance = null;

        public static FrmConfiguracion Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmConfiguracion();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {

                new BD.Empresa().Listar();

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
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

        private void btnGuardar_Click(object sender, EventArgs e)
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
