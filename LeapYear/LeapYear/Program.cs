using System;

namespace LeapYear
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int i = 0;
            int currentYear = DateTime.Today.Year;
            while (true)
            {
                Console.WriteLine("Write a passed year:");
                var inputYear = Convert.ToInt32(Console.ReadLine());
                if (inputYear >= currentYear)
                {
                    Console.WriteLine(inputYear + (" this is not a passed year!"));
                }
                else
                {
                    Console.WriteLine("Here is the leap years between " + inputYear + " and " + currentYear + ":");
                    for (i = inputYear; i <= currentYear; i++)
                    {
                        if (DateTime.IsLeapYear(i))
                        {
                            Console.Write(i + "\n");
                        }
                        
                        
                    }
                }
                
            }
          

            

        }
    }
}
