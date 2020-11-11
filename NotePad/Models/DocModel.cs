using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad.Models
{
    public class DocModel : ObservableObject
    {
        private string _text;
        public string Text
        {
            get {return _text;}
            set {onPropertyChanged(ref _text, value);}
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { onPropertyChanged(ref _filePath, value); }
        }
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { onPropertyChanged(ref _fileName, value); }
        }

        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath)) { return true; }
                return false;

            }
        }
    }
}
