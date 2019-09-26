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
            //var inputImageWidth = inputPath.Length;
            //var inputImageHeight = inputImage.Height;
                       
            if (inputPath == null)
            {
                Console.WriteLine("You need to input a path to a picture! Try again!");
            }
            //else if (inputImage < minSize)//måste fixa, try catch?
            //{
            //    Console.WriteLine("Your input picture is too small! Try again!");
            //}
            //else if (inputPath > maxSize)//måste fixe, try catch?
            //{
            //    Console.WriteLine("Your input pictrue is too big! Try again!");
            //}
            else
            {
                
                //var savePath = Path.GetDirectoryName(inputPath);
                //var saveName = Path.GetFileNameWithoutExtension(inputPath);
                //var saveExtension = Path.GetExtension(inputPath);
                var inputPicture = new Bitmap(inputImage);
                var inputPicture1 = new Bitmap(inputImage);
                var inputPicture2 = new Bitmap(inputImage);
                ImageModification.MakeNegativePicture(inputPicture);
                ImageModification.MakeBlurredPicture(inputPicture1);
                ImageModification.MakeGrayscalePicture(inputPicture2);
                //var combindingGrayscale = Path.Combine(savePath + "\\" + saveName + "_GRAYSCALE" + saveExtension);
                //var combindingBlurred = Path.Combine(savePath + "\\" + saveName + "_BLURRED" + saveExtension);
                //var combindingNegative = Path.Combine(savePath + "\\" + saveName + "_NEGATIVE" + saveExtension);
                //grayscalePicture.Save(combindingGrayscale);
                //blurredPicture.Save(combindingBlurred);
                //negativePicture.Save(combindingNegative);

                Console.WriteLine("SUCCSES");
            }
            


        }
    }
}
