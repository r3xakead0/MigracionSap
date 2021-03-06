﻿namespace MigracionSap.Cliente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMigracionDocumentos));
            this.dgvDocumentosError = new System.Windows.Forms.DataGridView();
            this.tbcMigraciones = new System.Windows.Forms.TabControl();
            this.tbpSincronizar = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSincronizar = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDocumentos = new System.Windows.Forms.ComboBox();
            this.txtUltimaSincronizacion = new System.Windows.Forms.TextBox();
            this.lblSociedad = new System.Windows.Forms.Label();
            this.cboSociedades = new System.Windows.Forms.ComboBox();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumentosError = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnErrores = new System.Windows.Forms.Button();
            this.tbpHistorial = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.LBLrangodefechas = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.LBLal = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.cboTiposDocumentos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHistorial = new System.Windows.Forms.TextBox();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.stssEstado = new System.Windows.Forms.StatusStrip();
            this.stlMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmConfigurar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfigurarSociedades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfigurarEjecuciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAyudaInformacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMigracion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosError)).BeginInit();
            this.tbcMigraciones.SuspendLayout();
            this.tbpSincronizar.SuspendLayout();
            this.grpSincronizar.SuspendLayout();
            this.tbpHistorial.SuspendLayout();
            this.grpFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.stssEstado.SuspendLayout();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocumentosError
            // 
            this.dgvDocumentosError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentosError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentosError.Location = new System.Drawing.Point(8, 123);
            this.dgvDocumentosError.Name = "dgvDocumentosError";
            this.dgvDocumentosError.Size = new System.Drawing.Size(726, 313);
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
            this.tbpSincronizar.Controls.Add(this.label5);
            this.tbpSincronizar.Controls.Add(this.grpSincronizar);
            this.tbpSincronizar.Controls.Add(this.label2);
            this.tbpSincronizar.Controls.Add(this.txtDocumentosError);
            this.tbpSincronizar.Controls.Add(this.btnEnviar);
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(726, 14);
            this.label5.TabIndex = 58;
            this.label5.Text = "Lista de Documentos con Errores";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpSincronizar
            // 
            this.grpSincronizar.Controls.Add(this.label3);
            this.grpSincronizar.Controls.Add(this.label4);
            this.grpSincronizar.Controls.Add(this.cboDocumentos);
            this.grpSincronizar.Controls.Add(this.txtUltimaSincronizacion);
            this.grpSincronizar.Controls.Add(this.lblSociedad);
            this.grpSincronizar.Controls.Add(this.cboSociedades);
            this.grpSincronizar.Controls.Add(this.btnSincronizar);
            this.grpSincronizar.Location = new System.Drawing.Point(8, 6);
            this.grpSincronizar.Name = "grpSincronizar";
            this.grpSincronizar.Size = new System.Drawing.Size(726, 97);
            this.grpSincronizar.TabIndex = 56;
            this.grpSincronizar.TabStop = false;
            this.grpSincronizar.Text = "Filtro de Sincronización";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(437, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 22);
            this.label3.TabIndex = 59;
            this.label3.Text = "Última Sincronización";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 14);
            this.label4.TabIndex = 56;
            this.label4.Text = "Documento :";
            // 
            // cboDocumentos
            // 
            this.cboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentos.Enabled = false;
            this.cboDocumentos.FormattingEnabled = true;
            this.cboDocumentos.Location = new System.Drawing.Point(147, 54);
            this.cboDocumentos.Name = "cboDocumentos";
            this.cboDocumentos.Size = new System.Drawing.Size(271, 22);
            this.cboDocumentos.TabIndex = 57;
            // 
            // txtUltimaSincronizacion
            // 
            this.txtUltimaSincronizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUltimaSincronizacion.Location = new System.Drawing.Point(437, 55);
            this.txtUltimaSincronizacion.Name = "txtUltimaSincronizacion";
            this.txtUltimaSincronizacion.ReadOnly = true;
            this.txtUltimaSincronizacion.Size = new System.Drawing.Size(162, 22);
            this.txtUltimaSincronizacion.TabIndex = 52;
            this.txtUltimaSincronizacion.TabStop = false;
            this.txtUltimaSincronizacion.Text = "dd/MM/yyyyy HH:mm:ss";
            this.txtUltimaSincronizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSociedad
            // 
            this.lblSociedad.AutoSize = true;
            this.lblSociedad.Location = new System.Drawing.Point(20, 28);
            this.lblSociedad.Name = "lblSociedad";
            this.lblSociedad.Size = new System.Drawing.Size(73, 14);
            this.lblSociedad.TabIndex = 54;
            this.lblSociedad.Text = "Sociedad :";
            // 
            // cboSociedades
            // 
            this.cboSociedades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSociedades.Enabled = false;
            this.cboSociedades.FormattingEnabled = true;
            this.cboSociedades.Location = new System.Drawing.Point(147, 26);
            this.cboSociedades.Name = "cboSociedades";
            this.cboSociedades.Size = new System.Drawing.Size(271, 22);
            this.cboSociedades.TabIndex = 55;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSincronizar.Image = ((System.Drawing.Image)(resources.GetObject("btnSincronizar.Image")));
            this.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSincronizar.Location = new System.Drawing.Point(614, 26);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(96, 50);
            this.btnSincronizar.TabIndex = 8;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 51;
            this.label2.Text = "Nro. Registros :";
            // 
            // txtDocumentosError
            // 
            this.txtDocumentosError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentosError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentosError.Location = new System.Drawing.Point(670, 442);
            this.txtDocumentosError.Name = "txtDocumentosError";
            this.txtDocumentosError.ReadOnly = true;
            this.txtDocumentosError.Size = new System.Drawing.Size(64, 22);
            this.txtDocumentosError.TabIndex = 50;
            this.txtDocumentosError.Text = "0";
            this.txtDocumentosError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.Location = new System.Drawing.Point(121, 440);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(107, 24);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnErrores
            // 
            this.btnErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErrores.Image = ((System.Drawing.Image)(resources.GetObject("btnErrores.Image")));
            this.btnErrores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnErrores.Location = new System.Drawing.Point(8, 440);
            this.btnErrores.Name = "btnErrores";
            this.btnErrores.Size = new System.Drawing.Size(107, 24);
            this.btnErrores.TabIndex = 5;
            this.btnErrores.Text = "Errores";
            this.btnErrores.UseVisualStyleBackColor = true;
            this.btnErrores.Click += new System.EventHandler(this.btnErrores_Click);
            // 
            // tbpHistorial
            // 
            this.tbpHistorial.Controls.Add(this.label6);
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
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Navy;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(726, 14);
            this.label6.TabIndex = 59;
            this.label6.Text = "Lista de Documentos Migrados";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVer
            // 
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVer.Location = new System.Drawing.Point(8, 439);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(107, 24);
            this.btnVer.TabIndex = 51;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
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
            this.grpFiltro.Location = new System.Drawing.Point(8, 6);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(726, 97);
            this.grpFiltro.TabIndex = 50;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtro de Busqueda";
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
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(147, 26);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(113, 22);
            this.dtpInicio.TabIndex = 41;
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
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(290, 26);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(113, 22);
            this.dtpFin.TabIndex = 43;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(614, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 50);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            // cboTiposDocumentos
            // 
            this.cboTiposDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposDocumentos.FormattingEnabled = true;
            this.cboTiposDocumentos.Location = new System.Drawing.Point(147, 54);
            this.cboTiposDocumentos.Name = "cboTiposDocumentos";
            this.cboTiposDocumentos.Size = new System.Drawing.Size(256, 22);
            this.cboTiposDocumentos.TabIndex = 45;
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
            // txtHistorial
            // 
            this.txtHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHistorial.Location = new System.Drawing.Point(670, 442);
            this.txtHistorial.Name = "txtHistorial";
            this.txtHistorial.ReadOnly = true;
            this.txtHistorial.Size = new System.Drawing.Size(64, 22);
            this.txtHistorial.TabIndex = 48;
            this.txtHistorial.Text = "0";
            this.txtHistorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(8, 123);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(726, 313);
            this.dgvHistorial.TabIndex = 47;
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
            this.stlMensaje.Size = new System.Drawing.Size(700, 17);
            this.stlMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfigurar,
            this.tsmAyuda});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(784, 24);
            this.mnuPrincipal.TabIndex = 3;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // tsmConfigurar
            // 
            this.tsmConfigurar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfigurarSociedades,
            this.tsmConfigurarEjecuciones});
            this.tsmConfigurar.Name = "tsmConfigurar";
            this.tsmConfigurar.Size = new System.Drawing.Size(76, 20);
            this.tsmConfigurar.Text = "&Configurar";
            // 
            // tsmConfigurarSociedades
            // 
            this.tsmConfigurarSociedades.Image = ((System.Drawing.Image)(resources.GetObject("tsmConfigurarSociedades.Image")));
            this.tsmConfigurarSociedades.Name = "tsmConfigurarSociedades";
            this.tsmConfigurarSociedades.Size = new System.Drawing.Size(136, 22);
            this.tsmConfigurarSociedades.Text = "S&ociedades";
            this.tsmConfigurarSociedades.Click += new System.EventHandler(this.tsmConfigurarSociedades_Click);
            // 
            // tsmConfigurarEjecuciones
            // 
            this.tsmConfigurarEjecuciones.Image = ((System.Drawing.Image)(resources.GetObject("tsmConfigurarEjecuciones.Image")));
            this.tsmConfigurarEjecuciones.Name = "tsmConfigurarEjecuciones";
            this.tsmConfigurarEjecuciones.Size = new System.Drawing.Size(136, 22);
            this.tsmConfigurarEjecuciones.Text = "E&jecuciones";
            this.tsmConfigurarEjecuciones.Click += new System.EventHandler(this.tsmConfigurarPlanes_Click);
            // 
            // tsmAyuda
            // 
            this.tsmAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAyudaInformacion});
            this.tsmAyuda.Name = "tsmAyuda";
            this.tsmAyuda.Size = new System.Drawing.Size(53, 20);
            this.tsmAyuda.Text = "&Ayuda";
            // 
            // tsmAyudaInformacion
            // 
            this.tsmAyudaInformacion.Image = ((System.Drawing.Image)(resources.GetObject("tsmAyudaInformacion.Image")));
            this.tsmAyudaInformacion.Name = "tsmAyudaInformacion";
            this.tsmAyudaInformacion.Size = new System.Drawing.Size(139, 22);
            this.tsmAyudaInformacion.Text = "I&nformación";
            // 
            // tmrMigracion
            // 
            this.tmrMigracion.Enabled = true;
            this.tmrMigracion.Interval = 60000;
            this.tmrMigracion.Tick += new System.EventHandler(this.tmrMigracion_Tick);
            // 
            // FrmMigracionDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.stssEstado);
            this.Controls.Add(this.mnuPrincipal);
            this.Controls.Add(this.tbcMigraciones);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuPrincipal;
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
            this.tbpSincronizar.PerformLayout();
            this.grpSincronizar.ResumeLayout(false);
            this.grpSincronizar.PerformLayout();
            this.tbpHistorial.ResumeLayout(false);
            this.tbpHistorial.PerformLayout();
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.stssEstado.ResumeLayout(false);
            this.stssEstado.PerformLayout();
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
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
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmConfigurar;
        private System.Windows.Forms.ToolStripMenuItem tsmConfigurarSociedades;
        private System.Windows.Forms.ToolStripMenuItem tsmConfigurarEjecuciones;
        private System.Windows.Forms.ToolStripMenuItem tsmAyuda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHistorial;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumentosError;
        private System.Windows.Forms.TextBox txtUltimaSincronizacion;
        private System.Windows.Forms.Label lblSociedad;
        private System.Windows.Forms.ComboBox cboSociedades;
        private System.Windows.Forms.GroupBox grpSincronizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDocumentos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem tsmAyudaInformacion;
        private System.Windows.Forms.Timer tmrMigracion;
    }
}