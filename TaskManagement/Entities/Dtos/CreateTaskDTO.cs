using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

      //  [RegularExpression(@"^\d{4}-\d\d-\d\d \d\d-\d\d-\d\d")]
        public string StartDate { get; set; }

        
        public string DueDate { get; set; }

        public Guid Priority { get; set; }

        public Guid Assigner { get; set; }

        public List<Guid> Assignee { get; set; }

        public Guid Status { get; set; }

        public Guid ParentTaskId { get; set; } 

        public Guid ReminderPeriodId { get; set; }
    }
}
