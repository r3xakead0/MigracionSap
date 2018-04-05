namespace MigracionSap.Cliente
{
    partial class FrmSolicitudCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSolicitudCompra));
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblSolicitante = new System.Windows.Forms.Label();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.txtUsuarioC = new System.Windows.Forms.TextBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblFechaDocumento = new System.Windows.Forms.Label();
            this.dtpFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaRequerida = new System.Windows.Forms.Label();
            this.dtpFechaRequerida = new System.Windows.Forms.DateTimePicker();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(19, 16);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(42, 14);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo :";
            // 
            // lblSolicitante
            // 
            this.lblSolicitante.AutoSize = true;
            this.lblSolicitante.Location = new System.Drawing.Point(19, 72);
            this.lblSolicitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolicitante.Name = "lblSolicitante";
            this.lblSolicitante.Size = new System.Drawing.Size(81, 14);
            this.lblSolicitante.TabIndex = 5;
            this.lblSolicitante.Text = "Solicitante :";
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Location = new System.Drawing.Point(19, 100);
            this.lblComentarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(96, 14);
            this.lblComentarios.TabIndex = 6;
            this.lblComentarios.Text = "Comentarios :";
            // 
            // txtUsuarioCodigo
            // 
            this.txtUsuarioC.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuarioC.Location = new System.Drawing.Point(131, 69);
            this.txtUsuarioC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioC.Name = "txtUsuarioCodigo";
            this.txtUsuarioC.ReadOnly = true;
            this.txtUsuarioC.Size = new System.Drawing.Size(107, 22);
            this.txtUsuarioC.TabIndex = 8;
            this.txtUsuarioC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentario.BackColor = System.Drawing.SystemColors.Window;
            this.txtComentario.Location = new System.Drawing.Point(131, 97);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ReadOnly = true;
            this.txtComentario.Size = new System.Drawing.Size(728, 64);
            this.txtComentario.TabIndex = 10;
            // 
            // lblFechaDocumento
            // 
            this.lblFechaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaDocumento.AutoSize = true;
            this.lblFechaDocumento.Location = new System.Drawing.Point(619, 16);
            this.lblFechaDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaDocumento.Name = "lblFechaDocumento";
            this.lblFechaDocumento.Size = new System.Drawing.Size(53, 14);
            this.lblFechaDocumento.TabIndex = 11;
            this.lblFechaDocumento.Text = "Fecha :";
            // 
            // dtpFechaDocumento
            // 
            this.dtpFechaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDocumento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDocumento.Enabled = false;
            this.dtpFechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDocumento.Location = new System.Drawing.Point(732, 13);
            this.dtpFechaDocumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpFechaDocumento.Name = "dtpFechaDocumento";
            this.dtpFechaDocumento.Size = new System.Drawing.Size(127, 22);
            this.dtpFechaDocumento.TabIndex = 12;
            // 
            // lblFechaRequerida
            // 
            this.lblFechaRequerida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaRequerida.AutoSize = true;
            this.lblFechaRequerida.Location = new System.Drawing.Point(619, 72);
            this.lblFechaRequerida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaRequerida.Name = "lblFechaRequerida";
            this.lblFechaRequerida.Size = new System.Drawing.Size(80, 14);
            this.lblFechaRequerida.TabIndex = 14;
            this.lblFechaRequerida.Text = "Requerido :";
            // 
            // dtpFechaRequerida
            // 
            this.dtpFechaRequerida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaRequerida.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaRequerida.Enabled = false;
            this.dtpFechaRequerida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaRequerida.Location = new System.Drawing.Point(732, 69);
            this.dtpFechaRequerida.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpFechaRequerida.Name = "dtpFechaRequerida";
            this.dtpFechaRequerida.Size = new System.Drawing.Size(127, 22);
            this.dtpFechaRequerida.TabIndex = 15;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(17, 177);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(842, 222);
            this.dgvDetalle.TabIndex = 16;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Enabled = false;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Servicios",
            "Articulos"});
            this.cboTipo.Location = new System.Drawing.Point(131, 13);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(323, 22);
            this.cboTipo.TabIndex = 17;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(807, 361);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(9, 4);
            this.checkedListBox1.TabIndex = 18;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(752, 405);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 24);
            this.btnCerrar.TabIndex = 31;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(19, 44);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(71, 14);
            this.lblEmpresa.TabIndex = 33;
            this.lblEmpresa.Text = "Empresa :";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmpresa.Location = new System.Drawing.Point(131, 41);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(728, 22);
            this.txtEmpresa.TabIndex = 32;
            // 
            // FrmSolicitudCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 441);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.dtpFechaRequerida);
            this.Controls.Add(this.lblFechaRequerida);
            this.Controls.Add(this.dtpFechaDocumento);
            this.Controls.Add(this.lblFechaDocumento);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.txtUsuarioC);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.lblSolicitante);
            this.Controls.Add(this.lblTipo);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmSolicitudCompra";
            this.Text = "Solicitud de Compra";
            this.Load += new System.EventHandler(this.FrmSolicitudCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblSolicitante;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.TextBox txtUsuarioC;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblFechaDocumento;
        private System.Windows.Forms.DateTimePicker dtpFechaDocumento;
        private System.Windows.Forms.Label lblFechaRequerida;
        private System.Windows.Forms.DateTimePicker dtpFechaRequerida;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
    }
}

