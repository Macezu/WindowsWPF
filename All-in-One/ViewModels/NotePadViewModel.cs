using All_In_One.Models;


namespace All_In_One.ViewModels
{
    public class NotePadViewModel
    {
        private DocModel _document;
        public EditorViewModel Editor { get; set; }
        public FileViewModel File { get; set; }
        public HelpViewModel Help { get; set; }

        public NotePadViewModel()
        {
            _document = new DocModel();
            Help = new HelpViewModel();
            Editor = new EditorViewModel(_document);
            File = new FileViewModel(_document);
        }
    }
}
