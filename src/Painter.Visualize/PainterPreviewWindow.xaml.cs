using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Painter.Geometry;

namespace Painter.Visualize
{
    public partial class PainterPreviewWindow : Window
    {
        private readonly VisualDrawingMechanism v;
        private const int Count = 10;
        private const int AxesThickness = 4;
        private readonly SolidColorBrush AxesColor = Brushes.Black;
        private readonly SolidColorBrush PointsColor = Brushes.Red;
        private const int PathTtl = 5000;
        private const int PointsRadius = 5;

        public PainterPreviewWindow()
        {
            InitializeComponent();
            Loaded += (_, __) =>
            {
                DrawAxes();
                DrawGrid();
            };
        }

        public void DrawCircle(VectorPosition position)
        {
            var x = Canvas.ActualWidth / Count;
            var y = Canvas.ActualHeight / Count;
            var ellipse = new Ellipse
            {
                Fill = PointsColor,
                Height = PointsRadius * 2,
                Width = PointsRadius * 2,
                Margin = new Thickness(position.CentimetersX * x - PointsRadius, Canvas.ActualHeight - position.CentimetersY * y - PointsRadius, 0, 0)
            };
            Canvas.Children.Add(ellipse);
            Task.Delay(PathTtl).ContinueWith(_ =>
            {
                Canvas.Children.Remove(ellipse);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DrawGrid()
        {
            var step = Canvas.ActualWidth / Count;
            for (var i = 1; i <= Count; i++)
            {
                var verticalLine = new Line
                {
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 2,
                    X1 = step * i,
                    Y1 = 0,
                    X2 = step * i,
                    Y2 = Canvas.ActualHeight
                };
                Canvas.Children.Add(verticalLine);
            }

            step = Canvas.ActualHeight / Count;
            for (var i = 0; i < Count; i++)
            {
                var horizontalLine = new Line
                {
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 2,
                    X1 = 0,
                    Y1 = i * step,
                    X2 = Canvas.ActualWidth,
                    Y2 = i * step
                };
                Canvas.Children.Add(horizontalLine);
            }
        }
        private void DrawAxes()
        {
            var xAxe = new Line
            {
                Stroke = AxesColor,
                StrokeThickness = AxesThickness,
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = Canvas.ActualHeight
            };
            var yAxe = new Line
            {
                Stroke = AxesColor,
                StrokeThickness = AxesThickness,
                X1 = 0,
                Y1 = Canvas.ActualHeight,
                X2 = Canvas.ActualWidth,
                Y2 = Canvas.ActualHeight
            };
            Canvas.Children.Add(xAxe);
            Canvas.Children.Add(yAxe);
        }
    }
}