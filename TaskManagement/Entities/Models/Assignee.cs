using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Models
{
    public class Assignee
    {
        ///<summary>
        /// Id of the Assignee 
        ///</summary>
        public Guid Id { get; set; }

        ///<summary>
        /// Name of the assignee
        ///</summary>
        public string Name { get; set; }
    }
}
