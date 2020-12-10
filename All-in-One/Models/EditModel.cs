using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace All_In_One.Models
{
    class EditModel : ObservableObject
    {
        private DrawingAttributes _ink;
        public DrawingAttributes Ink
        {
            get { return _ink; }
            set { onPropertyChanged(ref _ink, value); }
        }

        private Slider _slider;
        public Slider Slider
        {
            get { return _slider; }
            set { onPropertyChanged(ref _slider, value); }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set { onPropertyChanged(ref _width, value); }
        }

        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { onPropertyChanged(ref _color, value); }
        }

 
    }
}
