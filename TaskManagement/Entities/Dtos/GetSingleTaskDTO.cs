using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class GetSingleTaskDTO
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
        /// Description of the task
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        ///<summary>
        /// Start date of the task
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
        public string Priority { get; set; }

        ///<summary>
        /// Assigner of the task
        ///</summary>
        [JsonProperty(PropertyName = "assigner")]
        public string Assigner { get; set; }

        ///<summary>
        /// list of Assignee of assigned to the task
        ///</summary>
        [JsonProperty(PropertyName = "assignee")]
        public List<string> Assignee { get; set; }

        ///<summary>
        /// Status of the task
        ///</summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        ///<summary>
        /// list of sub task assigned to the task
        ///</summary>
        [JsonProperty(PropertyName = "sub_task")]
        public List<SubTaskDTO> SubTasks { get; set; }
    }
}
