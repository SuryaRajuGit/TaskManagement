﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public Guid Priority { get; set; }

        public Guid Assigner { get; set; }

        public List<Guid> Assignee { get; set; }

        public Guid Status { get; set; }

        public Guid ParentTaskId { get; set; } 
    }
}