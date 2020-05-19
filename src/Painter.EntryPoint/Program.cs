using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Autofac;
using Painter.Core;
using Painter.Visualize;

namespace Painter.EntryPoint
{
    public static class Program
    {
        [STAThread]
        public static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DrawingService>().As<IDrawingService>();
            builder.RegisterType<CombinedDrawingMechanism>().As<IDrawingMechanism>();
            builder.RegisterInstance(new VisualDrawingMechanism());
            builder.RegisterType<LoggingDrawingMechanism>().AsSelf();
            builder.Register(c => new IDrawingMechanism[]
            {
                // c.Resolve<DrawingMechanism>(),
                c.Resolve<VisualDrawingMechanism>(),
                c.Resolve<LoggingDrawingMechanism>()
            });
            builder.Register(c => new DrawingMechanism(null, null));
            var container = builder.Build();

            var drawingService = container.Resolve<IDrawingService>();

            StartVisualization(container);
            Thread.Sleep(3000);
            await StartDemoAsync(drawingService);
            Console.ReadKey();
        }

        private static async Task StartDemoAsync(IDrawingService drawingService)
        {
            var lines = new IDrawingPrimitive[]
            {
                new LinePrimitive(new Position(1, 1), new Position(2,2))
            };
            await drawingService.DrawAsync(lines);
        }

        private static void StartVisualization(IContainer container)
        {
            var thread = new Thread(() =>
            {
                var app = new App();
                var window = new MainWindow(container.Resolve<VisualDrawingMechanism>());
                app.Run(window);
            });
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private static void StartReal()
        {
        }
    }
}
