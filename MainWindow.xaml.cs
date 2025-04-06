using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using УчебнаяНагрузка1.Model;
using Microsoft.EntityFrameworkCore;
namespace УчебнаяНагрузка1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public static class UserSession
    {
        public static bool IsAdmin { get; set; }
    }
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Add.IsEnabled = UserSession.IsAdmin;
            Edit.IsEnabled = UserSession.IsAdmin;
            Delete.IsEnabled = UserSession.IsAdmin;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //загружаем и отображаем инфу 
            LoadDBInDataGrid();
        }
        void LoadDBInDataGrid()
        {
            //созд короткоживущий контекст
            using (УчебнаяНагрузкаContext _db = new УчебнаяНагрузкаContext())
            {
                //получаем номер выделенной строки
                int selectedIndex = DG.SelectedIndex;
                //загружаем связанные таблицы
                _db.Дисциплиныs.Load();
                _db.Преподавателиs.Load();
                //привязываем таблицу в датагрид
                DG.ItemsSource = _db.РаспределениеНагрузкиs.ToList();

                DG.Focus();
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            //добавление 
            Data.нагрузка = null;
            AddEditRN f = new AddEditRN();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                Data.нагрузка = (РаспределениеНагрузки)DG.SelectedItem;
                AddEditRN f = new AddEditRN();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInDataGrid();
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                //Получаем текущую запись
                РаспределениеНагрузки row = (РаспределениеНагрузки)DG.SelectedItem;
                if (row != null)
                {
                    using (УчебнаяНагрузкаContext _db = new УчебнаяНагрузкаContext())
                    {
                        //удаляем запись
                        _db.РаспределениеНагрузкиs.Remove(row);
                        _db.SaveChanges();
                    }
                    LoadDBInDataGrid();
                }
            }
            else DG.Focus();
        }

        private void P_click(object sender, RoutedEventArgs e)
        {
            WindowP c = new WindowP();
            this.Close();
            c.ShowDialog();
        }

        private void D_click(object sender, RoutedEventArgs e)
        {
            WindowD d = new WindowD();
            this.Close();
            d.ShowDialog();
        }
    }
}