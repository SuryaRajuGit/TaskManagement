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
            CreateMap<Tasks, CreateTaskDTO>().ReverseMap().ForMember(sel => sel.TaskMapAssignee,fin => fin.MapFrom(act => new List<TaskMapAssignee>()));
            
            CreateMap<GetSingleTaskDTO,Tasks>().ReverseMap().ForMember(sel => sel.Priority,fin => fin.MapFrom(act => ""))
                .ForMember(sel => sel.Status,fin => fin.MapFrom(act => ""))
                .ForMember(sel => sel.SubTasks,fin => fin.MapFrom(act=> new List<SubTaskDTO>()))
                .ForMember(sel => sel.Assignee,fin => fin.MapFrom(act => new List<string>()));

            CreateMap<GetTaskDTO, Tasks>().ReverseMap()
                .ForMember(sel => sel.Assignee, fin => fin.MapFrom(act => new List<string>()))
                .ForMember(sel => sel.Status, fin => fin.MapFrom(act => ""))
                .ForMember(sel => sel.Priority, fin => fin.MapFrom(act => ""));

            //CreateMap<Tasks, UpdateTaskDTO>().ReverseMap().ForMember(sel => sel.TaskMapAssignee, fin => fin.MapFrom(act => new List<TaskMapAssignee>()))
            //    .ForMember(sel => sel.StartDate, fin => fin.MapFrom(act => new DateTime()))
            //    .ForMember(sel => sel.DueDate, fin => fin.MapFrom(act => new DateTime()));
        }
    }
}
