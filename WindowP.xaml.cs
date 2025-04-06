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
using УчебнаяНагрузка1.Model;
using Microsoft.EntityFrameworkCore;

namespace УчебнаяНагрузка1
{
    /// <summary>
    /// Логика взаимодействия для WindowP.xaml
    /// </summary>
    /// 
    
    public partial class WindowP : Window
    {
        public WindowP()
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
                _db.РаспределениеНагрузкиs.Load();
                //привязываем таблицу в датагрид
                DG.ItemsSource = _db.Преподавателиs.ToList();

                DG.Focus();
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            //добавление товара
            DataP.преподаватели = null;
            AddEditP f = new AddEditP();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                DataP.преподаватели = (Преподаватели)DG.SelectedItem;
                AddEditP f = new AddEditP();
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
                Преподаватели row = (Преподаватели)DG.SelectedItem;
                if (row != null)
                {
                    using (УчебнаяНагрузкаContext _db = new УчебнаяНагрузкаContext())
                    {
                        //удаляем запись
                        _db.Преподавателиs.Remove(row);
                        _db.SaveChanges();
                    }
                    LoadDBInDataGrid();
                }
            }
            else DG.Focus();
        }

        private void P_click(object sender, RoutedEventArgs e)
        {
            MainWindow c = new MainWindow();
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
