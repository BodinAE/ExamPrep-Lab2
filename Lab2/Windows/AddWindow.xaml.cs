using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab2.Models;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public MainWindow MainWin {  get; set; }
        public AddWindow(MainWindow mainwin)
        {
            InitializeComponent();
            MainWin = mainwin;
            ApplianceType.ItemsSource = Enum.GetValues(typeof(ApplianceTypeEnum)).Cast<ApplianceTypeEnum>();
            Status.ItemsSource = Enum.GetValues(typeof(RepairStatusEnum)).Cast<RepairStatusEnum>();
        }

        private void AddRepair(object sender, RoutedEventArgs e)
        {
            bool DateGood, TypeGood, ModelGood, ProblemGood, NameGood, PhoneGood, StatusGood;
            DateGood = Date.Text != "";
            TypeGood = ApplianceType.SelectedItem is not null;
            ModelGood = Model.Text != "";
            ProblemGood = Problem.Text != "";
            NameGood = (ClientName.Text != "") && (ClientName.Text.Count(c => c == ' ') == 2);
            PhoneGood = Phone.Text != "";
            StatusGood = Status.SelectedItem is not null;
            if (DateGood && TypeGood && ModelGood && ProblemGood && NameGood && PhoneGood && StatusGood)
            {
                string[] dateArr = Date.ToString().Split('.');
                dateArr[2] = dateArr[2].Split(" ")[0];
                MainWin.RepairList.Add(
                    new(
                        new DateOnly(Convert.ToInt32(dateArr[2]), Convert.ToInt32(dateArr[1]), Convert.ToInt32(dateArr[0])),
                        (ApplianceTypeEnum)ApplianceType.SelectedItem,
                        Model.Text,
                        Problem.Text,
                        ClientName.Text,
                        Phone.Text,
                        "Fixer",
                        (RepairStatusEnum)Status.SelectedItem));
                MessageBox.Show("Item added");
            }
            else
            {
                MessageBox.Show("Data is bad");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
