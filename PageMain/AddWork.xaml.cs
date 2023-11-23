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
    /// Логика взаимодействия для AddWork.xaml
    /// </summary>
    public partial class AddWork : Page
    {
        public AddWork()
        {
            InitializeComponent();

            VidWorkCmb.SelectedValuePath = "id";
            VidWorkCmb.DisplayMemberPath = "Name";
            VidWorkCmb.ItemsSource = App.context.VidWork.ToList();

        }
        private void AddWorkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WorkNameTb.Text == "")
            {
                MessageBox.Show("Введите наименование работы");
            }
            if (VidWorkCmb.Text == "")
            {
                MessageBox.Show("Выберите типо работ");
            }
            Work addWork = new Work
            {
                Name = WorkNameTb.Text,
                VidWork = VidWorkCmb.SelectedItem as VidWork
            };
            App.context.Work.Add(addWork);
            App.context.SaveChanges();
            MessageBox.Show("Работа добавлена!");
            WorkNameTb.Text = "";
            VidWorkCmb.Text = "";
        }
    }
}
