using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Painter.Core;
using Painter.Geometry;

namespace Painter.Visualize
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SynchronizationContext synchronizationContext;
        public event NewPosition New;

        public void InvokeNew(Position position)
        {
            New.Invoke(position);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            New += (p) =>
            {
                ((MainWindow) MainWindow).Dispatcher.Invoke(() => ((MainWindow) MainWindow)?.DrawCircle(p));
            };
        }
    }

    public delegate void NewPosition(Position position);
}