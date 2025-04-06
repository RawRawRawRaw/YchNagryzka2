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
    /// Логика взаимодействия для AddEditRN.xaml
    /// </summary>
    /// 

    public static class Data
    {
        public static РаспределениеНагрузки нагрузка;
    }
    public partial class AddEditRN : Window
    {
        public AddEditRN()
        {
            InitializeComponent();
        }

        УчебнаяНагрузкаContext _db = new УчебнаяНагрузкаContext();
        РаспределениеНагрузки _нагрузка;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //загружаем в списки таблицы для выбора
            Kl.Text = _db.РаспределениеНагрузкиs.ToList().ToString();
            Nomer.Text = _db.РаспределениеНагрузкиs.ToList().ToString();
            Sem.Text = _db.РаспределениеНагрузкиs.ToList().ToString();
            kol.Text = _db.РаспределениеНагрузкиs.ToList().ToString();

            TabNom.ItemsSource = _db.Преподавателиs.ToList();
            TabNom.DisplayMemberPath = "ТабельныйНомер";
            if (Data.нагрузка == null)
            {
                
                //создать новую запись
                _нагрузка = new РаспределениеНагрузки();
            }
            else
            {
                
                _нагрузка = _db.РаспределениеНагрузкиs.Find(Data.нагрузка.Ключ);

            }

            WindowAddEdit.DataContext = _нагрузка;
        }

        private void AddEdit_click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (Sem.Text.Length == 0 || Nomer.Text.Length == 0 
                || Kl.Text.Length == 0 || kol.Text.Length == 0 
                || TabNom.SelectedItem == null)
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
                if (Data.нагрузка == null)
                {
                    //добавляем в бд
                    _db.РаспределениеНагрузкиs.Add(_нагрузка);
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
