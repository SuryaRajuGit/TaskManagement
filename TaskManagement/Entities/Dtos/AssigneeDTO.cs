using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class AssigneeDTO
    {
        ///<summary>
        /// Assignee id
        ///</summary>
        public Guid Id { get; set; }

        ///<summary>
        /// Assignee Name
        ///</summary>
        public string Name { get; set; }
    }
}
