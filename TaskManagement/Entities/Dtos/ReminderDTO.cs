using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class ReminderDTO
    {
        ///<summary>
        /// Reminder period of the task
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "reminder_period")]
        public Guid ReminderPeriodId { get; set; }
    }
}
