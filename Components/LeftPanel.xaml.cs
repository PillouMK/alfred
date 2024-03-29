using Newtonsoft.Json.Linq;
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
using Alfred.Controller;

namespace Alfred.Components
{
    /// <summary>
    /// Logique d'interaction pour Panel.xaml
    /// </summary>
    public partial class LeftPanel : UserControl
    {
        public LeftPanel()
        {
            InitializeComponent();
            UpdateProjectList();
        }
        public void UpdateProjectList()
        {
            ProjectComboBox.Items.Clear();
            var nomsDesProjets = GlobalVariables.dbContext.Projects.Select(p => p.Name).ToList();

            foreach (var nom in nomsDesProjets)
            {
                ProjectComboBox.Items.Add(nom);
                ProjectComboBox.SelectedItem = ProjectComboBox.Items[0];
            }

        }

        private async void CreateProjectButton(object sender, RoutedEventArgs e)
        {
            Disable_Button();
            ProjectManager project = new ProjectManager();
            await project.CreateNewProject(ProjectNameInput.Text);
            Enable_Button();
            UpdateProjectList();
        }

        private void Disable_Button()
        {
            ProjectButton.IsEnabled = false;
            ProjectButton.Content = null;
            LoaderIcon.Visibility = Visibility.Visible;
        }

        private void Enable_Button()
        {
            ProjectButton.IsEnabled = true;
            ProjectButton.Content = "Créez un nouveau projet";
            LoaderIcon.Visibility = Visibility.Collapsed;
        }
    }
}
