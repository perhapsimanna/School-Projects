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
            
            string inputPath;
            Image inputImage;
            bool error = false;

            do
            {
                Console.Write("Write the path to the picture you want to alternate here: ");
                inputPath = Console.ReadLine();

                try
                {
                    Path.GetFullPath(inputPath);
                    inputImage = Image.FromFile(inputPath);
                    if (inputImage.Height < 200 && inputImage.Width < 200 || inputImage.Height > 1080 && inputImage.Width > 1920)
                    {
                        Console.WriteLine("Your input picture must be between 200/200 - 1920/1080 (Width/Height) Try again!");
                        error = true;
                    }
                    else{
                        var inputPicture = new Bitmap(inputImage);
                        var inputPictureOne = new Bitmap(inputImage);
                        var inputPictureTwo = new Bitmap(inputImage);
                        ImageModification.MakeNegativePicture(inputPicture, inputPath);
                        ImageModification.MakeBlurredPicture(inputPictureOne, inputPath);
                        ImageModification.MakeGrayscalePicture(inputPictureTwo, inputPath);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("ERROR: Not a valid filepath", ex);
                    error = true;
                    
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ERROR: path cannot be null or empty", ex);
                    error = true;
                }

            } while (error == true) ;
     
        }
    }
}
