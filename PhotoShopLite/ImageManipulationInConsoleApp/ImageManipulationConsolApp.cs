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
            //C:\Users\90annlin\Downloads\Gramse.jpg
            Console.Write("Input your path to a picture you want to alternate here: ");
            var inputPath = Console.ReadLine();
            var inputImage = Image.FromFile(inputPath);
            var inputImageWidth = inputImage.Width;
            var inputImageHeight = inputImage.Height;
                       
            if (inputPath == null || inputImage == null)//try catch
            {
                Console.WriteLine("You need to input a path to a picture! Try again!");
            }
            else if (inputImageWidth < 100 && inputImageHeight < 100)
            {
                Console.WriteLine("Your input picture is too small! Try again!");
            }
            else if (inputImageWidth > 1920 && inputImageHeight > 1080)
            {
                Console.WriteLine("Your input pictrue is too big! Try again!");
            }
            else
            {
                
                
                var inputPicture = new Bitmap(inputImage);
                var inputPictureOne = new Bitmap(inputImage);
                var inputPictureTwo = new Bitmap(inputImage);
                ImageModification.MakeNegativePicture(inputPicture, inputPath);
                ImageModification.MakeBlurredPicture(inputPictureOne, inputPath);
                ImageModification.MakeGrayscalePicture(inputPictureTwo, inputPath);
                

                Console.WriteLine("SUCCSES");
            }
            


        }
    }
}
