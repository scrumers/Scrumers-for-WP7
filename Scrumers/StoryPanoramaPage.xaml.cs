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
    public partial class StoryPanoramaPage : PhoneApplicationPage
    {
        public StoryPanoramaPage()
        {
            InitializeComponent();
        }

        //When accessing page, refresh story tasks
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedStoryIdString = "";
            if (NavigationContext.QueryString.TryGetValue("selectedStoryId", out selectedStoryIdString))
            {
                Story currentStory = (from story in DataProvider.getStories() where story.id == int.Parse(selectedStoryIdString) select story).First<Story>();
                App.ViewModel.LoadStory(currentStory);
                AllListBox.ItemsSource = App.ViewModel.Tasks["All"];
                ToDoListBox.ItemsSource = App.ViewModel.Tasks["To Do"];
                InProgressListBox.ItemsSource = App.ViewModel.Tasks["In progress"];
                DoneListBox.ItemsSource = App.ViewModel.Tasks["Done"];
            }
        }

        private void StoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO : go to Task Page
        }
    }
}
