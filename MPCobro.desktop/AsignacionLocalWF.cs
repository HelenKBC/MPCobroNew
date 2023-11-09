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
    public partial class AsignacionLocalWF : Form
    {
        int localIdAnterior = 0;
        int Id = 0;
        List<Locales> local;
        List<Arrendatario> arrendatario;
        public AsignacionLocalWF()
        {
            InitializeComponent();
            UpdateGrid();
            UpdateCombolocal();
            UpdateComboArrendatario();
            btnModificar.Visible = false;
        }

        private void UpdateComboArrendatario()
        {
            var arrenda = ArrendatarioBLL.Instance.SelectAll().ToList();
            var arrendaConNombreCompleto = arrenda.Select(e => new
            {
                NombreCompleto = $"{e.Nombre} {e.Apellido}",
                ArrendatarioId = e.ArrendatarioId
            }).ToList();

            cbxArrendatario.DataSource = arrendaConNombreCompleto;
            cbxArrendatario.DisplayMember = "NombreCompleto";
            cbxArrendatario.ValueMember = "ArrendatarioId";
        }

        private void UpdateCombolocal()
        {
            // Realiza una consulta para obtener los locales con EstadoId igual 
            var localesConEstado4 = LocalesBLL.Instance.SelectAll().Where(l => l.EstadoId == 1).ToList();
            // Asigna los resultados al ComboBox
            cbxLocal.DataSource = localesConEstado4;
            cbxLocal.DisplayMember = "Nombre";
            cbxLocal.ValueMember = "LocalesId";

        }


        private void UpdateGrid()
        {
            arrendatario = ArrendatarioBLL.Instance.SelectAll();
            local = LocalesBLL.Instance.SelectAll();
            var query = (from x in AsignacionLocalBLL.Instance.SelectAll()
                         join e in arrendatario on x.ArrendatarioId equals e.ArrendatarioId
                         join r in local on x.LocalId equals r.LocalesId
                         select new
                         {
                             Id = x.AsignacionLocalId,
                             IdLocal = x.LocalId,
                             Locales = r.Nombre,
                             Arrendatario = e.Nombre + " " + e.Apellido,
                             FechaInicio = x.FechaInicio,
                             FechaUltimoPago = x.FechaUltimoPago,
                             Monto = x.Monto

                         }
                         ).ToList();
            dgvAsignacionLocal.DataSource = query.ToList();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Locales locales = new Locales
            {
                LocalesId = (int)cbxLocal.SelectedValue,
                EstadoId = 4
            };
            if (locales == null)
            { }
            else
            {
                LocalesBLL.Instance.UpdateEstado(locales);
                AsignacionLocal asignacion = new AsignacionLocal
                {
                    AsignacionLocalId = Id,
                    LocalId = (int)cbxLocal.SelectedValue,
                    ArrendatarioId = (int)cbxArrendatario.SelectedValue,
                    FechaInicio = Convert.ToDateTime(dpFechaInicio.Text),
                    FechaUltimoPago = Convert.ToDateTime(dpFechaUltima.Text),
                    Monto = decimal.Parse(txtMonto.Text)
                };
                if (asignacion != null)
                {
                    AsignacionLocalBLL.Instance.Update(asignacion);
                    MessageBox.Show("Datos modificados exitosamente...",
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                    LimpiarForm();
                    UpdateCombolocal();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Locales locales = new Locales
            {
                LocalesId = (int)cbxLocal.SelectedValue,
                EstadoId = 4
            };
            if (locales == null)
            { }
            else
            {
                LocalesBLL.Instance.UpdateEstado(locales);

                AsignacionLocal asignacion = new AsignacionLocal
                {
                    LocalId = (int)cbxLocal.SelectedValue,
                    ArrendatarioId = (int)cbxArrendatario.SelectedValue,
                    FechaInicio = Convert.ToDateTime(dpFechaInicio.Text),
                    FechaUltimoPago = Convert.ToDateTime(dpFechaUltima.Text),
                    Monto = decimal.Parse(txtMonto.Text)
                };
                if (asignacion == null)
                {
                    MessageBox.Show("Llene los datos por favor...",
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AsignacionLocalBLL.Instance.Insert(asignacion);
                    MessageBox.Show("Datos guardados exitosamente...",
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                    UpdateCombolocal();
                    LimpiarForm();
                }
            }
        }

        private void LimpiarForm()
        {
            Id = 0;
            cbxArrendatario.SelectedValue = 0;
            cbxLocal.SelectedValue = 0;
            txtMonto.Clear();
        }

        private void AsignacionLocalWF_Load(object sender, EventArgs e)
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

        private void dgvAsignacionLocal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAsignacionLocal.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                int id = (int)dgvAsignacionLocal.Rows[e.RowIndex].Cells["Id"].Value;
                localIdAnterior = (int)dgvAsignacionLocal.Rows[e.RowIndex].Cells["IdLocal"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (AsignacionLocalBLL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino exitozamente el registro",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Locales locales = new Locales
                {
                    LocalesId = localIdAnterior,
                    EstadoId = 1
                };
                if (locales != null)
                {
                    LocalesBLL.Instance.UpdateEstado(locales);
                    UpdateCombolocal();
                    cbxLocal.Text = dgvAsignacionLocal.Rows[e.RowIndex].Cells["Locales"].Value.ToString();
                }
                UpdateGrid();
            }
            else if (dgvAsignacionLocal.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvAsignacionLocal.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show("Realmente desea editar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Id = id;
                    localIdAnterior = (int)dgvAsignacionLocal.Rows[e.RowIndex].Cells["IdLocal"].Value;
                    cbxArrendatario.Text = dgvAsignacionLocal.Rows[e.RowIndex].Cells["Arrendatario"].Value.ToString();
                    dpFechaInicio.Text = dgvAsignacionLocal.Rows[e.RowIndex].Cells["FechaInicio"].Value.ToString();
                    dpFechaUltima.Text = dgvAsignacionLocal.Rows[e.RowIndex].Cells["FechaUltimoPago"].Value.ToString();
                    txtMonto.Text = dgvAsignacionLocal.Rows[e.RowIndex].Cells["Monto"].Value.ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    cbxArrendatario.Enabled = false;
                    Locales locales = new Locales
                    {
                        LocalesId = localIdAnterior,
                        EstadoId = 1
                    };
                    if (locales == null)
                    { }
                    else
                    {
                        LocalesBLL.Instance.UpdateEstado(locales);
                        UpdateCombolocal();
                        cbxLocal.Text = dgvAsignacionLocal.Rows[e.RowIndex].Cells["Locales"].Value.ToString();
                    }
                }
            }
        }
    }
}
