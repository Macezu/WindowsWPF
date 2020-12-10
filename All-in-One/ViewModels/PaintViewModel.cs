using All_In_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace All_In_One.ViewModels
{
    class PaintViewModel
    {
        private CanvModel _canvas;
        public EditViewModel Edit { get; set; }

        public PaintViewModel()
        {
            _canvas = new CanvModel();
            Edit = new EditViewModel(_canvas);
        }
    }

}
