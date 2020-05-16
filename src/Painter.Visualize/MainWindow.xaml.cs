using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Painter.Core;

namespace Painter.Visualize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VisualDrawingMechanism v;
        private const int Count = 10;
        private const int AxesThickness = 4;
        private readonly SolidColorBrush AxesColor = Brushes.Black;
        private readonly SolidColorBrush PointsColor = Brushes.Red;
        private Dispatcher uiDispatcher;
        private const int PathTtl = 5000;
        private const int PointsRadius = 5;

        public MainWindow(VisualDrawingMechanism v)
        {
            this.v = v;
            InitializeComponent();
            v.NewPositionReached += MyMethod;
            Loaded += (_, __) =>
            {
                DrawAxes();
                DrawGrid();
                uiDispatcher = Dispatcher;
            };
        }
        
        public void MyMethod(Position position)
        {
            if (Dispatcher.CurrentDispatcher != uiDispatcher)
            {
                uiDispatcher.Invoke(delegate()
                {
                    DrawCircle(position);
                    // UI thread code
                });
            }
            else
            {
                // UI thread code
            }
        }

        public void DrawCircle(Position position)
        {
            var x = canvas1.ActualWidth / Count;
            var y = canvas1.ActualHeight / Count;
            var ellipse = new Ellipse
            {
                Fill = PointsColor,
                Height = PointsRadius * 2,
                Width = PointsRadius * 2,
                Margin = new Thickness(position.X * x - PointsRadius, canvas1.ActualHeight - position.Y * y - PointsRadius, 0, 0)
            };
            canvas1.Children.Add(ellipse);
            Task.Delay(PathTtl).ContinueWith(_ =>
            {
                canvas1.Children.Remove(ellipse);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DrawGrid()
        {
            var step = canvas1.ActualWidth / Count;
            for (var i = 1; i <= Count; i++)
            {
                var verticalLine = new Line
                {
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 2,
                    X1 = step * i,
                    Y1 = 0,
                    X2 = step * i,
                    Y2 = canvas1.ActualHeight
                };
                canvas1.Children.Add(verticalLine);
            }

            step = canvas1.ActualHeight / Count;
            for (var i = 0; i < Count; i++)
            {
                var horizontalLine = new Line
                {
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 2,
                    X1 = 0,
                    Y1 = i * step,
                    X2 = canvas1.ActualWidth,
                    Y2 = i * step
                };
                canvas1.Children.Add(horizontalLine);
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
                Y2 = canvas1.ActualHeight
            };
            var yAxe = new Line
            {
                Stroke = AxesColor,
                StrokeThickness = AxesThickness,
                X1 = 0,
                Y1 = canvas1.ActualHeight,
                X2 = canvas1.ActualWidth,
                Y2 = canvas1.ActualHeight
            };
            canvas1.Children.Add(xAxe);
            canvas1.Children.Add(yAxe);
        }
    }
}