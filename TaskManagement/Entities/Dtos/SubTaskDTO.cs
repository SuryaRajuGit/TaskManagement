using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class SubTaskDTO
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "assignee")]
        public List<string> Assignee { get; set; }
    }
}
