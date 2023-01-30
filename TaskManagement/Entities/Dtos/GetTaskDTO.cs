using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class GetTaskDTO
    {
        ///<summary>
        /// Id of the task
        ///</summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        ///<summary>
        /// Name of the task
        ///</summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        ///<summary>
        /// Due date of the task
        ///</summary>
        [JsonProperty(PropertyName = "due_date")]
        public DateTime DueDate { get; set; }

        ///<summary>
        /// Priority of the task
        ///</summary>
        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }

        ///<summary>
        /// Assignee of the task
        ///</summary>
        [JsonProperty(PropertyName = "assignee")]
        public List<string> Assignee { get; set; }

        ///<summary>
        /// Status of the task
        ///</summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
