using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPCobro.BusinessLogic;
using MPCobro.Entities;

namespace MPCobro.desktop
{
    public partial class EmpleadoWF : MaterialSkin.Controls.MaterialForm
    {
        int Id = 0;
        List<Estado> estados;
        List<Rol> rol;
        public EmpleadoWF()
        {
            InitializeComponent();
            UpdateGrid();
            UpdateComboEstado();
            UpdateComboRol();
            btnModificar.Visible = false;
            cbxEstado.SelectedValue = 0;
            cbxRol.SelectedValue = 0;
        }
        private void UpdateGrid()
        {
            estados = EstadoBLL.Instance.SelectAll();
            rol = RolBLL.Instance.SelectAll();
            var query = (from x in EmpleadoBLL.Instance.SelectAll()
                         join e in estados on x.EstadoId equals e.EstadoId
                         join r in rol on x.RolId equals r.RolId
                         select new
                         {
                             Id = x.EmpleadoId,
                             Rol = r.Nombre,
                             Estado = e.Nombre,
                             Nombre = x.Nombre,
                             Apellido = x.Apellido,
                             Telefono = x.Telefono,
                             DUI = x.DUI,
                             Correo = x.CorreoElectronico
                         }
                         ).ToList();
            dgvEmpleado.DataSource = query.ToList();
        }

        private void UpdateComboRol()
        {
            cbxRol.DataSource = RolBLL.Instance.SelectAll().ToList();
            cbxRol.DisplayMember = "Nombre";
            cbxRol.ValueMember = "RolId";
        }

        private void UpdateComboEstado()
        {
            cbxEstado.DataSource = EstadoBLL.Instance.SelectAll().ToList();
            cbxEstado.DisplayMember = "Nombre";
            cbxEstado.ValueMember = "EstadoId";
        }
        

        private void dgvEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpleado.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                int id = (int)dgvEmpleado.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes) 
                {
                    if(EmpleadoBLL.Instance.Delete(id))
                    {
                       MessageBox.Show("Se elimino exitozamente el registro",
                       "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();
            }
            else if(dgvEmpleado.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvEmpleado.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea editar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Id = id;
                    txtNombre.Text= dgvEmpleado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    txtApellido.Text= dgvEmpleado.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                    txtTelefono.Text = dgvEmpleado.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                    txtDUI.Text = dgvEmpleado.Rows[e.RowIndex].Cells["DUI"].Value.ToString();
                    txtCorreo.Text = dgvEmpleado.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                    cbxEstado.Text = dgvEmpleado.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                    cbxRol.Text = dgvEmpleado.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    MessageBox.Show("Edite los datos necesarios del formulario",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado { 
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                DUI = txtDUI.Text,
                EstadoId = (int)cbxEstado.SelectedValue,
                RolId = (int)cbxRol.SelectedValue,
                CorreoElectronico = txtCorreo.Text
            };
            if (empleado == null)
            {
                MessageBox.Show("Llene los datos por favor...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EmpleadoBLL.Instance.Insert(empleado);
                MessageBox.Show("Datos guardados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                LimpiarForm();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado
            {
                EmpleadoId = Id,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                DUI = txtDUI.Text,
                EstadoId = (int)cbxEstado.SelectedValue,
                RolId = (int)cbxRol.SelectedValue,
                CorreoElectronico = txtCorreo.Text
            };
            if (empleado != null)
            {
                EmpleadoBLL.Instance.Update(empleado);
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

        private void LimpiarForm()
        {
            Id = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDUI.Clear();
            cbxEstado.SelectedValue = 0;
            cbxRol.SelectedValue = 0;
            txtCorreo.Clear();
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }
    }
}
