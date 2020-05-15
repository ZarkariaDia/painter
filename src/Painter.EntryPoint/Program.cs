using System;
using Painter.Visualize;

namespace Painter.EntryPoint
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new App().Run(new MainWindow());
        }
    }
}
