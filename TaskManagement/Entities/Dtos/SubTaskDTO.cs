using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class SubTaskDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<string> Assignee { get; set; }
    }
}
