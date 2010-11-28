using System;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Scrumers.Data
{
	/// <summary>
	/// DataProvider store all datas and, when needed, request them to a XML or via API call (not implemented yet)
	/// </summary>
	class DataProvider
	{
        private static List<Task> tasks;
        private static List<Story> stories;
        private static List<Sprint> sprints;
        private static List<Project> projects;

        public static List<Task> getTasks()
        {
            if (tasks == null)
            {
                tasks = new List<Task>();
                try
                {
                    XmlReader reader = XmlReader.Create("Data/tasks.xml");
                    reader.Read(); //read xml declaration
                    reader.Read(); //read whitespace
                    reader.Read();
                    if (reader.NodeType != XmlNodeType.Element || reader.Name != "tasks")
                    {
                        throw new XmlException("the first element should be tasks");
                    }
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "task")
                        {
                            Task t = new Task();
                            Debug.WriteLine("Reading a task");
                            string nextElement = "Undefined";
                            while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "task") && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    nextElement = reader.Name;
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    nextElement = "Undefined";
                                }
                                else if (reader.NodeType == XmlNodeType.Text)
                                {
                                    switch (nextElement)
                                    {
                                        case "completed-at":
                                            t.completedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "created-at":
                                            t.createdAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "description":
                                            t.description = reader.Value;
                                            break;
                                        case "elapsed-time":
                                            t.elapsedTime = int.Parse(reader.Value);
                                            break;
                                        case "estimated-duration":
                                            t.estimatedDuration = int.Parse(reader.Value);
                                            break;
                                        case "id":
                                            t.id = int.Parse(reader.Value);
                                            break;
                                        case "is-started":
                                            t.isStarted = bool.Parse(reader.Value);
                                            break;
                                        case "name":
                                            t.name = reader.Value;
                                            break;
                                        case "pilote-id":
                                            t.piloteId = int.Parse(reader.Value);
                                            break;
                                        case "project-id":
                                            t.projectId = int.Parse(reader.Value);
                                            break;
                                        case "sprint-id":
                                            t.sprintId = int.Parse(reader.Value);
                                            break;
                                        case "started-at":
                                            t.startedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "status":
                                            t.status = reader.Value;
                                            break;
                                        case "updated-at":
                                            t.updatedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "user-story-id":
                                            t.userStoryId = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }//end while
                            tasks.Add(t);
                        }
                    }
                }
                catch (XmlException Ex)
                {
                    Debug.WriteLine("Erreur: " + Ex.Message);
                }
            }
            return tasks;
        }

        public static List<Story> getStories()
        {
            if (stories == null)
            {
                stories = new List<Story>();
                try
                {
                    XmlReader reader = XmlReader.Create("Data/stories.xml");
                    reader.Read(); //read xml declaration
                    reader.Read(); //read whitespace
                    reader.Read();
                    if (reader.NodeType != XmlNodeType.Element || reader.Name != "user-stories")
                    {
                        throw new XmlException("the first element should be stories");
                    }
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "user-story")
                        {
                            Story s = new Story();
                            Debug.WriteLine("Reading a story");
                            string nextElement = "Undefined";
                            while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "user-story") && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    nextElement = reader.Name;
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    nextElement = "Undefined";
                                }
                                else if (reader.NodeType == XmlNodeType.Text)
                                {
                                    switch (nextElement)
                                    {
                                        case "backlog-id":
                                            s.backlogId = int.Parse(reader.Value);
                                            break;
                                        case "completed-at":
                                            s.completedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "created-at":
                                            s.createdAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "description":
                                            s.description = reader.Value;
                                            break;
                                        case "id":
                                            s.id = int.Parse(reader.Value);
                                            break;
                                        case "is-must-have":
                                            s.isMustHave = bool.Parse(reader.Value);
                                            break;
                                        case "name":
                                            s.name = reader.Value;
                                            break;
                                        case "points":
                                            s.points = int.Parse(reader.Value);
                                            break;
                                        case "position":
                                            s.position = int.Parse(reader.Value);
                                            break;
                                        case "project-id":
                                            s.projectId = int.Parse(reader.Value);
                                            break;
                                        case "sprint-id":
                                            s.sprintId = int.Parse(reader.Value);
                                            break;
                                        case "status":
                                            s.status = reader.Value;
                                            break;
                                        case "updated-at":
                                            s.updatedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "sprint-name":
                                            s.sprintName = reader.Value;
                                            break;
                                        case "tasks-count":
                                            s.tasksCount = int.Parse(reader.Value);
                                            break;
                                        case "left-tasks-count":
                                            s.leftTasksCount = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }//end while
                            stories.Add(s);
                        }
                    }
                }
                catch (XmlException Ex)
                {
                    Debug.WriteLine("Erreur: " + Ex.Message);
                }
            }
            return stories;
        }

        public static List<Sprint> getSprints()
        {
            if (sprints == null)
            {
                sprints = new List<Sprint>();
                try
                {
                    XmlReader reader = XmlReader.Create("Data/sprints.xml");
                    reader.Read(); //read xml declaration
                    reader.Read(); //read whitespace
                    reader.Read();
                    if (reader.NodeType != XmlNodeType.Element || reader.Name != "sprints")
                    {
                        throw new XmlException("the first element should be sprints");
                    }
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "sprint")
                        {
                            Sprint s = new Sprint();
                            Debug.WriteLine("Reading a sprint");
                            string nextElement = "Undefined";
                            while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "sprint") && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    nextElement = reader.Name;
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    nextElement = "Undefined";
                                }
                                else if (reader.NodeType == XmlNodeType.Text)
                                {
                                    switch (nextElement)
                                    {
                                        case "created-at":
                                            s.createdAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "end-at":
                                            s.endAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "id":
                                            s.id = int.Parse(reader.Value);
                                            break;
                                        case "name":
                                            s.name = reader.Value;
                                            break;
                                        case "project-id":
                                            s.projectId = int.Parse(reader.Value);
                                            break;
                                        case "start-at":
                                            s.startAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "step":
                                            s.step = int.Parse(reader.Value);
                                            break;
                                        case "updated-at":
                                            s.updatedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "velocity":
                                            s.velocity = int.Parse(reader.Value);
                                            break;
                                        case "theorical-velocity":
                                            s.theoricalVelocity = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }//end while
                            sprints.Add(s);
                        }
                    }
                }
                catch (XmlException Ex)
                {
                    Debug.WriteLine("Erreur: " + Ex.Message);
                }
            }
            return sprints;
        }

		public static List<Project> getProjects()
		{
            if (projects == null)
            {
                projects = new List<Project>();
                try
                {
                    XmlReader reader = XmlReader.Create("Data/projects.xml");
                    reader.Read(); //read xml declaration
                    reader.Read(); //read whitespace
                    reader.Read();
                    if (reader.NodeType != XmlNodeType.Element || reader.Name != "projects")
                    {
                        throw new XmlException("the first element should be projects");
                    }
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "project")
                        {
                            Project p = new Project();
                            Debug.WriteLine("Reading a project");
                            string nextElement = "Undefined";
                            while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "project") && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    nextElement = reader.Name;
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    nextElement = "Undefined";
                                }
                                else if (reader.NodeType == XmlNodeType.Text)
                                {
                                    switch (nextElement)
                                    {
                                        case "created-at":
                                            p.createdAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "description":
                                            p.description = reader.Value;
                                            break;
                                        case "id":
                                            p.id = int.Parse(reader.Value);
                                            break;
                                        case "is-open":
                                            p.isOpen = bool.Parse(reader.Value);
                                            break;
                                        case "name":
                                            p.name = reader.Value;
                                            break;
                                        case "organisation-id":
                                            p.organisationId = int.Parse(reader.Value);
                                            break;
                                        case "updated-at":
                                            p.updatedAt = DateTime.Parse(reader.Value);
                                            break;
                                        case "organisation-name":
                                            p.organisationName = reader.Value;
                                            break;
                                        case "total-story-points":
                                            p.totalStoryPoints = int.Parse(reader.Value);
                                            break;
                                        case "average-velocity":
                                            p.averageVelocity = float.Parse(reader.Value, CultureInfo.InvariantCulture);
                                            break;
                                        case "sprints-completed":
                                            p.sprintsCompleted = int.Parse(reader.Value);
                                            break;
                                        case "sprints-left":
                                            p.sprintsLeft = int.Parse(reader.Value);
                                            break;
                                        case "days-left":
                                            p.daysLeft = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }//end while
                            projects.Add(p);
                        }
                    }
                }
                catch (XmlException Ex)
                {
                    Debug.WriteLine("Erreur: " + Ex.Message);
                }
            }
            return projects;
		}
	}
}


/* Test code to print a xml file to console
 *                  switch (reader.NodeType) 
					{
						case XmlNodeType.Element:
							
							string sNameElement = reader.Name;
							
							Console.WriteLine("Element :" + sNameElement);
							break;
						
						case XmlNodeType.EndElement:

							string sNameEndElement = reader.Name;

							Console.WriteLine("End Element :" + sNameEndElement);
							break;

						case XmlNodeType.Attribute:

							string sNameAttribute = reader.Name;

							Console.WriteLine("Attribute :" + sNameAttribute);
							break;

						case XmlNodeType.Text:

							string sNameText = reader.Name;

							Console.WriteLine("Text :" + sNameText + " Value : " + reader.Value);
							break;

						default:
							break;
					}*/