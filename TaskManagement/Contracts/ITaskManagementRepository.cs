using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;
using TaskManagement.Models;

namespace TaskManagement.Contracts
{
    public interface ITaskManagementRepository
    {
        public bool IsUserExist(string userName);

        public string GetPassword(string userName);

        public List<RefTerm> GetRefSetData(string key);

        public bool IsTaskNameExist(string name);

        public Guid SaveTask(Tasks task);

        public bool IsUserIdExist(Guid id);

        public List<Tasks> GetTaskList(Guid id, int size, int pageNo);

        public List<RefSetTerm> GetTermData();

        public List<RefTerm> GetSetData();

        public List<string> GetAssigneeName( List<Guid> assigneeList);

        public Tasks GetTask(Guid id);

        public List<Tasks> GetSubTasks(Guid id);

        public string GetAssigner(Guid id);

        public bool IsTaskIdExist(Guid id);

        public Guid IsUserExist(List<Guid> ids);

        public void UpdateTask(Tasks tasks);

        public bool DeleteTask(Guid id);

        public bool IsStatusIdFound(Guid id);

        public void UpdateStatus(Guid id,Guid userId);

        public void UpdateRemainder(Guid id, Guid remainderId);

        public List<Assignee> GetAssigneeList();

    }
}
