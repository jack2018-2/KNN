using System;
using ConsoleApp10.Algorythm;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            var algorythm = new KNN();
            PrintParams();
            algorythm.DoKNN();
            Console.ReadKey();
        }

        private static void PrintParams()
        {
            Console.WriteLine("Алгоритм запущен с параметрами:");
        }
    }
}
