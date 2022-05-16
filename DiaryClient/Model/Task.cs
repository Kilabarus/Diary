using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DiaryClient.Model
{
    public class Task
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public Nullable<long> Type_Id { get; set; }
        public Nullable<long> Frequency_Id { get; set; }
        public Nullable<long> Status_Id { get; set; }

        public virtual TaskType TaskType { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
        public virtual TaskFrequency TaskFrequency { get; set; }
    }
}
