namespace application
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSetImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRotateImage = new System.Windows.Forms.Button();
            this.btnFlipImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetImage
            // 
            this.btnSetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSetImage.Location = new System.Drawing.Point(12, 417);
            this.btnSetImage.Name = "btnSetImage";
            this.btnSetImage.Size = new System.Drawing.Size(133, 60);
            this.btnSetImage.TabIndex = 0;
            this.btnSetImage.Text = "Resim Seç";
            this.btnSetImage.UseVisualStyleBackColor = true;
            this.btnSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 399);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnRotateImage
            // 
            this.btnRotateImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRotateImage.Location = new System.Drawing.Point(167, 417);
            this.btnRotateImage.Name = "btnRotateImage";
            this.btnRotateImage.Size = new System.Drawing.Size(133, 60);
            this.btnRotateImage.TabIndex = 2;
            this.btnRotateImage.Text = "Döndür";
            this.btnRotateImage.UseVisualStyleBackColor = true;
            this.btnRotateImage.Click += new System.EventHandler(this.btnRotateImage_Click);
            // 
            // btnFlipImage
            // 
            this.btnFlipImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFlipImage.Location = new System.Drawing.Point(323, 417);
            this.btnFlipImage.Name = "btnFlipImage";
            this.btnFlipImage.Size = new System.Drawing.Size(133, 60);
            this.btnFlipImage.TabIndex = 3;
            this.btnFlipImage.Text = "Çevir";
            this.btnFlipImage.UseVisualStyleBackColor = true;
            this.btnFlipImage.Click += new System.EventHandler(this.btnFlipImage_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 488);
            this.Controls.Add(this.btnFlipImage);
            this.Controls.Add(this.btnRotateImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSetImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Döndürme";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRotateImage;
        private System.Windows.Forms.Button btnFlipImage;
    }
}