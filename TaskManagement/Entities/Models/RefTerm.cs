using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Models
{
    public class RefTerm : BaseModel
    {

        ///<summary>
        /// key of the refterm
        ///</summary>
        public string Key { get; set; }

        ///<summary>
        /// Description of the refterm
        ///</summary>
        public string Description { get; set; } 

    }
}
