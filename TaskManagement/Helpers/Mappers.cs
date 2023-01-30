using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities.Dtos;
using TaskManagement.Models;

namespace TaskManagement.Helpers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Tasks, CreateTaskDTO>().ReverseMap().ForMember(sel => sel.TaskMapAssignee,fin => fin.MapFrom(act => new List<TaskAssigneeMapping>()));
            
            CreateMap<GetSingleTaskDTO,Tasks>().ReverseMap().ForMember(sel => sel.Priority,fin => fin.MapFrom(act => ""))
                .ForMember(sel => sel.Status,fin => fin.MapFrom(act => ""))
                .ForMember(sel => sel.SubTasks,fin => fin.MapFrom(act=> new List<SubTaskDTO>()))
                .ForMember(sel => sel.Assignee,fin => fin.MapFrom(act => new List<string>()));

            CreateMap<GetTaskDTO, Tasks>().ReverseMap()
                .ForMember(sel => sel.Assignee, fin => fin.MapFrom(act => new List<string>()))
                .ForMember(sel => sel.Status, fin => fin.MapFrom(act => ""))
                .ForMember(sel => sel.Priority, fin => fin.MapFrom(act => ""));

            CreateMap<User, AssigneeDTO>().ReverseMap();
            CreateMap<User, SignUpDTO>().ReverseMap();

            CreateMap<MetaDataResponse, RefTerm>().ReverseMap();

            CreateMap<AssigneeDTO, User>().ReverseMap();

            CreateMap<ReminderResponseDTO, Tasks>().ReverseMap()
                .ForMember(fin => fin.TaskId,sel=>sel.MapFrom(act=>act.Id))
                .ForMember(fin => fin.ReminderMessage,sel=>sel.MapFrom(act=> $"Task due date {act.DueDate}"));

            CreateMap<TaskAssigneeMapping, TaskAssigneeMapping>().ReverseMap();
        }
    }
}
