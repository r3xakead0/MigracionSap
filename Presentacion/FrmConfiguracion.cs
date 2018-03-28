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

        private BE.Configuracion configuracion = null;

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {

                this.configuracion = new BE.Configuracion();

                this.cboTipoBD.Items.Add("MSSQL 2008");
                this.cboEmpresa.SelectedIndex = 0;

                var lstBeEmpresa = new BD.Empresa().Listar();
                this.cboEmpresa.DataSource = lstBeEmpresa;
                this.cboEmpresa.DisplayMember = "Nombre";
                this.cboEmpresa.ValueMember = "Id";
                
                this.cboEmpresa.SelectedIndex = 0;

                var beEmpresa = (BE.Empresa)this.cboEmpresa.SelectedItem;

                if (beEmpresa != null)
                {
                    configuracion = new BD.Configuracion().Obtener(beEmpresa);
                    if (configuracion != null)
                    {
                        this.txtServidor.Text = configuracion.Servidor;

                        this.txtServidor.Text = configuracion.LicenciaSAP;
                        this.txtUsuarioSBO.Text = configuracion.UsuarioSAP;
                        this.txtClaveSBO.Text = configuracion.ClaveSAP;

                        this.txtNombreBD.Text = configuracion.BaseDatos;
                        this.txtUsuarioBD.Text = configuracion.UsuarioBD;
                        this.txtClaveSBO.Text = configuracion.ClaveBD;
                    }
                }
                

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
