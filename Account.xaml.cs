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
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public Account()
        {
            InitializeComponent();
            Lk();
        }
        public void Lk()
        {
            var sd = AppConnect.K_04Entities.Patient.Where(i => i.Login == Class1.Login).FirstOrDefault();
            if (sd != null)
            {
                Sur.Text = sd.Surname;
                Nam.Text = sd.Name;
                Pat.Text = sd.Patronymic;
                BirthD.Text = sd.BirthDate.ToString();
                PolicyN.Text = sd.PolicyNumber;
                Log.Text = sd.Login;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reception1 reception1 = new Reception1();
            reception1.Show();
            Close();
        }
    }
}
