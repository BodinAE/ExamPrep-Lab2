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

namespace Lab2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public MainWindow MainWin { get; set; }
        public Repair SelectedRepair { get; set; }
        
        public EditWindow(MainWindow mainwin, Repair selectedrepair)
        {
            InitializeComponent();
            MainWin = mainwin;
            ApplianceType.ItemsSource = Enum.GetValues(typeof(ApplianceTypeEnum)).Cast<ApplianceTypeEnum>();
            Status.ItemsSource = Enum.GetValues(typeof(RepairStatusEnum)).Cast<RepairStatusEnum>();
            SelectedRepair = selectedrepair;
            Date.Text = SelectedRepair.Date.ToString();
            ApplianceType.SelectedIndex = (int)SelectedRepair.ApplianceType;
            Model.Text = SelectedRepair.Model;
            Problem.Text = SelectedRepair.Problem;
            ClientName.Text = SelectedRepair.Name.ToString();
            Phone.Text = SelectedRepair.Phone;
            Status.SelectedIndex = (int)SelectedRepair.RepairStatus;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditRepair(object sender, RoutedEventArgs e)
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
                SelectedRepair.Date = new DateOnly(Convert.ToInt32(dateArr[2]), Convert.ToInt32(dateArr[1]), Convert.ToInt32(dateArr[0]));
                SelectedRepair.ApplianceType = (ApplianceTypeEnum)ApplianceType.SelectedItem;
                SelectedRepair.Model = Model.Text;
                SelectedRepair.Problem = Problem.Text;
                SelectedRepair.Name = new ClientName(ClientName.Text);
                SelectedRepair.Phone = Phone.Text;
                SelectedRepair.RepairStatus = (RepairStatusEnum)Status.SelectedItem;
                MessageBox.Show("Item changed");
                Close();
            }
            else
            {
                MessageBox.Show("Data is bad");
            }

        }
    }
}
