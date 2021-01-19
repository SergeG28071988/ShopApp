﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();

            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users)
                str += "Name:  " + user.Name + " | ";
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if(name.Length < 5)
            {
                textBoxName.ToolTip = "Это поле заполнено не корректно!";
                textBoxName.Background = Brushes.Gray;
            }
            else if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле заполнено не корректно!";
                textBoxLogin.Background = Brushes.Gray;
            }
            else if (pass.Length < 5 )
            {
                passBox.ToolTip = "Это поле заполнено не корректно!";
                passBox.Background = Brushes.Gray;
            }
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Это поле заполнено не корректно!";
                passBox_2.Background = Brushes.Gray;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле заполнено не корректно!";
                textBoxEmail.Background = Brushes.Gray;
            }
            else
            {
                textBoxName.ToolTip = "";
                textBoxName.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Всё хорошо!");
                User user = new User(name, login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
