﻿using System;
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
    public partial class FrmMenu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public FrmMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            
            if (activeForm != null)
            {
                activeForm.Close();
            }
              
            
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.UsuarioWF(),sender);
        }

        private void btnArrendatrio_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.EmpleadoWF(), sender);
        }

        private void btnArrendatario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.ArrendatarioWF(), sender);
        }

        private void btnEdificios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.EdificioWF(), sender);
        }

        private void btnLocales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.LocalesWF(), sender);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.CategoriaWF(), sender);
        }

        private void btnEstados_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.EstadoWF(), sender);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.WFRol(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.AsignacionLocalWF(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.CobroWF(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MPCobro.desktop.LoginWF(), sender);
        }
    }
}
