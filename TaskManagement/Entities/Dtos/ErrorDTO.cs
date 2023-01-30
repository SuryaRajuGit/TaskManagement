using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Dtos
{
    public class ErrorDTO
    {
        ///<summary>
        /// Type of the error
        ///</summary>
        public string type { get; set; }

        ///<summary>
        /// Error description
        ///</summary>
        public string description { get; set; }
    }
}
