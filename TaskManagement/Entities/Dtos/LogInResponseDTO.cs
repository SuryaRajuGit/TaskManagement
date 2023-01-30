using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class LogInResponseDTO
    {
        ///<summary>
        /// jwt token 
        ///</summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        ///<summary>
        /// toke type
        ///</summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
    }
}
