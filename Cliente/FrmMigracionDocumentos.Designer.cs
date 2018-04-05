namespace MigracionSap.Cliente
{
    partial class FrmMigracionDocumentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMigracionDocumentos));
            this.dgvDocumentosError = new System.Windows.Forms.DataGridView();
            this.tbcMigraciones = new System.Windows.Forms.TabControl();
            this.tbpSincronizar = new System.Windows.Forms.TabPage();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.btnErrores = new System.Windows.Forms.Button();
            this.tbpHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboTiposDocumentos = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.LBLal = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.LBLrangodefechas = new System.Windows.Forms.Label();
            this.stssEstado = new System.Windows.Forms.StatusStrip();
            this.stlMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmConfigurar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfigurarSociedades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfigurarPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.txtHistorial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.btnVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosError)).BeginInit();
            this.tbcMigraciones.SuspendLayout();
            this.tbpSincronizar.SuspendLayout();
            this.tbpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.stssEstado.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocumentosError
            // 
            this.dgvDocumentosError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentosError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentosError.Location = new System.Drawing.Point(6, 120);
            this.dgvDocumentosError.Name = "dgvDocumentosError";
            this.dgvDocumentosError.Size = new System.Drawing.Size(732, 314);
            this.dgvDocumentosError.TabIndex = 0;
            // 
            // tbcMigraciones
            // 
            this.tbcMigraciones.AccessibleName = "";
            this.tbcMigraciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMigraciones.Controls.Add(this.tbpSincronizar);
            this.tbcMigraciones.Controls.Add(this.tbpHistorial);
            this.tbcMigraciones.Location = new System.Drawing.Point(16, 27);
            this.tbcMigraciones.Name = "tbcMigraciones";
            this.tbcMigraciones.SelectedIndex = 0;
            this.tbcMigraciones.Size = new System.Drawing.Size(752, 497);
            this.tbcMigraciones.TabIndex = 1;
            // 
            // tbpSincronizar
            // 
            this.tbpSincronizar.Controls.Add(this.btnEnviar);
            this.tbpSincronizar.Controls.Add(this.btnSincronizar);
            this.tbpSincronizar.Controls.Add(this.btnErrores);
            this.tbpSincronizar.Controls.Add(this.dgvDocumentosError);
            this.tbpSincronizar.Location = new System.Drawing.Point(4, 23);
            this.tbpSincronizar.Name = "tbpSincronizar";
            this.tbpSincronizar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSincronizar.Size = new System.Drawing.Size(744, 470);
            this.tbpSincronizar.TabIndex = 0;
            this.tbpSincronizar.Text = "Sincronizar";
            this.tbpSincronizar.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(119, 440);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(107, 24);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSincronizar.Location = new System.Drawing.Point(631, 6);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(107, 24);
            this.btnSincronizar.TabIndex = 8;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // btnErrores
            // 
            this.btnErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErrores.Location = new System.Drawing.Point(6, 440);
            this.btnErrores.Name = "btnErrores";
            this.btnErrores.Size = new System.Drawing.Size(107, 24);
            this.btnErrores.TabIndex = 5;
            this.btnErrores.Text = "Errores";
            this.btnErrores.UseVisualStyleBackColor = true;
            this.btnErrores.Click += new System.EventHandler(this.btnErrores_Click);
            // 
            // tbpHistorial
            // 
            this.tbpHistorial.Controls.Add(this.btnVer);
            this.tbpHistorial.Controls.Add(this.grpFiltro);
            this.tbpHistorial.Controls.Add(this.label1);
            this.tbpHistorial.Controls.Add(this.txtHistorial);
            this.tbpHistorial.Controls.Add(this.dgvHistorial);
            this.tbpHistorial.Location = new System.Drawing.Point(4, 23);
            this.tbpHistorial.Name = "tbpHistorial";
            this.tbpHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHistorial.Size = new System.Drawing.Size(744, 470);
            this.tbpHistorial.TabIndex = 1;
            this.tbpHistorial.Text = "Historial";
            this.tbpHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(6, 112);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(728, 321);
            this.dgvHistorial.TabIndex = 47;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(597, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(113, 50);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboTiposDocumentos
            // 
            this.cboTiposDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposDocumentos.FormattingEnabled = true;
            this.cboTiposDocumentos.Location = new System.Drawing.Point(147, 54);
            this.cboTiposDocumentos.Name = "cboTiposDocumentos";
            this.cboTiposDocumentos.Size = new System.Drawing.Size(256, 22);
            this.cboTiposDocumentos.TabIndex = 45;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(16, 57);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(87, 14);
            this.lblDocumento.TabIndex = 44;
            this.lblDocumento.Text = "Documento :";
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(290, 26);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(113, 22);
            this.dtpFin.TabIndex = 43;
            // 
            // LBLal
            // 
            this.LBLal.AutoSize = true;
            this.LBLal.Location = new System.Drawing.Point(266, 28);
            this.LBLal.Name = "LBLal";
            this.LBLal.Size = new System.Drawing.Size(18, 14);
            this.LBLal.TabIndex = 42;
            this.LBLal.Text = "al";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(147, 26);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(113, 22);
            this.dtpInicio.TabIndex = 41;
            // 
            // LBLrangodefechas
            // 
            this.LBLrangodefechas.AutoSize = true;
            this.LBLrangodefechas.Location = new System.Drawing.Point(16, 28);
            this.LBLrangodefechas.Name = "LBLrangodefechas";
            this.LBLrangodefechas.Size = new System.Drawing.Size(125, 14);
            this.LBLrangodefechas.TabIndex = 40;
            this.LBLrangodefechas.Text = "Rango De Fechas :";
            // 
            // stssEstado
            // 
            this.stssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlMensaje});
            this.stssEstado.Location = new System.Drawing.Point(0, 540);
            this.stssEstado.Name = "stssEstado";
            this.stssEstado.Size = new System.Drawing.Size(784, 22);
            this.stssEstado.TabIndex = 2;
            this.stssEstado.Text = "statusStrip1";
            // 
            // stlMensaje
            // 
            this.stlMensaje.AutoSize = false;
            this.stlMensaje.Name = "stlMensaje";
            this.stlMensaje.Size = new System.Drawing.Size(600, 17);
            this.stlMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfigurar,
            this.tsmAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmConfigurar
            // 
            this.tsmConfigurar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfigurarSociedades,
            this.tsmConfigurarPlanes});
            this.tsmConfigurar.Name = "tsmConfigurar";
            this.tsmConfigurar.Size = new System.Drawing.Size(76, 20);
            this.tsmConfigurar.Text = "Configurar";
            // 
            // tsmConfigurarSociedades
            // 
            this.tsmConfigurarSociedades.Name = "tsmConfigurarSociedades";
            this.tsmConfigurarSociedades.Size = new System.Drawing.Size(180, 22);
            this.tsmConfigurarSociedades.Text = "Sociedades";
            this.tsmConfigurarSociedades.Click += new System.EventHandler(this.tsmConfigurarSociedades_Click);
            // 
            // tsmConfigurarPlanes
            // 
            this.tsmConfigurarPlanes.Name = "tsmConfigurarPlanes";
            this.tsmConfigurarPlanes.Size = new System.Drawing.Size(180, 22);
            this.tsmConfigurarPlanes.Text = "Plan de Ejecuciones";
            this.tsmConfigurarPlanes.Click += new System.EventHandler(this.tsmConfigurarPlanes_Click);
            // 
            // tsmAyuda
            // 
            this.tsmAyuda.Name = "tsmAyuda";
            this.tsmAyuda.Size = new System.Drawing.Size(53, 20);
            this.tsmAyuda.Text = "Ayuda";
            // 
            // txtHistorial
            // 
            this.txtHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHistorial.Location = new System.Drawing.Point(670, 442);
            this.txtHistorial.Name = "txtHistorial";
            this.txtHistorial.Size = new System.Drawing.Size(64, 22);
            this.txtHistorial.TabIndex = 48;
            this.txtHistorial.Text = "0";
            this.txtHistorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 49;
            this.label1.Text = "Nro. Registros :";
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.LBLrangodefechas);
            this.grpFiltro.Controls.Add(this.dtpInicio);
            this.grpFiltro.Controls.Add(this.LBLal);
            this.grpFiltro.Controls.Add(this.dtpFin);
            this.grpFiltro.Controls.Add(this.btnBuscar);
            this.grpFiltro.Controls.Add(this.lblDocumento);
            this.grpFiltro.Controls.Add(this.cboTiposDocumentos);
            this.grpFiltro.Location = new System.Drawing.Point(8, 9);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(726, 97);
            this.grpFiltro.TabIndex = 50;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtro";
            // 
            // btnVer
            // 
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVer.Location = new System.Drawing.Point(6, 439);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(107, 24);
            this.btnVer.TabIndex = 51;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            // 
            // FrmMigracionDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.stssEstado);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tbcMigraciones);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMigracionDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migracion De Documentos";
            this.Load += new System.EventHandler(this.FrmMigracionDocumentos_Load);
            this.Resize += new System.EventHandler(this.FrmMigracionDocumentos_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosError)).EndInit();
            this.tbcMigraciones.ResumeLayout(false);
            this.tbpSincronizar.ResumeLayout(false);
            this.tbpHistorial.ResumeLayout(false);
            this.tbpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.stssEstado.ResumeLayout(false);
            this.stssEstado.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocumentosError;
        private System.Windows.Forms.TabControl tbcMigraciones;
        private System.Windows.Forms.TabPage tbpSincronizar;
        private System.Windows.Forms.TabPage tbpHistorial;
        private System.Windows.Forms.Button btnErrores;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label LBLrangodefechas;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label LBLal;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboTiposDocumentos;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.StatusStrip stssEstado;
        private System.Windows.Forms.ToolStripStatusLabel stlMensaje;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmConfigurar;
        private System.Windows.Forms.ToolStripMenuItem tsmConfigurarSociedades;
        private System.Windows.Forms.ToolStripMenuItem tsmConfigurarPlanes;
        private System.Windows.Forms.ToolStripMenuItem tsmAyuda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHistorial;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.Button btnVer;
    }
}