using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab2.Data;
using Lab2.Models;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Repair> RepairList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            using (ApplicationContext AppContext = new ApplicationContext())
            {
                RepairList = AppContext.Repairs;
            }
            RepairsList.ItemsSource = RepairList;
        }

        private void ShowAddWindow(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.MainWin = this;
            addWindow.ShowDialog();
        }
    }
}