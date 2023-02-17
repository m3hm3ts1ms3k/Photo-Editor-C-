using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using AForge.Imaging.Filters;
using System.Drawing.Drawing2D;
using AForge.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;


namespace application
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true; //form içinde form açma seçeneği aktif
            
        }

        System.Drawing.Image file;
        Boolean opened = false;

        void reload()
        {
            if (!opened)
            {
                MessageBox.Show("Hata: Lütfen önce bir resim açın");
            }

            else
            {
            
                pictureBox2.Width = 720;
                pictureBox2.Height = 480;

                pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                file = pictureBox2.Image;
                opened = true;
            }
        }
        void saveImage()
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);

                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;

                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }

                    pictureBox2.Image.Save(sfd.FileName, format);
                }
            }

            else
                MessageBox.Show("Resim yüklenmedi, lütfen resim yükleyin");
        }
        void openImage()
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                file = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = file;
                opened = true;
            }
        }


        void sepia()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // imagebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{0.393f, 0.349f, 0.272f, 0, 0},
                    new float[]{0.769f, 0.686f, 0.534f, 0, 0},
                    new float[]{.189f, .168f, .131f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini görüntü öznitelik nesnesine iletin 
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(eksen-x dikdörtgeninin konumu, eksen-y konumu, dikdörtgenin genişliği, dikdörtgenin yüksekliği),
                görüntünün x ekseni dikdörtgenindeki konumu, görüntünün y ekseni dikdörtgenindeki konumu, görüntünün genişliği, görüntünün yüksekliği,
                grafik biriminin formatı, görüntü özelliklerini sağlayın   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void grayscale()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın.");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // imagebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir..*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                    new float[]{0.59f, 0.59f, 0.59f, 0, 0},
                    new float[]{0.11f, 0.11f, 0.11f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini görüntü öznitelik nesnesine iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), görüntünün x eksenindeki konumu, görüntünün dikdörtgen y eksenindeki konumu, genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar  */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void invert()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // storing image into img variable of image type from picturebox1
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{-1, 0, 0, 0, 1.00f},
                    new float[]{0, -1, 0, 0, 1.00f},
                    new float[]{0, 0, -1, 0, 1.00f},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{1, 1, 1, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini görüntü öznitelik nesnesine iletin ia
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
               dikdörtgen x ekseninde görüntünün konumu, dikdörtgen y ekseninde görüntünün konumu, görüntünün genişliği, görüntünün yüksekliği,
               grafik biriminin formatı, görüntü özelliklerini sağlayın   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void rbgTobgr()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // görüntüyü, görüntü türünün img değişkenine depolamak picturebox1
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{0, 0, 1, 0, 0},
                    new float[]{0, 1, 0, 0, 0},
                    new float[]{1, 0, 0, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                             Grafikler newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(eksen-x dikdörtgeninin konumu, eksen-y konumu, dikdörtgenin genişliği, dikdörtgenin yüksekliği),
                görüntünün x ekseni dikdörtgenindeki konumu, görüntünün y ekseni dikdörtgenindeki konumu, görüntünün genişliği, görüntünün yüksekliği,
                grafik biriminin formatı, görüntü özelliklerini sağlayın   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void blackAndWhite()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // imagebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü için piksel verilerinden oluşan resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma
                                                                         ve nitelikleri. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{1.5f, 1.5f, 1.5f, 0, 0},
                    new float[]{1.5f, 1.5f, 1.5f, 0, 0},
                    new float[]{1.5f, 1.5f, 1.5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{-1, -1, -1, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                             Grafikler newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(eksen-x dikdörtgeninin konumu, eksen-y konumu, dikdörtgenin genişliği, dikdörtgenin yüksekliği),
                görüntünün x ekseni dikdörtgenindeki konumu, görüntünün y ekseni dikdörtgenindeki konumu, görüntünün genişliği, görüntünün yüksekliği,
                grafik biriminin formatı, görüntü özelliklerini sağlayın   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void polaroid()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // picturebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{1.438f, -0.062f, -0.062f, 0, 0},
                    new float[]{-0.122f, 1.378f, -0.122f, 0, 0},
                    new float[]{-0.016f, -0.016f, 1.483f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{-0.03f, 0.05f, -0.02f, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), görüntünün x eksenindeki konumu, görüntünün dikdörtgen y eksenindeki konumu, genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void ccorrect()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // picturebox1 den resim türünün img değişkenine resmi depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();
                //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{1, 0, 0, 0, 0},
                    new float[]{0, 0.8f, 0, 0, 0},
                    new float[]{0, 0, 0.5f, 0, 0},
                    new float[]{0, 0, 0, 0.5f, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun. Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), görüntünün x eksenindeki konumu, görüntünün dikdörtgen y eksenindeki konumu, genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        void checkf()
        {
            if (!opened)
            {
                MessageBox.Show("Bir Görüntü açın ve ardından değişiklikleri uygulayın");
            }
            else
            {

                System.Drawing.Image img = pictureBox2.Image;                             // picturebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. 
                                                                           * Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();
                //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{1, 0, 0, 0, 0},
                    new float[]{0, 0.8f, 0, 0, 0},
                    new float[]{0, 0, 0.5f, 0, 0},
                    new float[]{0, 0, 0, 0.5f, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                             Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*  g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), görüntünün x eksenindeki konumu, 
                 *  görüntünün dikdörtgen y eksenindeki konumu, genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar  */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;

            }
        }

        System.Drawing.Image zoom(System.Drawing.Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }


        void crop()
        {
            Cursor = Cursors.Default;



            if (cropWidth < 1)
            {

                return;

            }

            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            //İlk önce önceden hesaplanmış noktaların yardımıyla bir dikdörtgen tanımlarız.

            Bitmap OriginalImage = new Bitmap(pictureBox2.Image, pictureBox2.Width, pictureBox2.Height);

            //Orijinal fotoğraf

            Bitmap _img = new Bitmap(cropWidth, cropHeight);

            // kırpma görüntüsü için

            Graphics g = Graphics.FromImage(_img);

            // grafik oluşturmak

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            //görüntü niteliklerini ayarla

            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);



            pictureBox2.Image = _img;

            pictureBox2.Width = _img.Width;

            pictureBox2.Height = _img.Height;

            //pictureBox2.Location= new Point( 232,12);

            btnCrop.Enabled = false;
        }

        void brightness()
        {
            float changeb = trackBar1.Value * 0.1f;
            float changec = trackBar2.Value * 0.1f;
            float changes = trackBar3.Value * 0.1f;
           // float changealpha = trackBar3.Value * 0.1f;
           // float changep = trackBar3.Value * 0.1f;

            trackBar1.Text = changeb.ToString();
            trackBar2.Text = changec.ToString();
            trackBar3.Text = changes.ToString();

            reload();
            if (!opened)
            {
            }
            else
            {



                System.Drawing.Image img = pictureBox2.Image;                             // picturebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. 
                                                                           * Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{1, 0, 0, 0, 0},
                    new float[]{0, 1, 0, 0, 0},
                    new float[]{0, 0, 1, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0+changeb, 0+changeb, 0+changeb, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                             Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), görüntünün x eksenindeki konumu, görüntünün dikdörtgen y eksenindeki konumu, genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;


            }
        }

        void contrast()
        {
            float changeb = trackBar1.Value * 0.1f;
            float changec = trackBar2.Value * 0.1f;
           float changes = trackBar3.Value * 0.1f;
           float t=0;
            // float changealpha = trackBar3.Value * 0.1f;
            // float changep = trackBar3.Value * 0.1f;

            trackBar1.Text = changeb.ToString();
            trackBar2.Text = changec.ToString();
            trackBar3.Text = changes.ToString();

            reload();
            if (!opened)
            {
            }
            else
            {



                System.Drawing.Image img = pictureBox2.Image;                             // picturebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. 
                                                                           * Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{1+changec, 0, 0, 0, 0},
                    new float[]{0, 1+changec, 0, 0, 0},
                    new float[]{0, 0, 1+changec, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{t, t, t, 0, 1}
                });

                if (changec == 0)
                    t = (1f - changec) / 2f;

                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun.
                                                             Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), 
                 *   görüntünün x eksenindeki konumu, görüntünün dikdörtgen y eksenindeki konumu, genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;


            }
        }

        void saturation()
        {
            float changeb = trackBar1.Value * 0.1f;
            float changec = trackBar2.Value * 0.1f;
            float changes = trackBar3.Value * 0.1f;
            // float changealpha = trackBar3.Value * 0.1f;
            // float changep = trackBar3.Value * 0.1f;

            float lumR = 0.3086f;

            float lumG = 0.6094f;

            float lumB = 0.0820f;
            float sr = (1 - changes) * lumR;

            float sg = (1 - changes) * lumG;

            float sb = (1 - changes) * lumB;



            trackBar1.Text = changeb.ToString();
            trackBar2.Text = changec.ToString();
            trackBar3.Text = changes.ToString();

            reload();
            if (!opened)
            {
            }
            else
            {



                System.Drawing.Image img = pictureBox2.Image;                             // picturebox1'den görüntü türünün img değişkenine görüntüyü depolamak
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* Bir grafik görüntüsü ve nitelikleri için piksel verilerinden oluşan, resim kutusunda içe aktarılan resmin yüksekliğinin bir bitmap'ini oluşturma. 
                                                                           * Bitmap, piksel verileriyle tanımlanan görüntülerle çalışmak için kullanılan bir nesnedir.*/

                ImageAttributes ia = new ImageAttributes();                 //bir görüntü özniteliği nesnesi oluşturmak, görüntülerin özniteliğini değiştirmektir.
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // şimdi renkleri değiştirmek veya görüntüye görüntü filtresi uygulamak için renk matrisi nesnesini oluşturuyor
                {
                    new float[]{sr+changes, sr, sr, 0, 0},
                    new float[]{sg, sg+changes, sg, 0, 0},
                    new float[]{sb, sb, sb+changes, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           //renk matrisini resim öznitelik nesnesi ia'ya iletin
                Graphics g = Graphics.FromImage(bmpInverted);   /*g adında yeni bir grafik nesnesi oluşturun; Değişiklik için grafik nesnesi oluşturun. Graphics newGraphics = Graphics.FromImage(imageFile); değişiklik için grafiklere görüntü yükleme biçimidir*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                /*   g.drawimage(resim, yeni dikdörtgen(dikdörtgen ekseni-x'in konumu, konum ekseni-y, dikdörtgenin genişliği, dikdörtgenin yüksekliği), görüntünün x eksenindeki konumu, görüntünün dikdörtgen y eksenindeki konumu, 
                 *   genişliği görüntü, görüntünün yüksekliği, grafik biriminin biçimi, görüntü niteliklerini sağlar   */


                g.Dispose();                            //Bu Grafik tarafından kullanılan tüm kaynakları serbest bırakır.
                pictureBox2.Image = bmpInverted;


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveImage();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
            sepia();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            brightness();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            contrast();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            saturation();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reload();
            grayscale();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reload();
            invert();
        }

        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        int oCropX;
        int oCropY;
        Pen cropPen;
        DashStyle cropDashStyle = DashStyle.DashDot;

        void movedown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            btnCrop.Enabled = true;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;

                cropX = e.X;
                cropY = e.Y;

                cropPen = new Pen(Color.Black, 1);

                cropPen.DashStyle = DashStyle.DashDotDot;
            }

            pictureBox2.Refresh();
        }

        

        void move(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            btnCrop.Enabled = true;

            if (pictureBox2.Image == null)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox2.Refresh();
                cropWidth = e.X - cropX;
                cropHeight = e.Y - cropY;

                try
                {
                    pictureBox2.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                }

                catch(ArgumentNullException){

                }
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.ContextMenu = new ContextMenu();

            pictureBox2.MouseDown += new MouseEventHandler(movedown);
            pictureBox2.MouseMove += new MouseEventHandler(move);
        }

        void smooth()
        {        
            
            System.Drawing.Bitmap image = (Bitmap)pictureBox2.Image;
            AForge.Imaging.Filters.ConservativeSmoothing filter = new AForge.Imaging.Filters.ConservativeSmoothing();
            pictureBox2.Image = filter.Apply(image);
            //RChanges.Clear();
        
        }

        void sepia1()
        {

            System.Drawing.Bitmap image = (Bitmap)pictureBox2.Image;
            AForge.Imaging.Filters.Sepia filter = new AForge.Imaging.Filters.Sepia();
            pictureBox2.Image = filter.Apply(image);
            //RChanges.Clear();

        }

        void GaussianSharp()
        {

            System.Drawing.Bitmap image = (Bitmap)pictureBox2.Image;
            AForge.Imaging.Filters.GaussianSharpen filter = new AForge.Imaging.Filters.GaussianSharpen();
            pictureBox2.Image = filter.Apply(image);
            //RChanges.Clear();

        }

        void WaterWavef()
        {

            System.Drawing.Bitmap image = (Bitmap)pictureBox2.Image;
            AForge.Imaging.Filters.WaterWave filter = new AForge.Imaging.Filters.WaterWave();
            filter.HorizontalWavesCount = 10;
            filter.HorizontalWavesAmplitude = 5;
            filter.VerticalWavesCount = 3;
            filter.VerticalWavesAmplitude = 15;
            pictureBox2.Image = filter.Apply(image);
            //RChanges.Clear();

        }

        void Sharp()
        {

            System.Drawing.Bitmap image = (Bitmap)pictureBox2.Image;
            AForge.Imaging.Filters.Sharpen filter = new AForge.Imaging.Filters.Sharpen();
            pictureBox2.Image = filter.Apply(image);
            //RChanges.Clear();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            reload();
            rbgTobgr();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            reload();
            blackAndWhite();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            reload();
            polaroid();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            smooth();
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            crop();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not: Görüntüyü önce bilgisayara kaydetmeyi unutmayın.");
            System.Diagnostics.Process.Start("https://www.instagram.com");
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
           
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ccorrect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(pictureBox2.Image!=null)
            {
                pictureBox2.Dispose();
            }
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            //if (trackBar4.Value > 0)
           // {
               

                //img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100)
              // pictureBox2.Image = zoom(file, new Size(trackBar4.Value, trackBar4.Value));
            //}
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sepia1();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            GaussianSharp();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            WaterWavef();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Sharp();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reload();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            reload();
            sepia1();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // açılacak forum
            form3.MdiParent = this; // Bu formu parent olarak veriyoruz.
            form3.TopMost= true;
          
      

             form3.Show(); // Form3 açılıyor

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); // açılacak forum
            form4.MdiParent = this; // Bu formu parent olarak veriyoruz.



            form4.Show(); // Form4 açılıyor
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); // açılacak forum
            form5.MdiParent = this; // Bu formu parent olarak veriyoruz.



            form5.Show(); // Form4 açılıyor
        }

        private void button13_Click_2(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(); // açılacak forum
            form6.MdiParent = this; // Bu formu parent olarak veriyoruz.



            form6.Show(); // Form4 açılıyor
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(); // açılacak forum
            form7.MdiParent = this; // Bu formu parent olarak veriyoruz.



            form7.Show(); // Form4 açılıyor
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(); // açılacak forum
            form8.MdiParent = this; // Bu formu parent olarak veriyoruz.



            form8.Show(); // Form4 açılıyor
        }

        
    }
    }

