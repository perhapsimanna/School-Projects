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
            var combinding = Path.Combine(savePath + saveName + imageModificationName + saveExtension);
            return combinding;
        }
        public static void MakeNegativePicture(Bitmap imageSource)
        {
            Bitmap refrenceImageNegative = imageSource;
            
                        
            int inputImageWidth = refrenceImageNegative.Width;
            int inputImageHeight = refrenceImageNegative.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = refrenceImageNegative.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    refrenceImageNegative.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            refrenceImageNegative.Save(ImageModification.GetInputPath(det ska finnas en stäng här, "_NEGATIVE"));

        }

        public static void MakeBlurredPicture(Bitmap imageSource)
        {

            Bitmap refrenceImageBlurred = imageSource;

            int kernelSize = 5;
            float Avg = (float)1 / kernelSize;

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

                hAvg[0] = hSum[0] * Avg;
                hAvg[1] = hSum[1] * Avg;
                hAvg[2] = hSum[2] * Avg;
                hAvg[3] = hSum[3] * Avg;

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

                        hAvg[0] = hSum[0] * Avg;
                        hAvg[1] = hSum[1] * Avg;
                        hAvg[2] = hSum[2] * Avg;
                        hAvg[3] = hSum[3] * Avg;
                    }

                    refrenceImageBlurred.SetPixel(w, h, Color.FromArgb((int)hAvg[0], (int)hAvg[1], (int)hAvg[2], (int)hAvg[3]));
                }
            }
            refrenceImageBlurred.Save(@"C:\Users\90annlin\Downloads\Gramse_BLURRED.jpg");
        }

        public static void MakeGrayscalePicture(Bitmap imageSource)
        {
            Bitmap refrenceImageGrayscale = imageSource;

            int inputImageWidth = refrenceImageGrayscale.Width;
            int inputImageHeight = refrenceImageGrayscale.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = refrenceImageGrayscale.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    int averagePixelValue = (r + g + b) / 3;

                    refrenceImageGrayscale.SetPixel(x, y, Color.FromArgb(a, averagePixelValue, averagePixelValue, averagePixelValue));

                }

            }
            refrenceImageGrayscale.Save(@"C:\Users\90annlin\Downloads\Gramse_GRAYSCALE.jpg");


        }


    }





}
