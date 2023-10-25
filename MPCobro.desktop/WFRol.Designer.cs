namespace MPCobro.desktop
{
    partial class WFRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRol));
            this.bntNuevo = new System.Windows.Forms.Button();
            this.dgvRol = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).BeginInit();
            this.SuspendLayout();
            // 
            // bntNuevo
            // 
            this.bntNuevo.BackColor = System.Drawing.Color.PaleGreen;
            this.bntNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntNuevo.Location = new System.Drawing.Point(662, 520);
            this.bntNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bntNuevo.Name = "bntNuevo";
            this.bntNuevo.Size = new System.Drawing.Size(231, 43);
            this.bntNuevo.TabIndex = 11;
            this.bntNuevo.Text = "Nuevo";
            this.bntNuevo.UseVisualStyleBackColor = false;
            this.bntNuevo.Click += new System.EventHandler(this.bntNuevo_Click);
            // 
            // dgvRol
            // 
            this.dgvRol.AllowUserToAddRows = false;
            this.dgvRol.AllowUserToDeleteRows = false;
            this.dgvRol.AllowUserToOrderColumns = true;
            this.dgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvRol.Location = new System.Drawing.Point(37, 145);
            this.dgvRol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRol.Name = "dgvRol";
            this.dgvRol.RowHeadersWidth = 62;
            this.dgvRol.RowTemplate.Height = 28;
            this.dgvRol.Size = new System.Drawing.Size(856, 342);
            this.dgvRol.TabIndex = 10;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 80;
            // 
            // WFRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 606);
            this.Controls.Add(this.bntNuevo);
            this.Controls.Add(this.dgvRol);
            this.Name = "WFRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rol";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bntNuevo;
        public System.Windows.Forms.DataGridView dgvRol;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}