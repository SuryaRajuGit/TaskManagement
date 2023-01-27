using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Models
{
    public class Tasks : BaseModel
    {

        ///<summary>
        /// Name of the Task 
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Description of the Task
        ///</summary>
        public string Description { get; set; }

        ///<summary>
        /// Startdate of the Task
        ///</summary>
        public DateTime StartDate { get; set; }

        ///<summary>
        /// Duedate of the task
        ///</summary>
        public DateTime DueDate { get; set; }

        ///<summary>
        /// Priority of the task
        ///</summary>
        public Guid Priority { get; set; }

        ///<summary>
        /// status of the task
        ///</summary>
        public Guid Status { get; set; }

        ///<summary>
        /// id of the assigner
        ///</summary>
        public Guid Assigner { get; set; }

        ///<summary>
        /// Id of the parent task 
        ///</summary>
        public Guid ParentTaskId { get; set; }

        ///<summary>
        /// meta-data of the remainder 
        ///</summary>
        public Guid ReminderPeriodId { get; set; }

        ///<summary>
        /// List of assignee details
        ///</summary>
        public List<TaskAssigneeMapping> TaskMapAssignee { get; set; }

    }
}
