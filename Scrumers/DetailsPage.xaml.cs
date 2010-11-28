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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Scrumers
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructeur
        public DetailsPage()
        {
            InitializeComponent();
        }

        // Lors de l'accès à la page, affectez l'élément sélectionné dans la liste au contexte de données
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
        }
    }
}