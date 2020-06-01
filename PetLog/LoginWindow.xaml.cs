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
using Database;

namespace PetLog
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public UsersManager UsersManager { get; set; }
        public LoginWindow()
        {
            UsersManager = new UsersManager();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordPasswordBox.Password;

            var user = UsersManager.Login(login, password);
            if (user == null)
            {
                MessageBox.Show("Niepoprawny login lub hasło!", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            AnimalsWindow animalsWindow = new AnimalsWindow(user);
            animalsWindow.Show();

            Close();
        }
    }
}