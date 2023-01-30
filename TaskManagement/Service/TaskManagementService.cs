using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Models;

namespace TaskManagement.Service
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly ITaskManagementRepository _taskManagementRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public TaskManagementService(ITaskManagementRepository taskManagementRepository, IMapper mapper, IHttpContextAccessor context)
        {
            _taskManagementRepository = taskManagementRepository;
            _mapper = mapper;
            _context = context;
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
                return new ErrorDTO() { type = "NotFound", description = "User not found with the user name" };
            }
            return null;
        }

        ///<summary>
        /// Validates user login details and return JWT token
        /// <param name = "loginDTO" ></ param >
        ///</summary>
        public LogInResponseDTO VerifyUser(LoginDTO loginDTO)
        {
            //gets user passwod
            string encryptPassword = _taskManagementRepository.GetPassword(loginDTO.Email);
            if(encryptPassword == null)
            {
                return null;
            }
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(this.key, this.iv);
            byte[] inputbuffer = Convert.FromBase64String(encryptPassword);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            string password = Encoding.Unicode.GetString(outputBuffer);
            Guid id = _taskManagementRepository.GetId(loginDTO.Email);
            if (password == loginDTO.Password)
            {

                JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
                byte[] tokenKey = Encoding.UTF8.GetBytes(Constants.secutityKey);

                SecurityTokenDescriptor tokenDeprictor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, id.ToString()) ,
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
            //gets refset data
            List<RefTerm> refTerm = _taskManagementRepository.GetRefSetData(key);
            if (refTerm == null)
            {
                return null;
            }

            List<MetaDataResponse> destinationList = _mapper.Map<List<MetaDataResponse>>(refTerm);

            return destinationList;
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
            if(task.StartDate == null && task.DueDate != null)
            {
                task.StartDate =   DateTime.Now.ToString();
            }
            //Checks task name exist or not and returns bool 
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
            // gets user id from claims
            Guid id = Guid.Parse(_context.HttpContext.User.Claims.First(sel => sel.Issuer == Constants.Issuer).Value);
            if(task.Status == Guid.Empty)
            {
                Guid statusId = _taskManagementRepository.GetStatusId();
                task.Status = statusId;
            }

            if(task.Priority == Guid.Empty)
            {
                Guid priorityId = _taskManagementRepository.GetPriorityId();
                task.Priority = priorityId;
            }
            Tasks tasks1 = _mapper.Map<Tasks>(task);
            tasks1.Id = taskId;
            tasks1.Assigner = id;
            List<TaskAssigneeMapping> tasksList = new List<TaskAssigneeMapping>();
            if(task.Assignee != null)
            {
                foreach (Guid item in task.Assignee)
                {
                    TaskAssigneeMapping taskAssignee = new TaskAssigneeMapping()
                    {
                        Id = Guid.NewGuid(),
                        AssigneeId = item,
                        TaskId = taskId,
                        CreatedDate=DateTime.Now,
                        CreatedId=id,
                        IsActive=true
                    };
                    tasksList.Add(taskAssignee);
                }
                tasks1.TaskMapAssignee.AddRange(tasksList);
            }
            tasks1.IsActive = true;
            tasks1.CreatedDate = DateTime.Now;
            return _taskManagementRepository.SaveTask(tasks1);
        }

        ///<summary>
        /// Checks user id exist or not
        /// <param name = "id" ></ param >
        ///</summary>
        public ErrorDTO IsUserIdExist(Guid id)
        {
            // Checks user id exist or not
            bool isUserIdExist = _taskManagementRepository.IsUserIdExist(id);
            if(!isUserIdExist)
            {
                return new ErrorDTO() {type="NotFound",description="User id not exist" };
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
            sortOrder = sortOrder == null ? Constants.ASC : sortOrder;

            sortBy = sortBy == null ? Constants.Name : sortBy;

            List<Tasks> paginatedList = _taskManagementRepository.GetTaskList( id,  size,  pageNo);
            List<Tasks> sortList = new List<Tasks>();
            if (paginatedList.Count() == 0)
            {
                return null;
            }
            //sorts paginated list of tasks
            switch (sortBy)
            {
                case Constants.Name:
                    sortList = sortOrder == Constants.DSC ? paginatedList.OrderByDescending(item => item.Name).ToList() : paginatedList.OrderBy(item => item.Name).ToList();
                    break;
                case Constants.DueDate:
                    sortList = sortOrder == Constants.DSC ? paginatedList.OrderByDescending(item => item.DueDate).ToList() : paginatedList.OrderBy(item => item.DueDate).ToList();
                    break;
                case Constants.Status:
                    sortList = sortOrder == Constants.DSC ? paginatedList.OrderByDescending(item => item.Status).ToList() : paginatedList.OrderBy(item => item.Status).ToList();
                    break;
                default:
                    sortList = paginatedList;
                    break;
            }
            // Gets refterm data
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<GetTaskDTO> taskList = new List<GetTaskDTO>();
            foreach (Tasks item in sortList)
            {
                GetTaskDTO getTaskDTO = _mapper.Map<GetTaskDTO>(item);
                getTaskDTO.Priority = termData.Where(find => find.Id == item.Priority).Select(sel => sel.Key).First();
                getTaskDTO.Status = termData.Where(find => find.Id == item.Status).Select(sel => sel.Key).First();
                //Gets list of assignee names  with assignee ids
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
            // Gets Task with id
            Tasks task = _taskManagementRepository.GetTask(id);
            if(task == null)
            {
                return null;
            }
            // Gets Sub tasks of parent task
            List<Tasks> subTasks = _taskManagementRepository.GetSubTasks(id);
            // Gets refterm data
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            GetSingleTaskDTO getSingleTaskDTO = _mapper.Map<GetSingleTaskDTO>(task);
            getSingleTaskDTO.Status = termData.Where(find => find.Id == task.Status).Select(sel => sel.Key).First();
            getSingleTaskDTO.Priority = termData.Where(find => find.Id == task.Priority).Select(sel => sel.Key).First();
            // Gets assignee names with list of assignee ids
            getSingleTaskDTO.Assignee = _taskManagementRepository.GetAssigneeName(task.TaskMapAssignee.Select(each => each.AssigneeId).ToList());
            // Gets assigner name
            getSingleTaskDTO.Assigner = _taskManagementRepository.GetAssigner(task.Assigner);
            List<SubTaskDTO> subTaskList = new List<SubTaskDTO>();

            foreach (Tasks item in subTasks)
            {
                SubTaskDTO subTask = new SubTaskDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    //Gets assignee names with list of assignee ids
                    Assignee = _taskManagementRepository.GetAssigneeName(item.TaskMapAssignee.Select(each => each.AssigneeId).ToList())
                };
                subTaskList.Add(subTask);
            }
            getSingleTaskDTO.SubTasks.AddRange(subTaskList);
            return getSingleTaskDTO;
        }

        ///<summary>
        /// Checks Task details already exist or not
        /// <param name = "id" ></ param >
        /// <param name = "updateTask" ></ param >
        ///</summary>
        public ErrorDTO IsTaskExist(Guid id,UpdateTaskDTO updateTask)
        {
            //Checks task id exist or not
            bool isTaskExist = _taskManagementRepository.IsTaskIdExist(id);
            if(!isTaskExist)
            {
                return new ErrorDTO() {type="NotFound",description="Task id not found" };
            }
            //Gets refterm data
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<Guid> ids = termData.Select(sel => sel.Id).ToList();
            if (!ids.Contains(updateTask.Priority) && updateTask.Priority != Guid.Empty)
            {
                return new ErrorDTO() {type="NotFound",description=$"Meta-data id {updateTask.Priority} not found" };
            }
            if(!ids.Contains(updateTask.Status) && updateTask.Status != Guid.Empty)
            {
                return new ErrorDTO() { type = "NotFound", description = $"Meta-data id {updateTask.Priority} not found" };
            }
            if (updateTask.Assignee == null)
            {
                return null;
            }
            Guid userId = _taskManagementRepository.IsUserExist(updateTask.Assignee);
            if (userId != Guid.Empty)
            {
                return new ErrorDTO() { type = "NotFound", description = $"Assignee with id {userId} not found" };
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
            //Checks update task name exist or not  and return bool
            bool isTaskNameExist = _taskManagementRepository.IsUpdateTaskNameExist(updateTask.Name,id);
            if(isTaskNameExist)
            {
                return new ErrorDTO() {type="Conflict",description="Task name already exist" };
            }
            if (updateTask.StartDate == null && updateTask.DueDate != null)
            {
                updateTask.StartDate = DateTime.Now.ToString();
            }
            //Gets task details with task id
            Tasks task = _taskManagementRepository.GetTask(id);
            task.TaskMapAssignee = new List<TaskAssigneeMapping>();
            List<Guid> assigneeIds = task.TaskMapAssignee.Select(sel => sel.AssigneeId).ToList();
            task.Name = updateTask.Name;
            task.Description = updateTask.Description;
            if (updateTask.StartDate == null && updateTask.DueDate == null)
            {
                updateTask.StartDate = DateTime.MinValue.ToString();
                updateTask.DueDate = DateTime.MinValue.ToString();
            }
            task.StartDate = DateTime.Parse(updateTask.StartDate);
            task.Priority = updateTask.Priority;
            task.Status = updateTask.Status;
            if (updateTask.Priority == Guid.Empty )
            {
                task.Priority = _taskManagementRepository.GetPriorityId();
            }
            if(updateTask.Status == Guid.Empty)
            {
                task.Status = _taskManagementRepository.GetStatusId();
            }
            task.DueDate = DateTime.Parse(updateTask.DueDate);
            //Gets user id from claims
            Guid userId = Guid.Parse(_context.HttpContext.User.Claims.First(sel => sel.Issuer == Constants.Issuer).Value);
            if (updateTask.Assignee != null)
            {
                task.TaskMapAssignee = updateTask.Assignee.Select(sel => new TaskAssigneeMapping
                {
                    AssigneeId = sel,
                    TaskId = id,
                    UpdatedDate= DateTime.Now,
                    UpdatedId= userId,
                    IsActive = true
                }).ToList();
            }
            
            _taskManagementRepository.UpdateTask(task);
            return null;
        }

        ///<summary>
        /// Deletes Task
        /// <param name = "id" ></ param >
        ///</summary>
        public ErrorDTO DeleteTask(Guid id)
        {
            //Checks task exist or not and retuns bool
            bool isTaskIdExist = _taskManagementRepository.DeleteTask(id);
            if(!isTaskIdExist)
            {
                return new ErrorDTO() {type="NotFound",description=$"Task with id {id} not found" };
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
            //Checks task id exist or not and retruns bool
            bool isTaskIdExist = _taskManagementRepository.IsTaskIdExist(id);
            if(!isTaskIdExist)
            {
                return new ErrorDTO() {type="NotFound",description="Task id not found" };
            }
            //checks status id exist or not and returns bool
            bool isStatusId = _taskManagementRepository.IsStatusIdFound(statusId);
            if(!isStatusId)
            {
                return new ErrorDTO() {type="NotFound",description="meta-data not found" };
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
        /// <param name = "reminderId" ></ param >
        ///</summary>
        public ErrorDTO IsUpdateReminder(Guid id, Guid reminderId)
        {
            //Checks update id exist or not and returns bool
            bool isTaskIdExist = _taskManagementRepository.IsTaskIdExist(id);
            if (!isTaskIdExist)
            {
                return new ErrorDTO() { type = "NotFound", description = "Task id not found" };
            }
            // Checks status id exist or not and returns bool
            bool isStatusId = _taskManagementRepository.IsStatusIdFound(reminderId);
            if (!isStatusId)
            {
                return new ErrorDTO() { type = "NotFound", description = "meta-data not found" };
            }
            return null;
        }

        ///<summary>
        /// Updates Task reminder
        /// <param name = "id" ></ param >
        /// <param name = "reminderId" ></ param >
        ///</summary>
        public void UpdateReminder(Guid id, Guid reminderId)
        {
            _taskManagementRepository.UpdateReminder(id,reminderId);
        }

        ///<summary>
        /// Gets list of assignee
        ///</summary>
        public List<AssigneeDTO> GetAssigneeList()
        {
            //Gets list of assignee 
            List<User> assignees = _taskManagementRepository.GetAllAssignee();
            if (assignees.Count() == 0)
            {
                return null;
            }

            List<AssigneeDTO> list = _mapper.Map<List<AssigneeDTO>>(assignees);
            return list;
        }

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "end" ></ param >
        /// <param name = "start" ></ param >
        ///</summary>
        public ErrorDTO IsDateInvalid(string end,string start,Guid reminderId)
        {
            DateTime dateTime = DateTime.Now;
            if (end == null && start == null)
            {
                return null;
            }
            if(start !=null && end == null)
            {
                return new ErrorDTO() {type="BadRequest",description="DueDate is Required" };
            }
            if(start == null && end != null)
            {
                TimeSpan time = new TimeSpan(0, 0, 0, 1);
                DateTime combined = dateTime.Add(time);
                start = combined.ToString();
            }
            if (!DateTime.TryParse(start, out DateTime startDate))
            {
                return new ErrorDTO() { type = "BadRequest", description = $"Invalid start datetime {start}" };
            }
            if (!DateTime.TryParse(end, out DateTime endDate))
            {
                return new ErrorDTO() { type = "BadRequest", description = $"Invalid due datetime {end}" };
            }
            string day = dateTime.ToString(Constants.Date);
            DateTime currentDay = DateTime.Parse(day);
            if (currentDay > startDate && currentDay != startDate)
            {
                return new ErrorDTO() { type="BadRequest",description="Invalid  start datetime"};
            }
            if (Convert.ToDateTime(startDate) >= Convert.ToDateTime(endDate))
            {
                return new ErrorDTO() {type="BadRequest",description="DueDate must be greater than StartDate" };
            }
            //Gets remainder days with remainder id

           
            if(reminderId == Guid.Empty)
            {
                return null;
            }
            string reminderDays = _taskManagementRepository.GetReminderDays(reminderId);
            char daysChar = reminderDays[0];

            DateTime endDateString = DateTime.Parse(DateTime.Parse(end).ToString(Constants.Date));
            DateTime dueDateString = DateTime.Parse(DateTime.Parse(start).ToString(Constants.Date));

            int reaminderDays = int.Parse(daysChar.ToString());

            if ((endDateString - dueDateString).Days < reaminderDays && reminderId != Guid.Empty)
            {
                return new ErrorDTO() { type = "BadRequest", description = "Invalid Remainder days" };
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
            if(createTask.StartDate ==  null && createTask.DueDate == null)
            {
                return null;
            }
            if(createTask.StartDate == null)
            {
                createTask.StartDate = DateTime.Now.ToString();
            }
            DateTime startDate = DateTime.Parse(createTask.StartDate);
            DateTime dueDate = DateTime.Parse(createTask.DueDate);
            //Gets parent task with id
            Tasks parentTask = _taskManagementRepository.IsParentTaskDatesValid(createTask.DueDate, createTask.StartDate, createTask.ParentTaskId);
            if(parentTask.DueDate == DateTime.MinValue && parentTask.StartDate == DateTime.MinValue)
            {
                return null;
            }
            if (Convert.ToDateTime(parentTask.StartDate) > Convert.ToDateTime(startDate) || Convert.ToDateTime(startDate) > Convert.ToDateTime(parentTask.DueDate))
            {
                return new ErrorDTO() { type = "BadRequest", description = "StartDate must be with the time period of parent task" };
            }
            if (Convert.ToDateTime(parentTask.DueDate) < Convert.ToDateTime(dueDate))
            {
                return new ErrorDTO() { type = "BadRequest", description = "DueDate must be with the time period of parent task" };
            }
            return null;
        }

        ///<summary>
        /// Checks start date is lesser than due date
        /// <param name = "task" ></ param >
        ///</summary>
        public ErrorDTO CheckMetadata(CreateTaskDTO task)
        {
            //Gets list of refterm data
            List<RefTerm> termData = _taskManagementRepository.GetSetData();
            List<Guid> ids = termData.Select(sel => sel.Id).ToList();
            if (!ids.Contains(task.Priority) && task.Priority != Guid.Empty)
            {
                return new ErrorDTO() { type = "NotFound", description = $"Meta-data id {task.Priority} not found" };
            }
            else if (!ids.Contains(task.Status) && task.Status != Guid.Empty)
            {
                return new ErrorDTO() { type = "NotFound", description = $"Meta-data id {task.Priority} not found" };
            }
            else if (!ids.Contains(task.ReminderPeriodId) && task.ReminderPeriodId != Guid.Empty)
            {
                return new ErrorDTO() { type = "NotFound", description = $"Meta-data id {task.ReminderPeriodId} not found" };
            }
            
            if (task.Assignee != null)
            {
                //Checks user name exist or not and returns Guid
                Guid userId = _taskManagementRepository.IsUserExist(task.Assignee);
                if(userId != Guid.Empty)
                {
                    return new ErrorDTO() { type = "NotFound", description = $"Assignee with id {userId} not found" };
                }
            }
            if(task.ParentTaskId != Guid.Empty )
            {
                // Checks parent task id exist or not and returns bool
                bool isParentTaskExist = _taskManagementRepository.CheckParentTaskId(task.ParentTaskId);
                if(!isParentTaskExist)
                {
                    return new ErrorDTO() {type= "NotFound", description="Parent task id not exist" };
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
            //Gets Parent Task with id
            Tasks parentTask = _taskManagementRepository.GetParentTask(id);
            if(parentTask == null || (parentTask.StartDate == DateTime.MinValue && parentTask.DueDate == DateTime.MinValue))
            {
                return null;
            }
            DateTime startDate = DateTime.Parse(task.StartDate);
            DateTime dueDate = DateTime.Parse(task.DueDate);
            if (Convert.ToDateTime(parentTask.StartDate) > Convert.ToDateTime(startDate) || Convert.ToDateTime(startDate) > Convert.ToDateTime(parentTask.DueDate))
            {
                return new ErrorDTO() { type = "BadRequest", description = "StartDate must be with the time period of parent task" };
            }
            if (Convert.ToDateTime(parentTask.DueDate) < Convert.ToDateTime(dueDate))
            {
                return new ErrorDTO() { type = "BadRequest", description = "DueDate must be with the time period of parent task" };
            }
            return null;
        }
        ///<summary>
        /// Checks user name aleady exist or not
        /// <param name = "user" ></ param >
        ///</summary>
        public ErrorDTO SignUp(SignUpDTO user)
        {
            bool checkUserName = _taskManagementRepository.CheckUserName(user.Email);
            if (checkUserName)
            {
                return new ErrorDTO() { type = "Conflict", description = "User name already exist" };
            }
            bool checkPhone = _taskManagementRepository.CheckPhone(user.Phone);
            if (checkPhone)
            {
                return new ErrorDTO() {type="Conflict", description="Phone number already exist" };
            }
            return null;
        }
        ///<summary>
        /// Saves user details and returns id
        /// <param name = "user" ></ param >
        ///</summary>
        public Guid SaveUser(SignUpDTO user)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(this.key, this.iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(user.Password);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            string EncryptPassword = Convert.ToBase64String(outputBuffer);
            User userData = _mapper.Map<User>(user);
            userData.Password = EncryptPassword;
            Guid userId = Guid.NewGuid();
            userData.Id = userId;
            userData.Name = user.Name; 
            userData.Phone = user.Phone;
            userData.IsActive = true;
            userData.CreatedDate = DateTime.Now;
            userData.CreatedId = userId;
            // Saves user details and return id
            Guid id = _taskManagementRepository.SaveUser(userData);
            return id;
        }

        ///<summary>
        /// Gets list of remainders
        ///</summary>
        public List<ReminderResponseDTO> GetReminder()
        {
            //Gets user id from claims
            Guid id = Guid.Parse(_context.HttpContext.User.Claims.First(sel => sel.Issuer == Constants.Issuer).Value);
            //Gets list of Tasks with user id
            List<Tasks> tasks = _taskManagementRepository.GetTaskList(id);
            DateTime dateTime = DateTime.Now;
            string day = dateTime.ToString(Constants.Date);
            DateTime currentDay = DateTime.Parse(day);
            //Gets refterm data 
            List<RefTerm> reminderDays = _taskManagementRepository.GetRefTermDays();
            List<ReminderResponseDTO> list = new List<ReminderResponseDTO>();
            foreach (Tasks item in tasks)
            {
                //Gets remainder days with remainder id
                string daysString = reminderDays.Where(fin => fin.Id == item.ReminderPeriodId).Select(sel => sel.Key).First();
                char daysChar = daysString[0];
                int days = int.Parse(daysChar.ToString());
                string dueDateString = item.DueDate.ToString(Constants.Date);
                DateTime dueDate = DateTime.Parse(dueDateString);

                string currentString = currentDay.ToString(Constants.Date);
                DateTime currentDate = DateTime.Parse(currentString);

                string startString = item.StartDate.ToString(Constants.Date);
                DateTime startDate = DateTime.Parse(startString);

                DateTime remainderDay = dueDate.AddDays(-days);

                if(remainderDay <= currentDate)
                {
                    ReminderResponseDTO reminder = _mapper.Map<ReminderResponseDTO>(item);
                    list.Add(reminder);
                }          
            }
            if(list.Count() != 0)
            {
                return list;
            }
            return null;
        }
        public ErrorDTO IsDateValid(Guid id, Guid reminderId)
        {
            Tasks task = _taskManagementRepository.GetTask(id);
            string remainder = _taskManagementRepository.GetReminderDays(reminderId);
            char daysChar = remainder[0];
            int days = int.Parse(daysChar.ToString());
            DateTime startDate = task.StartDate;
            DateTime dueDate = task.DueDate;

            DateTime start = DateTime.Parse(startDate.ToString(Constants.Date));
            DateTime due = DateTime.Parse(dueDate.ToString(Constants.Date));

            DateTime current = DateTime.Now;
            DateTime currentDate = DateTime.Parse(current.ToString(Constants.Date));

            if((currentDate >= due.AddDays(-days)) || (due - start ).TotalDays < days )
            {
                return new ErrorDTO() {type="BadRequest",description="Invalid Reminder period" };
            }
            return null;
        }
    }
}
