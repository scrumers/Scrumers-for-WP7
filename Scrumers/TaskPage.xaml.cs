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
using System.Windows.Data;

namespace Scrumers
{
    public partial class TaskPage : PhoneApplicationPage
    {
        public TaskPage()
        {
            InitializeComponent();
        }

        //When accessing page, display the task
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedTaskIdString = "";
            if (NavigationContext.QueryString.TryGetValue("selectedTaskId", out selectedTaskIdString))
            {
                
                App.ViewModel.LoadTask(int.Parse(selectedTaskIdString));

                //create a binding between PageTitle text and currentTask name
                Binding bind = new Binding("name");
                bind.Mode = BindingMode.OneWay;
                bind.Source = App.ViewModel.CurrentTask;
                PageTitle.SetBinding(TextBlock.TextProperty, bind);
            }
        }

        private void MarkTaskToDo(object sender, RoutedEventArgs e)
        {

        }

        private void PlayPause(object sender, RoutedEventArgs e)
        {

        }

        private void MarkTaskDone(object sender, RoutedEventArgs e)
        {

        }
    }
}