using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class ReminderResponseDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "task_id")]
        public Guid TaskId { get; set; }

        [JsonProperty(PropertyName = "remainder_message")]
        public string ReminderMessage { get; set; }
    }
}
