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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        Image ZoomPicture(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width),
                Convert.ToInt32(img.Height * size.Height));
            Graphics gpu = Graphics.FromImage(bm);
            gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }
        PictureBox org;

        private void Form8_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 6;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.UseWaitCursor = false;

            this.DoubleBuffered = true; 
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = ZoomPicture(org.Image, new Size(trackBar1.Value, trackBar1.Value));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                org = new PictureBox();
                org.Load(od.FileName);
                pictureBox1.Load(od.FileName);
            }
        }

       

        
    }
}
