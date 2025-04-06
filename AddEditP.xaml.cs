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
    /// Логика взаимодействия для AddEditP.xaml
    /// </summary>
    /// 

    public static class DataP
    {
        public static Преподаватели преподаватели;
    }
    public partial class AddEditP : Window
    {
        public AddEditP()
        {
            InitializeComponent();
        }

        УчебнаяНагрузкаContext _db = new УчебнаяНагрузкаContext();
        Преподаватели _преподаватели;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //загружаем в списки таблицы для выбора
            TabNom.Text = _db.Преподавателиs.ToList().ToString();
            fam.Text = _db.Преподавателиs.ToList().ToString();
            im.Text = _db.Преподавателиs.ToList().ToString();
            ot.Text = _db.Преподавателиs.ToList().ToString();
            dol.Text = _db.Преподавателиs.ToList().ToString();
            st.Text = _db.Преподавателиs.ToList().ToString();

            kaf.ItemsSource = _db.Преподавателиs.ToList();
            kaf.DisplayMemberPath = "Кафедра";
            if (Data.нагрузка == null)
            {
                //создать новую запись
                _преподаватели = new Преподаватели();
            }
            else
            {
                _преподаватели = _db.Преподавателиs.Find(DataP.преподаватели.ТабельныйНомер);
            }
            AddEditPr.DataContext = _преподаватели;
        }

        private void AddEdit_click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (TabNom.Text.Length == 0 || fam.Text.Length == 0
                || im.Text.Length == 0 || ot.Text.Length == 0
                || dol.Text.Length == 0 || kaf.SelectedItem == null
                || st.Text.Length == 0)
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
                if (DataP.преподаватели == null)
                {
                    //добавляем в бд
                    _db.Преподавателиs.Add(_преподаватели);
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
