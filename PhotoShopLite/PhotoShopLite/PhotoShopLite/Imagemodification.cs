using System.Drawing;
using System.IO;

namespace PhotoShopLite
{
    public class ImageModification
    {
        public static string GetInputPath(string path, string imageModificationName)
        {
            var savePath = Path.GetDirectoryName(path);
            var saveName = Path.GetFileNameWithoutExtension(path);
            var saveExtension = Path.GetExtension(path);
            var separator = Path.DirectorySeparatorChar;
            var combining = Path.Combine(savePath + separator + saveName + imageModificationName + saveExtension);
            return combining;
        }
        public static void MakeNegativePicture(Bitmap imageSource, string path)
        {
            Bitmap refrenceImageNegative = imageSource;
            var newPath = GetInputPath(path, "_NEGATIVE");
                        
            int inputImageWidth = refrenceImageNegative.Width;
            int inputImageHeight = refrenceImageNegative.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelvalue = refrenceImageNegative.GetPixel(x, y);

                    int alpha = pixelvalue.A;
                    int red = pixelvalue.R;
                    int green = pixelvalue.G;
                    int blue = pixelvalue.B;

                    red = 255 - red;
                    green = 255 - green;
                    blue = 255 - blue;

                    refrenceImageNegative.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                }
            }
            refrenceImageNegative.Save(newPath);
        }

        public static void MakeBlurredPicture(Bitmap imageSource, string path)
        {
            Bitmap refrenceImageBlurred = imageSource;
            var newPath = GetInputPath(path, "_BLURRED");

            int kernelSize = 5;
            float avg = (float)1 / kernelSize;

            for (int h = 0; h < refrenceImageBlurred.Height; h++)
            {
                float[] hSum = new float[] { 0f, 0f, 0f, 0f };
                float[] hAvg = new float[] { 0f, 0f, 0f, 0f };

                for (int x = 0; x < kernelSize; x++)
                {
                    Color tmpColor = refrenceImageBlurred.GetPixel(x, h);
                    hSum[0] += tmpColor.A;
                    hSum[1] += tmpColor.R;
                    hSum[2] += tmpColor.G;
                    hSum[3] += tmpColor.B;
                }

                hAvg[0] = hSum[0] * avg;
                hAvg[1] = hSum[1] * avg;
                hAvg[2] = hSum[2] * avg;
                hAvg[3] = hSum[3] * avg;

                for (int w = 0; w < refrenceImageBlurred.Width; w++)
                {
                    if ((w - kernelSize / 2 >= 0 && w + 1 + kernelSize / 2 < refrenceImageBlurred.Width))
                    {
                        Color tmp_pColor = refrenceImageBlurred.GetPixel(w - kernelSize / 2, h);

                        hSum[0] -= tmp_pColor.A;
                        hSum[1] -= tmp_pColor.R;
                        hSum[2] -= tmp_pColor.G;
                        hSum[3] -= tmp_pColor.B;

                        Color tmp_nColor = refrenceImageBlurred.GetPixel(w + 1 + kernelSize / 2, h);

                        hSum[0] += tmp_nColor.A;
                        hSum[1] += tmp_nColor.R;
                        hSum[2] += tmp_nColor.G;
                        hSum[3] += tmp_nColor.B;

                        hAvg[0] = hSum[0] * avg;
                        hAvg[1] = hSum[1] * avg;
                        hAvg[2] = hSum[2] * avg;
                        hAvg[3] = hSum[3] * avg;
                    }

                    refrenceImageBlurred.SetPixel(w, h, Color.FromArgb((int)hAvg[0], (int)hAvg[1], (int)hAvg[2], (int)hAvg[3]));
                }
            }
            refrenceImageBlurred.Save(newPath);
        }

        public static void MakeGrayscalePicture(Bitmap imageSource, string path)
        {
            Bitmap refrenceImageGrayscale = imageSource;
            var newPath = GetInputPath(path, "_GRAYSCALE");

            int inputImageWidth = refrenceImageGrayscale.Width;
            int inputImageHeight = refrenceImageGrayscale.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = refrenceImageGrayscale.GetPixel(x, y);

                    int alpha = pixelValue.A;
                    int red = pixelValue.R;
                    int green = pixelValue.G;
                    int blue = pixelValue.B;

                    int averagePixelvalue = (red + green + blue) / 3;

                    refrenceImageGrayscale.SetPixel(x, y, Color.FromArgb(alpha, averagePixelvalue, averagePixelvalue, averagePixelvalue));
                }
            }
            refrenceImageGrayscale.Save(newPath);
        }
    }





}
