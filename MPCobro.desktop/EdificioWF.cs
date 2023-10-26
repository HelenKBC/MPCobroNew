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
    public partial class EdificioWF : Form
    {
        int Id = 0;
        public EdificioWF()
        {
            InitializeComponent();
            UpdateGrid();
            btnModificar.Visible = false;
        }

        private void UpdateGrid()
        {
            var query = (from x in EdificioBLL.Instance.SelectAll()
                         select new
                         {
                             Id = x.EdificioId,
                             Nombre = x.Nombre,
                             CantidadLocales = x.CantidadLocales,
                         }
                         ).ToList();
            dgvEdificio.DataSource = query.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Edificio edificio = new Edificio
            {
                Nombre = txtNombre.Text,
                CantidadLocales = Convert.ToInt32(txtNum.Text)
            };
            if (edificio == null)
            {
                MessageBox.Show("Llene los datos por favor...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EdificioBLL.Instance.Insert(edificio);
                MessageBox.Show("Datos guardados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                LimpiarForm();
            }
        }

        private void LimpiarForm()
        {
            Id = 0;
            txtNombre.Clear();
            txtNum.ResetText();
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void dgvEdificio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEdificio.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                int id = (int)dgvEdificio.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (EdificioBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino exitozamente el registro",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();
            }
            else if (dgvEdificio.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvEdificio.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea editar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Id = id;
                    txtNombre.Text = dgvEdificio.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    txtNum.Text = dgvEdificio.Rows[e.RowIndex].Cells["CantidadLocales"].Value.ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    MessageBox.Show("Edite los datos necesarios del formulario",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Edificio edificio = new Edificio
            {
                EdificioId = Id,
                Nombre = txtNombre.Text,
                CantidadLocales = int.Parse(txtNum.Text)
            };
            if (edificio != null)
            {
                EdificioBLL.Instance.Update(edificio);
                MessageBox.Show("Datos modificados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                LimpiarForm();
                btnGuardar.Visible = true;
                btnModificar.Visible = false;
            }
            else
            {
                MessageBox.Show("Llene todos los datos necesarios para el registro...",
                     "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EdificioWF_Load(object sender, EventArgs e)
        {
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
    }
}
