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
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }

       
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }

      
        [JsonProperty(PropertyName = "priority")]
        public Guid Priority { get; set; }

       
        [JsonProperty(PropertyName = "assignee")]
        public List<Guid> Assignee { get; set; }

       
        [JsonProperty(PropertyName = "status")]
        public Guid Status { get; set; }

    }
}
