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
        public AddWindow()
        {
            InitializeComponent();
            ApplianceType.ItemsSource = Enum.GetValues(typeof(Repair.ApplianceTypeEnum)).Cast<Repair.ApplianceTypeEnum>();
            Status.ItemsSource = Enum.GetValues(typeof(Repair.RepairStatusEnum)).Cast<Repair.RepairStatusEnum>();
        }

        private void AddRepair(object sender, RoutedEventArgs e)
        {
            if ((Date.Text == "") || 
                !(int.TryParse(ID.Text, out int id)) || 
                (ApplianceType.SelectedItem is null) || 
                (Model.Text == "") || 
                (Problem.Text == "") || 
                (ClientName.Text == "") || 
                (Phone.Text == "") || 
                (ClientName.Text == "") || 
                (Status.SelectedItem is null))
            {
                MessageBox.Show("Data not filled");
                return;
            }
            string[] date = Date.ToString().Split('.');
            date[2] = date[2].Split(" ")[0];
            MainWin.RepairList.Add(new()
            {
                Id = id,
                Date = new DateOnly(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])),
                ApplianceType = (Repair.ApplianceTypeEnum)ApplianceType.SelectedItem,
                Model = Model.Text,
                Problem = Problem.Text,
                ClientName = ClientName.Text,
                Phone = Phone.Text,
                RepairStatus = (Repair.RepairStatusEnum)Status.SelectedItem,
            });
            MessageBox.Show("Item added");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
