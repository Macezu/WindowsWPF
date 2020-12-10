using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using All_In_One.Models;
using Application = System.Windows.Forms.Application;
using Path = System.IO.Path;

namespace All_In_One.Views
{
    /// <summary>
    /// Interaction logic for PaintWin.xaml
    /// </summary>
    public partial class PaintWin : Window
    {
        DrawingAttributes inkDA;
        public PaintWin()
        {
            InitializeComponent();
            inkDA = new DrawingAttributes(); 

        }

        private void colorbtn_Click(object sender, RoutedEventArgs e)
        {
            var colordialog = new ColorDialog();
            colordialog.ShowDialog();
            var color = colordialog.Color;
            inkDA.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
            updateInk();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inkcanvasX.Strokes.Clear();
        }

        private void brushslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double newVal = e.NewValue;
            inkDA.Width = newVal;
            inkDA.Height = newVal;
            updateInk();
        }

       private void updateInk()
        {
            inkDA.FitToCurve = false;
            inkcanvasX.DefaultDrawingAttributes = inkDA;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)inkcanvasX.ActualWidth, (int)inkcanvasX.ActualHeight, 100.0, 100.0, PixelFormats.Default);
            bmp.Render(inkcanvasX);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            
            FileStream stream = File.Create("..\\SavedImages\\Canvas.png");
            encoder.Save(stream);
            stream.Close();
        }
    }
}
