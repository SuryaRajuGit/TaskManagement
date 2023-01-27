using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Contracts;
using TaskManagement.Entities.Dtos;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class TaskManagementRepository : ITaskManagementRepository
    {
        private readonly TaskManagementContext _taskManagementContext;
        public TaskManagementRepository(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext;
        }

        ///<summary>
        /// Checks user name exist or not 
        ///</summary>
        ///<return>bool</return>
        public bool IsUserExist(string email)
        {
            return _taskManagementContext.User.Any(item => item.Email == email && item.IsActive == true);
        }

        ///<summary>
        /// Gets user password
        ///</summary>
        ///<return>string</return>
        public string GetPassword(string email)
        {
            return _taskManagementContext.User.Where(find => find.Email == email && find.IsActive == true).Select(term => term.Password ).FirstOrDefault();
        }

        ///<summary>
        /// Gets list of meta-data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public List<RefTerm> GetRefSetData(string key)
        {
            bool isExists = _taskManagementContext.RefSet.Any(cus => cus.Key == key && cus.IsActive == true);
            if (!isExists)
            {
                return null;
            }
            List<RefTerm> refTermList = _taskManagementContext.SetRefTerm.Include(src => src.RefSet).Include(src => src.RefTerm).Where(wrt => wrt.RefSet.Key == key && wrt.IsActive == true).Select(src => src.RefTerm).ToList();
            return refTermList;
        }

        ///<summary>
        /// Checks task name already exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsTaskNameExist(string name)
        {
            return _taskManagementContext.Tasks.Any(find => find.Name == name && find.IsActive == true);
        }
        ///<summary>
        /// Checks task name already exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsUpdateTaskNameExist(string name,Guid id)
        {
            return _taskManagementContext.Tasks.Any(find => find.Name == name && find.Id != id && find.IsActive == true);
        }
        ///<summary>
        /// Saves task details
        ///</summary>
        ///<return>Guid</return>
        public Guid SaveTask(Tasks task)
        {
            _taskManagementContext.Tasks.Add(task);
            _taskManagementContext.SaveChanges();
            return task.Id;
        }

        ///<summary>
        /// Checks Assignee id exist or not
        ///</summary>
        ///<return>List<RefTerm></return>
        public bool IsUserIdExist(Guid id)
        {
            return _taskManagementContext.User.Any(find => find.Id == id && find.IsActive == true);
        }

        ///<summary>
        /// Gets list of meta-data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public bool IsExist(List<TaskAssigneeMapping> taskMapAssignee, Guid id)
        {
            foreach (TaskAssigneeMapping item in taskMapAssignee)
            {
                if (item.AssigneeId == id)
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        /// Gets list of tasks 
        ///</summary>
        ///<return>List<Tasks></return>
        public List<Tasks> GetTaskList(Guid id, int size, int pageNo)
        {
            List<Tasks> list = new List<Tasks>();
            foreach (Tasks item in _taskManagementContext.Tasks.Include(s => s.TaskMapAssignee).Where(find => find.IsActive == true).Skip((pageNo - Constants.pageNO) * Constants.pagesize).Take(size))
            {
                bool isExist =  item.Assigner == id || item.TaskMapAssignee.Select(s => s.AssigneeId).ToList().Contains(id);
                if (isExist)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        ///<summary>
        /// Gets list of meta-data  
        ///</summary>
        ///<return>List<RefSetTerm></return>
        public List<SetRefTerm> GetTermData()
        {
            return _taskManagementContext.SetRefTerm.Where(find => find.IsActive == true).ToList();
        }

        ///<summary>
        /// Gets list of ref set data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public List<RefTerm> GetSetData()
        {
            return _taskManagementContext.RefTerm.Where(find => find.IsActive == true).ToList();
        }

        ///<summary>
        /// Gets list Assignee names
        ///</summary>
        ///<return>List<string></return>
        public List<string> GetAssigneeName(List<Guid> assigneeList)
        {
            List<string> assignee = new List<string>();
            foreach (User item in _taskManagementContext.User)
            {
                if(assigneeList.Contains(item.Id) && item.IsActive == true)
                {
                    assignee.Add(item.Name);
                }
            }
            return assignee.OrderBy(sel => sel).ToList(); 
        }

        ///<summary>
        /// Gets list of ref set data 
        ///</summary>
        ///<return>List<RefTerm></return>
        public Tasks GetTask(Guid id)
        {
            return _taskManagementContext.Tasks.Include(term => term.TaskMapAssignee).Where(find =>find.Id == id && find.IsActive == true).FirstOrDefault();
        }

        ///<summary>
        /// Gets list of Tasks
        ///</summary>
        ///<return>List<Tasks></return>
        public List<Tasks> GetSubTasks(Guid id)
        {
            return _taskManagementContext.Tasks.Include(sel => sel.TaskMapAssignee.Where(fin => fin.IsActive == true)).Where(find => find.ParentTaskId == id && find.IsActive == true).ToList();
        }

        ///<summary>
        /// Gets Assignee name
        ///</summary>
        ///<return>stirng</return>
        public string GetAssigner(Guid id)
        {
            return _taskManagementContext.User.Where(find => find.Id == id && find.IsActive == true).Select(sel => sel.Name).First();
        }

        ///<summary>
        /// Checks Task id exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsTaskIdExist(Guid id)
        {
            return _taskManagementContext.Tasks.Any(find => find.Id == id && find.IsActive == true);
        }

        ///<summary>
        /// Checks user id exist or not
        ///</summary>
        ///<return>Guid</return>
        public Guid IsUserExist(List<Guid> ids)
        {
            foreach (Guid item in ids)
            {
                bool isExist = _taskManagementContext.User.Any(sel => sel.Id == item && sel.IsActive == true);
                if(!isExist)
                {
                    return item;
                }
            }
            return Guid.Empty;
        }

        ///<summary>
        /// Updates Task details
        ///</summary>
        public void UpdateTask(Tasks tasks)
        {
            List<TaskAssigneeMapping> list = new List<TaskAssigneeMapping>();

            foreach (TaskAssigneeMapping item in _taskManagementContext.TaskAssigneeMapping.Where(find => find.TaskId == tasks.Id && find.IsActive == true))
            {
                item.IsActive = false;
            }
            _taskManagementContext.Tasks.Update(tasks);
            _taskManagementContext.TaskAssigneeMapping.UpdateRange(list);
            _taskManagementContext.SaveChanges();
        }

        ///<summary>
        /// Deletes Task
        ///</summary>
        ///<return>bool</return>
        public bool DeleteTask(Guid id)
        {
            List<Tasks> task = _taskManagementContext.Tasks.Include(term => term.TaskMapAssignee.Where(sel => sel.IsActive == true)).Where(find => find.Id == id 
            || find.ParentTaskId == id && find.IsActive == true).ToList();
            foreach (Tasks item in task)
            {
                item.IsActive = false;
                foreach (var each in item.TaskMapAssignee)
                {
                    each.IsActive = false;
                }
            }
            if(task.Count() == 0)
            {
                return false;
            }
            _taskManagementContext.Tasks.UpdateRange(task);
            _taskManagementContext.SaveChanges();
            return true;
        }

        ///<summary>
        /// Checks meta-data exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsStatusIdFound(Guid id)
        {
            return _taskManagementContext.RefTerm.Any(sel => sel.Id == id && sel.IsActive == true);
        }

        ///<summary>
        /// Updates Task status
        ///</summary>
        public void UpdateStatus(Guid id,Guid statusId)
        {
            Tasks task = _taskManagementContext.Tasks.Where(find => find.Id == id && find.IsActive == true).First();
            task.Status = statusId;
            _taskManagementContext.SaveChanges();
        }

        ///<summary>
        /// Updates Task remainder
        ///</summary>
        public void UpdateReminder(Guid id, Guid reminderId)
        {
            Tasks task = _taskManagementContext.Tasks.Where(find => find.Id == id && find.IsActive == true).First();
            task.ReminderPeriodId = reminderId;
            _taskManagementContext.SaveChanges();
        }

        ///<summary>
        /// Gets list of Assginee 
        ///</summary>
        ///<return>List<Assignee></return>
        public List<User> GetAllAssignee()
        {
            return _taskManagementContext.User.Where(find => find.IsActive == true).ToList();
        }

        ///<summary>
        /// checks assignee is exist or not
        ///</summary>
        ///<return>bool</return>
        public bool IsAssignerExist(Guid id)
        {
            return _taskManagementContext.User.Any(find => find.Id == id && find.IsActive == true);
        }

        ///<summary>
        /// checks parent id exist or not
        ///</summary>
        ///<return>bool</return>
        public bool CheckParentTaskId(Guid id)
        {
            return _taskManagementContext.Tasks.Any(find => find.Id == id && find.IsActive == true);
        }

        ///<summary>
        /// checks parent task date exist or not
        ///</summary>
        ///<return>Tasks</return>
        public Tasks IsParentTaskDatesValid(string end, string start, Guid parentTaskId)
        {
            return  _taskManagementContext.Tasks.Where(find => find.Id == parentTaskId && find.IsActive == true).FirstOrDefault();
        }


        ///<summary>
        /// checks parent task exist or not
        ///</summary>
        ///<return>Tasks</return>
        public Tasks GetParentTask(Guid id)
        {
            Guid taskId = _taskManagementContext.Tasks.Where(find => find.Id == id && find.IsActive == true).Select(sel => sel.ParentTaskId).FirstOrDefault();
            if(taskId == null)
            {
                return null;
            }
            return _taskManagementContext.Tasks.Where(sel => sel.Id == taskId).FirstOrDefault();
        }

        ///<summary>
        /// checks new user sign up exits or not
        ///</summary>
        ///<return>bool</return>
        public bool CheckUserName(string email)
        {
            return _taskManagementContext.User.Any(sel => sel.Email == email && sel.IsActive == true);
        }

        ///<summary>
        /// checks phone number exist or not
        ///</summary>
        ///<return>bool</return>
        public bool CheckPhone(string phone)
        {
            return _taskManagementContext.User.Any(sel => sel.Phone == phone && sel.IsActive == true);
        }

        ///<summary>
        /// Saves user details
        ///</summary>
        ///<return>Guid</return>
        public Guid SaveUser(User user)
        {
            _taskManagementContext.User.Add(user);
            _taskManagementContext.SaveChanges();
            return user.Id;
        }
        ///<summary>
        /// Gets user id with user name
        ///</summary>
        ///<return>Guid</return>
        public Guid GetId(string email)
        {
            return _taskManagementContext.User.Where(find => find.Email == email && find.IsActive == true).Select(sel => sel.Id).FirstOrDefault();
        }

        ///<summary>
        /// Gets status id 
        ///</summary>
        ///<return>Guid</return>
        public Guid GetStatusId()
        {
            return _taskManagementContext.RefTerm.Where(sel => sel.Key == Constants.Open && sel.IsActive == true).Select(fin => fin.Id).First();
        }

        ///<summary>
        /// Gets priority id
        ///</summary>
        ///<return>Guid</return>
        public Guid GetPriorityId()
        {
            return _taskManagementContext.RefTerm.Where(sel => sel.Key == Constants.Low && sel.IsActive == true).Select(sel => sel.Id).First();
        }

        public List<Tasks> GetTaskList(Guid id)
        {
            Guid status = _taskManagementContext.RefTerm.Where(sel => sel.Key == Constants.Complete && sel.IsActive == true).Select(sel => sel.Id).First();
            return _taskManagementContext.Tasks.Where(find => find.Assigner == id && find.ReminderPeriodId != Guid.Empty && find.DueDate != DateTime.MinValue && find.Status != status && find.IsActive == true).ToList();
        }

        public List<RefTerm> GetRefTermDays()
        {
            return _taskManagementContext.RefTerm.Where(find => find.Key == Constants.days_3 || find.Key == Constants.days_7 && find.IsActive == true).ToList();
        }

        public string GetReminderDays(Guid id)
        {
            return _taskManagementContext.RefTerm.Where(find => find.IsActive == true && find.Id == id).Select(sel => sel.Key).First();
        }
    }
}
