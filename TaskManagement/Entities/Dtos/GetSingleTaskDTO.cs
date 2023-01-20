using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class GetSingleTaskDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; }

        public string Assigner { get; set; }

        public List<string> Assignee { get; set; }

        public string Status { get; set; }

        public List<SubTaskDTO> SubTasks { get; set; }
    }
}
