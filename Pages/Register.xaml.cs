using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Alfred.Data;
using Alfred.Models_db;
using Alfred.Controller;
using Alfred.Models;

namespace Alfred.Pages
{

    public partial class Register : Page
    {
        UserManager user;
        public Register()
        {
            InitializeComponent();
        }
        MainWindow mainWindow { get => System.Windows.Application.Current.MainWindow as MainWindow; }

        private void Switch_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("/Pages/Login.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Disable_Button();
            UserManager user = new UserManager();
            JObject userRespond = await user.RegisterUser(User_Input.username.Text, Email_Input.username.Text, Pasw_Input.username.Text);

            bool success = (bool)userRespond["success"];

            if (success)
            {
                JObject JsonResult = (JObject)userRespond["result"];
                GlobalVariables.User = UserModel.FromJson(JsonResult);
                mainWindow.mainFrame.Navigate(new Uri("/Pages/dashboard.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                string error = (string)userRespond["msg"];
                Error_Message.Text = error;
            }

            Enable_Button();
        }
        private void Disable_Button()
        {
            Login_Button.IsEnabled = false;
            Login_Button.Content = null;
            LoaderIcon.Visibility = Visibility.Visible;
        }

        private void Enable_Button()
        {
            Login_Button.IsEnabled = true;
            Login_Button.Content = "Connexion";
            LoaderIcon.Visibility = Visibility.Collapsed;
        }



    }
}
