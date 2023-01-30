using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class SignUpDTO
    {
        ///<summary>
        /// Email of the user
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Enter Valid email address")]
        public string Email { get; set; }

        ///<summary>
        /// Password do the user
        ///</summary>
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
            ErrorMessage = "Passwords must be at least 8 characters, one upper case (A-Z)," +
            "one lower case (a-z),a number (0-9) and special character (e.g. !@#$%^&*)")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        ///<summary>
        /// Phone of the user
        ///</summary>
        [Required]
        [Phone(ErrorMessage = "PhoneNumber field is not a valid phone number")]
        [MinLength(10)]
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        ///<summary>
        /// Name of the user
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
