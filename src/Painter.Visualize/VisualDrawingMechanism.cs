using System;
using System.Threading;
using System.Threading.Tasks;
using Painter.Core;
using Painter.Geometry;
using Painter.Mechanics;

namespace Painter.Visualize
{
    internal class VisualDrawingMechanism : IDrawingMechanism
    {
        private SynchronizationContext windowSynchronizationContext;
        private PainterPreviewWindow window;

        private readonly AtomicBoolean isUpState = new AtomicBoolean();

        private readonly TaskCompletionSource<bool> initSignal = new TaskCompletionSource<bool>(false);

        public SynchronizationContext WindowSynchronizationContext
        {
            set
            {
                windowSynchronizationContext = value ?? throw new ArgumentNullException(nameof(value));
                initSignal.TrySetResult(true);
            }
        }

        public PainterPreviewWindow Window
        {
            set => window = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void WaitForInitialize()
        {
            initSignal.Task.GetAwaiter().GetResult();
        }

        public Task MoveToAsync(VectorPosition position)
        {
            //should draw different circle for IsUpState == true
            InvokeOnWindowThread(() => window.DrawCircle(position));
            return Task.CompletedTask;
        }

        public Task UpAsync()
        {
            isUpState.TrySetTrue();
            return Task.CompletedTask;
        }

        public Task DownAsync()
        {
            isUpState.TrySetFalse();
            return Task.CompletedTask;
        }

        private void InvokeOnWindowThread(Action callback) => windowSynchronizationContext.Send(_ => callback(), null);
    }
}