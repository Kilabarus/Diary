using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaryClient.Model
{
    public class TaskType
    {
        public TaskType()
        {
            Tasks = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
