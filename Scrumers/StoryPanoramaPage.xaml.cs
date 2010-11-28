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
                App.ViewModel.LoadStory(int.Parse(selectedStoryIdString));
                AllListBox.ItemsSource = App.ViewModel.Tasks["All"];
                ToDoListBox.ItemsSource = App.ViewModel.Tasks["To Do"];
                InProgressListBox.ItemsSource = App.ViewModel.Tasks["In progress"];
                DoneListBox.ItemsSource = App.ViewModel.Tasks["Done"];
            }
        }

        private void StoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox senderList = (ListBox)sender;
            //If selected index is -1 (no selection), do nothing
            if (senderList.SelectedIndex == -1)
                return;

            //Navigate to new page
            NavigationService.Navigate(new Uri("/TaskPage.xaml?selectedTaskId=" + ((ItemViewModel)senderList.SelectedItem).Id, UriKind.Relative));

            //Reinit selected index on -1 (no selection)
            senderList.SelectedIndex = -1;
        }
    }
}
