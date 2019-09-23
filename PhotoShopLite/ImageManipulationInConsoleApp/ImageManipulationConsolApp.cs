using PhotoShopLite;
using System;
using System.Drawing;
using System.IO;

namespace ImageManipulationInConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input your path to the picture you want to alternate here: ");
            var inputPath = (Bitmap)Image.FromFile(Console.ReadLine());
            var savePath = Path.GetFileNameWithoutExtension(inputPath.ToString);

            Bitmap inputPicture = new Bitmap(inputPath);
            Bitmap inputPicture1 = new Bitmap(inputPath);
            Bitmap inputPicture2 = new Bitmap(inputPath);
            var negativePicture = ImageModification.MakeNegativePicture(inputPicture);
            var blurredPicture = ImageModification.MakeBlurredPicture(inputPicture1);
            var grayscalePicture = ImageModification.MakeGrayscalePicture(inputPicture2);
            grayscalePicture.Save(@"C:\Users\90annlin\Downloads\Gramse_GRAYSCALE.jpg");
            blurredPicture.Save(@"C:\Users\90annlin\Downloads\Gramse_BLURRED.jpg");
            negativePicture.Save(@"C:\Users\90annlin\Downloads\Gramse_NEGATIVE.jpg");

            Console.WriteLine("SUCCSES");

            


        }
    }
}
