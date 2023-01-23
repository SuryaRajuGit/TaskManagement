using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Models;

namespace TaskManagement.Contracts
{
    public interface ITaskManagementService
    {
        public ErrorDTO IsUserExist(string userName);

        public LogInResponseDTO VerifyUser(LoginDTO password);

        public List<MetaDataResponse> GetRefSetData(string key);

        public ErrorDTO ModelStateInvalid(ModelStateDictionary ModelState);

        public Guid? CreateTask(CreateTaskDTO task);

        public ErrorDTO IsUserIdExist(Guid id);

        public List<GetTaskDTO> GetTaskList(Guid id,int size,int pageNo,string sortBy,string sortOrder);

        public GetSingleTaskDTO GetSingleTask(Guid id);

        public ErrorDTO IsTaskExist(Guid id,UpdateTaskDTO updateTask);

        public ErrorDTO UpdateTask(Guid id,UpdateTaskDTO task);

        public ErrorDTO DeleteTask(Guid id);

        public ErrorDTO IsUpdateTaskStatusExist(Guid id,Guid taskId);

        public void UpdateStatus(Guid id,Guid statusId);

        public ErrorDTO IsUpdateRemainder(Guid id,Guid remainderId);

        public void UpdateRemainder(Guid id,Guid remainderId);

        public List<Assignee> GetAssigneeList();

        public ErrorDTO IsDateInvalid(string datetime,string time);

        public ErrorDTO CheckMetadata(CreateTaskDTO task);

    }
}
