using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Models
{
    public class User : BaseModel
    {
        ///<summary>
        /// User Email
        ///</summary>
        public string Email { get; set; }

        ///<summary>
        /// password of the user
        ///</summary>
        public string Password { get; set; }

        ///<summary>
        /// password of the user
        ///</summary>
        public string Phone { get; set; }

        ///<summary>
        /// name of the user
        ///</summary>
        public string Name { get; set; }
    }
}
