using System.Drawing;

namespace PhotoShopLite
{
    public class NegativeImage
    {
        public Bitmap InputImage { get; }
        public NegativeImage(Bitmap inputImage)
        {
            InputImage = inputImage;
        }


        public Bitmap TransformPictureFromOrigialToNegative()
        {
            Bitmap inputImage = new Bitmap(InputImage);

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

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    inputImage.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return inputImage;

        }

    }





}
