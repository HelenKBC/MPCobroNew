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
        }
        private void UpdateComboEmpleado()
        {
            cbxEmpleado.DataSource = EmpleadoBLL.Instance.SelectAll().ToList();
            cbxEmpleado.DisplayMember = "Nombre";
            cbxEmpleado.ValueMember = "EmpleadoId";
        }
        private void UpdateComboLocales()
        {
            cbxLocal.DataSource = LocalesBLL.Instance.SelectAll().ToList();
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
        {
            Cobro cobro = new Cobro
            {
                EmpleadoId = (int)cbxEmpleado.SelectedValue,
                LocalId = (int)cbxLocal.SelectedValue,
                FechaCobro = Convert.ToDateTime(dpFechaCobro.Text)
            };
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
    }
}
