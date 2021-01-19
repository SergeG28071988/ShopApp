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

namespace ShopApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (name.Length < 5)
            {
                textBoxName.ToolTip = "Это поле заполнено не корректно!";
                textBoxName.Background = Brushes.Gray;
            }
            else if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле заполнено не корректно!";
                textBoxLogin.Background = Brushes.Gray;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле заполнено не корректно!";
                passBox.Background = Brushes.Gray;
            }

            else
            {
                textBoxName.ToolTip = "";
                textBoxName.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;

                using (AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(b => b.Name == name && b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if(authUser != null)
                {
                    MessageBox.Show("Всё хорошо!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Вы ввели что-то не так!");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
