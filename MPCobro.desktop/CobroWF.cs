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
                             dpFechaCobro = x.FechaCobro
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
        {// Obtén los valores seleccionados en los controles
            int empleadoId = (int)cbxEmpleado.SelectedValue;
            int localId = (int)cbxLocal.SelectedValue;
            DateTime fechaCobro = Convert.ToDateTime(dpFechaCobro.Text);

            // Realiza la operación de cobro
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

        }
    }
}
