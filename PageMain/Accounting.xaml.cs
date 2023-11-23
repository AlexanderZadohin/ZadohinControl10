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
    /// Логика взаимодействия для Accounting.xaml
    /// </summary>
    public partial class Accounting : Page
    {
        public Accounting()
        {
            InitializeComponent();

            FloorFlightCmb.SelectedValuePath = "id";
            FloorFlightCmb.DisplayMemberPath = "Name";
            FloorFlightCmb.ItemsSource = App.context.FloorFlight.ToList();

            TrainCmb.SelectedValuePath = "id";
            TrainCmb.DisplayMemberPath = "Name";
            TrainCmb.ItemsSource = App.context.Train.ToList();

            VidWorkCmb.SelectedValuePath = "id";
            VidWorkCmb.DisplayMemberPath = "Name";
            VidWorkCmb.ItemsSource = App.context.VidWork.ToList();

            WorkCmb.SelectedValuePath = "id";
            WorkCmb.DisplayMemberPath = "Name";
            WorkCmb.ItemsSource = App.context.Work.ToList();

            DataGR.ItemsSource = App.context.Ucet.ToList();
        }

        private void AddAccountingBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(WorkCmb.Text))
                mes += "Выберите работу\n";
            if (string.IsNullOrWhiteSpace(VidWorkCmb.Text))
                mes += "Выберите вид работы\n";
            if (string.IsNullOrWhiteSpace(TrainCmb.Text))
                mes += "Выберите поезд\n";
            if (string.IsNullOrWhiteSpace(FloorFlightCmb.Text))
                mes += "Выберите этажность\n";
            if (string.IsNullOrWhiteSpace(DTPicker.Text))
                mes += "Выберите Дату\n";
            if (string.IsNullOrWhiteSpace(PriceTb.Text))
                mes += "Введите цену работы\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Ucet addUcet = new Ucet
            {
                Train = TrainCmb.SelectedItem as Train,
                Work = WorkCmb.SelectedItem as Work,
                DateWork = Convert.ToDateTime(DTPicker.Text),
                Price = Convert.ToDecimal(PriceTb.Text)
            };
            App.context.Ucet.Add(addUcet);
            App.context.SaveChanges();
            MessageBox.Show("Запис добавлена");

            DataGR.ItemsSource = App.context.Ucet.ToList();

            PriceTb.Text = "";
            DTPicker.Text = "";
            FloorFlightCmb.Text = "";
            TrainCmb.Text = "";
            VidWorkCmb.Text = "";
            WorkCmb.Text = "";

        }

        private void FloorFlightCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedFF = Convert.ToInt32(FloorFlightCmb.SelectedValue);
            TrainCmb.ItemsSource = App.context.Train.Where(x => x.FloorFlight.id == selectedFF).ToList(); ;
        }

        private void VidWorkCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int selectedVW = Convert.ToInt32(VidWorkCmb.SelectedValue);
            WorkCmb.ItemsSource = App.context.Work.Where(x => x.VidWork.id == selectedVW).ToList(); ;
        }
    }
}
