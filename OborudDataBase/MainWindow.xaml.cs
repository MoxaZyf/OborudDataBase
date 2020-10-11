using OborudDataBase.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using OborudDataBase.ViewModels;

namespace OborudDataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DB db;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
            //db = new DB();
            //db.Oboruds.Load();
            //List<User> users = new List<User>();
            //users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23), ImageUrl = "http://www.wpf-tutorial.com/images/misc/john_doe.jpg" });
            //users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            //users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            //dgUsers.ItemsSource = users; 
        }

        private void EditOrder(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MyViewModel;
            if (vm != null)
            {
                vm.Save();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так, данные не сохранились");
            }
        }
    }
    //public class User
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //    public DateTime Birthday { get; set; }

    //    public string ImageUrl { get; set; }
    //}
}
