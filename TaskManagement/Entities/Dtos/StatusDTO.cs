using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class StatusDTO
    {
        ///<summary>
        /// Status of the task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "status")]
        public Guid Status { get; set; }
    }
}
