using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Listanäkymä1
{
    public class Lang: INotifyPropertyChanged
    {
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        public int YearPublished
        {
            get { return _yearpublished; }
            set { _yearpublished = value; }
        }
    
        private string _name;
        private int _yearpublished;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Lang(string name, int yearPublished)
        {
            Name = name;
            YearPublished = yearPublished;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Lang> lista = new ObservableCollection<Lang>(); // oli <string>
        
        public MainWindow()
        {
            InitializeComponent();

            lista.Add(new Lang("C#", 1998));//lista.Add("C#");
            lista.Add(new Lang("C++", 1986));
            lista.Add(new Lang("Kotlin", 2017));
            

            listBox1.ItemsSource = lista;
            Console.WriteLine("Hello");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //lista.Add(textBox1.Text);
      //      listBox1.ItemsSource = null;
      //      listBox1.ItemsSource = lista;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox1.Text = listBox1.SelectedValue.ToString();
            //textBox1.Text = (listBox1.SelectedItem as Lang).YearPublished.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lista[0].Name += "2";
        }
    }
}
