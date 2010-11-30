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
using System.Windows.Threading;
using System.ComponentModel;

namespace Scrumers
{
    public partial class TaskPage : PhoneApplicationPage
    {
        private bool playing = false;
        private DispatcherTimer playTimer;
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

                //create a binding between EstimatedDurationLeft text and currentTask name
                bind = new Binding("EstimatedRemainingTime");
                bind.Mode = BindingMode.OneWay;
                bind.Source = App.ViewModel.CurrentTask;                
                EstimatedDurationLeft.SetBinding(TextBlock.TextProperty, bind);
            }
        }

        private void MarkTaskToDo(object sender, RoutedEventArgs e)
        {
            App.ViewModel.CurrentTask.Status = "To do";
            App.ViewModel.CurrentTask.elapsedTime = 0;
            backAction();
            NavigationService.GoBack();
        }

        private void PlayPause(object sender, RoutedEventArgs e)
        {
            if (!playing)
            {
                App.ViewModel.CurrentTask.Status = "In progress";
                if (playTimer == null)
                {
                    playTimer = new DispatcherTimer();
                    playTimer.Interval = TimeSpan.FromSeconds(1);
                    playTimer.Tick +=
                        delegate(object s, EventArgs args)
                        {
                            App.ViewModel.CurrentTask.elapsedTime += 1;
                        };
                    
                }
                PlayPauseButton.Content = "Pause";
                playTimer.Start();
                playing = true;
            }
            else
            {
                PlayPauseButton.Content = "Play";
                playTimer.Stop();
                playing = false;
            }
        }

        private void MarkTaskDone(object sender, RoutedEventArgs e)
        {
            App.ViewModel.CurrentTask.Status = "Done";
            backAction();
            NavigationService.GoBack();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            backAction();
            base.OnBackKeyPress(e);
        }

        private void backAction()
        {
            if (playTimer != null)
            {
                playTimer.Stop();
            }
            playing = false;
        }
    }
}