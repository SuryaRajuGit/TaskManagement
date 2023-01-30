using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class MetaDataResponse
    {
        ///<summary>
        /// id of the meta-data
        ///</summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        ///<summary>
        /// key of the meta-data
        ///</summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        ///<summary>
        /// Description of the meta-data
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
