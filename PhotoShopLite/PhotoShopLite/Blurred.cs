using System;
using System.Drawing;

namespace PhotoShopLite
{

    public class Blurred
    {
        public Bitmap InputImage { get; }
        public Blurred(Bitmap inputImage)
        {
            InputImage = inputImage;
        }

        public Bitmap BlurredImage()
        {
            Bitmap blurredImage = new Bitmap(InputImage);

            int BlurKernelSize = 5;
            float Avg = (float)1 / BlurKernelSize;

            for (int h = 0; h < InputImage.Height; h++)
            {
                float[] hSum = new float[] { 0f, 0f, 0f, 0f };
                float[] hAvg = new float[] { 0f, 0f, 0f, 0f };

                for (int x = 0; x < BlurKernelSize; x++)
                {
                    Color tmpColor = InputImage.GetPixel(x, h);
                    hSum[0] += tmpColor.A;
                    hSum[1] += tmpColor.R;
                    hSum[2] += tmpColor.G;
                    hSum[3] += tmpColor.B;
                }

                hAvg[0] = hSum[0] * Avg;
                hAvg[1] = hSum[1] * Avg;
                hAvg[2] = hSum[2] * Avg;
                hAvg[3] = hSum[3] * Avg;

                for (int w = 0; w < InputImage.Width; w++)
                {
                    if ((w - BlurKernelSize / 2 >= 0 && w + 1 + BlurKernelSize / 2 < InputImage.Width))
                    {
                        Color tmp_pColor = InputImage.GetPixel(w - BlurKernelSize / 2, h);

                        hSum[0] -= tmp_pColor.A;
                        hSum[1] -= tmp_pColor.R;
                        hSum[2] -= tmp_pColor.G;
                        hSum[3] -= tmp_pColor.B;

                        Color tmp_nColor = InputImage.GetPixel(w + 1 + BlurKernelSize / 2, h);

                        hSum[0] += tmp_nColor.A;
                        hSum[1] += tmp_nColor.R;
                        hSum[2] += tmp_nColor.G;
                        hSum[3] += tmp_nColor.B;

                        hAvg[0] = hSum[0] * Avg;
                        hAvg[1] = hSum[1] * Avg;
                        hAvg[2] = hSum[2] * Avg;
                        hAvg[3] = hSum[3] * Avg;
                    }

                    blurredImage.SetPixel(w, h, Color.FromArgb((int)hAvg[0], (int)hAvg[1], (int)hAvg[2], (int)hAvg[3]));
                }
            }
            return blurredImage;
        }







    }





}
