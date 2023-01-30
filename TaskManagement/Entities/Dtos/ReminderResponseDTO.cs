using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class ReminderResponseDTO
    {
        ///<summary>
        /// Name of the response
        ///</summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        ///<summary>
        /// Task id
        ///</summary>
        [JsonProperty(PropertyName = "task_id")]
        public Guid TaskId { get; set; }

        ///<summary>
        /// reminder response of the task
        ///</summary>
        [JsonProperty(PropertyName = "remainder_message")]
        public string ReminderMessage { get; set; }
    }
}
