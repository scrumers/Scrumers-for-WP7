﻿using System;
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
    public class Story
    {
        public int backlogId { get; set; }
        public DateTime completedAt { get; set; }
        public int contextualId { get; set; }
        public DateTime createdAt { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public bool isMustHave { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public int position { get; set; }
        public int projectId { get; set; }
        public int sprintId { get; set; }
        public string status { get; set; }
        public DateTime updatedAt { get; set; }
        public string sprintName { get; set; }
        public int tasksCount { get; set; }
        public int leftTasksCount { get; set; }
    }
}
