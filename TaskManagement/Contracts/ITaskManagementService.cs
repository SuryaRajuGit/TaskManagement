using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Models;

namespace TaskManagement.Contracts
{
    public interface ITaskManagementService
    {
        ///<summary>
        /// Checks user id exist or not
        /// <param name = "userName" ></ param >
        ///</summary>
        public ErrorDTO IsUserExist(string userName);

        ///<summary>
        /// Validates user login details and return JWT token
        /// <param name = "loginDTO" ></ param >
        ///</summary>
        public LogInResponseDTO VerifyUser(LoginDTO password);

        ///<summary>
        /// Gets list of meta-data linked to the key
        ///  <param name = "key" ></ param >
        ///</summary>
        public List<MetaDataResponse> GetRefSetData(string key);

        ///<summary>
        /// Validates request pay load and return ErrorDTO
        ///  <param name = "ModelState" ></ param >
        ///</summary>
        public ErrorDTO ModelStateInvalid(ModelStateDictionary ModelState);

        ///<summary>
        /// Creates New task
        /// <param name = "task" ></ param >
        ///</summary>
        public Guid? CreateTask(CreateTaskDTO task);

        ///<summary>
        /// Checks user id exist or not
        /// <param name = "id" ></ param >
        ///</summary>
        public ErrorDTO IsUserIdExist(Guid id);

        ///<summary>
        /// Gets list of Tasks
        /// <param name = "id" ></ param >
        /// <param name = "size" ></ param >
        /// <param name = "pageNo" ></ param >
        /// <param name = "sortOrder" ></ param >
        /// <param name = "sortBy" ></ param >
        ///</summary>
        public List<GetTaskDTO> GetTaskList(Guid id,int size,int pageNo,string sortBy,string sortOrder);

        ///<summary>
        /// Gets single task details
        /// <param name = "id" ></ param >
        ///</summary>
        public GetSingleTaskDTO GetSingleTask(Guid id);

        ///<summary>
        /// Checks Task details already exist or not
        /// <param name = "id" ></ param >
        /// <param name = "updateTask" ></ param >
        ///</summary>
        public ErrorDTO IsTaskExist(Guid id,UpdateTaskDTO updateTask);

        ///<summary>
        /// Updates task details
        /// <param name = "id" ></ param >
        /// <param name = "updateTask" ></ param >
        ///</summary>
        public ErrorDTO UpdateTask(Guid id,UpdateTaskDTO task);

        ///<summary>
        /// Deletes Task
        /// <param name = "id" ></ param >
        ///</summary>
        public ErrorDTO DeleteTask(Guid id);

        ///<summary>
        /// Checks meta-data id exist or not
        ///  <param name = "id" ></ param >
        ///   <param name = "statusId" ></ param >
        ///</summary>
        public ErrorDTO IsUpdateTaskStatusExist(Guid id,Guid taskId);

        ///<summary>
        /// Updates Task status
        /// <param name = "id" ></ param >
        /// <param name = "userId" ></ param >
        ///</summary>
        public void UpdateStatus(Guid id,Guid statusId);

        ///<summary>
        /// Checks meta-data id exist or not
        /// <param name = "id" ></ param >
        /// <param name = "reminderId" ></ param >
        ///</summary>
        public ErrorDTO IsUpdateReminder(Guid id,Guid reminderId);

        ///<summary>
        /// Checks meta-data id exist or not
        /// <param name = "id" ></ param >
        /// <param name = "reminderId" ></ param >
        ///</summary>
        public void UpdateReminder(Guid id,Guid reminderId);

        ///<summary>
        /// Gets list of assignee
        ///</summary>
        public List<AssigneeDTO> GetAssigneeList();

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "end" ></ param >
        /// <param name = "start" ></ param >
        ///</summary>
        public ErrorDTO IsDateInvalid(string datetime,string time,Guid reminderId);

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "task" ></ param >
        ///</summary>
        public ErrorDTO CheckMetadata(CreateTaskDTO task);

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "createTask" ></ param >
        ///</summary>
        public ErrorDTO CheckParentTaskDateDetails(CreateTaskDTO task);

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "task" ></ param >
        /// <param name = "id" ></ param >
        ///</summary>
        public ErrorDTO CheckParentTaskDate(UpdateTaskDTO task,Guid id);

        ///<summary>
        /// Checks user name aleady exist or not
        /// <param name = "user" ></ param >
        ///</summary>
        public ErrorDTO SignUp(SignUpDTO user);

        ///<summary>
        /// Saves user details and returns id
        /// <param name = "user" ></ param >
        ///</summary>
        public Guid SaveUser(SignUpDTO user);

        ///<summary>
        /// Gets reminder detailsof user
        ///</summary>
        public List<ReminderResponseDTO> GetReminder();

    }
}
