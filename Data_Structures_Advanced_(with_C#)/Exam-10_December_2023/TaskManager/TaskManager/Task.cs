using System.Collections.Generic;

namespace TaskManager
{
    public class Task
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Assignee { get; set; }

        public int Priority { get; set; }

        public Task Dependant { get; set; }

        public HashSet<Task> Dependencies { get; set; } = new HashSet<Task>();

        public override string ToString()
        {
            return this.Title;
        }
    }
}