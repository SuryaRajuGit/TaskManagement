using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Models;
using TaskManagement.Models;

namespace TaskManagement.Service
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly ITaskManagementRepository _taskManagementRepository;
        byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public TaskManagementService(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }

        ///<summary>
        /// Checks user id exist or not
        ///</summary>
        public ErrorDTO IsUserExist(string userName)
        {
            bool isUserExist = _taskManagementRepository.IsUserExist(userName);
            if (!isUserExist)
            {
                return new ErrorDTO() { type = "User", description = "User not found with the user name" };
            }
            return null;
        }

        ///<summary>
        /// Validates user login details and return JWT token
        ///</summary>
        public LogInResponseDTO VerifyUser(LoginDTO loginDTO)
        {
            string encryptPassword = _taskManagementRepository.GetPassword(loginDTO.UserName);
            if(encryptPassword == null)
            {
                return null;
            }
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(this.key, this.iv);
            byte[] inputbuffer = Convert.FromBase64String(encryptPassword);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            string password = Encoding.Unicode.GetString(outputBuffer);
            if (password == loginDTO.Password)
            {
                JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
                byte[] tokenKey = Encoding.UTF8.GetBytes(Constants.secutityKey);

                SecurityTokenDescriptor tokenDeprictor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, loginDTO.UserName) ,
                        }
                        ),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenhandler.CreateToken(tokenDeprictor);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                LogInResponseDTO response = new LogInResponseDTO()
                {
                    access_token = tokenString,
                    token_type = Constants.token_type
                };
                return response;
            }
            return null;
        }

        ///<summary>
        /// Gets list of meta-data linked to the key
        ///</summary>
        public List<MetaDataResponse> GetRefSetData(string key)
        {
            List<RefTerm> refTerm = _taskManagementRepository.GetRefSetData(key);
            if (refTerm == null)
            {
                return null;
            }
            List<MetaDataResponse> responseList = new List<MetaDataResponse>();
            foreach (RefTerm item in refTerm)
            {
                MetaDataResponse response = new MetaDataResponse
                {
                    id = item.Id.ToString(),
                    key = item.Key,
                    description = item.Description
                };
                responseList.Add(response);
            }
            return responseList;
        }

        ///<summary>
        /// Validates request pay load and return ErrorDTO
        ///</summary>
        public ErrorDTO ModelStateInvalid(ModelStateDictionary ModelState)
        {
            return new ErrorDTO
            {
                type = ModelState.Keys.FirstOrDefault(),
                description =
                ModelState.Values.Select(src => src.Errors.Select(src => src.ErrorMessage).FirstOrDefault()).FirstOrDefault()
            };
        }

        ///<summary>
        /// Creates New task
        ///</summary>
        public Guid? CreateTask(CreateTaskDTO task)
        {
            bool isTaskNameExist = _taskManagementRepository.IsTaskNameExist(task.Name);
            if(isTaskNameExist == true)
            {
                return null;
            }
            Tasks tasks = new Tasks()
            {
                Id=Guid.NewGuid(),
            };
            return _taskManagementRepository.SaveTask(tasks);
        }

        ///<summary>
        /// Checks user id exist or not
        ///</summary>
        public ErrorDTO IsUserIdExist(Guid id)
        {
            bool isUserIdExist = _taskManagementRepository.IsUserIdExist(id);
            if(!isUserIdExist)
            {
                return new ErrorDTO() {type="User",description="User id not exist" };
            }
            return null;
        }

        ///<summary>
        /// Gets list of Tasks
        ///</summary>
        public List<GetTaskDTO> GetTaskList(Guid id, int size, int pageNo, string sortBy, string sortOrder)
        {
            List<Tasks> paginatedList = _taskManagementRepository.GetTaskList( id,  size,  pageNo);
            List<Tasks> sortList = new List<Tasks>();
            if (paginatedList.Count() == 0)
            {
                return null;
            }
            switch (sortBy)
            {
                case Constants.Name:
                    if(sortOrder == Constants.DSC)
                    {
                        sortList = paginatedList.OrderByDescending(item => item.Name).ToList();
                    }
                    else
                    {
                        sortList = paginatedList.OrderBy(item => item.Name).ToList();
                    }
                    break;
                case Constants.DueDate: 
                    if(sortOrder == Constants.DSC)
                    {
                        sortList = paginatedList.OrderByDescending(item => item.DueDate).ToList();
                    }
                    else
                    {
                        sortList = paginatedList.OrderBy(item => item.DueDate).ToList();
                    }
                    break;
                case Constants.Status: 
                    if(sortOrder == Constants.DSC)
                    {
                        sortList = paginatedList.OrderByDescending(item => item.Status).ToList();
                    }
                    else
                    {
                        sortList = paginatedList.OrderBy(item => item.Status).ToList();
                    }
                    break;
                case Constants.Priority: 
                    if (sortOrder == Constants.DSC)
                    {
                        sortList = paginatedList.OrderByDescending(item => item.Priority).ToList();
                    }
                    else
                    {
                        sortList = paginatedList.OrderBy(item => item.Priority).ToList();
                    }
                    break;
            }
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<GetTaskDTO> taskList = new List<GetTaskDTO>();
            foreach (Tasks item in sortList)
            {
                GetTaskDTO task = new GetTaskDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Assignee = _taskManagementRepository.GetAssigneeName(item.TaskMapAssignee.Select(each => each.AssigneeId).ToList()),
                    Status = termData.Where(find => find.Id == id).Select(sel => sel.Key).First(),
                    DueDate=item.DueDate,
                    Priority= termData.Where(find => find.Id == id).Select(sel => sel.Key).First()
                };
                taskList.Add(task);
            }
            return taskList;
        }

        ///<summary>
        /// Gets single task details
        ///</summary>
        public GetSingleTaskDTO GetSingleTask(Guid id)
        {
            Tasks task = _taskManagementRepository.GetTask(id);
            if(task == null)
            {
                return null;
            }
            List<Tasks> subTasks = _taskManagementRepository.GetSubTasks(id);
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            GetSingleTaskDTO getSingleTaskDTO = new GetSingleTaskDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                DueDate = task.DueDate,
                Priority = termData.Where(find => find.Id == task.Priority).Select(sel => sel.Key).First(),
                Status = termData.Where(find => find.Id == task.Status).Select(sel => sel.Key).First(),
                Assigner = _taskManagementRepository.GetAssigner(task.Assigner),
                Assignee = _taskManagementRepository.GetAssigneeName(task.TaskMapAssignee.Select(each => each.AssigneeId).ToList()),
                SubTasks = new List<SubTaskDTO>()
            };
            List<SubTaskDTO> subTaskList = new List<SubTaskDTO>();
            foreach (Tasks item in subTasks)
            {
                SubTaskDTO subTask = new SubTaskDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Assignee = _taskManagementRepository.GetAssigneeName(item.TaskMapAssignee.Select(each => each.AssigneeId).ToList())
                };
                subTaskList.Add(subTask);
            }
            getSingleTaskDTO.SubTasks.AddRange(subTaskList);
            return getSingleTaskDTO;
        }

        ///<summary>
        /// Checks Task details already exist or not
        ///</summary>
        public ErrorDTO IsTaskExist(Guid id,UpdateTaskDTO updateTask)
        {
            bool isTaskExist = _taskManagementRepository.IsTaskIdExist(id);
            if(!isTaskExist)
            {
                return new ErrorDTO() {type="Task",description="Task id not found" };
            }
            Guid userId = _taskManagementRepository.IsUserExist(updateTask.Assignee);
            if(userId != Guid.Empty)
            {
                return new ErrorDTO() {type="Assignee",description=$"Assignee with id {userId} not found" };
            }
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<Guid> ids = termData.Select(sel => sel.Id).ToList();
            if (!ids.Contains(updateTask.Priority))
            {
                return new ErrorDTO() {type="Priority",description=$"Meta-data id {updateTask.Priority} not found" };
            }
            else if(!ids.Contains(updateTask.Status))
            {
                return new ErrorDTO() { type = "Status", description = $"Meta-data id {updateTask.Priority} not found" };
            }
            return null;
        }

        ///<summary>
        /// Updates task details
        ///</summary>
        public ErrorDTO UpdateTask(Guid id,UpdateTaskDTO updateTask)
        {
            bool isTaskNameExist = _taskManagementRepository.IsTaskNameExist(updateTask.Name);
            if(isTaskNameExist)
            {
                return new ErrorDTO() {type="Task",description="Task name already exist" };
            }
            Tasks task = _taskManagementRepository.GetTask(id);
            task.TaskMapAssignee = new List<TaskMapAssignee>();
            List<Guid> assigneeIds = task.TaskMapAssignee.Select(sel => sel.AssigneeId).ToList();
            task.Name = updateTask.Name;
            task.Description = updateTask.Description;
            task.StartDate = updateTask.StartDate;
            task.DueDate = updateTask.DueDate;
            task.Priority = updateTask.Priority;
            task.Status = updateTask.Status;
            foreach (Guid item in updateTask.Assignee)
            {
                TaskMapAssignee taskMapAssignee = new TaskMapAssignee()
                {
                    Id=Guid.NewGuid(),
                    AssigneeId=item,
                    TaskId=id,
                };
                task.TaskMapAssignee.Add(taskMapAssignee);
            }
            _taskManagementRepository.UpdateTask(task);
            return null;
        }

        ///<summary>
        /// Deletes Task
        ///</summary>
        public ErrorDTO DeleteTask(Guid id)
        {
            bool isTaskIdExist = _taskManagementRepository.DeleteTask(id);
            if(!isTaskIdExist)
            {
                return new ErrorDTO() {type="Task",description=$"Task with id {id} not found" };
            }
            return null;
        }

        ///<summary>
        /// Checks meta-data id exist or not
        ///</summary>
        public ErrorDTO IsUpdateTaskStatusExist(Guid id, Guid statusId)
        {
            bool isTaskIdExist = _taskManagementRepository.IsTaskIdExist(id);
            if(!isTaskIdExist)
            {
                return new ErrorDTO() {type="Task",description="Task id not found" };
            }
            bool isStatusId = _taskManagementRepository.IsStatusIdFound(statusId);
            if(isStatusId)
            {
                return new ErrorDTO() {type="Meta-data",description="meta-data not found" };
            }
            return null;
        }

        ///<summary>
        /// Updates Task status
        ///</summary>
        public void UpdateStatus(Guid id,Guid userId)
        {
            _taskManagementRepository.UpdateStatus(id,userId);
        }

        ///<summary>
        /// Checks meta-data id exist or not
        ///</summary>
        public ErrorDTO IsUpdateRemainder(Guid id, Guid remainderId)
        {
            bool isTaskIdExist = _taskManagementRepository.IsTaskIdExist(id);
            if (!isTaskIdExist)
            {
                return new ErrorDTO() { type = "Task", description = "Task id not found" };
            }
            bool isStatusId = _taskManagementRepository.IsStatusIdFound(remainderId);
            if (isStatusId)
            {
                return new ErrorDTO() { type = "StatusId", description = "meta-data not found" };
            }
            return null;
        }

        ///<summary>
        /// Updates Task remainder
        ///</summary>
        public void UpdateRemainder(Guid id, Guid remainderId)
        {
            _taskManagementRepository.UpdateRemainder(id,remainderId);
        }

        ///<summary>
        /// Gets list of assignee
        ///</summary>
        public List<Assignee> GetAssigneeList()
        {
            List<Assignee> assignees = _taskManagementRepository.GetAssigneeList();
            if (assignees.Count() == 0)
            {
                return null;
            }
            return assignees;
        }
    }
}
