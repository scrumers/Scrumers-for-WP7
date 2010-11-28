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
    public class Sprint
    {
        public DateTime createdAt { get; set; }
        public DateTime endAt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int projectId { get; set; }
        public DateTime startAt { get; set; }
        public int step { get; set; }
        public DateTime updatedAt { get; set; }
        public int velocity { get; set; }
        public int theoricalVelocity { get; set; }

        public Sprint()
        {
        }
    }
}
