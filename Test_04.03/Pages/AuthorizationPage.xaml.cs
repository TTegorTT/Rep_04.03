using System;
using System.Collections.Generic;
using System.Configuration;
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
using Test_04._03.Classes;

namespace Test_04._03.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                var users = DB.context.Пользователи.ToList();
                bool check = false;
                foreach (var user in users)
                {
                    if (user.Логин == Login.Text)
                    {
                        check = true;
                    }
                }
                if (!check)
                {
                    MessageBox.Show("Такого логина не существует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                foreach (var user in users) 
                { 
                    if(user.Логин == Login.Text)
                    {
                        if(user.Пароль == Password.Text)
                        {
                            CurrentUser.Name = user.ФИО;
                            CurrentUser.Role = user.Роль_сотрудника;

                            MessageBox.Show("Вы успешно авторизовались!");
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен не верно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        
                    }
                }  
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GuestLogin_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Name = "Гость";
            CurrentUser.Role = "Гость";

            MessageBox.Show("Вы вошли как гость!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
