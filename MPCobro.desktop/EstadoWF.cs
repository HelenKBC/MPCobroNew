using MPCobro.BusinessLogic;
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
    public partial class EstadoWF : Form
    {
        List<Estado> _listadoEstados;
        int Id = 0;
        public EstadoWF()
        {
            InitializeComponent();
        }

        private void EstadoWF_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            LoadThemes();
        }
        private void LoadThemes()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        private void UpdateGrid()
        {
            var query = (from x in EstadoBLL.Instance.SelectAll()
                         select new
                         {
                             Id = x.EstadoId,
                             Nombre = x.Nombre
                         }
                         ).ToList();
            dgvEstado.DataSource = query.ToList();
        }

        private void dgvEstado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (dgvEstado.Rows[e.RowIndex].Cells["Eliminar"].Selected)
              {
                int id = (int)dgvEstado.Rows[e.RowIndex].Cells["Id"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (EstadoBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino el registro seleccionado?",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                UpdateGrid();
              }
        }
        private void bntNuevo_Click(object sender, EventArgs e)
        {
            NuevoEstadoWF frm = new NuevoEstadoWF();
            frm.Show();
            frm.BringToFront();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}