using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using BD = MigracionSap.Cliente.BaseDatos;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente
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

            this.configuracion = new BE.Configuracion();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarTiposBD();

                this.CargarEmpresas();

                var beEmpresa = (BE.Empresa)this.cboEmpresa.SelectedItem;
                if (beEmpresa != null)
                    this.CargarConfiguracion(beEmpresa.Id);
                
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

                #region Validaciones 

                var beEmpresa = (BE.Empresa)this.cboEmpresa.SelectedItem;
                if (beEmpresa == null)
                {
                    this.cboEmpresa.Focus();
                    General.CriticalMessage("Seleccione una Empresa");
                    return;
                }

                if (this.txtServidor.Text.Trim().Length == 0)
                {
                    this.txtServidor.Focus();
                    General.CriticalMessage("Ingrese una Servidor");
                    return;
                }

                if (this.txtLicenciaSBO.Text.Trim().Length == 0)
                {
                    this.txtLicenciaSBO.Focus();
                    General.CriticalMessage("Ingrese una Servidor de Licencia");
                    return;
                }

                if (this.txtUsuarioSBO.Text.Trim().Length == 0)
                {
                    this.txtUsuarioSBO.Focus();
                    General.CriticalMessage("Ingrese un Usuario de SBO");
                    return;
                }

                if (this.txtClaveSBO.Text.Trim().Length == 0)
                {
                    this.txtClaveSBO.Focus();
                    General.CriticalMessage("Ingrese una Clave de SBO");
                    return;
                }

                if (this.txtNombreBD.Text.Trim().Length == 0)
                {
                    this.txtNombreBD.Focus();
                    General.CriticalMessage("Ingrese una Base de Datos");
                    return;
                }

                if (this.txtUsuarioBD.Text.Trim().Length == 0)
                {
                    this.txtUsuarioBD.Focus();
                    General.CriticalMessage("Ingrese un Usuario de BD");
                    return;
                }

                if (this.txtClaveSBO.Text.Trim().Length == 0)
                {
                    this.txtClaveSBO.Focus();
                    General.CriticalMessage("Ingrese una Clave de BD");
                    return;
                }

                #endregion

                if (this.configuracion != null)
                    this.configuracion = new BE.Configuracion();

                this.configuracion.Empresa = beEmpresa;

                this.configuracion.Servidor = this.txtServidor.Text;

                this.configuracion.LicenciaSAP = this.txtLicenciaSBO.Text;
                this.configuracion.UsuarioSAP = this.txtUsuarioSBO.Text;
                this.configuracion.ClaveSAP = this.txtClaveSBO.Text;

                //this.configuracion.TipoBD = int.Parse(this.cboTipoBD.SelectedValue);

                this.configuracion.BaseDatos = this.txtNombreBD.Text;
                this.configuracion.UsuarioBD = this.txtUsuarioBD.Text;
                this.configuracion.ClaveBD = this.txtClaveSBO.Text;

                bool rpta = false;
                if (this.configuracion.Id == 0)
                {
                    rpta = new BD.Configuracion().Insertar(ref this.configuracion);
                }
                else
                {
                    rpta = new BD.Configuracion().Actualizar(this.configuracion);
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

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                var frmEmpresa = FrmEmpresa.Instance();
                frmEmpresa.StartPosition = FormStartPosition.CenterScreen;
                frmEmpresa.Show();
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void cboEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var beEmpresa = (BE.Empresa)this.cboEmpresa.SelectedItem;
                if (beEmpresa != null)
                    this.CargarConfiguracion(beEmpresa.Id);
                
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }

        private void CargarConfiguracion(int idEmpresa)
        {
            try
            {
                this.configuracion = new BD.Configuracion().Obtener(idEmpresa);

                if (this.configuracion != null)
                {

                    this.txtServidor.Text = this.configuracion.Servidor;

                    this.txtServidor.Text = this.configuracion.LicenciaSAP;
                    this.txtUsuarioSBO.Text = this.configuracion.UsuarioSAP;
                    this.txtClaveSBO.Text = this.configuracion.ClaveSAP;

                    //this.configuracion.TipoBD = int.Parse(this.cboTipoBD.SelectedValue.ToString());

                    this.txtNombreBD.Text = this.configuracion.BaseDatos;
                    this.txtUsuarioBD.Text = this.configuracion.UsuarioBD;
                    this.txtClaveSBO.Text = this.configuracion.ClaveBD;
                }
                else
                {
                    this.txtServidor.Clear();

                    this.txtServidor.Clear();
                    this.txtUsuarioSBO.Clear();
                    this.txtClaveSBO.Clear(); ;

                    this.cboTipoBD.SelectedIndex = 0;

                    this.txtNombreBD.Clear();
                    this.txtUsuarioBD.Clear();
                    this.txtClaveSBO.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpresas()
        {
            try
            {
                var lstBeEmpresa = new BD.Empresa().Listar();
                this.cboEmpresa.DataSource = lstBeEmpresa;
                this.cboEmpresa.DisplayMember = "Nombre";
                this.cboEmpresa.ValueMember = "Id";

                this.cboEmpresa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposBD()
        {
            try
            {

                this.cboTipoBD.Items.Add("MSSQL 2008");

                this.cboTipoBD.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
