using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NotePad.ViewModels
{
    public class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }

        public HelpViewModel()
        {
            HelpCommand = new Commands(DisplayAbout);
        }

        private void DisplayAbout()
        {
            MessageBox.Show("Made By Marco 2020");
        }
    }
}
