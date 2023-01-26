using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Dtos;
using TaskManagement.Models;

namespace TaskManagement.Contracts
{
    public interface ITaskManagementRepository
    {
        ///<summary>
        /// Checks user id exist or not
        ///</summary>
        ///<return>Guid</return>
        public bool IsUserExist(string userName);

        ///<summary>
        /// Gets user password
        ///</summary>
        ///<return>string</return>
        public string GetPassword(string userName);

        ///<summary>
        /// Gets list of meta-data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public List<RefTerm> GetRefSetData(string key);

        ///<summary>
        /// Checks task name already exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsTaskNameExist(string name);

        ///<summary>
        /// Saves task details
        ///</summary>
        ///<return>Guid</return>
        public Guid SaveTask(Tasks task);

        ///<summary>
        /// Checks Assignee id exist or not
        ///</summary>
        ///<return>List<RefTerm></return>
        public bool IsUserIdExist(Guid id);

        ///<summary>
        /// Gets list of tasks 
        ///</summary>
        ///<return>List<Tasks></return>
        public List<Tasks> GetTaskList(Guid id, int size, int pageNo);

        ///<summary>
        /// Gets list of meta-data  
        ///</summary>
        ///<return>List<RefSetTerm></return>
        public List<RefSetTerm> GetTermData();

        ///<summary>
        /// Gets list of ref set data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public List<RefTerm> GetSetData();

        ///<summary>
        /// Gets list Assignee names
        ///</summary>
        ///<return>List<string></return>
        public List<string> GetAssigneeName( List<Guid> assigneeList);

        ///<summary>
        /// Gets list of ref set data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public Tasks GetTask(Guid id);

        ///<summary>
        /// Gets list of Tasks
        ///</summary>
        ///<return>List<Tasks></return>
        public List<Tasks> GetSubTasks(Guid id);

        ///<summary>
        /// Gets Assignee name
        ///</summary>
        ///<return>stirng</return>
        public string GetAssigner(Guid id);

        ///<summary>
        /// Checks Task id exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsTaskIdExist(Guid id);

        ///<summary>
        /// Checks user id exist or not
        ///</summary>
        ///<return>Guid</return>
        public Guid IsUserExist(List<Guid> ids);

        ///<summary>
        /// Updates Task details
        ///</summary>
        public void UpdateTask(Tasks tasks);

        ///<summary>
        /// Deletes Task
        ///</summary>
        ///<return>bool</return>
        public bool DeleteTask(Guid id);

        ///<summary>
        /// Checks meta-data exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsStatusIdFound(Guid id);

        ///<summary>
        /// Updates Task status
        ///</summary>
        public void UpdateStatus(Guid id,Guid userId);

        ///<summary>
        /// Updates Task remainder
        ///</summary>
        public void UpdateRemainder(Guid id, Guid remainderId);

        ///<summary>
        /// Gets list of Assginee 
        ///</summary>
        ///<return>List<Assignee></return>
        public List<User> GetAllAssignee();

        ///<summary>
        /// checks assignee is exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsAssignerExist(Guid id);

        ///<summary>
        /// Checks task name already exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsUpdateTaskNameExist(string name,Guid id);

        ///<summary>
        /// checks parent id exist or not
        ///</summary>
        ///<return>bool</return>
        public bool CheckParentTaskId(Guid id);

        ///<summary>
        /// checks parent task date exist or not
        ///</summary>
        ///<return>Tasks</return>
        public Tasks IsParentTaskDatesValid(string end, string start, Guid parentTaskId);

        ///<summary>
        /// checks parent task exist or not
        ///</summary>
        ///<return>Tasks</return>
        public Tasks GetParentTask(Guid id);

        ///<summary>
        /// checks new user sign up exits or not
        ///</summary>
        ///<return>bool</return>
        public bool CheckUserName(string name);

        ///<summary>
        /// checks phone number exist or not
        ///</summary>
        ///<return>bool</return>
        public bool CheckPhone(string phone);

        ///<summary>
        /// Saves user details
        ///</summary>
        ///<return>Guid</return>
        public Guid SaveUser(User user);

        ///<summary>
        /// Gets user id with user name
        ///</summary>
        ///<return>Guid</return>
        public Guid GetId(string userName);

        ///<summary>
        /// Gets status id 
        ///</summary>
        ///<return>Guid</return>
        public Guid GetStatusId();

        ///<summary>
        /// Gets priority id
        ///</summary>
        ///<return>Guid</return>
        public Guid GetPriorityId();
    }
}
