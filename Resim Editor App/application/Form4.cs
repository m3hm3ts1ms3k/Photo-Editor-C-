using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application
{
    public partial class Form4 : Form
    {
        Bitmap bmp = new Bitmap(1024, 768);
        Pen p = new Pen(Color.Black, 5);
        bool drawing = false;
        public Form4()
        {
          

            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawing)

                drawing = false;
            else
                drawing = true;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawEllipse(p, e.X, e.Y, 3, 1);
                pictureBox1.Image = bmp;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            p.Color = Color.Red;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            p.Color = Color.Blue;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            p.Color = Color.Green;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            p.Color = Color.Purple;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            p.Color = Color.Lime;
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog= new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg Resim|*.jpg| Bitmap Resim *.bmp|";
            saveFileDialog.Title = "Dosyayı kaydedin.";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs,System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
            }
        }
    }
}
