using MPCobro.BusinessLogic;
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
    public partial class WFRol : Form
    {
        public WFRol()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void bntNuevo_Click(object sender, EventArgs e)
        {
            NuevoRolWF frm = new NuevoRolWF();
            frm.Show();
            frm.BringToFront();
            this.Close();
        }
        public void UpdateGrid()
        {
            var query = (from x in RolBLL.Instance.SelectAll()
                         select new
                         {
                             Id = x.RolId,
                             Nombre = x.Nombre
                         }
                         ).ToList();
            dgvRol.DataSource = query.ToList();
        }

        private void WFRol_Load(object sender, EventArgs e)
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
