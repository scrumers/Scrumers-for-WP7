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

namespace Scrumers.Data
{
    public class Task
    {
        public DateTime completedAt { get; set; }
        public DateTime createdAt { get; set; }
        public string description { get; set; }
        public int elapsedTime { get; set; }
        public int estimatedDuration { get; set; }
        public int id { get; set; }
        public bool isStarted { get; set; }
        public string name { get; set; }
        public int piloteId { get; set; }
        public int projectId { get; set; }
        public int sprintId { get; set; }
        public DateTime startedAt { get; set; }
        public string status { get; set; }
        public DateTime updatedAt { get; set; }
        public int userStoryId { get; set; }
    }
}
