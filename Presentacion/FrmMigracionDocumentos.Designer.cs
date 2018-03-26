namespace MigracionSap.Presentacion
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
            this.dgvSincronizar = new System.Windows.Forms.DataGridView();
            this.tbcSincronizar = new System.Windows.Forms.TabControl();
            this.tbpSincronizar = new System.Windows.Forms.TabPage();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnErrores = new System.Windows.Forms.Button();
            this.tbpHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboTiposDocumentos = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.dtpFisn = new System.Windows.Forms.DateTimePicker();
            this.LBLal = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.LBLrangodefechas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSincronizar)).BeginInit();
            this.tbcSincronizar.SuspendLayout();
            this.tbpSincronizar.SuspendLayout();
            this.tbpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSincronizar
            // 
            this.dgvSincronizar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSincronizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSincronizar.Location = new System.Drawing.Point(6, 6);
            this.dgvSincronizar.Name = "dgvSincronizar";
            this.dgvSincronizar.Size = new System.Drawing.Size(947, 343);
            this.dgvSincronizar.TabIndex = 0;
            // 
            // tbcSincronizar
            // 
            this.tbcSincronizar.AccessibleName = "";
            this.tbcSincronizar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcSincronizar.Controls.Add(this.tbpSincronizar);
            this.tbcSincronizar.Controls.Add(this.tbpHistorial);
            this.tbcSincronizar.Location = new System.Drawing.Point(16, 13);
            this.tbcSincronizar.Name = "tbcSincronizar";
            this.tbcSincronizar.SelectedIndex = 0;
            this.tbcSincronizar.Size = new System.Drawing.Size(967, 412);
            this.tbcSincronizar.TabIndex = 1;
            // 
            // tbpSincronizar
            // 
            this.tbpSincronizar.Controls.Add(this.btnEnviar);
            this.tbpSincronizar.Controls.Add(this.btnRecibir);
            this.tbpSincronizar.Controls.Add(this.btnVisualizar);
            this.tbpSincronizar.Controls.Add(this.btnErrores);
            this.tbpSincronizar.Controls.Add(this.dgvSincronizar);
            this.tbpSincronizar.Location = new System.Drawing.Point(4, 23);
            this.tbpSincronizar.Name = "tbpSincronizar";
            this.tbpSincronizar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSincronizar.Size = new System.Drawing.Size(959, 385);
            this.tbpSincronizar.TabIndex = 0;
            this.tbpSincronizar.Text = "Sincronizar";
            this.tbpSincronizar.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.Location = new System.Drawing.Point(119, 355);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(107, 24);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnRecibir
            // 
            this.btnRecibir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecibir.Location = new System.Drawing.Point(6, 355);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(107, 24);
            this.btnRecibir.TabIndex = 8;
            this.btnRecibir.Text = "Recibir";
            this.btnRecibir.UseVisualStyleBackColor = true;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Location = new System.Drawing.Point(846, 355);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(107, 24);
            this.btnVisualizar.TabIndex = 6;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnErrores
            // 
            this.btnErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErrores.Location = new System.Drawing.Point(733, 355);
            this.btnErrores.Name = "btnErrores";
            this.btnErrores.Size = new System.Drawing.Size(107, 24);
            this.btnErrores.TabIndex = 5;
            this.btnErrores.Text = "Errores";
            this.btnErrores.UseVisualStyleBackColor = true;
            // 
            // tbpHistorial
            // 
            this.tbpHistorial.Controls.Add(this.dgvHistorial);
            this.tbpHistorial.Controls.Add(this.btnBuscar);
            this.tbpHistorial.Controls.Add(this.cboTiposDocumentos);
            this.tbpHistorial.Controls.Add(this.lblDocumento);
            this.tbpHistorial.Controls.Add(this.dtpFisn);
            this.tbpHistorial.Controls.Add(this.LBLal);
            this.tbpHistorial.Controls.Add(this.dtpInicio);
            this.tbpHistorial.Controls.Add(this.LBLrangodefechas);
            this.tbpHistorial.Location = new System.Drawing.Point(4, 23);
            this.tbpHistorial.Name = "tbpHistorial";
            this.tbpHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHistorial.Size = new System.Drawing.Size(959, 385);
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
            this.dgvHistorial.Location = new System.Drawing.Point(8, 38);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(941, 341);
            this.dgvHistorial.TabIndex = 47;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(836, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(113, 24);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // cboTiposDocumentos
            // 
            this.cboTiposDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposDocumentos.FormattingEnabled = true;
            this.cboTiposDocumentos.Location = new System.Drawing.Point(551, 9);
            this.cboTiposDocumentos.Name = "cboTiposDocumentos";
            this.cboTiposDocumentos.Size = new System.Drawing.Size(256, 22);
            this.cboTiposDocumentos.TabIndex = 45;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(420, 12);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(87, 14);
            this.lblDocumento.TabIndex = 44;
            this.lblDocumento.Text = "Documento :";
            // 
            // dtpFisn
            // 
            this.dtpFisn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFisn.Location = new System.Drawing.Point(280, 10);
            this.dtpFisn.Name = "dtpFisn";
            this.dtpFisn.Size = new System.Drawing.Size(113, 22);
            this.dtpFisn.TabIndex = 43;
            // 
            // LBLal
            // 
            this.LBLal.AutoSize = true;
            this.LBLal.Location = new System.Drawing.Point(256, 12);
            this.LBLal.Name = "LBLal";
            this.LBLal.Size = new System.Drawing.Size(18, 14);
            this.LBLal.TabIndex = 42;
            this.LBLal.Text = "al";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(137, 10);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(113, 22);
            this.dtpInicio.TabIndex = 41;
            // 
            // LBLrangodefechas
            // 
            this.LBLrangodefechas.AutoSize = true;
            this.LBLrangodefechas.Location = new System.Drawing.Point(6, 12);
            this.LBLrangodefechas.Name = "LBLrangodefechas";
            this.LBLrangodefechas.Size = new System.Drawing.Size(125, 14);
            this.LBLrangodefechas.TabIndex = 40;
            this.LBLrangodefechas.Text = "Rango De Fechas :";
            // 
            // FrmMigracionDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 438);
            this.Controls.Add(this.tbcSincronizar);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMigracionDocumentos";
            this.Text = "Migracion De Documentos";
            this.Load += new System.EventHandler(this.FrmMigracionDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSincronizar)).EndInit();
            this.tbcSincronizar.ResumeLayout(false);
            this.tbpSincronizar.ResumeLayout(false);
            this.tbpHistorial.ResumeLayout(false);
            this.tbpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSincronizar;
        private System.Windows.Forms.TabControl tbcSincronizar;
        private System.Windows.Forms.TabPage tbpSincronizar;
        private System.Windows.Forms.TabPage tbpHistorial;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnErrores;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label LBLrangodefechas;
        private System.Windows.Forms.DateTimePicker dtpFisn;
        private System.Windows.Forms.Label LBLal;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboTiposDocumentos;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnRecibir;
    }
}