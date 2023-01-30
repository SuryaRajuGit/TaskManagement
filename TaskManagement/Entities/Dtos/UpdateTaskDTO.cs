using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class UpdateTaskDTO
    {
        ///<summary>
        /// Name of the task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        ///<summary>
        /// Description of the task
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        ///<summary>
        /// Start date of the task
        ///</summary>
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }

        ///<summary>
        /// Due date of the task
        ///</summary>
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }

        ///<summary>
        /// priority of the task
        ///</summary>
        [JsonProperty(PropertyName = "priority")]
        public Guid Priority { get; set; }

        ///<summary>
        /// list  assignee of the task
        ///</summary>
        [JsonProperty(PropertyName = "assignee")]
        public List<Guid> Assignee { get; set; }

        ///<summary>
        /// Status of the task
        ///</summary>
        [JsonProperty(PropertyName = "status")]
        public Guid Status { get; set; }

    }
}
