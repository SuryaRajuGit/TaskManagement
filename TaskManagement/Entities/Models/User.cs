using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class User
    {
        ///<summary>
        /// Id of the user
        ///</summary>
        public Guid Id { get; set; }

        ///<summary>
        /// User name
        ///</summary>
        public string UserName { get; set; }

        ///<summary>
        /// password of the user
        ///</summary>
        public string Password { get; set; }
    }
}
