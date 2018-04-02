namespace MigracionSap.Cliente
{
    partial class FrmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.lbServidor = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.txtNombreBD = new System.Windows.Forms.TextBox();
            this.lblNombreBD = new System.Windows.Forms.Label();
            this.txtUsuarioBD = new System.Windows.Forms.TextBox();
            this.lblUsuarioBD = new System.Windows.Forms.Label();
            this.grpBaseDatos = new System.Windows.Forms.GroupBox();
            this.cboTipoBD = new System.Windows.Forms.ComboBox();
            this.lblTipoBD = new System.Windows.Forms.Label();
            this.lblClaveBD = new System.Windows.Forms.Label();
            this.txtClaveBD = new System.Windows.Forms.TextBox();
            this.grpLicencia = new System.Windows.Forms.GroupBox();
            this.lblClaveSBO = new System.Windows.Forms.Label();
            this.txtClaveSBO = new System.Windows.Forms.TextBox();
            this.lblLicenciaSBO = new System.Windows.Forms.Label();
            this.txtLicenciaSBO = new System.Windows.Forms.TextBox();
            this.lblUsuarioSBO = new System.Windows.Forms.Label();
            this.txtUsuarioSBO = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEmpresa = new System.Windows.Forms.Button();
            this.grpBaseDatos.SuspendLayout();
            this.grpLicencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbServidor
            // 
            this.lbServidor.AutoSize = true;
            this.lbServidor.Location = new System.Drawing.Point(19, 43);
            this.lbServidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbServidor.Name = "lbServidor";
            this.lbServidor.Size = new System.Drawing.Size(68, 14);
            this.lbServidor.TabIndex = 22;
            this.lbServidor.Text = "Servidor :";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(19, 16);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(71, 14);
            this.lblEmpresa.TabIndex = 21;
            this.lblEmpresa.Text = "Empresa :";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(245, 355);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 24);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.SystemColors.Window;
            this.txtServidor.Location = new System.Drawing.Point(131, 40);
            this.txtServidor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.ReadOnly = true;
            this.txtServidor.Size = new System.Drawing.Size(323, 22);
            this.txtServidor.TabIndex = 32;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.Enabled = false;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Items.AddRange(new object[] {
            "Servicios",
            "Articulos"});
            this.cboEmpresa.Location = new System.Drawing.Point(131, 12);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(294, 22);
            this.cboEmpresa.TabIndex = 33;
            // 
            // txtNombreBD
            // 
            this.txtNombreBD.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombreBD.Location = new System.Drawing.Point(119, 49);
            this.txtNombreBD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombreBD.Name = "txtNombreBD";
            this.txtNombreBD.ReadOnly = true;
            this.txtNombreBD.Size = new System.Drawing.Size(297, 22);
            this.txtNombreBD.TabIndex = 35;
            // 
            // lblNombreBD
            // 
            this.lblNombreBD.AutoSize = true;
            this.lblNombreBD.Location = new System.Drawing.Point(17, 52);
            this.lblNombreBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreBD.Name = "lblNombreBD";
            this.lblNombreBD.Size = new System.Drawing.Size(65, 14);
            this.lblNombreBD.TabIndex = 34;
            this.lblNombreBD.Text = "Nombre :";
            // 
            // txtUsuarioBD
            // 
            this.txtUsuarioBD.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuarioBD.Location = new System.Drawing.Point(119, 77);
            this.txtUsuarioBD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioBD.Name = "txtUsuarioBD";
            this.txtUsuarioBD.ReadOnly = true;
            this.txtUsuarioBD.Size = new System.Drawing.Size(297, 22);
            this.txtUsuarioBD.TabIndex = 37;
            // 
            // lblUsuarioBD
            // 
            this.lblUsuarioBD.AutoSize = true;
            this.lblUsuarioBD.Location = new System.Drawing.Point(17, 80);
            this.lblUsuarioBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioBD.Name = "lblUsuarioBD";
            this.lblUsuarioBD.Size = new System.Drawing.Size(64, 14);
            this.lblUsuarioBD.TabIndex = 36;
            this.lblUsuarioBD.Text = "Usuario :";
            // 
            // grpBaseDatos
            // 
            this.grpBaseDatos.Controls.Add(this.cboTipoBD);
            this.grpBaseDatos.Controls.Add(this.lblTipoBD);
            this.grpBaseDatos.Controls.Add(this.lblClaveBD);
            this.grpBaseDatos.Controls.Add(this.txtClaveBD);
            this.grpBaseDatos.Controls.Add(this.lblNombreBD);
            this.grpBaseDatos.Controls.Add(this.txtNombreBD);
            this.grpBaseDatos.Controls.Add(this.lblUsuarioBD);
            this.grpBaseDatos.Controls.Add(this.txtUsuarioBD);
            this.grpBaseDatos.Location = new System.Drawing.Point(22, 208);
            this.grpBaseDatos.Name = "grpBaseDatos";
            this.grpBaseDatos.Size = new System.Drawing.Size(432, 141);
            this.grpBaseDatos.TabIndex = 40;
            this.grpBaseDatos.TabStop = false;
            this.grpBaseDatos.Text = "Base de Datos";
            // 
            // cboTipoBD
            // 
            this.cboTipoBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBD.Enabled = false;
            this.cboTipoBD.FormattingEnabled = true;
            this.cboTipoBD.Items.AddRange(new object[] {
            "Servicios",
            "Articulos"});
            this.cboTipoBD.Location = new System.Drawing.Point(119, 21);
            this.cboTipoBD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboTipoBD.Name = "cboTipoBD";
            this.cboTipoBD.Size = new System.Drawing.Size(297, 22);
            this.cboTipoBD.TabIndex = 41;
            // 
            // lblTipoBD
            // 
            this.lblTipoBD.AutoSize = true;
            this.lblTipoBD.Location = new System.Drawing.Point(17, 24);
            this.lblTipoBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoBD.Name = "lblTipoBD";
            this.lblTipoBD.Size = new System.Drawing.Size(42, 14);
            this.lblTipoBD.TabIndex = 40;
            this.lblTipoBD.Text = "Tipo :";
            // 
            // lblClaveBD
            // 
            this.lblClaveBD.AutoSize = true;
            this.lblClaveBD.Location = new System.Drawing.Point(17, 108);
            this.lblClaveBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClaveBD.Name = "lblClaveBD";
            this.lblClaveBD.Size = new System.Drawing.Size(51, 14);
            this.lblClaveBD.TabIndex = 38;
            this.lblClaveBD.Text = "Clave :";
            // 
            // txtClaveBD
            // 
            this.txtClaveBD.BackColor = System.Drawing.SystemColors.Window;
            this.txtClaveBD.Location = new System.Drawing.Point(119, 105);
            this.txtClaveBD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtClaveBD.Name = "txtClaveBD";
            this.txtClaveBD.PasswordChar = '*';
            this.txtClaveBD.ReadOnly = true;
            this.txtClaveBD.Size = new System.Drawing.Size(297, 22);
            this.txtClaveBD.TabIndex = 39;
            // 
            // grpLicencia
            // 
            this.grpLicencia.Controls.Add(this.lblClaveSBO);
            this.grpLicencia.Controls.Add(this.txtClaveSBO);
            this.grpLicencia.Controls.Add(this.lblLicenciaSBO);
            this.grpLicencia.Controls.Add(this.txtLicenciaSBO);
            this.grpLicencia.Controls.Add(this.lblUsuarioSBO);
            this.grpLicencia.Controls.Add(this.txtUsuarioSBO);
            this.grpLicencia.Location = new System.Drawing.Point(22, 77);
            this.grpLicencia.Name = "grpLicencia";
            this.grpLicencia.Size = new System.Drawing.Size(432, 113);
            this.grpLicencia.TabIndex = 42;
            this.grpLicencia.TabStop = false;
            this.grpLicencia.Text = "Licencia SBO";
            // 
            // lblClaveSBO
            // 
            this.lblClaveSBO.AutoSize = true;
            this.lblClaveSBO.Location = new System.Drawing.Point(17, 80);
            this.lblClaveSBO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClaveSBO.Name = "lblClaveSBO";
            this.lblClaveSBO.Size = new System.Drawing.Size(51, 14);
            this.lblClaveSBO.TabIndex = 38;
            this.lblClaveSBO.Text = "Clave :";
            // 
            // txtClaveSBO
            // 
            this.txtClaveSBO.BackColor = System.Drawing.SystemColors.Window;
            this.txtClaveSBO.Location = new System.Drawing.Point(119, 77);
            this.txtClaveSBO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtClaveSBO.Name = "txtClaveSBO";
            this.txtClaveSBO.PasswordChar = '*';
            this.txtClaveSBO.ReadOnly = true;
            this.txtClaveSBO.Size = new System.Drawing.Size(297, 22);
            this.txtClaveSBO.TabIndex = 39;
            // 
            // lblLicenciaSBO
            // 
            this.lblLicenciaSBO.AutoSize = true;
            this.lblLicenciaSBO.Location = new System.Drawing.Point(17, 24);
            this.lblLicenciaSBO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenciaSBO.Name = "lblLicenciaSBO";
            this.lblLicenciaSBO.Size = new System.Drawing.Size(65, 14);
            this.lblLicenciaSBO.TabIndex = 34;
            this.lblLicenciaSBO.Text = "Nombre :";
            // 
            // txtLicenciaSBO
            // 
            this.txtLicenciaSBO.BackColor = System.Drawing.SystemColors.Window;
            this.txtLicenciaSBO.Location = new System.Drawing.Point(119, 21);
            this.txtLicenciaSBO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLicenciaSBO.Name = "txtLicenciaSBO";
            this.txtLicenciaSBO.ReadOnly = true;
            this.txtLicenciaSBO.Size = new System.Drawing.Size(297, 22);
            this.txtLicenciaSBO.TabIndex = 35;
            // 
            // lblUsuarioSBO
            // 
            this.lblUsuarioSBO.AutoSize = true;
            this.lblUsuarioSBO.Location = new System.Drawing.Point(17, 52);
            this.lblUsuarioSBO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioSBO.Name = "lblUsuarioSBO";
            this.lblUsuarioSBO.Size = new System.Drawing.Size(64, 14);
            this.lblUsuarioSBO.TabIndex = 36;
            this.lblUsuarioSBO.Text = "Usuario :";
            // 
            // txtUsuarioSBO
            // 
            this.txtUsuarioSBO.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuarioSBO.Location = new System.Drawing.Point(119, 49);
            this.txtUsuarioSBO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioSBO.Name = "txtUsuarioSBO";
            this.txtUsuarioSBO.ReadOnly = true;
            this.txtUsuarioSBO.Size = new System.Drawing.Size(297, 22);
            this.txtUsuarioSBO.TabIndex = 37;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(358, 355);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(107, 24);
            this.btnGuardar.TabIndex = 43;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmpresa.Location = new System.Drawing.Point(432, 12);
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Size = new System.Drawing.Size(22, 22);
            this.btnEmpresa.TabIndex = 44;
            this.btnEmpresa.Text = "+";
            this.btnEmpresa.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 391);
            this.Controls.Add(this.btnEmpresa);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grpLicencia);
            this.Controls.Add(this.grpBaseDatos);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lbServidor);
            this.Controls.Add(this.lblEmpresa);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracion";
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.grpBaseDatos.ResumeLayout(false);
            this.grpBaseDatos.PerformLayout();
            this.grpLicencia.ResumeLayout(false);
            this.grpLicencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbServidor;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.TextBox txtNombreBD;
        private System.Windows.Forms.Label lblNombreBD;
        private System.Windows.Forms.TextBox txtUsuarioBD;
        private System.Windows.Forms.Label lblUsuarioBD;
        private System.Windows.Forms.GroupBox grpBaseDatos;
        private System.Windows.Forms.Label lblClaveBD;
        private System.Windows.Forms.TextBox txtClaveBD;
        private System.Windows.Forms.ComboBox cboTipoBD;
        private System.Windows.Forms.Label lblTipoBD;
        private System.Windows.Forms.GroupBox grpLicencia;
        private System.Windows.Forms.Label lblClaveSBO;
        private System.Windows.Forms.TextBox txtClaveSBO;
        private System.Windows.Forms.Label lblLicenciaSBO;
        private System.Windows.Forms.TextBox txtLicenciaSBO;
        private System.Windows.Forms.Label lblUsuarioSBO;
        private System.Windows.Forms.TextBox txtUsuarioSBO;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEmpresa;
    }
}

