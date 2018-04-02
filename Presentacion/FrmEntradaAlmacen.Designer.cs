namespace MigracionSap.Cliente
{
    partial class FrmEntradaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntradaAlmacen));
            this.dtpFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDocumento = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.txtUsuarioCodigo = new System.Windows.Forms.TextBox();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.lblSolicitante = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtNroOrden = new System.Windows.Forms.TextBox();
            this.lblNroOrden = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaDocumento
            // 
            this.dtpFechaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDocumento.Enabled = false;
            this.dtpFechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDocumento.Location = new System.Drawing.Point(731, 13);
            this.dtpFechaDocumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpFechaDocumento.Name = "dtpFechaDocumento";
            this.dtpFechaDocumento.Size = new System.Drawing.Size(127, 22);
            this.dtpFechaDocumento.TabIndex = 28;
            // 
            // lblFechaDocumento
            // 
            this.lblFechaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaDocumento.AutoSize = true;
            this.lblFechaDocumento.Location = new System.Drawing.Point(619, 15);
            this.lblFechaDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaDocumento.Name = "lblFechaDocumento";
            this.lblFechaDocumento.Size = new System.Drawing.Size(53, 14);
            this.lblFechaDocumento.TabIndex = 27;
            this.lblFechaDocumento.Text = "Fecha :";
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentario.BackColor = System.Drawing.SystemColors.Window;
            this.txtComentario.Location = new System.Drawing.Point(131, 41);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ReadOnly = true;
            this.txtComentario.Size = new System.Drawing.Size(727, 60);
            this.txtComentario.TabIndex = 26;
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuarioNombre.Location = new System.Drawing.Point(267, 13);
            this.txtUsuarioNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.ReadOnly = true;
            this.txtUsuarioNombre.Size = new System.Drawing.Size(292, 22);
            this.txtUsuarioNombre.TabIndex = 25;
            // 
            // txtUsuarioCodigo
            // 
            this.txtUsuarioCodigo.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuarioCodigo.Location = new System.Drawing.Point(131, 13);
            this.txtUsuarioCodigo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioCodigo.Name = "txtUsuarioCodigo";
            this.txtUsuarioCodigo.ReadOnly = true;
            this.txtUsuarioCodigo.Size = new System.Drawing.Size(127, 22);
            this.txtUsuarioCodigo.TabIndex = 24;
            this.txtUsuarioCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Location = new System.Drawing.Point(19, 44);
            this.lblComentarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(96, 14);
            this.lblComentarios.TabIndex = 22;
            this.lblComentarios.Text = "Comentarios :";
            // 
            // lblSolicitante
            // 
            this.lblSolicitante.AutoSize = true;
            this.lblSolicitante.Location = new System.Drawing.Point(19, 16);
            this.lblSolicitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolicitante.Name = "lblSolicitante";
            this.lblSolicitante.Size = new System.Drawing.Size(81, 14);
            this.lblSolicitante.TabIndex = 21;
            this.lblSolicitante.Text = "Solicitante :";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(17, 135);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(842, 259);
            this.dgvDetalle.TabIndex = 29;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(752, 400);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 24);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.BackColor = System.Drawing.SystemColors.Window;
            this.txtNroOrden.Location = new System.Drawing.Point(131, 107);
            this.txtNroOrden.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.ReadOnly = true;
            this.txtNroOrden.Size = new System.Drawing.Size(127, 22);
            this.txtNroOrden.TabIndex = 32;
            this.txtNroOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNroOrden
            // 
            this.lblNroOrden.AutoSize = true;
            this.lblNroOrden.Location = new System.Drawing.Point(19, 110);
            this.lblNroOrden.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroOrden.Name = "lblNroOrden";
            this.lblNroOrden.Size = new System.Drawing.Size(85, 14);
            this.lblNroOrden.TabIndex = 31;
            this.lblNroOrden.Text = "Nro. Orden :";
            // 
            // FrmEntradaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 436);
            this.Controls.Add(this.txtNroOrden);
            this.Controls.Add(this.lblNroOrden);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.dtpFechaDocumento);
            this.Controls.Add(this.lblFechaDocumento);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.txtUsuarioNombre);
            this.Controls.Add(this.txtUsuarioCodigo);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.lblSolicitante);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEntradaAlmacen";
            this.Text = "Entrada de Almacén";
            this.Load += new System.EventHandler(this.FrmEntradaAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaDocumento;
        private System.Windows.Forms.Label lblFechaDocumento;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.TextBox txtUsuarioCodigo;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.Label lblSolicitante;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtNroOrden;
        private System.Windows.Forms.Label lblNroOrden;
    }
}

