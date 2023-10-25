using BarcodeLib;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MPCobro.desktop
{
    public partial class LocalesWF : MaterialSkin.Controls.MaterialForm
    {

        int Id = 0;
        List<Estado> estados;
        List<Edificio> edificio;
        List<Categoria> categoria;
        public LocalesWF()
        {
            InitializeComponent();
            UpdateComboEstado();
            UpdateComboEdificio();
            UpdateComboCategoria();
            UpdateGrid();
        }

        private void UpdateComboCategoria()
        {
            cbxCategoria.DataSource = CategoriaBLL.Instance.SelectAll().ToList();
            cbxCategoria.DisplayMember = "Nombre";
            cbxCategoria.ValueMember = "CategoriaId";
        }

        private void UpdateComboEdificio()
        {
            cbxEdificio.DataSource = EdificioBLL.Instance.SelectAll().ToList();
            cbxEdificio.DisplayMember = "Nombre";
            cbxEdificio.ValueMember = "EdificioId";
        }
        private void UpdateComboEstado()
        {
            cbxEstado.DataSource = EstadoBLL.Instance.SelectAll().ToList();
            cbxEstado.DisplayMember = "Nombre";
            cbxEstado.ValueMember = "EstadoId";
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Locales local = new Locales
            {
                Nombre = txtNombre.Text,
                EstadoId = (int)cbxEstado.SelectedValue,
                EdificioId = (int)cbxEdificio.SelectedValue,
                CategoriaId = (int)cbxCategoria.SelectedValue,
                CodigoDeBarras = txtCodigo.Text
            };
            
            if (local !=  null)
            {
                LocalesBLL.Instance.Insert(local);
                pbxCodigo.Image.Save(@"C:\MPCobro\MPCobro.desktop\CodigosBarras\" + txtCodigo.Text + ".png");

                MessageBox.Show("Datos guardados exitosamente...",
                       "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Llene los datos por favor...",
                     "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
        private void LimpiarForm()
        {
           
        }
        private void UpdateGrid()
        {
            estados = EstadoBLL.Instance.SelectAll();
            edificio = EdificioBLL.Instance.SelectAll();
            categoria = CategoriaBLL.Instance.SelectAll();
            var query = (from x in LocalesBLL.Instance.SelectAll()
                         join e in estados on x.EstadoId equals e.EstadoId
                         join d in edificio on x.EdificioId equals d.EdificioId
                         join c in categoria on x.CategoriaId equals c.CategoriaId
                         select new
                         {
                             Id = x.LocalesId,
                             Estado = e.Nombre,
                             Edificio = d.Nombre,
                             categoria = c.Nombre,
                             Nombre = x.Nombre,
                             CodigoBarra = x.CodigoDeBarras
                         }
                         ).ToList();
            dgvLocales.DataSource = query.ToList();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var query = (from x in LocalesBLL.Instance.SelectAll()
                         orderby x.LocalesId descending
                         select new
                         {
                             Id = x.LocalesId
                         }
             ).FirstOrDefault();
            string codigo = "000000" + (query.Id + 1);
            txtCodigo.Text = codigo;
            Barcode barcode = new Barcode();
            Bitmap imagenTitulo = ConvertirTextoImagen(txtNombre.Text.Trim(), 300, Color.White);
            Image img = barcode.Encode(BarcodeLib.TYPE.CODE128, txtCodigo.Text, Color.White, Color.Black,
                (int)(pbxCodigo.Width * 0.9), (int)(pbxCodigo.Height * 0.9));

            // Calcula la altura total para el nuevo Bitmap
            int alto_imagen_nuevo = img.Height + imagenTitulo.Height + 30; // 30 es un espacio para el texto

            // Crea un nuevo Bitmap que tenga suficiente altura para ambas imágenes y el texto
            Bitmap imagenNueva = new Bitmap(300, alto_imagen_nuevo);

            // Crea un objeto Graphics a partir del nuevo Bitmap
            using (Graphics dibujar = Graphics.FromImage(imagenNueva))
            {
                // Dibuja la imagen de título en la parte superior
                dibujar.DrawImage(imagenTitulo, new Point(0, 0));

                // Dibuja la imagen del código de barras debajo de la imagen de título
                dibujar.DrawImage(img, new Point(0, imagenTitulo.Height));

                // Agrega el texto del código generado debajo del código de barras
                using (Font font = new Font("Arial", 12))
                {
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        dibujar.DrawString(txtCodigo.Text, font, brush, new PointF(10, imagenTitulo.Height + img.Height + 10)); // Ajusta la posición según sea necesario
                    }
                }
            }

            // Actualiza el PictureBox
            pbxCodigo.Image = imagenNueva;
            pbxCodigo.Refresh(); // Añade esta línea para forzar una actualización


        }

        private Bitmap ConvertirTextoImagen(string texto, int ancho, Color color)
        {
            //creamos el objeto imagen Bitmap
            Bitmap objBitmap = new Bitmap(1, 1);
            int Width = 0;
            int Height = 0;
            //formateamos la fuente (tipo de letra, tamaño)
            System.Drawing.Font objFont = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            //creamos un objeto Graphics a partir del Bitmap
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            //establecemos el tamaño según la longitud del texto
            Width = ancho;
            Height = (int)objGraphics.MeasureString(texto, objFont).Height + 5;
            objBitmap = new Bitmap(objBitmap, new Size(Width, Height));

            objGraphics = Graphics.FromImage(objBitmap);

            objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            objGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat drawFormat = new StringFormat();
            objGraphics.Clear(color);

            drawFormat.Alignment = StringAlignment.Center;
            objGraphics.DrawString(texto, objFont, new SolidBrush(Color.Black), new RectangleF(0, (objBitmap.Height / 2) - (objBitmap.Height - 10), objBitmap.Width, objBitmap.Height), drawFormat);
            objGraphics.Flush();
            return objBitmap;
        }
    }
}
