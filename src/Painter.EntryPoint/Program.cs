using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Painter.Core;
using Painter.Visualize;
using DispatcherPriority = System.Windows.Threading.DispatcherPriority;

namespace Painter.EntryPoint
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //StartDemo();
            StartVisualization();
        }

        private static void StartDemo()
        {
            var lines = new IDrawingPrimitive[]
            {
                new LinePrimitive(new Position(), new Position())
            };
            var service = new DrawingService(new CombinedDrawingMechanism(new []
            {
                new VisualDrawingMechanism()
            }));
            service.DrawAsync(lines);
        }


        private static void StartLogging()
        {
            Console.WriteLine("Hello World!");
        }


        public static void StartVisualization()
        {
            var app = new App();
            var v = new VisualDrawingMechanism();
            var window = new MainWindow(v);
            app.Run(window);
        }

        private static void StartReal()
        {
        }
    }
}
