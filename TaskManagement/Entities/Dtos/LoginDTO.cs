﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Dtos
{
    public class LoginDTO
    {
        [Required]
        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
