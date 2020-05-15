using System;
using Painter.Visualize;

namespace Painter.EntryPoint
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
        }


        private static void StartLogging()
        {
            Console.WriteLine("Hello World!");
        }

        private static void StartVisualization()
        {
            new App().Run(new MainWindow());
        }

        private static void StartReal()
        {
        }
    }
}
