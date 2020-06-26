using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Autofac;
using Painter.Core;
using Painter.Geometry;
using Painter.Mechanics;
using Painter.Visualize;

namespace Painter.EntryPoint
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var visualizator = new PainterVisualizator();
            visualizator.Start();
            visualizator.WaitForInitialize();

            var builder = new ContainerBuilder();
            builder.RegisterType<DrawingService>().As<IDrawingService>();
            builder.RegisterType<CombinedDrawingMechanism>().As<IDrawingMechanism>();
            builder.RegisterType<LoggingDrawingMechanism>().AsSelf();
            builder.Register(c => new IDrawingMechanism[]
            {
                // c.Resolve<DrawingMechanism>(),
                visualizator.DrawingMechanism,
                c.Resolve<LoggingDrawingMechanism>()
            });
            builder.Register(c => new DrawingMechanism(null, null));
            var container = builder.Build();

            var drawingService = container.Resolve<IDrawingService>();

            StartDemoAsync(drawingService).GetAwaiter().GetResult();
            Console.ReadKey();
        }

        private static async Task StartDemoAsync(IDrawingService drawingService)
        {
            var lines = new IDrawingPrimitive[]
            {
                new LinePrimitive(VectorPosition.FromCentimeters(1, 1), VectorPosition.FromCentimeters(2, 2))
            };
            await drawingService.DrawAsync(new RandomPrimitive(-1));
        }
    }
}
