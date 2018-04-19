namespace MigracionSap.Cliente
{
    partial class FrmPlanificacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanificacion));
            this.lblHora = new System.Windows.Forms.Label();
            this.grpPlan = new System.Windows.Forms.GroupBox();
            this.dgvPlanificaciones = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboDia = new System.Windows.Forms.ComboBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.chkTemporizador = new System.Windows.Forms.CheckBox();
            this.dudMinutos = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(205, 24);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(46, 14);
            this.lblHora.TabIndex = 34;
            this.lblHora.Text = "Hora :";
            // 
            // grpPlan
            // 
            this.grpPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPlan.Controls.Add(this.dgvPlanificaciones);
            this.grpPlan.Controls.Add(this.label5);
            this.grpPlan.Controls.Add(this.btnQuitar);
            this.grpPlan.Controls.Add(this.dtpHora);
            this.grpPlan.Controls.Add(this.btnAgregar);
            this.grpPlan.Controls.Add(this.cboDia);
            this.grpPlan.Controls.Add(this.lblDia);
            this.grpPlan.Controls.Add(this.lblHora);
            this.grpPlan.Location = new System.Drawing.Point(12, 36);
            this.grpPlan.Name = "grpPlan";
            this.grpPlan.Size = new System.Drawing.Size(364, 304);
            this.grpPlan.TabIndex = 40;
            this.grpPlan.TabStop = false;
            this.grpPlan.Text = "Planificador";
            // 
            // dgvPlanificaciones
            // 
            this.dgvPlanificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlanificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanificaciones.Location = new System.Drawing.Point(6, 97);
            this.dgvPlanificaciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPlanificaciones.Name = "dgvPlanificaciones";
            this.dgvPlanificaciones.Size = new System.Drawing.Size(351, 171);
            this.dgvPlanificaciones.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(351, 14);
            this.label5.TabIndex = 59;
            this.label5.Text = "Lista de Planes";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitar.Location = new System.Drawing.Point(6, 274);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(351, 24);
            this.btnQuitar.TabIndex = 44;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dtpHora
            // 
            this.dtpHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHora.CustomFormat = "HH.mm:ss";
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(258, 21);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(99, 22);
            this.dtpHora.TabIndex = 42;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(6, 49);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(351, 24);
            this.btnAgregar.TabIndex = 43;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboDia
            // 
            this.cboDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDia.FormattingEnabled = true;
            this.cboDia.Location = new System.Drawing.Point(51, 21);
            this.cboDia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboDia.Name = "cboDia";
            this.cboDia.Size = new System.Drawing.Size(136, 22);
            this.cboDia.TabIndex = 41;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(7, 24);
            this.lblDia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(36, 14);
            this.lblDia.TabIndex = 40;
            this.lblDia.Text = "Dia :";
            // 
            // chkTemporizador
            // 
            this.chkTemporizador.AutoSize = true;
            this.chkTemporizador.Location = new System.Drawing.Point(18, 11);
            this.chkTemporizador.Name = "chkTemporizador";
            this.chkTemporizador.Size = new System.Drawing.Size(112, 18);
            this.chkTemporizador.TabIndex = 41;
            this.chkTemporizador.Text = "Temporizador";
            this.chkTemporizador.UseVisualStyleBackColor = true;
            this.chkTemporizador.CheckedChanged += new System.EventHandler(this.chkTemporizador_CheckedChanged);
            // 
            // dudMinutos
            // 
            this.dudMinutos.Location = new System.Drawing.Point(152, 10);
            this.dudMinutos.Name = "dudMinutos";
            this.dudMinutos.Size = new System.Drawing.Size(47, 22);
            this.dudMinutos.TabIndex = 42;
            this.dudMinutos.Text = "0";
            this.dudMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 60;
            this.label1.Text = "minutos";
            // 
            // FrmPlanificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dudMinutos);
            this.Controls.Add(this.chkTemporizador);
            this.Controls.Add(this.grpPlan);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlanificacion";
            this.Text = "Configurar de Ejecuciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlanificacion_FormClosing);
            this.Load += new System.EventHandler(this.FrmPlanificacion_Load);
            this.Resize += new System.EventHandler(this.FrmPlanificacion_Resize);
            this.grpPlan.ResumeLayout(false);
            this.grpPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.GroupBox grpPlan;
        private System.Windows.Forms.ComboBox cboDia;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.DataGridView dgvPlanificaciones;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkTemporizador;
        private System.Windows.Forms.DomainUpDown dudMinutos;
        private System.Windows.Forms.Label label1;
    }
}

