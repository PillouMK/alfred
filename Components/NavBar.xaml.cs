using Alfred.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alfred.Components
{
    /// <summary>
    /// Logique d'interaction pour NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        private void OnSignOutClicked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.User = new UserModel();
            mainWindow.mainFrame.Navigate(new Uri("/Pages/Login.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnProfileClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("/Pages/Profile.xaml", UriKind.RelativeOrAbsolute));
        }


        private void OnDashobardClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("/Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }


        



    }
}
