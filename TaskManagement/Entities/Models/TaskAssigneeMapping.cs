using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class TaskAssigneeMapping
    {
        ///<summary>
        /// Id of the class 
        ///</summary>
        public Guid Id { get; set; }

        ///<summary>
        /// foregin key of the task
        ///</summary>
        public Guid TaskId { get; set; }

        ///<summary>
        /// Id of the Assignee 
        ///</summary>
        public Guid AssigneeId { get; set; }
    }
}
