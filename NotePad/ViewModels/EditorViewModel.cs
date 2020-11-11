using NotePad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace NotePad.ViewModels
{
    public class EditorViewModel
    {
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public FormatModel Format { get; set; }
        public DocModel Document { get; set; }

        public EditorViewModel(DocModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new Commands(OpenStyleDialog);
            WrapCommand = new Commands(ToggleWrap);
           
        }

        private void OpenStyleDialog()
        {
            // Later
            //throw new NotImplementedException();
            var fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.ShowDialog();
        }

        private void ToggleWrap()
        {
            if (Format.Wrap == System.Windows.TextWrapping.Wrap)
                Format.Wrap = System.Windows.TextWrapping.NoWrap;
            else
                Format.Wrap = System.Windows.TextWrapping.Wrap;
        }
    }
}
