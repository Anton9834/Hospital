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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Hospital
{
    /// <summary>
    /// Логика взаимодействия для Reception1.xaml
    /// </summary>
    public partial class Reception1 : Window
    {
        Dictionary<long, Doctor> pairs = new Dictionary<long, Doctor>();
        public List<Doctor> doctors { get; set; }

        public Reception1()
        {
            InitializeComponent();
            LoadS();
            AppConnect.K_04Entities = new k_04Entities();
            DataContext = this;
        }
        public void LoadS()
        {
            var Spec = AppConnect.K_04Entities.Specialization.ToList();
            foreach (var sp in Spec)
            {
                Special.Items.Add(sp);
            }
        }

        private void Special_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var special = Special.SelectedItem as Specialization;
            if (special != null)
            {
                Doc.ItemsSource = AppConnect.K_04Entities.Doctor.Where(d => d.Specialization == special.Name).ToList();
            }
            Doc.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection connection = new SqlConnection(@"data source=10.14.206.27;initial catalog=k_04;persist security info=True;user id=user004;password=AoKd3kvc;MultipleActiveResultSets=True;App=EntityFramework;");

            //connection.Open();
            //string cmd = "SELECT Timetable.[Date], Timetable.StartTime, Timetable.FinishTime, Doctor.Surname, Doctor.[Name], Doctor.Patronymic FROM Timetable INNER JOIN Doctor ON Timetable.Doctor = Doctor.Id"; // Из какой таблицы нужен вывод 
            //SqlCommand createCommand = new SqlCommand(cmd, connection);
            //createCommand.ExecuteNonQuery();

            //SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            //DataTable dt = new DataTable("Timetable"); // В скобках указываем название таблицы
            //dataAdp.Fill(dt);
            //asd.ItemsSource = dt.DefaultView; // Сам вывод 
            //connection.Close();
            //var Spec = AppConnect.K_04Entities.Timetable.ToList();
            //foreach (var sp in Spec)
            //{
            //    asd.ItemsSource = Spec.ToList();
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Doc.Items.Count == 0)
            {
                MessageBox.Show("Выберите врача", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if(RecDate.SelectedDate==null)
            {
                MessageBox.Show("Выберите дату на которую хотите записаться", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                var id = AppConnect.K_04Entities.Reception.ToList().Count + 1;

                string LoginPatient = Class1.Login;

                Reception reception = new Reception();
                reception.Id = id++;
                reception.Date = RecDate.SelectedDate.Value;
                reception.Doctor = (Doc.SelectedItem as Doctor).Id;
                reception.Patient = Class1.Login;
                reception.Status = "В ожидании";

                AppConnect.K_04Entities.Reception.Add(reception);

                int result = AppConnect.K_04Entities.SaveChanges();
                if (result > 0)
                {
                    doctors = null;
                    Doc.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
                    asd.ItemsSource = null;
                    MessageBox.Show("Запись прошла успешно");
                }

                else
                {
                    MessageBox.Show("ERROR");
                }

                AppConnect.K_04Entities.SaveChanges();
            }

        }

        private void Cabinet_Click(object sender, RoutedEventArgs e)
        {
            Cabinet cabinet = new Cabinet();
            cabinet.Show();
            Close();
        }

        private void Acc_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Show();
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source =DESKTOP-7PPGAEU\SQLEXPRESS; Initial Catalog = k_04; Integrated Security = True");

            connection.Open();
            string cmd = "SELECT Timetable.[Date], Timetable.StartTime, Timetable.FinishTime, Doctor.Surname, Doctor.[Name], Doctor.Patronymic FROM Timetable INNER JOIN Doctor ON Timetable.Doctor = Doctor.Id"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Timetable"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            asd.ItemsSource = dt.DefaultView; // Сам вывод 
            connection.Close();

        }
    }
}
