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
    public partial class ArrendatarioWF : Form
    {
        List<Arrendatario> arrendatarios;
        int Id = 0;
        public ArrendatarioWF()
        {
            InitializeComponent();          
        }      
        private void ArrendatarioWF_Load(object sender, EventArgs e)
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
            var query = (from x in ArrendatarioBLL.Instance.SelectAll()


                         select new
                         {
                             Id = x.ArrendatarioId,
                             Nombre = x.Nombre,
                             Apellido = x.Apellido,
                             Telefono = x.Telefono,
                             Dui = x.Dui,
                             CorreoElectronico = x.CorreoElectronico
                         }
                         ).ToList();
            dgvArrendatario.DataSource = query.ToList();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Arrendatario entity = new Arrendatario();
            if (txtId.TextLength > 0)
            {
                entity.ArrendatarioId = int.Parse(txtId.Text);
                entity.Nombre = txtNombres.Text;
                entity.Apellido = txtApellidos.Text;
                entity.Dui = txtDui.Text;
                entity.Telefono = txtTelefono.Text;
                entity.CorreoElectronico = txtCorreo.Text;
                if (ArrendatarioBLL.Instance.Update(entity))
                    MessageBox.Show("El registro se actualizo corerctamente");
                else
                    MessageBox.Show("El registro no se actualizo");
            }
            else
            {
                if (txtNombres.TextLength > 0)
                {
                    entity.Nombre = txtNombres.Text;
                    entity.Apellido = txtApellidos.Text;
                    entity.Dui = txtDui.Text;
                    entity.Telefono = txtTelefono.Text;
                    entity.CorreoElectronico = txtCorreo.Text;
                    if (ArrendatarioBLL.Instance.Insert(entity))
                        MessageBox.Show("El registro se inserto corerctamente");
                    else
                        MessageBox.Show("El registro no se inserto");
                }
            }
            UpdateGrid();
        }

        private void dgvArrendatario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArrendatario.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = (int)dgvArrendatario.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (ArrendatarioBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino el registro seleccionado?",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();
            }
        }

        private void dgvArrendatario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvArrendatario.CurrentRow.Cells["Id"].Value.ToString();
            txtNombres.Text = dgvArrendatario.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellidos.Text = dgvArrendatario.CurrentRow.Cells["Apellido"].Value.ToString();
            txtTelefono.Text = dgvArrendatario.CurrentRow.Cells["Telefono"].Value.ToString();
            txtDui.Text = dgvArrendatario.CurrentRow.Cells["Dui"].Value.ToString();
            txtCorreo.Text = dgvArrendatario.CurrentRow.Cells["CorreoElectronico"].Value.ToString();
        }
    }
}