using All_In_One.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace All_In_One.ViewModels
{
    public class EditorViewModel
    {
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }

        public ICommand ReadCommand { get; }
        public FormatModel Format { get; set; }
        public DocModel Document { get; set; }

        public EditorViewModel(DocModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new Commands(OpenStyleDialog);
            ReadCommand = new Commands(ReadWebPage);
            WrapCommand = new Commands(ToggleWrap);
           
        }

        private void ReadWebPage()
        {

            string responseText;
            var address = Document.Text;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        responseText = responseStream.ReadToEnd();
                        Document.Text = responseText;
                    }
                }
            }
            catch 
            {
                responseText = "Could Not Parse Url";
                Document.Text = responseText;
            }
               
            


            
            
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
