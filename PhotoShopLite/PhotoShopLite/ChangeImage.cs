using System;
using System.Drawing;

namespace PhotoShopLite
{
    public class NegativeImage
    {

        public void TransformPictureFromOrigialToNegative()
        {
            Bitmap inputImage = new Bitmap("Read image");

            int inputImageWidth = inputImage.Width;
            int inputImageHeight = inputImage.Height;

            for (int y =0; y < inputImageHeight; y++)
            {
                for (int x =0; x < inputImageWidth; x++)
                {
                    Color pixelValue = inputImage.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    inputImage.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            inputImage.Save(//traget location with the name NEGATIVE in it)

        }

    }

    public class GrayScale
    {
        public void TransformPictureFromOrigialToGrayScale()
        {
            Bitmap inputImage = new Bitmap("Read Image");

            int inputImageWidth = inputImage.Width;
            int inputImageHeight = inputImage.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = inputImage.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    int averagePixelValue = (r + g + b) / 3;

                    inputImage.SetPixel(x, y, Color.FromArgb(a, averagePixelValue, averagePixelValue, averagePixelValue));

                }

            }

            inputImage.Save("Save Image with GRAYSCALE in name");



        }


    }


}
