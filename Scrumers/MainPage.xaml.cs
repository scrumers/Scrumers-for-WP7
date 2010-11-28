using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Scrumers
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();

            // Affecter l'exemple de données au contexte de données du contrôle ListBox
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Gérer la sélection modifiée sur ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si l'index sélectionné a la valeur -1 (pas de sélection), ne rien faire
            if (MainListBox.SelectedIndex == -1)
                return;

            // Naviguer vers la nouvelle page
            NavigationService.Navigate(new Uri("/SprintsPanoramaPage.xaml?selectedProjectId=" + ((ItemViewModel)MainListBox.SelectedItem).Id, UriKind.Relative));

            // Réinitialiser l'index sélectionné sur -1 (pas de sélection)
            MainListBox.SelectedIndex = -1;
        }

        // Charger les données pour les éléments ViewModel
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
    }
}