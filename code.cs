using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageCompareEqualsCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap firstImage = new Bitmap(@"D:\Desktop\pictureOne.png");
            Bitmap secondImage = new Bitmap(@"D:\Desktop\pictureTwo.png");

            // bool isEqual = ImageCompareString(firstImage, secondImage);
            bool isEqual = ImageCompareArray(firstImage, secondImage);
            if (isEqual)
            {
                MessageBox.Show("The image is equal 100%");
            }
            else
            {
                MessageBox.Show("The image is different.");
            }
        }

        public static bool ImageCompareString(Bitmap firstImage, Bitmap secondImage)
        {
            MemoryStream ms = new MemoryStream();
            firstImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String firstBitmap = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;

            secondImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String secondBitmap = Convert.ToBase64String(ms.ToArray());

            if (firstBitmap.Equals(secondBitmap))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ImageCompareArray(Bitmap firstImage, Bitmap secondImage)
        {
            bool flag = true;
            string firstPixel;
            string secondPixel;

            if (firstImage.Width == secondImage.Width && firstImage.Height == secondImage.Height)
            {
                for (int i = 0; i < firstImage.Width; i++)
                {
                    for (int j = 0; j < firstImage.Height; j++)
                    {
                        firstPixel = firstImage.GetPixel(i, j).ToString();
                        secondPixel = secondImage.GetPixel(i, j).ToString();
                        if (firstPixel != secondPixel)
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
