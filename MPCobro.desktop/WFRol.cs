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
    public partial class WFRol : MaterialSkin.Controls.MaterialForm
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
    }
}
