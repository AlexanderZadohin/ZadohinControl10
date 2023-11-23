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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZadohinControl10.Model;

namespace ZadohinControl10.PageMain
{
    /// <summary>
    /// Логика взаимодействия для AddTrain.xaml
    /// </summary>
    public partial class AddTrain : Page
    {
        public AddTrain()
        {
            InitializeComponent();

            FloorFlightCmb.SelectedValuePath = "id";
            FloorFlightCmb.DisplayMemberPath = "Name";
            FloorFlightCmb.ItemsSource = App.context.FloorFlight.ToList();
        }
        private void AddTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TrainNameTb.Text == "")
            {
                MessageBox.Show("Введите наименование работы");
            }
            if (FloorFlightCmb.Text == "")
            {
                MessageBox.Show("Выберите типо работ");
            }
            Train addTrain = new Train
            {
                Name = TrainNameTb.Text,
                FloorFlight = FloorFlightCmb.SelectedItem as FloorFlight
            };
            App.context.Train.Add(addTrain);
            App.context.SaveChanges();
            MessageBox.Show("Работа добавлена!");
            TrainNameTb.Text = "";
            FloorFlightCmb.Text = "";
        }
    }
}
