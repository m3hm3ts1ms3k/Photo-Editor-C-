using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;


namespace application
{
    public partial class Form5 : Form
    { 
        public string imageLink;
    
        public Form5()
        {
            InitializeComponent();
        imageFolder();
        }
    public void imageFolder()
    {
        
            
            
            Directory.CreateDirectory(@"D:\folder");
    }
        public void message()
        {
            MessageBox.Show("Resim burada dönüştürüldü : " + comboBox1.Text,"",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }



        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation= ofd.FileName;
                    imageLink= ofd.FileName;
                }
            }
        }

        public void convert (string selectFormat)
        {
            try
            {
                Image img = Image.FromFile(imageLink);
                if (selectFormat == "JPEG")
                {
                    img.Save(@"D:\folder\photo.jpeg",ImageFormat.Jpeg);
                }

                else if (selectFormat == "PNG")
                {
                    img.Save(@"D:\folder\photo.PNG", ImageFormat.Png);
                }

                else if (selectFormat == "ICON")
                {
                    img.Save(@"D:\folder\photo.ICON", ImageFormat.Icon);
                }

                else if (selectFormat == "WMF")
                {
                    img.Save(@"D:\folder\photo.WMF", ImageFormat.Wmf);
                }

                else if (selectFormat == "WMF")
                {
                    img.Save(@"D:\folder\photo.WMF", ImageFormat.Wmf);
                }

                else if (selectFormat == "GIF")
                {
                    img.Save(@"D:\folder\photo.GIF", ImageFormat.Gif);
                }

                else if (selectFormat == "TIFF")
                {
                    img.Save(@"D:\folder\photo.TIFF", ImageFormat.Tiff);
                }

                else if (selectFormat == "EMF")
                {
                    img.Save(@"D:\folder\photo.EMF", ImageFormat.Emf);
                }

                else
                {
                    MessageBox.Show("Dönüştürülemedi", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Önce Resim Seç");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(imageLink != null)
            {
                convert(comboBox1.Text);
                message();
            }
            
            else
            {
                MessageBox.Show("HATA");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
