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
using System.Windows.Navigation;

using Scrumers.Data;
namespace Scrumers
{
    public partial class SprintsPivotPage : PhoneApplicationPage
    {
        public SprintsPivotPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
        }

        //When accessing page, refresh sprints and stories
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //select sprints in selected project
            string selectedProjectIdString = "";
            if (NavigationContext.QueryString.TryGetValue("selectedProjectId", out selectedProjectIdString))
            {
                var selectedProjectSprints = from sprint in DataProvider.getSprints()
                                             where sprint.projectId == int.Parse(selectedProjectIdString)
                                             select sprint;

                //make a panorama item for each sprint
                foreach (Sprint sp in selectedProjectSprints)
                {
                    PivotItem sprintView = new PivotItem() { Header = sp.name };
                    sprintView.Content = new Grid() { Margin = new Thickness(12, 0, 12, 0) };

                    App.ViewModel.LoadSprint(sp);

                    //create listBox
                    ListBox sprintList = new ListBox() { Margin = new Thickness(0, 0, -12, 0), ItemsSource = App.ViewModel.Sprints[sp.id] };
                    sprintList.SelectionChanged += new SelectionChangedEventHandler(tasksList_SelectionChanged);
                    sprintList.ItemTemplate = (DataTemplate)Resources["SprintsListBoxDataTemplate"];


                    ((Grid)sprintView.Content).Children.Add(sprintList);

                    SprintsPivot.Items.Add(sprintView);
                }
            }
        }

        void tasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox senderList = (ListBox)sender;
            //If selected index is -1 (no selection), do nothing
            if (senderList.SelectedIndex == -1)
                return;

            //Navigate to new page
            NavigationService.Navigate(new Uri("/StoryPivotPage.xaml?selectedStoryId=" + ((ItemViewModel)senderList.SelectedItem).Id, UriKind.Relative));

            //Reinit selected index on -1 (no selection)
            senderList.SelectedIndex = -1;
        }
    }
}