using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class GetTaskDTO
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }

        [JsonProperty(PropertyName = "assignee")]
        public List<string> Assignee { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
