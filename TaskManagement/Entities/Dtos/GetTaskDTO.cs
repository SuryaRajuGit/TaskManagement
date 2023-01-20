using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class GetTaskDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } 

        public DateTime DueDate { get; set; }

        public string Priority { get; set; }

        public List<string> Assignee { get; set; }

        public string Status { get; set; }
    }
}
