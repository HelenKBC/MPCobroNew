namespace MPCobro.desktop
{
    partial class ArrendatarioWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrendatarioWF));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersona = new System.Windows.Forms.TabPage();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.lblDui = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.dgvArrendatario = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPersona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrendatario)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersona);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(33, 117);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 371);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPersona
            // 
            this.tabPersona.CausesValidation = false;
            this.tabPersona.Controls.Add(this.txtTelefono);
            this.tabPersona.Controls.Add(this.lblTelefono);
            this.tabPersona.Controls.Add(this.txtCorreo);
            this.tabPersona.Controls.Add(this.lblCorreo);
            this.tabPersona.Controls.Add(this.txtDui);
            this.tabPersona.Controls.Add(this.lblDui);
            this.tabPersona.Controls.Add(this.txtApellidos);
            this.tabPersona.Controls.Add(this.lblApellidos);
            this.tabPersona.Controls.Add(this.dgvArrendatario);
            this.tabPersona.Controls.Add(this.btnGuardar);
            this.tabPersona.Controls.Add(this.txtNombres);
            this.tabPersona.Controls.Add(this.txtId);
            this.tabPersona.Controls.Add(this.lblNombres);
            this.tabPersona.Controls.Add(this.lblId);
            this.tabPersona.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPersona.Location = new System.Drawing.Point(4, 26);
            this.tabPersona.Margin = new System.Windows.Forms.Padding(4);
            this.tabPersona.Name = "tabPersona";
            this.tabPersona.Padding = new System.Windows.Forms.Padding(4);
            this.tabPersona.Size = new System.Drawing.Size(1140, 341);
            this.tabPersona.TabIndex = 0;
            this.tabPersona.Text = "Arrendatario";
            this.tabPersona.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(11, 212);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(349, 26);
            this.txtTelefono.TabIndex = 16;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(10, 187);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(93, 24);
            this.lblTelefono.TabIndex = 15;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(11, 274);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(349, 26);
            this.txtCorreo.TabIndex = 14;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(10, 249);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(74, 24);
            this.lblCorreo.TabIndex = 13;
            this.lblCorreo.Text = "Correo";
            // 
            // txtDui
            // 
            this.txtDui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDui.Location = new System.Drawing.Point(11, 151);
            this.txtDui.Margin = new System.Windows.Forms.Padding(4);
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(349, 26);
            this.txtDui.TabIndex = 12;
            // 
            // lblDui
            // 
            this.lblDui.AutoSize = true;
            this.lblDui.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDui.Location = new System.Drawing.Point(10, 126);
            this.lblDui.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDui.Name = "lblDui";
            this.lblDui.Size = new System.Drawing.Size(41, 24);
            this.lblDui.TabIndex = 11;
            this.lblDui.Text = "Dui";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(11, 91);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(349, 26);
            this.txtApellidos.TabIndex = 10;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidos.Location = new System.Drawing.Point(10, 66);
            this.lblApellidos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(97, 24);
            this.lblApellidos.TabIndex = 9;
            this.lblApellidos.Text = "Apellidos";
            // 
            // dgvArrendatario
            // 
            this.dgvArrendatario.AllowUserToAddRows = false;
            this.dgvArrendatario.AllowUserToDeleteRows = false;
            this.dgvArrendatario.AllowUserToOrderColumns = true;
            this.dgvArrendatario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArrendatario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvArrendatario.Location = new System.Drawing.Point(390, 29);
            this.dgvArrendatario.Margin = new System.Windows.Forms.Padding(4);
            this.dgvArrendatario.Name = "dgvArrendatario";
            this.dgvArrendatario.RowHeadersWidth = 62;
            this.dgvArrendatario.Size = new System.Drawing.Size(711, 226);
            this.dgvArrendatario.TabIndex = 7;
            this.dgvArrendatario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArrendatario_CellContentClick);
            this.dgvArrendatario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArrendatario_CellDoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 80;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(905, 274);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(196, 43);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombres
            // 
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(11, 31);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(346, 26);
            this.txtNombres.TabIndex = 3;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(1079, 414);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(60, 23);
            this.txtId.TabIndex = 2;
            this.txtId.Visible = false;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.Location = new System.Drawing.Point(9, 6);
            this.lblNombres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(95, 24);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.Text = "Nombres";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(7, 4);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 17);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            this.lblId.Visible = false;
            // 
            // ArrendatarioWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 577);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ArrendatarioWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arrendatario";
            this.Load += new System.EventHandler(this.ArrendatarioWF_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPersona.ResumeLayout(false);
            this.tabPersona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrendatario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersona;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtDui;
        private System.Windows.Forms.Label lblDui;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.DataGridView dgvArrendatario;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}