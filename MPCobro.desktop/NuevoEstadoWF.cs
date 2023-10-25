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
    public partial class NuevoEstadoWF : MaterialSkin.Controls.MaterialForm
    {
        int id = 0;
        public NuevoEstadoWF()
        {
            InitializeComponent();
           
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
