using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application
{
    public partial class Form7 : Form
    {

        private Bitmap Image, Image2;
        private BitmapData ImageData, ImageData2;
        private byte[] buffer, buffer2;
        private int location, location2, location3;


        private IntPtr pointer, pointer2;
        private void Form7_Load(object sender, EventArgs e)
        {

        }
        public Form7()
        {
            InitializeComponent();
        }



        private void loadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image = new Bitmap(ofd.FileName);
                Image2 = new Bitmap(Image.Width * 2, Image.Height);
            }
            pictureBox1.Image = Image;
        }

        

        private void savebtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName, ImageFormat.Bmp);
            }
        }

        private void convert_Click(object sender, EventArgs e)
        {
            ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            ImageData2 = Image2.LockBits(new Rectangle(0, 0, Image2.Width, Image2.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            buffer = new byte[ImageData.Stride * Image.Height];
            buffer2 = new byte[ImageData2.Stride * Image2.Height];
            pointer = ImageData.Scan0;
            pointer2 = ImageData2.Scan0;
            Marshal.Copy(pointer, buffer, 0, buffer.Length);
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0, xx = Image2.Width * 3 - 3; x < Image.Width * 3; x += 3, xx -= 3)
                {
                    location = x + y * ImageData.Stride;
                    location2 = x + y * ImageData2.Stride;
                    location3 = xx + y * ImageData2.Stride;
                    buffer2[location2] = buffer[location];
                    buffer2[location2 + 1] = buffer[location + 1];
                    buffer2[location2 + 2] = buffer[location + 2];
                    buffer2[location3] = buffer[location];
                    buffer2[location3 + 1] = buffer[location + 1];
                    buffer2[location3 + 2] = buffer[location + 2];
                }
            }
            Marshal.Copy(buffer2, 0, pointer2, buffer2.Length);
            Image.UnlockBits(ImageData);
            Image2.UnlockBits(ImageData2);
            pictureBox1.Image = Image2;
        }

    }
}
