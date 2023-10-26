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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRol));
            this.bntNuevo = new System.Windows.Forms.Button();
            this.dgvRol = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).BeginInit();
            this.SuspendLayout();
            // 
            // bntNuevo
            // 
            this.bntNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.bntNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntNuevo.Location = new System.Drawing.Point(328, 341);
            this.bntNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.bntNuevo.Name = "bntNuevo";
            this.bntNuevo.Size = new System.Drawing.Size(173, 56);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvRol.Location = new System.Drawing.Point(64, 88);
            this.dgvRol.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRol.Name = "dgvRol";
            this.dgvRol.RowHeadersWidth = 62;
            this.dgvRol.RowTemplate.Height = 28;
            this.dgvRol.Size = new System.Drawing.Size(437, 221);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 474);
            this.Controls.Add(this.bntNuevo);
            this.Controls.Add(this.dgvRol);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WFRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rol";
            this.Load += new System.EventHandler(this.WFRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bntNuevo;
        public System.Windows.Forms.DataGridView dgvRol;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}