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
using System.Windows.Media.Animation;
using System.Media;

namespace Button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random r = new Random();
        private bool pressed = false;
        private bool tokyoBackground = false;
        private bool curryEaten = false;
        private SoundPlayer drivingSound = new SoundPlayer("assets\\driving.wav");
        private SoundPlayer risingSun = new SoundPlayer("assets\\beat of rising sun.wav");
        public MainWindow()
        {
            InitializeComponent();
            // Load sounds
            drivingSound.Load();
            risingSun.Load();

            // Storyboards
            Storyboard driveSB = this.Resources["DriveInitialD"] as Storyboard;
            driveSB.Completed += driveSB_Completed;

            Storyboard anticipate = this.Resources["Anticipation"] as Storyboard;
            anticipate.Completed += anticipate_Completed;
        }

        private void driveSB_Completed(object sender, EventArgs e)
        {
            btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos button.png", UriKind.Relative));
            btnCarlos.RenderTransform = new TranslateTransform();
        }

        private void anticipate_Completed(object sender, EventArgs e)
        {
            btnCarlos.RenderTransform = new TranslateTransform();
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


            /*
            Debug.WriteLine("Mouse Moving!");
            Storyboard anticipate = this.Resources["Anticipation"] as Storyboard;
            // check x, y coordinates to see if they match the x, y coordinates of the elements on the map
            if (((mousePos.X >= 390) & (mousePos.X <= 390 + btnCarlos.Width)) & ((mousePos.Y >= 620) & (mousePos.Y <= 625 + btnCarlos.Height)))
            {
                // Carlos is driving through Mount Haruna
                anticipate.Begin();
                Debug.WriteLine("Vroom vroom");
            }
            else if (((mousePos.X >= 270) & (mousePos.X <= 270 + btnCarlos.Width)) & ((mousePos.Y >= 660) & (mousePos.Y <= 660 + btnCarlos.Height)))
            {
                // Carlos eats curry
                anticipate.Begin();
                Debug.WriteLine("Curry");
            }
            else if (((mousePos.X >= 495) & (mousePos.X <= 495 + btnCarlos.Width)) & ((mousePos.Y >= 485) & (mousePos.Y <= 485 + btnCarlos.Height)))
            {
                // Carlos loves 7-Eleven
                anticipate.Begin();
                Debug.WriteLine("7-11");
            }
            else if (((mousePos.X >= 180) & (mousePos.X <= 180 + btnCarlos.Width)) & ((mousePos.Y >= 490) & (mousePos.Y <= 490 + btnCarlos.Height)))
            {
                // Carlo gets black sugar free coffee from the vending machine
                anticipate.Begin();
                Debug.WriteLine("Vending machine");
            }
            */
            btnCarlos.Margin = new Thickness(
                mousePos.X - (btnCarlos.Width / 2),
                mousePos.Y - (btnCarlos.Height / 2), 0, 0);
        }
        // Event handler for mouse click
        private void btnCarlos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pressed = true;
            // Determine if Tokyo background is set
            if (tokyoBackground)
            {
                // see if Carlos has already eaten the curry
                if (curryEaten)
                {
                    this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Button;component/assets/Japan empty curry.png")));
                }
                else
                {
                    this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Button;component/assets/Japan.png")));
                }

                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos button.png", UriKind.Relative));
            }
            risingSun.Stop();
            Point mousePos = e.GetPosition(this);

            // check x, y coordinates to see if they match the x, y coordinates of the elements on the map
            if (((mousePos.X >= 390) & (mousePos.X <= 390 + btnCarlos.Width)) & ((mousePos.Y >= 620) & (mousePos.Y <= 625 + btnCarlos.Height)))
            {
                // Carlos is driving through Mount Haruna
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/drive.png", UriKind.Relative));




                Storyboard driveSB = this.Resources["DriveInitialD"] as Storyboard;
                driveSB.Begin();






                drivingSound.Play();
                pressed = false;
                Debug.WriteLine("Vroom vroom");
            } else if (((mousePos.X >= 270) & (mousePos.X <= 270 + btnCarlos.Width)) & ((mousePos.Y >= 660) & (mousePos.Y <= 660 + btnCarlos.Height)))
            {
                // Carlos eats curry
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos eating button.png", UriKind.Relative));
                curryEaten = true;
                this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Button;component/assets/Japan empty curry.png")));
                Debug.WriteLine("Curry");
            } else if (((mousePos.X >= 495) & (mousePos.X <= 495 + btnCarlos.Width)) & ((mousePos.Y >= 485) & (mousePos.Y <= 485 + btnCarlos.Height)))
            {
                // Carlos loves 7-Eleven
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos heart eyes.png", UriKind.Relative));
                Debug.WriteLine("7-11");
            } else if (((mousePos.X >= 180) & (mousePos.X <= 180 + btnCarlos.Width)) & ((mousePos.Y >= 490) & (mousePos.Y <= 490 + btnCarlos.Height)))
            {
                // Carlo gets black sugar free coffee from the vending machine
                btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos holding coffee.png", UriKind.Relative));
                Debug.WriteLine("Vending machine");
            }
        }


        private void btnCarlos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pressed = false;
        }

        // The code below will run if the right button is clicked
        private void btnCarlos_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Carlos' fondest memory is night time in Japan
            btnCarlos.Source = new BitmapImage(new Uri(@"/assets/Carlos starry eyed.png", UriKind.Relative));
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Button;component/assets/Tokyo night.jpg")));
            tokyoBackground = true;
            risingSun.Play();
            Debug.Write("Tokyo night!");
        }
    }
}

