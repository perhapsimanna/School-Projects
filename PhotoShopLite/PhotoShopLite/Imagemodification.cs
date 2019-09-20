using System.Drawing;

namespace PhotoShopLite
{
    public class ImageModification
    {
       
        public static Bitmap MakeNegativePicture(Bitmap imageSource)
        {
            Bitmap refrenceImage = imageSource;

            int inputImageWidth = refrenceImage.Width;
            int inputImageHeight = refrenceImage.Height;

            for (int y = 0; y < inputImageHeight; y++)
            {
                for (int x = 0; x < inputImageWidth; x++)
                {
                    Color pixelValue = refrenceImage.GetPixel(x, y);

                    int a = pixelValue.A;
                    int r = pixelValue.R;
                    int g = pixelValue.G;
                    int b = pixelValue.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    refrenceImage.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return refrenceImage;

        }

    }





}
