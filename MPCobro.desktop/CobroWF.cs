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
    public partial class CobroWF : Form
    {
        int Id = 0;
        List<Empleado> empleados;
        List<Locales> locale;
        public CobroWF()
        {
            InitializeComponent();
            UpdateComboEmpleado();
            UpdateComboLocales();
            UpdateGrid();
            cbxEmpleado.Enabled = false;
            dpFechaCobro.Text = DateTime.Now.ToString();
        }
        private void UpdateComboEmpleado()
        {
            var empleados = EmpleadoBLL.Instance.SelectAll().ToList();
            var empleadoConNombreCompleto = empleados.Select(e => new
            {
                NombreCompleto = $"{e.Nombre} {e.Apellido}",
                EmpleadoId = e.EmpleadoId
            }).ToList();
            cbxEmpleado.DataSource = empleadoConNombreCompleto;
            cbxEmpleado.DisplayMember = "NombreCompleto";
            cbxEmpleado.ValueMember = "EmpleadoId";
        }
        private void UpdateComboLocales()
        {
            // Realiza una consulta para obtener los locales con EstadoId igual a 4
            var localesConEstado4 = LocalesBLL.Instance.SelectAll().Where(l => l.EstadoId == 4).ToList();
            // Asigna los resultados al ComboBox
            cbxLocal.DataSource = localesConEstado4;
            cbxLocal.DisplayMember = "Nombre";
            cbxLocal.ValueMember = "LocalesId";

        }
        private void UpdateGrid()
        {
            empleados = EmpleadoBLL.Instance.SelectAll();
            locale = LocalesBLL.Instance.SelectAll();
            var query = (from x in CobroBLL.Instance.SelectAll()
                         join e in empleados on x.EmpleadoId equals e.EmpleadoId
                         join d in locale on x.LocalId equals d.LocalesId
                         select new
                         {
                             Id = x.CobroId,
                             Empleado = e.Nombre,
                             Locales = d.Nombre,
                             FechaCobro = x.FechaCobro
                         }
                         ).ToList();
            dgvCobro.DataSource = query.ToList();
        }
        private void CobroWF_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int empleadoId = (int)cbxEmpleado.SelectedValue;
            int localId = (int)cbxLocal.SelectedValue;
            DateTime fechaCobro = Convert.ToDateTime(dpFechaCobro.Text);

            Cobro cobro = new Cobro
            {
                EmpleadoId = empleadoId,
                LocalId = localId,
                FechaCobro = fechaCobro
            };

            // Actualiza la fecha del último pago en las asignaciones locales relacionadas con el local del cobro
            var asignacionesLocales = AsignacionLocalBLL.Instance.SelectAll().Where(x => x.LocalId == localId);

            foreach (var asignacion in asignacionesLocales)
            {
                asignacion.FechaUltimoPago = fechaCobro;
                AsignacionLocalBLL.Instance.Update(asignacion);
            }

            if (cobro == null)
            {
                MessageBox.Show("Llene los datos por favor...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CobroBLL.Instance.Insert(cobro);
                MessageBox.Show("Datos guardados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void dgvCobro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCobro.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                int id = (int)dgvCobro.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (CobroBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino exitozamente el registro",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();
            }
            else if (dgvCobro.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvCobro.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea editar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Id = id;
                    dpFechaCobro.Text = dgvCobro.Rows[e.RowIndex].Cells["FechaCobro"].Value.ToString();
                    cbxEmpleado.Text = dgvCobro.Rows[e.RowIndex].Cells["Empleado"].Value.ToString();
                    cbxLocal.Text = dgvCobro.Rows[e.RowIndex].Cells["Locales"].Value.ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    MessageBox.Show("Edite los datos necesarios del formulario",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int empleadoId = (int)cbxEmpleado.SelectedValue;
            int localId = (int)cbxLocal.SelectedValue;
            DateTime fechaCobro = Convert.ToDateTime(dpFechaCobro.Text);

            // Realiza la operación de cobro
            Cobro cobro = new Cobro
            {
                CobroId = Id,
                EmpleadoId = empleadoId,
                LocalId = localId,
                FechaCobro = fechaCobro
            };

            // Actualiza la fecha del último pago en las asignaciones locales relacionadas con el local del cobro
            var asignacionesLocales = AsignacionLocalBLL.Instance.SelectAll().Where(x => x.LocalId == localId);

            foreach (var asignacion in asignacionesLocales)
            {
                asignacion.FechaUltimoPago = fechaCobro;
                AsignacionLocalBLL.Instance.Update(asignacion);
            }
            if (cobro != null)
            {
                CobroBLL.Instance.Update(cobro);
                MessageBox.Show("Datos modificados exitosamente...",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                btnGuardar.Visible = true;
                btnModificar.Visible = false;
            }
            else
            {
                MessageBox.Show("Llene todos los datos necesarios para el registro...",
                     "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
