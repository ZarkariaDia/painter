using System;
using System.Threading.Tasks;

namespace Painter.Core
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