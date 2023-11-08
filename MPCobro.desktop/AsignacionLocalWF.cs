using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPCobro.desktop
{
    public partial class AsignacionLocalWF : Form
    {
        int Id = 0;
        public AsignacionLocalWF()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AsignacionLocalWF_Load(object sender, EventArgs e)
        {
            LoadThemes();
        }
        private void LoadThemes()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
    }
}
