using System;

namespace Square
{
    public class Square
    {
        public Square(int side)
        {
            Side = side;
        }
        public int Area { get { return Side * Side; } }
        public int Side { get; }
    }



    class Program
    {
        static void Main(string[] args)
        {

            var kvadrat = new Square(2);
            Console.WriteLine(kvadrat.Area);
            
            


        }
    }
}
