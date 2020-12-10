using All_In_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Input;


namespace All_In_One.ViewModels
{
    class EditViewModel
    {
        

        public ICommand SaveCommand { get; }
        public ICommand EraseCommand { get; }
        public ICommand SizeCommand { get; }
        public ICommand ColorCommand { get; }

        public EditModel Edit { get; set; }
        public CanvModel Canvas { get; set; }




        public EditViewModel(CanvModel inkcanvas)
        {
            Canvas = inkcanvas;
            Edit = new EditModel();
            SaveCommand = new Commands(SaveFile);
            EraseCommand = new Commands(EraseCanvas);
            SizeCommand = new Commands(ChangeSize);
            ColorCommand = new Commands(ChangeColor);
        }

        public void ChangeColor()
        {
            var colordialog = new ColorDialog();
            colordialog.ShowDialog();
            var color =  colordialog.Color;
            Edit.Color = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            

        }

        public void ChangeSize()
        {
            Edit.Width = Edit.Slider.Value;
            

        }

        public void EraseCanvas()
        {
            Canvas.InkCanvas.Children.Clear();
        }

        public void SaveFile()
        {
            throw new NotImplementedException();
        }
    }
}
