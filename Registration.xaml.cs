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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            AppConnect.K_04Entities=new k_04Entities();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.K_04Entities.Patient.Count(x => x.Login == TextSur.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже существует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Patient patientObj = new Patient()
                {
                    Surname = TextSur.Text,
                    Name = TextName.Text,
                    Patronymic = TextPatr.Text,
                    BirthDate = Birth.SelectedDate.Value,
                    PolicyNumber = TextPolicy.Text,
                    Login= TextLog.Text,
                    Password= TextPass.Password
                };
                AppConnect.K_04Entities.Patient.Add(patientObj);
                AppConnect.K_04Entities.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Reception1 reception1 = new Reception1();
                reception1.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
