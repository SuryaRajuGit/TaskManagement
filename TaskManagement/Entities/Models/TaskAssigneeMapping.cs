using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Models
{
    public class TaskAssigneeMapping : BaseModel
    {

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
