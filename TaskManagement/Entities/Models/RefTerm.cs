using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class RefTerm
    {
        ///<summary>
        /// Id of the refterm 
        ///</summary>
        public Guid Id { get; set; }

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
