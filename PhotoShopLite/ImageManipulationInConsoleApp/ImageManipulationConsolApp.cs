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
            var inputPath = Console.ReadLine();
            var inputImage = Image.FromFile(inputPath);
            var savePath = Path.GetDirectoryName(inputPath);
            var saveName = Path.GetFileNameWithoutExtension(inputPath);
            var saveExtension = Path.GetExtension(inputPath);
            var inputPicture = new Bitmap(inputImage);
            var inputPicture1 = new Bitmap(inputImage);
            var inputPicture2 = new Bitmap(inputImage);
            var negativePicture = ImageModification.MakeNegativePicture(inputPicture);
            var blurredPicture = ImageModification.MakeBlurredPicture(inputPicture1);
            var grayscalePicture = ImageModification.MakeGrayscalePicture(inputPicture2);
            var combindingGrayscale = Path.Combine(savePath + "\\" + saveName + "_GRAYSCALE" + saveExtension);
            var combindingBlurred = Path.Combine(savePath + "\\" + saveName + "_BLURRED" + saveExtension);
            var combindingNegative = Path.Combine(savePath + "\\" + saveName + "_NEGATIVE" + saveExtension);
            grayscalePicture.Save(combindingGrayscale);
            blurredPicture.Save(combindingBlurred);
            negativePicture.Save(combindingNegative);

            Console.WriteLine("SUCCSES");

            


        }
    }
}
