using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class RemainderDTO
    {
        [Required]
        [JsonProperty(PropertyName = "remainder_period")]
        public Guid RemainderPeriodId { get; set; }
    }
}
