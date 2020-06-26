using System;
using System.Threading.Tasks;
using Painter.Geometry;

namespace Painter.Mechanics
{
    public class LoggingDrawingMechanism : IDrawingMechanism
    {
        public Task MoveToAsync(Position position)
        {
            Console.WriteLine($"Move to {position}");
            return Task.CompletedTask;
        }

        public Task UpAsync()
        {
            Console.WriteLine($"Up");
            return Task.CompletedTask;
        }

        public Task DownAsync()
        {
            Console.WriteLine($"Down");
            return Task.CompletedTask;
        }
    }
}