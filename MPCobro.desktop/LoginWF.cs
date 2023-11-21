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
            string nombreUsuario = txtUsuario.Text;
            string clave = txtPassword.Text;

            // Validar que se hayan ingresado nombre de usuario y contraseña
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Por favor, ingrese nombre de usuario y contraseña.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Intentar realizar el inicio de sesión
                Usuario usuario = UsuarioBLL.Instance.Login(nombreUsuario, clave);

                if (usuario != null)
                {
                    // Inicio de sesión exitoso
                    MessageBox.Show($"¡Bienvenido, {usuario.NombreUser}!", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Puedes cerrar este formulario y mostrar el formulario principal o realizar otras acciones necesarias.
                    
                    using (FrmMenu menuForm = new FrmMenu())
                    {
                        menuForm.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    // Las credenciales son incorrectas
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrmMenu frm = new FrmMenu();
            frm.Show();
        }
        private void LimpiarForm()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }
    }
}
