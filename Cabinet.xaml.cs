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
using Hospital.ApplicationData;

namespace Hospital
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Window
    {
        Dictionary<long, Doctor> pairs = new Dictionary<long, Doctor>();
        public List<Doctor> doctors { get; set; }
        public List<Reception> reception { get; set; }
        public Cabinet()
        {
            InitializeComponent();
            Lr();
            Lf();
            DataContext = this;
        }
       
        public void Lr()
        {
            var InCh = AppConnect.K_04Entities.Patient.Where(i => i.Login == Class1.Login).FirstOrDefault();
            if (InCh != null)
            {
                FIO.Text = InCh.Surname+" "+InCh.Name+" "+InCh.Patronymic;
            }
        }
        public void Lf()
        {
            var Stat = AppConnect.K_04Entities.Status.ToList();
            foreach (var st in Stat)
            {
                Status.Items.Add(st);
            }
        }

        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var status = Status.SelectedItem as Status;
            if (status != null)
            {
                Rec.ItemsSource = AppConnect.K_04Entities.Reception.Where(d => d.Status == status.Name).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reception1 reception1 = new Reception1();
            reception1.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Show();
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
