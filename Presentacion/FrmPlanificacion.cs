using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Cliente.BaseDatos;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente
{
    public partial class FrmPlanificacion : Form
    {

        #region "Patron Singleton"

        private static FrmPlanificacion frmInstance = null;

        public static FrmPlanificacion Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmPlanificacion();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmPlanificacion()
        {
            InitializeComponent();
        }

        private void FrmPlanificacion_Load(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 1; i < 8; i++)
                {
                    string dia = General.GetNameOfDay(i);
                    this.cboDia.Items.Add(dia);
                }
                this.cboDia.SelectedIndex = 0;

                this.dtpHora.Value = DateTime.Now;

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
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
