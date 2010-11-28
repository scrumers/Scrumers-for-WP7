
using System;

namespace Scrumers.Data
{
	public class Project
	{
		public DateTime createdAt { get; set; }
		public string description { get; set; }
		public int id { get; set; }
		public bool isOpen { get; set; }
		public string name { get; set; }
		public int organisationId { get; set; }
		public DateTime updatedAt { get; set; }
		public string organisationName { get; set; }
		public int totalStoryPoints { get; set; }
		public float averageVelocity { get; set; }
		public int sprintsCompleted { get; set; }
		public int sprintsLeft { get; set; }
		public int daysLeft { get; set; }

		public Project ()
		{
		}
	}
}
