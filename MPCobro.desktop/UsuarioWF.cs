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
    public partial class UsuarioWF : Form
    {
        int Id = 0;
        List<Empleado> _empleado;
        public UsuarioWF()
        {
            InitializeComponent();
            UpdateGridUser();
            UpdateComboEmpleado();
            btnModificar.Visible = false;
            cbxNombreEmpleado.SelectedValue = 0;

        }

        private void UpdateComboEmpleado()
        {
            var empleados = EmpleadoBLL.Instance.SelectAll().ToList();
            var empleadosConNombreCompleto = empleados.Select(e => new
            {
                NombreCompleto = $"{e.Nombre} {e.Apellido}",
                EmpleadoId = e.EmpleadoId
            }).ToList();

            cbxNombreEmpleado.DataSource = empleadosConNombreCompleto;
            cbxNombreEmpleado.DisplayMember = "NombreCompleto";
            cbxNombreEmpleado.ValueMember = "EmpleadoId";
        }

        private void UpdateGridUser()
        {
            
            _empleado = EmpleadoBLL.Instance.SelectAll();
            var query = (from x in UsuarioBLL.Instance.SelectAll()
            join e in _empleado on x.EmpleadoId equals e.EmpleadoId
                         select new
                         {
                             Id = x.UsuarioId,
                             Empleado = e.Nombre +" "+ e.Apellido,
                             Nombre = x.NombreUser,
                             Contraseña = x.Clave
                         }
                         ).ToList();
            dgvUsuario.DataSource = query.ToList();
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuario.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                int id = (int)dgvUsuario.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (EmpleadoBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino exitozamente el registro",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGridUser();
            }
            else if (dgvUsuario.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvUsuario.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea editar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Id = id;
                    cbxNombreEmpleado.Text = dgvUsuario.Rows[e.RowIndex].Cells["Empleado"].Value.ToString();
                    txtUsusario.Text = dgvUsuario.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    txtPassword.Text = dgvUsuario.Rows[e.RowIndex].Cells["Contraseña"].Value.ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    cbxNombreEmpleado.Enabled = false;
                    MessageBox.Show("Edite los datos necesarios del formulario",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                NombreUser = txtUsusario.Text,
                Clave = txtPassword.Text,
                EmpleadoId = (int)cbxNombreEmpleado.SelectedValue
            };
            if (usuario == null)
            {
                MessageBox.Show("Llene los datos por favor...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UsuarioBLL.Instance.Insert(usuario);
                MessageBox.Show("Datos guardados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGridUser();
                LimpiarForm();
            }
        }

        private void LimpiarForm()
        {
            Id = 0;
            txtUsusario.Clear();
            cbxNombreEmpleado.SelectedValue = 0;
            txtPassword.Clear();
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                UsuarioId = Id,
                NombreUser = txtUsusario.Text,
                Clave = txtPassword.Text,
                EmpleadoId = (int)cbxNombreEmpleado.SelectedValue
            };
            if (usuario != null)
            {
                UsuarioBLL.Instance.Update(usuario);
                MessageBox.Show("Datos modificados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGridUser();
                LimpiarForm();
                btnGuardar.Visible=true;
                btnModificar.Visible = false;
                cbxNombreEmpleado.Enabled = true;
            }
            else
            {
                MessageBox.Show("Llene todos los datos necesarios para el registro...",
                     "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UsuarioWF_Load(object sender, EventArgs e)
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
