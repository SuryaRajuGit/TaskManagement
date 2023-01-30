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
        ///<summary>
        /// id of the sub task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        ///<summary>
        /// Name of the task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        ///<summary>
        /// List of names of assignee assigned to task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "assignee")]
        public List<string> Assignee { get; set; }
    }
}
