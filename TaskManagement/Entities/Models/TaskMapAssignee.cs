using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class TaskMapAssignee
    {
        public Guid Id { get; set; }

        public Guid TaskId { get; set; }

        public Guid AssigneeId { get; set; }
    }
}
