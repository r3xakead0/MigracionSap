using System;
using System.Collections.Generic;
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

        private List<Planificacion> lstUiPlanificaciones = null;

        public FrmPlanificacion()
        {
            InitializeComponent();

            this.lstUiPlanificaciones = new List<Planificacion>();
        }

        private void FrmPlanificacion_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarDias();

                this.dtpHora.Value = DateTime.Now;

                this.CargarPlanificaciones();
                this.FormatoPlanificacioness();

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

                var plan = new BE.Planificacion();
                plan.Id = 0;
                plan.Dia = this.cboDia.SelectedIndex;
                plan.Hora = this.dtpHora.Value;

                bool rpta = new BD.Planificacion().Insertar(ref plan);
                if (rpta)
                {
                    this.CargarPlanificaciones();
                }

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
                if (this.dgvPlanificaciones.CurrentRow != null)
                {
                    var uiPlanificacion = (Planificacion)this.dgvPlanificaciones.CurrentRow.DataBoundItem;

                    bool rpta = new BD.Planificacion().Eliminar(uiPlanificacion.Id);
                    if (rpta)
                    {
                        this.CargarPlanificaciones();
                    }
                }
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }

        }

        private void CargarDias()
        {
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    string dia = General.GetNameOfDay(i);
                    this.cboDia.Items.Add(dia);
                }
                this.cboDia.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarPlanificaciones()
        {
            try
            {
                this.lstUiPlanificaciones = new List<Planificacion>();

                var lstBePlanificacion = new BD.Planificacion().Listar();
                foreach (var bePlanificacion in lstBePlanificacion)
                {
                    var uiPlanificacion = new Planificacion();

                    uiPlanificacion.Id = bePlanificacion.Id;
                    uiPlanificacion.Dia = General.GetNameOfDay(bePlanificacion.Dia);
                    uiPlanificacion.Hora = bePlanificacion.Hora.TimeOfDay;

                    this.lstUiPlanificaciones.Add(uiPlanificacion);
                }

                this.dgvPlanificaciones.DataSource = this.lstUiPlanificaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoPlanificacioness()
        {
            try
            {
                General.FormatDatagridview(ref this.dgvPlanificaciones);

                for (int i = 0; i < this.dgvPlanificaciones.Columns.Count; i++)
                    this.dgvPlanificaciones.Columns[i].Visible = false;

                this.dgvPlanificaciones.Columns["Dia"].Visible = true;
                this.dgvPlanificaciones.Columns["Dia"].HeaderText = "Dia";
                this.dgvPlanificaciones.Columns["Dia"].Width = 100;
                this.dgvPlanificaciones.Columns["Dia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPlanificaciones.Columns["Hora"].Visible = true;
                this.dgvPlanificaciones.Columns["Hora"].HeaderText = "Hora";
                this.dgvPlanificaciones.Columns["Hora"].Width = 80;
                this.dgvPlanificaciones.Columns["Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                General.AutoWidthColumn(ref this.dgvPlanificaciones, "Dia");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmPlanificacion_Resize(object sender, EventArgs e)
        {
            try
            {
                General.AutoWidthColumn(ref this.dgvPlanificaciones, "Dia");
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
        }
    }
}
