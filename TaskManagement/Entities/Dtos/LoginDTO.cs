using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Dtos
{
    public class LoginDTO
    {
        ///<summary>
        /// Email of the user
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        ///<summary>
        /// Password of the user
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
