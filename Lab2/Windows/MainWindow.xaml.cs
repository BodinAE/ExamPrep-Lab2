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
using Lab2.Windows;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Repair> RepairList { get; set; }
        //public bool AllowEdit = false;
        public int RepairIndex {
            get
            {
                return repairIndex;
            }
            set
            {
                //AllowEdit = true;
                repairIndex = value;
            }
        }
        private int repairIndex;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            using (ApplicationContext AppContext = new ApplicationContext())
            {
                RepairList = AppContext.Repairs;
            }
            RepairsList.ItemsSource = RepairList;
        }

        private void ShowAddWindow(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(this);
            addWindow.ShowDialog();
        }

        private void ShowEditWindow(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(this, RepairList[RepairIndex]);
            editWindow.ShowDialog();
            RepairsList.Items.Refresh();
        }
    }
}