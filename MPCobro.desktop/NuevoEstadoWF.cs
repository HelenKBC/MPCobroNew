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
    public partial class NuevoEstadoWF : Form
    {
        int id = 0;
        public NuevoEstadoWF()
        {
            InitializeComponent();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Estado entity = new Estado()
            {
                Nombre = txtNombre.Text
            };
            if (entity != null)
            {
                if (EstadoBLL.Instance.Insert(entity))
                {
                    MessageBox.Show("El registro se almaceno con exito", "Confirmacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoWF estadoWF = new EstadoWF();
                    estadoWF.Show();
                    this.Close();
                    txtNombre.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No deje campos vacios", "Confirmacion",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
