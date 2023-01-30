using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public static class Constants
    {
        ///<summary>
        /// security key for jwt
        ///</summary>
        public const string secutityKey = "thisismySecureKey12345678";

        ///<summary>
        /// Token type
        ///</summary>
        public const string token_type = "Bearer";

        ///<summary>
        /// Page size for geetting tasks
        ///</summary>
        public const int pageSize = 1;

        ///<summary>
        /// page no for getting tasks
        ///</summary>
        public const string pageno = "page-no";

        ///<summary>
        /// sort-by for sorting list of tasks
        ///</summary>
        public const string sortby = "sort-by";

        ///<summary>
        /// sort-order for sorting list of tasks 
        ///</summary>
        public const string sortorder = "sort-order";

        ///<summary>
        /// pageno for getting list of tasks
        ///</summary>
        public const int pageNo = 1;

        ///<summary>
        /// to sort list of tasks ascending order
        ///</summary>
        public const string ASC = "ASC";

        ///<summary>
        /// user id
        ///</summary>
        public const string userId = "user-id";

        ///<summary>
        /// user id
        ///</summary>
        public const string Name = "UserId";

        ///<summary>
        /// to sort list of tasks descending order
        ///</summary>
        public const string DSC = "DSC";

        ///<summary>
        /// Due date of task
        ///</summary>
        public const string DueDate = "dueDate";

        ///<summary>
        /// Priority of the task
        ///</summary>
        public const string Priority = "priority";

        ///<summary>
        /// Status of the task
        ///</summary>
        public const string Status = "status";

        ///<summary>
        /// page size of the task
        ///</summary>
        public const int pagesize = 5;

        ///<summary>
        /// page no of the task to get list of tasks
        ///</summary>
        public const int pageNO = 1;

        ///<summary>
        /// id
        ///</summary>
        public const string Id = "Id";

        ///<summary>
        /// to sort list of tasks descending order
        ///</summary>
        public const string Issuer = "LOCAL AUTHORITY";

        ///<summary>
        /// type of jwt token
        ///</summary>
        public const string Bearer = "Bearer";

        ///<summary>
        /// status type
        ///</summary>
        public const string Open = "OPEN";

        ///<summary>
        /// status type
        ///</summary>
        public const string Low = "LOW";

        ///<summary>
        /// to get date used D constant
        ///</summary>
        public const string  Date = "D";

        ///<summary>
        /// status type
        ///</summary>
        public const string Complete = "COMPLETED";

        ///<summary>
        /// remainder days
        ///</summary>
        public const string days_7 = "7_DAYS";

        ///<summary>
        ///remainder days
        ///</summary>
        public const string days_3 = "3_DAYS";
    }
}
