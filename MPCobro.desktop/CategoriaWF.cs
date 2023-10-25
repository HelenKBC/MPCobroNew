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
    public partial class CategoriaWF : MaterialSkin.Controls.MaterialForm
    {
        int Id = 0;
        public CategoriaWF()
        {
            InitializeComponent();
            UpdateGrid();
            btnModificar.Visible = false;
        }

        private void UpdateGrid()
        {
           
            var query = (from x in CategoriaBLL.Instance.SelectAll()
                         select new
                         {
                             Id = x.CategoriaId,
                             Nombre = x.Nombre,
                             Descripcion = x.Descripcion
                         }
                         ).ToList();
            dgvCategoria.DataSource = query.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };
            if (categoria == null)
            {
                MessageBox.Show("Llene los datos por favor...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CategoriaBLL.Instance.Insert(categoria);
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
            txtDescripcion.Clear();
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria
            {
                CategoriaId = Id,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };
            if (categoria != null)
            {
                CategoriaBLL.Instance.Update(categoria);
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

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                int id = (int)dgvCategoria.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (CategoriaBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino exitozamente el registro",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();
            }
            else if (dgvCategoria.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvCategoria.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea editar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Id = id;
                    txtNombre.Text = dgvCategoria.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvCategoria.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    MessageBox.Show("Edite los datos necesarios del formulario",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
