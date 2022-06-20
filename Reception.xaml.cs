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
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : Window
    {
        Dictionary<long, Doctor> pairs = new Dictionary<long, Doctor>();
        public Reception()
        {
            InitializeComponent();
            LoadS();
     
            AppConnect.K_04Entities = new k_04Entities();
         
        }
        public void LoadS()
        {
            var Spec = AppConnect.K_04Entities.Doctor.ToList();
            foreach(var sp in Spec)
            {
                Special.Items.Add(sp.Specialization);
                pairs[sp.Id] = sp;
            }
        }

        private void Special_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = AppConnect.K_04Entities.Doctor.Where(d => d.Specialization == (string)Special.SelectedItem).ToList();
            foreach (var sp in list)
            {

                if (Doc.Items.Count > 0)
                {
                    Doc.Items.Clear();
                }

                Doc.Items.Add(sp.Name+" "+sp.Surname+" "+sp.Patronymic);

            }

            
 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"data source=10.14.206.27;initial catalog=k_04;persist security info=True;user id=user004;password=AoKd3kvc;MultipleActiveResultSets=True;App=EntityFramework;");

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Doc.SelectedIndex!=-1)
            {
                var sd=Doc.SelectedItem as Doctor;
                Doc.Items.Add(sd);
            }
        }
    }
}
