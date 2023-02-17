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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Image Image;
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnRotateImage_Click(object sender, EventArgs e)
        {
            Image = pictureBox1.Image;
            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image=Image;
        }

        private void btnFlipImage_Click(object sender, EventArgs e)
        {
            Image = pictureBox1.Image;
            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = Image;
        }
    }
}
