using System;
using System.Drawing;
using System.IO;

namespace PhotoShopLite1._0
{
    class Program
    {
        public Bitmap GetGrayScale (Bitmap grayscale)
        {
            
            int inputImageWidth = grayscale.Width;
            int inputImageHeight = grayscale.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = grayscale.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    int averagePixelValue = (r + g + b) / 3;

                    grayscale.SetPixel(x, y, Color.FromArgb(a, averagePixelValue, averagePixelValue, averagePixelValue));

                }
            }
            return grayscale;
        }

        public Bitmap GetNegative (Bitmap negative)
        {
            int inputImageWidth = negative.Width;
            int inputImageHeight = negative.Height;
            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = negative.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    negative.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return negative;
            
        }
        public Bitmap GetBlurred (Bitmap blurred)
        {
            int inputImageWidth = blurred.Width;
            int inputImageHeight = blurred.Height;
            int kernelSize = 5;
            float Avg = (float)1 / kernelSize;

            for (int h = 0; h < blurred.Height; h++)
            {
                float[] hSum = new float[] { 0f, 0f, 0f, 0f };
                float[] hAvg = new float[] { 0f, 0f, 0f, 0f };

                for (int x = 0; x < kernelSize; x++)
                {
                    Color tmpColor = blurred.GetPixel(x, h);
                    hSum[0] += tmpColor.A;
                    hSum[1] += tmpColor.R;
                    hSum[2] += tmpColor.G;
                    hSum[3] += tmpColor.B;
                }

                hAvg[0] = hSum[0] * Avg;
                hAvg[1] = hSum[1] * Avg;
                hAvg[2] = hSum[2] * Avg;
                hAvg[3] = hSum[3] * Avg;

                for (int w = 0; w < blurred.Width; w++)
                {
                    if ((w - kernelSize / 2 >= 0 && w + 1 + kernelSize / 2 < blurred.Width))
                    {
                        Color tmp_pColor = blurred.GetPixel(w - kernelSize / 2, h);

                        hSum[0] -= tmp_pColor.A;
                        hSum[1] -= tmp_pColor.R;
                        hSum[2] -= tmp_pColor.G;
                        hSum[3] -= tmp_pColor.B;

                        Color tmp_nColor = blurred.GetPixel(w + 1 + kernelSize / 2, h);

                        hSum[0] += tmp_nColor.A;
                        hSum[1] += tmp_nColor.R;
                        hSum[2] += tmp_nColor.G;
                        hSum[3] += tmp_nColor.B;

                        hAvg[0] = hSum[0] * Avg;
                        hAvg[1] = hSum[1] * Avg;
                        hAvg[2] = hSum[2] * Avg;
                        hAvg[3] = hSum[3] * Avg;
                    }

                    blurred.SetPixel(w, h, Color.FromArgb((int)hAvg[0], (int)hAvg[1], (int)hAvg[2], (int)hAvg[3]));
                }
                
            }
            return blurred;
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Write the path of your picture: ");
            var inputImage = new Bitmap(Image.FromFile(Console.ReadLine()));

            


            
        }


    }
    //string fileName = null;
    //fileName = Path.GetFileName(inputImage.ToString());
    //var filePath = Path.(inputImage.ToString());
    //var inputImage = (Bitmap) Image.FromFile(Console.ReadLine());
    //Bitmap inputImage = new Bitmap(InputImage);
    //var negativeInputImage = inputImage;
    //int inputImageWidth = inputImage.Width;
    //int inputImageHeight = inputImage.Height;
    //Bitmap blurredImage = new Bitmap(InputImage);




}









