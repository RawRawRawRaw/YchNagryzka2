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

namespace УчебнаяНагрузка1
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void Log_click(object sender, RoutedEventArgs e)
        {
            if (Log.Text == "Админ" && Pas.Text == "Админ")
            {
                UserSession.IsAdmin = true;
                MainWindow c = new MainWindow();
                this.Close();
                c.ShowDialog();

            }
            else
            {
                MessageBox.Show("Логин или пароль неверны");
            }
        }

        private void esc_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogG_click(object sender, RoutedEventArgs e)
        {
            UserSession.IsAdmin = false;
            MainWindow c = new MainWindow();
            this.Close();
            c.ShowDialog();
        }
    }
}
