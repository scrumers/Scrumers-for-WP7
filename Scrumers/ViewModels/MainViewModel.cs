using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;

using Scrumers.Data;

namespace Scrumers
{
    public class MainViewModel : INotifyPropertyChanged
    {
        

        /// <summary>
        /// Collection for projects
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        /// <summary>
        /// Collection for sprints and their stories
        /// </summary>
        public Dictionary<int, ObservableCollection<ItemViewModel>> Sprints { get; private set; }

        /// <summary>
        /// Collection for tasks of a story (keys : All, To Do, In progress, Done)
        /// </summary>
        public Dictionary<string, ObservableCollection<ItemViewModel>> Tasks { get; private set; }

        /// <summary>
        /// When in Task page, represent the selected task
        /// </summary>
        public Task CurrentTask { get; private set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.Sprints = new Dictionary<int, ObservableCollection<ItemViewModel>>();
            this.Tasks = new Dictionary<string, ObservableCollection<ItemViewModel>>();
        }

        private string _sampleProperty = "Valeur de propriété d'un exemple de runtime";
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Create and add projects in collection Items.
        /// </summary>
        public void LoadData()
        {
            foreach (Project p in DataProvider.getProjects())
            {
                this.Items.Add(new ItemViewModel() { LineOne = p.name, LineTwo = p.organisationName, LineThree = p.createdAt.ToShortDateString(), Id = p.id.ToString() });
            }

            this.IsDataLoaded = true;
        }

        /// <summary>
        /// Create and add a sprint and its user stories
        /// </summary>
        public void LoadSprint(Sprint sp)
        {
            if (!Sprints.ContainsKey(sp.id))
            {
                this.IsDataLoaded = false;
                ObservableCollection<ItemViewModel> newCollection = new ObservableCollection<ItemViewModel>();
                foreach (Story st in DataProvider.getStories())
                {
                    if (st.sprintId == sp.id)
                    {
                        newCollection.Add(new ItemViewModel() { LineOne = st.name, LineTwo = st.status, LineThree = st.createdAt.ToShortDateString(), Id = st.id.ToString() });
                    }
                }
                Sprints.Add(sp.id, newCollection);
                this.IsDataLoaded = true;
            }
        }

        /// <summary>
        /// Create and add tasks of a story
        /// </summary>
        public void LoadStory(int storyId)
        {
            Story st = (from story in DataProvider.getStories() where story.id == storyId select story).First<Story>();
            Tasks.Clear();
            Tasks.Add("All", new ObservableCollection<ItemViewModel>());
            Tasks.Add("To do", new ObservableCollection<ItemViewModel>());
            Tasks.Add("In progress", new ObservableCollection<ItemViewModel>());
            Tasks.Add("Done", new ObservableCollection<ItemViewModel>());
            var storyTasks = from task in DataProvider.getTasks() where task.userStoryId == st.id select task;
            foreach (Task t in storyTasks)
            {
                // LineTwo is status instead of elapsed-time in All
                Tasks["All"].Add(new ItemViewModel() { LineOne = t.name, LineTwo = t.Status, LineThree = t.createdAt.ToShortDateString(), Id = t.id.ToString() });
                Tasks[t.Status].Add(new ItemViewModel() { LineOne = t.name, LineTwo = "Elapsed Time: " + t.elapsedTime.ToString(), LineThree = t.createdAt.ToShortDateString(), Id = t.id.ToString() });
            }
        }

        public void LoadTask(int taskId)
        {
            CurrentTask = (from task in DataProvider.getTasks() where task.id == taskId select task).First<Task>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}