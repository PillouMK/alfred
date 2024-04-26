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
using System.Windows.Forms;

namespace Alfred.Components
{
    /// <summary>
    /// Logique d'interaction pour Panel.xaml
    /// </summary>
    public partial class LeftPanel : System.Windows.Controls.UserControl
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
        private void GenerateEnvFile(string projectPath)
        {
            var envFilePath = System.IO.Path.Combine(projectPath, ".env");
            var envEntries = new List<string>
    {
        $"{EnvName1.Text}={EnvValue1.Text}",
        $"{EnvName2.Text}={EnvValue2.Text}",

        // Ajoutez d'autres lignes pour les autres champs de saisie si nécessaire
    };
            System.IO.File.WriteAllLines(envFilePath, envEntries);
            System.Windows.MessageBox.Show($"Fichier .env généré à : {envFilePath}", "Fichier généré", MessageBoxButton.OK, MessageBoxImage.Information);
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
        private void DisableGenerateButton()
        {
            GenerateProjectButton.Visibility = Visibility.Collapsed; // Cache le bouton
            GenerateLoaderIcon.Visibility = Visibility.Visible;      // Affiche le loader
        }

        private void EnableGenerateButton()
        {
            GenerateProjectButton.Visibility = Visibility.Visible;   // Affiche le bouton
            GenerateLoaderIcon.Visibility = Visibility.Collapsed;    // Cache le loader
        }



        private async void GenerateProject_Click(object sender, RoutedEventArgs e)
        {
            DisableGenerateButton();

            var selectedFramework = (FrameworkComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var projectPath = ProjectPathInput.Text;
            var projectName = ProjectNameInput.Text;

            if (string.IsNullOrWhiteSpace(projectPath) || selectedFramework == null || string.IsNullOrWhiteSpace(projectName))
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner un framework, spécifier un chemin valide et entrer un nom de projet.", "Information manquante", MessageBoxButton.OK, MessageBoxImage.Warning);
                EnableGenerateButton();
                return;
            }

            var safeProjectName = projectName.Replace(" ", "-");
            var fullProjectPath = System.IO.Path.Combine(projectPath, safeProjectName);
            try
            {
                switch (selectedFramework)
                {
                    case "React":
                        await Task.Run(() => ExecuteCommand($"npx create-react-app {safeProjectName}", projectPath));

                        GenerateEnvFile(fullProjectPath);
                        break;
                        // Ajoutez des cas pour d'autres frameworks si nécessaire.
                }
                System.Windows.MessageBox.Show("Projet généré avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show($"Erreur lors de la génération du projet: {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                EnableGenerateButton();
            }
        }





        private void ExecuteCommand(string command, string workingDirectory)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            };

            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo = procStartInfo;
                proc.Start();

                // Vous pouvez capturer la sortie ici si nécessaire
                string result = proc.StandardOutput.ReadToEnd();
                System.Windows.MessageBox.Show(result, "Résultat de la commande", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BrowseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    ProjectPathInput.Text = dialog.SelectedPath;
                }
            }
        }



    }
}