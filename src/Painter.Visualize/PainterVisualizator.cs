using System.Threading;
using System.Windows;
using Painter.Core;
using Painter.Mechanics;

namespace Painter.Visualize
{
    public class PainterVisualizator
    {
        private PainterPreviewWindow window;
        private Application application;

        private readonly VisualDrawingMechanism drawingMechanism;

        private readonly AtomicBoolean isStarted = new AtomicBoolean();

        public PainterVisualizator()
        {
            drawingMechanism = new VisualDrawingMechanism();
        }

        public IDrawingMechanism DrawingMechanism => drawingMechanism;

        public void WaitForInitialize() => drawingMechanism.WaitForInitialize();

        public void Start()
        {
            if (!isStarted.TrySetTrue())
                return;

            var thread = new Thread(() =>
            {
                window = new PainterPreviewWindow();
                window.Activated += (_, __) =>
                {
                    drawingMechanism.Window = window;
                    drawingMechanism.WindowSynchronizationContext = SynchronizationContext.Current;
                };
                application = new Application();
                application.Run(window);
            }) {IsBackground = true};

            thread.SetApartmentState(ApartmentState.STA);

            thread.Start();
        }
    }
}