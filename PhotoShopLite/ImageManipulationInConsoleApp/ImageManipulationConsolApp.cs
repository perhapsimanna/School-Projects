using PhotoShopLite;
using System;
using System.Drawing;

namespace ImageManipulationInConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input you path to your picture: ");
            var inputPath = (Bitmap)Image.FromFile(Console.ReadLine()); 
            Bitmap inputPicture = new Bitmap(inputPath);
            var negativePicture = ImageModification.MakeNegativePicture(inputPicture);
            negativePicture.Save(@"C:\Users\90annlin\Downloads\Gramse_NEGATIVE.jpg");
            


        }
    }
}
