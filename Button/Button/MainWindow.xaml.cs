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
            Point mousePos = e.GetPosition(this);

            // check x, y coordinates to see if they match the x, y coordinates of the elements on the map
            if (((mousePos.X >= 390) & (mousePos.X <= 390 + btnCarlos.Width)) & ((mousePos.Y >= 620) & (mousePos.Y <= 625 + btnCarlos.Height)))
            {
                // Check to see if Carlos is in mountainous area - Mount Haruna
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/drive.png", UriKind.Relative));
                Storyboard driveSB = this.FindResource("DriveInitialD") as Storyboard;
                driveSB.Begin();
                Debug.WriteLine("Vroom vroom");
            } else if (((mousePos.X >= 270) & (mousePos.X <= 270 + btnCarlos.Width)) & ((mousePos.Y >= 660) & (mousePos.Y <= 660 + btnCarlos.Height)))
            {
                // curry
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos eating button.png", UriKind.Relative));
                Debug.WriteLine("Curry");
            } else if (((mousePos.X >= 495) & (mousePos.X <= 495 + btnCarlos.Width)) & ((mousePos.Y >= 485) & (mousePos.Y <= 485 + btnCarlos.Height)))
            {
                // 7-Eleven
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos heart eyes.png", UriKind.Relative));
                Debug.WriteLine("7-11");
            } else if (((mousePos.X >= 180) & (mousePos.X <= 180 + btnCarlos.Width)) & ((mousePos.Y >= 490) & (mousePos.Y <= 490 + btnCarlos.Height)))
            {
                // Vending machine
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos holding coffee.png", UriKind.Relative));
                Debug.WriteLine("Vending machine");
            }
        }


        private void btnCarlos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pressed = false;
        }
    }
}

