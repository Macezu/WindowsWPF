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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation a = new DoubleAnimation();
            a.From = 50;
            a.To = 100;
            a.Duration = new Duration(TimeSpan.Parse("0:0:5"));
            ellipse1.BeginAnimation(Canvas.LeftProperty, a);
            Canvas.SetLeft(ellipse1, 200);
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            //Title = "" + e.GetPosition(canvas).X;
            var x = e.GetPosition(canvas).X - ellipse1.Width / 2;
            var y = e.GetPosition(canvas).Y - ellipse1.Height / 2;
            Canvas.SetTop(ellipse1, y);
            Canvas.SetLeft(ellipse1, x);
            
            
            //Ellipsien lisääminen
            
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = ellipse.Height = 20;
            ellipse.Fill = Brushes.Red;
            var x = e.GetPosition(canvas).X;
            var y = e.GetPosition(canvas).Y;


            if (e.LeftButton == MouseButtonState.Pressed)
            {
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, e.GetPosition(canvas).X);
                Canvas.SetTop(ellipse, e.GetPosition(canvas).Y);
            } else if (e.RightButton == MouseButtonState.Pressed)
            {
                foreach (var elem in canvas.Children)
                {
                    
                }
                if (canvas.Children.Count>1)
                    canvas.Children.RemoveAt(canvas.Children.Count - 1);
            }    
        }
    }
}
