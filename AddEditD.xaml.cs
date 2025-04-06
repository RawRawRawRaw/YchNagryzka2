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

namespace УчебнаяНагрузка1
{
    /// <summary>
    /// Логика взаимодействия для AddEditD.xaml
    /// </summary>
    /// 
    public static class DataD
    {
        public static Дисциплины дисциплины;
    }
    public partial class AddEditD : Window
    {
        public AddEditD()
        {
            InitializeComponent();
        }

        УчебнаяНагрузкаContext _db = new УчебнаяНагрузкаContext();
        Дисциплины _дисциплины;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //загружаем в списки таблицы для выбора
            kod.Text = _db.Дисциплиныs.ToList().ToString();
            naz.Text = _db.Дисциплиныs.ToList().ToString();
            nap.Text = _db.Дисциплиныs.ToList().ToString();
            if (DataD.дисциплины == null)
            {
                //создать новую запись
                _дисциплины = new Дисциплины();
            }
            else
            {
                _дисциплины = _db.Дисциплиныs.Find(DataD.дисциплины.Код);
            }
            WindowAddEdit.DataContext = _дисциплины;
        }

        private void AddEdit_click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (kod.Text.Length == 0 || naz.Text.Length == 0
                || nap.Text.Length == 0)
            {
                error.Append("Вбейте все данные");

            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (DataD.дисциплины == null)
                {
                    //добавляем в бд
                    _db.Дисциплиныs.Add(_дисциплины);
                    //сохраняем изменения
                    _db.SaveChanges();

                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void esc_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
