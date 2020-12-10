using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;

namespace All_In_One.Models
{
    class CanvModel: ObservableObject
    {
        private Stroke _stroke;

        public Stroke Stroke
        {
            get { return _stroke; }
            set { onPropertyChanged(ref _stroke, value); }
        }

        private InkCanvas _inkcanvas;
        public InkCanvas InkCanvas
        {
            get { return _inkcanvas; }
            set { onPropertyChanged(ref _inkcanvas, value); }
        }

       

 

    }
}
