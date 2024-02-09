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

namespace Alfred.Pages
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }

        private void Switch_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("/Pages/Register.xaml", UriKind.RelativeOrAbsolute));
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Disable_Button();
            JObject jsonResult = await Call_Login_Endpoint();
            bool is_success = jsonResult["success"].Value<bool>();
            Enable_Button();

            if (is_success)
            {
                Error_Message.Text = "";
                mainWindow.mainFrame.Navigate(new Uri("/Pages/dashboard.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Error_Message.Text = jsonResult["message"].Value<string>();
            }

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

        private async Task<JObject> Call_Login_Endpoint()
        {
            var Json_Data = new
            {
                email = Email_Input.username.Text,
                password = Pasw_Input.username.Text
            };

            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8000/api/login");
                string jsonDataString = JsonConvert.SerializeObject(Json_Data);
                StringContent content = new StringContent(jsonDataString, System.Text.Encoding.UTF8, "application/json");
                request.Content = content;

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JObject.Parse(jsonContent);

            }
            catch (Exception ex)
            {
                Error_Message.Text = ex.Message;
                JObject jsonObject = new JObject();
                jsonObject["success"] = false;
                jsonObject["message"] = ex.Message;
                return jsonObject;
            }
        }
    }
}
