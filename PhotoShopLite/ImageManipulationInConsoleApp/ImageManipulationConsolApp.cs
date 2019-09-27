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
            Console.Write("Write the path to the picture you want to alternate here: ");

            var inputPath = Console.ReadLine();
            var inputImage = Image.FromFile(inputPath);
            var inputImageWidth = inputImage.Width;
            var inputImageHeight = inputImage.Height;

            if (inputImageWidth < 200 && inputImageHeight < 200)
            {
                Console.WriteLine("Your input picture cannot be smaller then 200 x 200! Try again!");
            }
            else if (inputImageWidth > 1920 && inputImageHeight > 1080)
            {
                Console.WriteLine("Your input pictrue cannot be bigger then 1920 x 1080! Try again!");
            }
            else
            {
                var inputPicture = new Bitmap(inputImage);
                var inputPictureOne = new Bitmap(inputImage);
                var inputPictureTwo = new Bitmap(inputImage);
                ImageModification.MakeNegativePicture(inputPicture, inputPath);
                ImageModification.MakeBlurredPicture(inputPictureOne, inputPath);
                ImageModification.MakeGrayscalePicture(inputPictureTwo, inputPath);
            }

            /*Löser inte detta
            try
            {


            }
            catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine("The file was not found, please try again", fileNotFound);
            }
            catch (ArgumentException noFileInput)
            {
                Console.WriteLine("You need to enter a path to an imagefile that you would like to modify", noFileInput);
            }
            */
        }
    }
}
