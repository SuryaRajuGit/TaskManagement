using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class CreateTaskDTO
    {
        ///<summary>
        /// Name of the task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        ///<summary>
        /// Description of task
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        ///<summary>
        /// start date of the task
        ///</summary>
        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }

        ///<summary>
        /// Due date of the task
        ///</summary>
        [JsonProperty(PropertyName = "due_date")]
        public DateTime DueDate { get; set; }

        ///<summary>
        /// Priority of the task
        ///</summary>
        [JsonProperty(PropertyName = "priority")]
        public Guid Priority { get; set; }

        ///<summary>
        /// assigner of the task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "assigner")]
        public Guid Assigner { get; set; }

        ///<summary>
        /// list of assignee assigned to the task
        ///</summary>
        [JsonProperty(PropertyName = "assignee")]
        public List<Guid> Assignee { get; set; }

        ///<summary>
        /// Status of the task
        ///</summary>
        [JsonProperty(PropertyName = "status")]
        public Guid Status { get; set; }

        ///<summary>
        /// prarent task id 
        ///</summary>
        [JsonProperty(PropertyName = "parent_task_id")]
        public Guid ParentTaskId { get; set; }

        ///<summary>
        /// Reminder period of the task
        ///</summary>
        [JsonProperty(PropertyName = "remainder_period_id")]
        public Guid ReminderPeriodId { get; set; }
    }
}
