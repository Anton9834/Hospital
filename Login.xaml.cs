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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            AppConnect.K_04Entities=new k_04Entities();
#if DEBUG
            Log.Text = "petrov45";
            Pass.Password = "123";
#endif
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patientObj=AppConnect.K_04Entities.Patient.FirstOrDefault(x=>x.Login==Log.Text && x.Password ==Pass.Password);
                if (patientObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Class1.Login = patientObj.Login;
                    //MessageBox.Show("Здравствуйте " + patientObj.Surname + " " + patientObj.Name + " " + patientObj.Patronymic + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Reception1 reception1 = new Reception1();
                    reception1.Show();
                    Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
