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

namespace OlympicWheels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window2 win2 = new Window2();
  
        public MainWindow()
        {
            InitializeComponent();         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win2.ShowDialog();
        }
        private void Anim_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            
            
            foreach (UIElement elem  in canvas.Children)
            {
                DoubleAnimation a = new DoubleAnimation(); // Double-tyyppiselle arvolle
                a.From = Canvas.GetLeft(elem);
                a.To = r.Next(200,700);
                a.Duration = new Duration(TimeSpan.Parse("0:0:10"));
                elem.BeginAnimation(Canvas.LeftProperty, a);
            }           
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            List<SolidColorBrush> list = new List<SolidColorBrush>() { Brushes.Cyan, Brushes.Yellow, Brushes.Black, Brushes.Green, Brushes.Red };
            double x = canvas.Width/3;
            double y = canvas.Height/3;
            bool up = true;

            foreach (var elem in list)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = ellipse.Height = 60;
                ellipse.Stroke = elem;
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, x);
                if (up)
                {
                    Canvas.SetTop(ellipse, y);
                    up = false;
                } else
                {
                    Canvas.SetTop(ellipse, y + 35);
                    up = true;
                }          
                x += 32;
            }
            
        }
    }
}
