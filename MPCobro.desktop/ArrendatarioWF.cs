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
    public partial class ArrendatarioWF : MaterialSkin.Controls.MaterialForm
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

        private void dgvArrendatario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvArrendatario.CurrentRow.Cells["Id"].Value.ToString();
            txtNombres.Text = dgvArrendatario.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellidos.Text = dgvArrendatario.CurrentRow.Cells["Apellido"].Value.ToString();
            txtTelefono.Text = dgvArrendatario.CurrentRow.Cells["Telefono"].Value.ToString();
            txtDui.Text = dgvArrendatario.CurrentRow.Cells["Dui"].Value.ToString();
            txtCorreo.Text = dgvArrendatario.CurrentRow.Cells["CorreoElectronico"].Value.ToString();
        }

        private void dgvArrendatario_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
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
    }
}  