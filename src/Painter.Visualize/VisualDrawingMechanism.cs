using System.Threading;
using System.Threading.Tasks;
using Painter.Core;

namespace Painter.Visualize
{
    public class VisualDrawingMechanism : IDrawingMechanism
    {
        private int isUpState;
        public delegate void MarkPosition(Position position);
        public event MarkPosition NewPositionReached;

        public Task MoveToAsync(Position position)
        {
            NewPositionReached?.Invoke(position);
            return Task.CompletedTask;
        }

        public Task UpAsync()
        {
            Interlocked.Exchange(ref isUpState, 1);
            return Task.CompletedTask;
        }

        public Task DownAsync()
        {
            Interlocked.Exchange(ref isUpState, 0);
            return Task.CompletedTask;
        }
    }
}