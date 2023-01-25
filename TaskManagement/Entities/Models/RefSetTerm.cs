using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class RefSetTerm
    {
        ///<summary>
        /// Id of the Refterm 
        ///</summary>
        public Guid Id { get; set; }

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
