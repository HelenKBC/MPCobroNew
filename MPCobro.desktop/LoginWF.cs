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
    public partial class LoginWF : Form
    {
        public LoginWF()
        {
            InitializeComponent();
          
        }
        

        private void LoginWF_Load(object sender, EventArgs e)
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           /* FrmMenu frm = new FrmMenu();
            frm.Show();
           */
            Usuario usuario = new Usuario
           
            {
                NombreUser = txtUsuario.Text,
                Clave = txtPassword.Text,
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
                LimpiarForm();
            }
        }
        private void LimpiarForm()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }
    }
}
