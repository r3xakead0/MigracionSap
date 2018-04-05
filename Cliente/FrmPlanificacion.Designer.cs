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
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboDia = new System.Windows.Forms.ComboBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.dgvPlanificaciones = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.grpPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(17, 52);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(46, 14);
            this.lblHora.TabIndex = 34;
            this.lblHora.Text = "Hora :";
            // 
            // grpPlan
            // 
            this.grpPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPlan.Controls.Add(this.dtpHora);
            this.grpPlan.Controls.Add(this.btnAgregar);
            this.grpPlan.Controls.Add(this.cboDia);
            this.grpPlan.Controls.Add(this.lblDia);
            this.grpPlan.Controls.Add(this.lblHora);
            this.grpPlan.Location = new System.Drawing.Point(12, 12);
            this.grpPlan.Name = "grpPlan";
            this.grpPlan.Size = new System.Drawing.Size(242, 119);
            this.grpPlan.TabIndex = 40;
            this.grpPlan.TabStop = false;
            this.grpPlan.Text = "Plan";
            // 
            // dtpHora
            // 
            this.dtpHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHora.CustomFormat = "HH.mm:ss";
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(119, 49);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(100, 22);
            this.dtpHora.TabIndex = 42;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(20, 77);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(199, 24);
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
            this.cboDia.Items.AddRange(new object[] {
            "Servicios",
            "Articulos"});
            this.cboDia.Location = new System.Drawing.Point(119, 21);
            this.cboDia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboDia.Name = "cboDia";
            this.cboDia.Size = new System.Drawing.Size(100, 22);
            this.cboDia.TabIndex = 41;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(17, 24);
            this.lblDia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(36, 14);
            this.lblDia.TabIndex = 40;
            this.lblDia.Text = "Dia :";
            // 
            // dgvPlanificaciones
            // 
            this.dgvPlanificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlanificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanificaciones.Location = new System.Drawing.Point(12, 137);
            this.dgvPlanificaciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPlanificaciones.Name = "dgvPlanificaciones";
            this.dgvPlanificaciones.Size = new System.Drawing.Size(242, 156);
            this.dgvPlanificaciones.TabIndex = 44;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitar.Location = new System.Drawing.Point(12, 299);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(242, 24);
            this.btnQuitar.TabIndex = 44;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // FrmPlanificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 335);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.dgvPlanificaciones);
            this.Controls.Add(this.grpPlan);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlanificacion";
            this.Text = "Plan de Ejecución";
            this.Load += new System.EventHandler(this.FrmPlanificacion_Load);
            this.Resize += new System.EventHandler(this.FrmPlanificacion_Resize);
            this.grpPlan.ResumeLayout(false);
            this.grpPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanificaciones)).EndInit();
            this.ResumeLayout(false);

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
    }
}

