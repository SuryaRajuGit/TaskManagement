using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Models
{
    public class RefSet : BaseModel
    {

        ///<summary>
        /// Key of the refset
        ///</summary>
        public string Key { get; set; }

        ///<summary>
        /// Description of the refset
        ///</summary>
        public string Description { get; set; }
    }
}
