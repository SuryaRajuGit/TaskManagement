using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Models
{
    public class BaseModel
    {
        ///<summary>
        /// Primary key 
        ///</summary>
        public Guid Id  { get; set; }

        ///<summary>
        /// Created datetime of the row
        ///</summary>
        public DateTime CreatedDate { get; set; }

        ///<summary>
        /// Updated datetime fo the row
        ///</summary>
        public DateTime UpdatedDate { get; set; }

        ///<summary>
        /// Created user id 
        ///</summary>
        public Guid CreatedId { get; set; }

        ///<summary>
        /// Updated user id 
        ///</summary>
        public Guid UpdatedId { get; set; }

        ///<summary>
        /// Is soft deleted
        ///</summary>
        public bool IsActive { get; set; } 

    }
}
