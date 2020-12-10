
using System.Windows;


namespace All_In_One
{
    /// <summary>
    /// Interaction logic for NotePadWin.xaml
    /// </summary>
    public partial class NotePadWin : Window
    {
        public NotePadWin()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo("fi-FI");

            InitializeComponent();
            Title = Properties.Resources.Title;
        }
    }
}
