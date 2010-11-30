using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Scrumers.Data
{
    public class Task : INotifyPropertyChanged
    {
        public DateTime completedAt { get; set; }
        public DateTime createdAt { get; set; }
        public string description { get; set; }
        
        
        public int id { get; set; }
        public bool isStarted { get; set; }
        public string name { get; set; }
        public int piloteId { get; set; }
        public int projectId { get; set; }
        public int sprintId { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int userStoryId { get; set; }

        private string _status;
        /// <summary>
        /// Status will notify its changes
        /// </summary>
        /// <returns></returns>
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    NotifyPropertyChanged("Status");
                }
            }
        }

        private string _estimatedRemainingTime;
        /// <summary>
        /// EstimatedRemainingTime will notify its changes. It is a string as it is supposed to be display. Use elapsedTime to modify it.
        /// </summary>
        /// <returns></returns>
        public string EstimatedRemainingTime
        {
            get
            {
                return _estimatedRemainingTime;
            }
            set
            {
                if (value != _estimatedRemainingTime)
                {
                    _estimatedRemainingTime = value;
                    NotifyPropertyChanged("EstimatedRemainingTime");
                }
            }
        }

        private int _elapsedTime;
        public int elapsedTime 
        {
            get
            {
                return _elapsedTime;
            }
            set
            {
                if (value != _elapsedTime)
                {
                    _elapsedTime = value;
                    EstimatedRemainingTime = TimeSpan.FromSeconds(estimatedDuration - _elapsedTime).ToString();
                    NotifyPropertyChanged("elapsedTime");
                }
            }
        }

        private int _estimatedDuration;
        public int estimatedDuration
        {
            get
            {
                return _estimatedDuration;
            }
            set
            {
                if (value != _estimatedDuration)
                {
                    _estimatedDuration = value;
                    EstimatedRemainingTime = TimeSpan.FromSeconds(_estimatedDuration - elapsedTime).ToString();
                }
            }
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
