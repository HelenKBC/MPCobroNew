namespace MPCobro.desktop
{
    partial class EstadoWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadoWF));
            this.dgvEstado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.bntNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstado
            // 
            this.dgvEstado.AllowUserToAddRows = false;
            this.dgvEstado.AllowUserToDeleteRows = false;
            this.dgvEstado.AllowUserToOrderColumns = true;
            this.dgvEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvEstado.Location = new System.Drawing.Point(30, 156);
            this.dgvEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEstado.Name = "dgvEstado";
            this.dgvEstado.RowHeadersWidth = 62;
            this.dgvEstado.RowTemplate.Height = 28;
            this.dgvEstado.Size = new System.Drawing.Size(828, 363);
            this.dgvEstado.TabIndex = 0;
            this.dgvEstado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstado_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 80;
            // 
            // bntNuevo
            // 
            this.bntNuevo.BackColor = System.Drawing.Color.PaleGreen;
            this.bntNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntNuevo.Location = new System.Drawing.Point(714, 89);
            this.bntNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bntNuevo.Name = "bntNuevo";
            this.bntNuevo.Size = new System.Drawing.Size(144, 50);
            this.bntNuevo.TabIndex = 2;
            this.bntNuevo.Text = "Nuevo";
            this.bntNuevo.UseVisualStyleBackColor = false;
            this.bntNuevo.Click += new System.EventHandler(this.bntNuevo_Click);
            // 
            // EstadoWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.bntNuevo);
            this.Controls.Add(this.dgvEstado);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EstadoWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EstadoWF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstado;
        private System.Windows.Forms.Button bntNuevo;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}