using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class RefSet
    {
        ///<summary>
        /// Id of the refset
        ///</summary>
        public Guid Id { get; set; }

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
