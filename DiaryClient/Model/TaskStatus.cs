using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryClient.Model
{
    public class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
