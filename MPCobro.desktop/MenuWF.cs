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
    public partial class MenuWF : MaterialSkin.Controls.MaterialForm
    {
        public MenuWF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpleadoWF empleadoWF = new EmpleadoWF();
            empleadoWF.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrendatarioWF ar = new ArrendatarioWF();
            ar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UsuarioWF usuario = new UsuarioWF();    
            usuario.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EstadoWF stadoWF = new EstadoWF();  
            stadoWF.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EdificioWF ed = new EdificioWF();
            ed.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LocalesWF localesWF = new LocalesWF();  
            localesWF.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoriaWF categoria = new CategoriaWF();
            categoria.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WFRol rolWF = new WFRol();
            rolWF.ShowDialog();
        }
    }
}
