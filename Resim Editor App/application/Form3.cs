using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("C:\\Users\\ACER NITRO\\Documents\\resim.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image, Int16.Parse(tB1.Text), Int16.Parse(tB2.Text));
            //here Int16.Parse(textBox1.Text) demonstrates width of image after resize.
            pictureBox2.Image = bmp;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //Here we will write code for saving resized image.
            Bitmap bmpSave = new Bitmap(pictureBox2.Image);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG(*.jpeg,*.jpg)|*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bmpSave.Save(sfd.FileName+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            MessageBox.Show("Resim kaydedildi!");
            sfd.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
