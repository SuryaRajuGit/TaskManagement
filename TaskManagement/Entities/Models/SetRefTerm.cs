using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Models
{
    public class SetRefTerm :  BaseModel
    {
        ///<summary>
        /// foregin key of the refset 
        ///</summary>
        public Guid RefSetId { get; set; }
        public RefSet RefSet { get; set; }

        ///<summary>
        /// foregin key of the refterm
        ///</summary>
        public Guid RefTermId { get; set; }
        public RefTerm RefTerm { get; set; }
    }
}
