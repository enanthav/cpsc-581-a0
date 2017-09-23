using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
using System.Windows.Media.Animation;

namespace Button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random r = new Random();
        private DispatcherTimer sleepTimer = new DispatcherTimer();
        private bool pressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCarlos_MouseMove(object sender, MouseEventArgs e)
        {
            //runs everytime the mouse position is updated within the control
            if (pressed == false)
            {
                //mouse button not held down, we do nothing
                return;
            }

            Point mousePos = e.GetPosition(this);

            Debug.WriteLine("Please stop bothering me");
            btnCarlos.Margin = new Thickness(
                mousePos.X - (btnCarlos.Width / 2),
                mousePos.Y - (btnCarlos.Height / 2), 0, 0);

        }

        private void btnCarlos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pressed = true;
            btnCarlos.Source = new BitmapImage(new Uri(@"/assets/drive.png", UriKind.Relative));
        }

        private void btnCarlos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pressed = false;
        }
    }
}

