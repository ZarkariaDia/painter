using System;
using Painter.Core;
using Painter.Visualize;

namespace Painter.EntryPoint
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            StartDemo();
        }

        private static void StartDemo()
        {
            var lines = new IDrawingPrimitive[]
            {
                new LinePrimitive(new Position(), new Position())
            };
            var service = new DrawingService(null);
            service.DrawAsync(lines);
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
