using AutoMapper;
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
        private readonly IMapper _mapper;
        byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public TaskManagementService(ITaskManagementRepository taskManagementRepository, IMapper mapper)
        {
            _taskManagementRepository = taskManagementRepository;
            _mapper = mapper;
        }

        ///<summary>
        /// Checks user id exist or not
        /// <param name = "userName" ></ param >
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
        /// <param name = "loginDTO" ></ param >
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
                    Expires = DateTime.UtcNow.AddMinutes(90),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken token = tokenhandler.CreateToken(tokenDeprictor);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                LogInResponseDTO response = new LogInResponseDTO()
                {
                    AccessToken = tokenString,
                    TokenType = Constants.token_type
                };
                return response;
            }
            return null;
        }

        ///<summary>
        /// Gets list of meta-data linked to the key
        ///  <param name = "key" ></ param >
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
                    Id = item.Id.ToString(),
                    Key = item.Key,
                    Description = item.Description
                };
                responseList.Add(response);
            }
            return responseList;
        }

        ///<summary>
        /// Validates request pay load and return ErrorDTO
        ///  <param name = "ModelState" ></ param >
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
        /// <param name = "task" ></ param >
        ///</summary>
        public Guid? CreateTask(CreateTaskDTO task)
        {
            bool isTaskNameExist = _taskManagementRepository.IsTaskNameExist(task.Name);
            if(isTaskNameExist == true)
            {
                return null;
            }
            DateTime startDate;
            DateTime dueDate;
            DateTime.TryParse(task.StartDate, out startDate);
            DateTime.TryParse(task.DueDate, out dueDate);
            Guid taskId = Guid.NewGuid();
            //Tasks tasks = new Tasks()
            //{
            //    Id=taskId,
            //    Description=task.Description,
            //    DueDate= dueDate,
            //    Assigner=task.Assigner,
            //    Name=task.Name,
            //    ParentTaskId=task.ParentTaskId,
            //    Priority=task.Priority,
            //    StartDate= startDate,
            //    Status=task.Status,
            //    ReminderPeriodId=Guid.Empty,
            //    TaskMapAssignee = new List<TaskMapAssignee>(),
            //};
            Tasks tasks1 = _mapper.Map<Tasks>(task);
            tasks1.Id = taskId;
            List<TaskMapAssignee> tasksList = new List<TaskMapAssignee>();
            foreach (Guid item in task.Assignee)
            {
                TaskMapAssignee taskAssignee = new TaskMapAssignee()
                {
                    Id=Guid.NewGuid(),
                    AssigneeId=item,
                    TaskId = taskId
                };
                tasksList.Add(taskAssignee);
            }
            tasks1.TaskMapAssignee.AddRange(tasksList);
           // tasks.TaskMapAssignee.AddRange(tasksList);

            return _taskManagementRepository.SaveTask(tasks1);
        }

        ///<summary>
        /// Checks user id exist or not
        /// <param name = "id" ></ param >
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
        /// <param name = "id" ></ param >
        /// <param name = "size" ></ param >
        /// <param name = "pageNo" ></ param >
        /// <param name = "sortOrder" ></ param >
        /// <param name = "sortBy" ></ param >
        ///</summary>
        public List<GetTaskDTO> GetTaskList(Guid id, int size, int pageNo, string sortOrder, string sortBy  )
        {
            if(sortOrder == null)
            {
                sortOrder = Constants.ASC;
            }
            if(sortBy == null)
            {
                sortBy = Constants.Name;
            }
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
                        sortList = paginatedList.OrderBy(item => item.Priority).ToList();
                    }
                    else
                    {
                        sortList = paginatedList.OrderByDescending(item => item.Priority).ToList();
                    }
                    break;
                default:
                    sortList = paginatedList;
                    break;
            }
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<GetTaskDTO> taskList = new List<GetTaskDTO>();
            foreach (Tasks item in sortList)
            {

                //GetTaskDTO task = new GetTaskDTO()
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    Assignee = _taskManagementRepository.GetAssigneeName(item.TaskMapAssignee.Select(each => each.AssigneeId).ToList()),
                //    Status = termData.Where(find => find.Id == item.Status).Select(sel => sel.Key).First(),
                //    DueDate=item.DueDate,
                //    Priority= termData.Where(find => find.Id == item.Priority).Select(sel => sel.Key).First(),
                //};
                GetTaskDTO getTaskDTO = _mapper.Map<GetTaskDTO>(item);
                getTaskDTO.Priority = termData.Where(find => find.Id == item.Priority).Select(sel => sel.Key).First();
                getTaskDTO.Status = termData.Where(find => find.Id == item.Status).Select(sel => sel.Key).First();
                getTaskDTO.Assignee = _taskManagementRepository.GetAssigneeName(item.TaskMapAssignee.Select(each => each.AssigneeId).ToList());
                taskList.Add(getTaskDTO);
            }
            return taskList;
        }

        ///<summary>
        /// Gets single task details
        /// <param name = "id" ></ param >
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
            //List<Guid> ll = task.TaskMapAssignee.Select(each => each.AssigneeId).ToList();
            //List<string> l = _taskManagementRepository.GetAssigneeName(task.TaskMapAssignee.Select(each => each.AssigneeId).ToList());
            //GetSingleTaskDTO getSingleTaskDTO = new GetSingleTaskDTO()
            //{
            //    Id = task.Id,
            //    Name = task.Name,
            //    Description = task.Description,
            //    StartDate = task.StartDate,
            //    DueDate = task.DueDate,
            //    Priority = termData.Where(find => find.Id == task.Priority).Select(sel => sel.Key).First(),
            //    Status = termData.Where(find => find.Id == task.Status).Select(sel => sel.Key).First(),
            //    Assigner = _taskManagementRepository.GetAssigner(task.Assigner),
            //    Assignee = _taskManagementRepository.GetAssigneeName(task.TaskMapAssignee.Select(each => each.AssigneeId).ToList()),
            //    SubTasks = new List<SubTaskDTO>()
            //};
            GetSingleTaskDTO getSingleTaskDTO = _mapper.Map<GetSingleTaskDTO>(task);
            getSingleTaskDTO.Status = termData.Where(find => find.Id == task.Status).Select(sel => sel.Key).First();
            getSingleTaskDTO.Priority = termData.Where(find => find.Id == task.Priority).Select(sel => sel.Key).First();
            getSingleTaskDTO.Assignee = _taskManagementRepository.GetAssigneeName(task.TaskMapAssignee.Select(each => each.AssigneeId).ToList());
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
           // getSingleTaskDTO.SubTasks.AddRange(subTaskList);
            return getSingleTaskDTO;
        }

        ///<summary>
        /// Checks Task details already exist or not
        /// <param name = "id" ></ param >
        /// <param name = "updateTask" ></ param >
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
        /// <param name = "id" ></ param >
        /// <param name = "updateTask" ></ param >
        ///</summary>
        public ErrorDTO UpdateTask(Guid id,UpdateTaskDTO updateTask)
        {
            bool isTaskNameExist = _taskManagementRepository.IsUpdateTaskNameExist(updateTask.Name,id);
            if(isTaskNameExist)
            {
                return new ErrorDTO() {type="Task",description="Task name already exist" };
            }
            Tasks task = _taskManagementRepository.GetTask(id);
            task.TaskMapAssignee = new List<TaskMapAssignee>();
            List<Guid> assigneeIds = task.TaskMapAssignee.Select(sel => sel.AssigneeId).ToList();
            task.Name = updateTask.Name;
            task.Description = updateTask.Description;
            task.StartDate = DateTime.Parse(updateTask.StartDate);
            task.DueDate = DateTime.Parse(updateTask.DueDate);
            task.Priority = updateTask.Priority;
            task.Status = updateTask.Status;
            task.TaskMapAssignee = updateTask.Assignee.Select(sel => new TaskMapAssignee
            {
                AssigneeId = sel,
                TaskId = id
            }
            ).ToList();
            _taskManagementRepository.UpdateTask(task);
            return null;
        }

        ///<summary>
        /// Deletes Task
        /// <param name = "id" ></ param >
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
        ///  <param name = "id" ></ param >
        ///   <param name = "statusId" ></ param >
        ///</summary>
        public ErrorDTO IsUpdateTaskStatusExist(Guid id, Guid statusId)
        {
            bool isTaskIdExist = _taskManagementRepository.IsTaskIdExist(id);
            if(!isTaskIdExist)
            {
                return new ErrorDTO() {type="Task",description="Task id not found" };
            }
            bool isStatusId = _taskManagementRepository.IsStatusIdFound(statusId);
            if(!isStatusId)
            {
                return new ErrorDTO() {type="Meta-data",description="meta-data not found" };
            }
            return null;
        }

        ///<summary>
        /// Updates Task status
        /// <param name = "id" ></ param >
        /// <param name = "userId" ></ param >
        ///</summary>
        public void UpdateStatus(Guid id,Guid userId)
        {
            _taskManagementRepository.UpdateStatus(id,userId);
        }

        ///<summary>
        /// Checks meta-data id exist or not
        /// <param name = "id" ></ param >
        /// <param name = "remainderId" ></ param >
        ///</summary>
        public ErrorDTO IsUpdateRemainder(Guid id, Guid remainderId)
        {
            bool isTaskIdExist = _taskManagementRepository.IsTaskIdExist(id);
            if (!isTaskIdExist)
            {
                return new ErrorDTO() { type = "Task", description = "Task id not found" };
            }
            bool isStatusId = _taskManagementRepository.IsStatusIdFound(remainderId);
            if (!isStatusId)
            {
                return new ErrorDTO() { type = "StatusId", description = "meta-data not found" };
            }
            return null;
        }

        ///<summary>
        /// Updates Task remainder
        /// <param name = "id" ></ param >
        /// <param name = "remainderId" ></ param >
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

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "end" ></ param >
        /// <param name = "start" ></ param >
        ///</summary>
        public ErrorDTO IsDateInvalid(string end,string start)
        {
            
            if (!DateTime.TryParse(start, out DateTime startDate))
            {
                return new ErrorDTO() { type = "StartDate", description = $"Invalid date time {start}" };
            }
            if (!DateTime.TryParse(end, out DateTime endDate))
            {
                return new ErrorDTO() { type = "DueDate", description = $"Invalid date time {end}" };
            }
            if (Convert.ToDateTime(startDate) >= Convert.ToDateTime(endDate))
            {
                return new ErrorDTO() {type="DueDate",description="DueDate must be greater than StartDate" };
            }
            return null;
        }

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "createTask" ></ param >
        ///</summary>
        public ErrorDTO CheckParentTaskDateDetails(CreateTaskDTO createTask)
        {
            if(createTask.ParentTaskId == Guid.Empty)
            {
                return null;
            }
            DateTime startDate = DateTime.Parse(createTask.StartDate);
            DateTime dueDate = DateTime.Parse(createTask.DueDate);
            Tasks parentTask = _taskManagementRepository.IsParentTaskDatesValid(createTask.DueDate, createTask.StartDate, createTask.ParentTaskId);
            if (Convert.ToDateTime(parentTask.StartDate) > Convert.ToDateTime(startDate) || Convert.ToDateTime(startDate) > Convert.ToDateTime(parentTask.DueDate))
            {
                return new ErrorDTO() { type = "StartDate", description = "StartDate must be with the time period of parent task" };
            }
            if (Convert.ToDateTime(parentTask.DueDate) < Convert.ToDateTime(dueDate))
            {
                return new ErrorDTO() { type = "DueDate", description = "DueDate must be with the time period of parent task" };
            }
            return null;
        }

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "task" ></ param >
        ///</summary>
        public ErrorDTO CheckMetadata(CreateTaskDTO task)
        {
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<Guid> ids = termData.Select(sel => sel.Id).ToList();
            if (!ids.Contains(task.Priority))
            {
                return new ErrorDTO() { type = "Priority", description = $"Meta-data id {task.Priority} not found" };
            }
            else if (!ids.Contains(task.Status))
            {
                return new ErrorDTO() { type = "Status", description = $"Meta-data id {task.Priority} not found" };
            }
            else if (!ids.Contains(task.ReminderPeriodId) && task.ReminderPeriodId != Guid.Empty)
            {
                return new ErrorDTO() { type = "RemainderPeriod", description = $"Meta-data id {task.ReminderPeriodId} not found" };
            }
            Guid userId = _taskManagementRepository.IsUserExist(task.Assignee);
            if (userId != Guid.Empty)
            {
                return new ErrorDTO() { type = "Assignee", description = $"Assignee with id {userId} not found" };
            }
            bool isAssignerExist = _taskManagementRepository.IsAssignerExist(task.Assigner);
            if(!isAssignerExist)
            {
                return new ErrorDTO() {type="Assigner",description=$"Assigner with id {task.Assigner} not found" };
            }
            if(task.ParentTaskId != Guid.Empty)
            {
                bool isParentTaskExist = _taskManagementRepository.CheckParentTaskId(task.ParentTaskId);
                if(!isParentTaskExist)
                {
                    return new ErrorDTO() {type="Task",description="Parent task id not exist" };
                }
            }
            return null;
        }

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "task" ></ param >
        /// <param name = "id" ></ param >
        ///</summary>
        public ErrorDTO CheckParentTaskDate(UpdateTaskDTO task,Guid id)
        {
            Tasks parentTask = _taskManagementRepository.GetParentTask(id);
            if(parentTask == null)
            {
                return null;
            }
            DateTime startDate = DateTime.Parse(task.StartDate);
            DateTime dueDate = DateTime.Parse(task.DueDate);
            if (Convert.ToDateTime(parentTask.StartDate) > Convert.ToDateTime(startDate) || Convert.ToDateTime(startDate) > Convert.ToDateTime(parentTask.DueDate))
            {
                return new ErrorDTO() { type = "StartDate", description = "StartDate must be with the time period of parent task" };
            }
            if (Convert.ToDateTime(parentTask.DueDate) < Convert.ToDateTime(dueDate))
            {
                return new ErrorDTO() { type = "DueDate", description = "DueDate must be with the time period of parent task" };
            }
            return null;
        }
    }
}
