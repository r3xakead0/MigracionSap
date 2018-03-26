namespace MigracionSap.Presentacion
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
            this.lblNumeracion = new System.Windows.Forms.Label();
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblSolicitante = new System.Windows.Forms.Label();
            this.LblComentarios = new System.Windows.Forms.Label();
            this.TxTNum2 = new System.Windows.Forms.TextBox();
            this.TxtNumeroSolicitante = new System.Windows.Forms.TextBox();
            this.TxtSolicitantenombre = new System.Windows.Forms.TextBox();
            this.TxtComentario = new System.Windows.Forms.TextBox();
            this.LBLFechaDocumento = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.LblFechaREquerida = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.DataGridSolicitudDeCompra = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboBoXTipo = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSolicitudDeCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumeracion
            // 
            this.lblNumeracion.AutoSize = true;
            this.lblNumeracion.Location = new System.Drawing.Point(25, 23);
            this.lblNumeracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeracion.Name = "lblNumeracion";
            this.lblNumeracion.Size = new System.Drawing.Size(90, 14);
            this.lblNumeracion.TabIndex = 2;
            this.lblNumeracion.Text = "Numeracion :";
            this.lblNumeracion.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNum1
            // 
            this.txtNum1.Location = new System.Drawing.Point(127, 19);
            this.txtNum1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.Size = new System.Drawing.Size(107, 22);
            this.txtNum1.TabIndex = 3;
            this.txtNum1.Text = "2018";
            this.txtNum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(25, 54);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(42, 14);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo :";
            this.lblTipo.Click += new System.EventHandler(this.lblTipo_Click);
            // 
            // lblSolicitante
            // 
            this.lblSolicitante.AutoSize = true;
            this.lblSolicitante.Location = new System.Drawing.Point(24, 90);
            this.lblSolicitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolicitante.Name = "lblSolicitante";
            this.lblSolicitante.Size = new System.Drawing.Size(81, 14);
            this.lblSolicitante.TabIndex = 5;
            this.lblSolicitante.Text = "Solicitante :";
            // 
            // LblComentarios
            // 
            this.LblComentarios.AutoSize = true;
            this.LblComentarios.Location = new System.Drawing.Point(16, 128);
            this.LblComentarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblComentarios.Name = "LblComentarios";
            this.LblComentarios.Size = new System.Drawing.Size(96, 14);
            this.LblComentarios.TabIndex = 6;
            this.LblComentarios.Text = "Comentarios :";
            // 
            // TxTNum2
            // 
            this.TxTNum2.Location = new System.Drawing.Point(244, 19);
            this.TxTNum2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxTNum2.Name = "TxTNum2";
            this.TxTNum2.Size = new System.Drawing.Size(205, 22);
            this.TxTNum2.TabIndex = 7;
            this.TxTNum2.Text = "000123";
            this.TxTNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtNumeroSolicitante
            // 
            this.TxtNumeroSolicitante.Location = new System.Drawing.Point(127, 87);
            this.TxtNumeroSolicitante.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtNumeroSolicitante.Name = "TxtNumeroSolicitante";
            this.TxtNumeroSolicitante.Size = new System.Drawing.Size(107, 22);
            this.TxtNumeroSolicitante.TabIndex = 8;
            this.TxtNumeroSolicitante.Text = "USR01";
            this.TxtNumeroSolicitante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtSolicitantenombre
            // 
            this.TxtSolicitantenombre.Location = new System.Drawing.Point(243, 87);
            this.TxtSolicitantenombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSolicitantenombre.Name = "TxtSolicitantenombre";
            this.TxtSolicitantenombre.Size = new System.Drawing.Size(205, 22);
            this.TxtSolicitantenombre.TabIndex = 9;
            this.TxtSolicitantenombre.Text = "Pepito Perz";
            // 
            // TxtComentario
            // 
            this.TxtComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtComentario.Location = new System.Drawing.Point(127, 128);
            this.TxtComentario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtComentario.Multiline = true;
            this.TxtComentario.Name = "TxtComentario";
            this.TxtComentario.Size = new System.Drawing.Size(723, 92);
            this.TxtComentario.TabIndex = 10;
            this.TxtComentario.Text = "Comentarios sobre solicitud de compra de articulos  ";
            // 
            // LBLFechaDocumento
            // 
            this.LBLFechaDocumento.AutoSize = true;
            this.LBLFechaDocumento.Location = new System.Drawing.Point(571, 23);
            this.LBLFechaDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLFechaDocumento.Name = "LBLFechaDocumento";
            this.LBLFechaDocumento.Size = new System.Drawing.Size(128, 14);
            this.LBLFechaDocumento.TabIndex = 11;
            this.LBLFechaDocumento.Text = "Fecha Documento :";
            this.LBLFechaDocumento.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(725, 19);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 22);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // LblFechaREquerida
            // 
            this.LblFechaREquerida.AutoSize = true;
            this.LblFechaREquerida.Location = new System.Drawing.Point(571, 54);
            this.LblFechaREquerida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFechaREquerida.Name = "LblFechaREquerida";
            this.LblFechaREquerida.Size = new System.Drawing.Size(121, 14);
            this.LblFechaREquerida.TabIndex = 14;
            this.LblFechaREquerida.Text = "Fecha Requerida :";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(725, 54);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(111, 22);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // DataGridSolicitudDeCompra
            // 
            this.DataGridSolicitudDeCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridSolicitudDeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSolicitudDeCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Codigo,
            this.Column2,
            this.Column3,
            this.Proveedor,
            this.Column4});
            this.DataGridSolicitudDeCompra.Location = new System.Drawing.Point(9, 247);
            this.DataGridSolicitudDeCompra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DataGridSolicitudDeCompra.Name = "DataGridSolicitudDeCompra";
            this.DataGridSolicitudDeCompra.Size = new System.Drawing.Size(851, 307);
            this.DataGridSolicitudDeCompra.TabIndex = 16;
            this.DataGridSolicitudDeCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSolicitudDeCompra_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Numero Lista";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "        Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "           Descripción";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "        Cantidad";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "            Centro Costo";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "            Proveedor";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // ComboBoXTipo
            // 
            this.ComboBoXTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoXTipo.FormattingEnabled = true;
            this.ComboBoXTipo.Items.AddRange(new object[] {
            "Servicios",
            "Articulos"});
            this.ComboBoXTipo.Location = new System.Drawing.Point(127, 54);
            this.ComboBoXTipo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComboBoXTipo.Name = "ComboBoXTipo";
            this.ComboBoXTipo.Size = new System.Drawing.Size(323, 22);
            this.ComboBoXTipo.TabIndex = 17;
            this.ComboBoXTipo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(807, 361);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(9, 17);
            this.checkedListBox1.TabIndex = 18;
            // 
            // FrmSolicitudCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 566);
            this.Controls.Add(this.DataGridSolicitudDeCompra);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.ComboBoXTipo);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.LblFechaREquerida);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.LBLFechaDocumento);
            this.Controls.Add(this.TxtComentario);
            this.Controls.Add(this.TxtSolicitantenombre);
            this.Controls.Add(this.TxtNumeroSolicitante);
            this.Controls.Add(this.TxTNum2);
            this.Controls.Add(this.LblComentarios);
            this.Controls.Add(this.lblSolicitante);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtNum1);
            this.Controls.Add(this.lblNumeracion);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmSolicitudCompra";
            this.Text = "Solicitud de Compra";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSolicitudDeCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNumeracion;
        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblSolicitante;
        private System.Windows.Forms.Label LblComentarios;
        private System.Windows.Forms.TextBox TxTNum2;
        private System.Windows.Forms.TextBox TxtNumeroSolicitante;
        private System.Windows.Forms.TextBox TxtSolicitantenombre;
        private System.Windows.Forms.TextBox TxtComentario;
        private System.Windows.Forms.Label LBLFechaDocumento;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label LblFechaREquerida;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView DataGridSolicitudDeCompra;
        private System.Windows.Forms.ComboBox ComboBoXTipo;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

