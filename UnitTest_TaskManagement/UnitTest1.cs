using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TaskManagement.Controllers;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Models;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Repository;
using TaskManagement.Service;
using Xunit;

namespace UnitTest_TaskManagement
{
    public class UnitTest1
    {
        private readonly IMapper _mapper;
        private readonly TaskManagementController _taskManagementController;
        private readonly TaskManagementRepository _repository;
        private readonly TaskManagementService _taskManagementServices;
        byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private readonly TaskManagementContext _context;
        public UnitTest1()
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder().
            ConfigureLogging((builderContext, loggingBuilder) =>
            {
                loggingBuilder.AddConsole((options) =>
                {
                    options.IncludeScopes = true;
                });
            });
            IHost host = hostBuilder.Build();
            ILogger<TaskManagementController> _logger = host.Services.GetRequiredService<ILogger<TaskManagementController>>();

            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mappers());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            DbContextOptions<TaskManagementContext> options = new DbContextOptionsBuilder<TaskManagementContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new TaskManagementContext(options);
            AddData();
            _context.Database.EnsureCreated();
            _repository = new TaskManagementRepository(_context);
            _taskManagementServices = new TaskManagementService(_repository, _mapper);
            _taskManagementController = new TaskManagementController(_taskManagementServices, _logger);
        }
        public void AddData()
        {
            string refTermPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\RefTermData.csv";
            string refTermCSV = File.ReadAllText(refTermPath);
            string[] RefTermdata = refTermCSV.Split('\r');
            List<RefTerm> list = new List<RefTerm>();
            foreach (string item in RefTermdata)
            {
                string[] row = item.Split(",");
                RefTerm refObj = new RefTerm { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString() };
                list.Add(refObj);
            }

            _context.RefTerm.AddRange(list);

            string refSetTermPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\RefSetTerm.csv";
            string refSetTermCSV = File.ReadAllText(refSetTermPath);
            string[] RefSetTermdata = refSetTermCSV.Split('\r');
            List<RefSetTerm> SetRefTermlist = new List<RefSetTerm>();
            foreach (string item in RefSetTermdata)
            {
                string[] row = item.Split(",");
                RefSetTerm refObj = new RefSetTerm() { Id = Guid.NewGuid(), RefSetId = Guid.Parse(row[0]), RefTermId = Guid.Parse(row[1]) };
                SetRefTermlist.Add(refObj);
            }
            _context.AddRange(SetRefTermlist);

            string refSetPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\RefSetData.csv";
            string refSetCSV = File.ReadAllText(refSetPath);
            string[] refSetdata = refSetCSV.Split('\r');
            List<RefSet> refSetList = new List<RefSet>();
            foreach (string item in refSetdata)
            {
                string[] row = item.Split(",");
                RefSet refObj = new RefSet { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString() };
                refSetList.Add(refObj);
            }
            _context.RefSet.AddRange(refSetList);


            string loginPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\LoginData.csv";
            string loginCSV = File.ReadAllText(loginPath);
            string[] LoginData = loginCSV.Split('\r');
            List<User> LoginList = new List<User>();
            foreach (string item in LoginData)
            {
                string[] row = item.Split(",");
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateEncryptor(this.key, this.iv);
                byte[] inputbuffer = Encoding.Unicode.GetBytes(row[1]);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                string EncryptPassword = Convert.ToBase64String(outputBuffer);
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = row[0],
                    Password = EncryptPassword
                };
                LoginList.Add(user);
            }
            _context.User.AddRange(LoginList);
            Assignee assig = new Assignee { Id = Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"), Name = "test" };
            _context.Assignee.Add(assig);

            string taskDatePath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\TaskData.csv";
            string taskCSV = File.ReadAllText(taskDatePath);
            string[] taskData = taskCSV.Split('\r');
            int c = 0;
            foreach (string item in taskData)
            {
                
                string[] row = item.Split(",");
                List<TaskMapAssignee> listAssignee = new List<TaskMapAssignee>();
                TaskMapAssignee assignee = new TaskMapAssignee()
                {
                    Id = Guid.Parse(row[9]),
                    AssigneeId = Guid.Parse(row[10]),
                    TaskId = Guid.Parse(row[0])
                };
                listAssignee.Add(assignee);
                Tasks tasks = new Tasks()
                {
                    Id =Guid.Parse(row[0]),
                    Name = row[1],
                    Description = row[2],
                    StartDate = DateTime.Parse(row[3]),
                    DueDate = DateTime.Parse(row[4]),
                    Status = Guid.Parse(row[5]),
                    Assigner=Guid.Parse(row[10]),
                    Priority=Guid.Parse(row[8]),
                    TaskMapAssignee = listAssignee,
                    ReminderPeriodId=Guid.Parse(row[11])
                };
                if(c == 0)
                {
                    tasks.ParentTaskId = Guid.Parse("931714f8-da93-42ec-85fe-bf5175bd30f5");
                }
                c = c + 1;
                _context.Tasks.Add(tasks);
            }
            _context.SaveChanges();
        }

        [Fact]
        public void Test_VerifyUser()
        {
            LoginDTO login = new LoginDTO()
            {
                Password = "passworD@123",
                UserName = "surya"
            };
            LoginDTO inValidlogin = new LoginDTO()
            {
                UserName="sury",
                Password = "password@123",
               
            };
            IActionResult response = _taskManagementController.VerifyUser(login);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);


            IActionResult response1 = _taskManagementController.VerifyUser(inValidlogin);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);

            Assert.Equal(401, result1.StatusCode);
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public void Test_CreateTask()
        {
            List<Guid> guids = new List<Guid>();
            guids.Add(Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"));
            CreateTaskDTO createTaskDTO = new CreateTaskDTO()
            {
                Name = "test",
                Description = "test",
                DueDate = "09/01/2023 03:00:00",
                StartDate = "08/01/2023 03:00:00",
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),
                Assigner = Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"),
                Assignee = guids,
            };
            IActionResult response = _taskManagementController.CreateTask(createTaskDTO);
            ObjectResult result = Assert.IsType<ObjectResult>(response);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void Test_GetMetaDataList()
        {
            string key = "STATUS";
            IActionResult response = _taskManagementController.GetMetaDataList(key);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Test_GetTaskDetails()
        {
            IActionResult response = _taskManagementController.GetTaskDetails(Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"), "Name", "ASC", 5, 1);
            IActionResult response1 = _taskManagementController.GetTaskDetails(Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"), "Name", "DSC", 5, 1);
            //IActionResult response1 = _taskManagementController.GetTaskDetails(Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"), "DueDate", "DSC", 5, 1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            OkObjectResult result1 = Assert.IsType<OkObjectResult>(response1);

            Assert.Equal(200, result1.StatusCode);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_GetSingleTask()
        {
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            Guid id1 = Guid.Parse("931714f8-da93-42ec-85fe-bf5175bd30f5");
            IActionResult response = _taskManagementController.GetSingleTask(id);
            IActionResult response1 = _taskManagementController.GetSingleTask(id1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            OkObjectResult result1 = Assert.IsType<OkObjectResult>(response1);

            Assert.Equal(200, result1.StatusCode);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_UpdateTask()
        {
            List<Guid> guids = new List<Guid>();
            guids.Add(Guid.Parse("e87f391c-e655-4d72-be4f-e14c0464f6e6"));
            UpdateTaskDTO updateTaskDTO = new UpdateTaskDTO()
            {
                Name = "Suryaraju",
                Description = "test up",
                DueDate = "04/01/2009 15:32:00",
                StartDate = "03/01/2009 06:32:00",
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                
                Assignee = guids,
            };
            UpdateTaskDTO updateTaskDTO1 = new UpdateTaskDTO()
            {
                Name = "Suryaraju",
                Description = "test up",
                DueDate = "03/01/2009 15:32:00",
                StartDate = "05/01/2009 06:32:00",
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                
                Assignee = guids,
            };
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");

            IActionResult response = _taskManagementController.UpdateTask(id, updateTaskDTO);
            IActionResult response1 = _taskManagementController.UpdateTask(id, updateTaskDTO1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            BadRequestObjectResult result1 = Assert.IsType<BadRequestObjectResult>(response1);

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(400, result1.StatusCode);
        }
        [Fact]
        public void Test_DeleteTask()
        {
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            IActionResult response = _taskManagementController.DeleteTask(id);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_UpdateStatus()
        {
            StatusDTO statusDTO = new StatusDTO()
            {
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844")
            };
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            IActionResult response = _taskManagementController.UpdateStatus(id, statusDTO);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_UpdateRemainder()
        {
            RemainderDTO remainderDTO = new RemainderDTO()
            {
                RemainderPeriodId = Guid.Parse("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980")
            };
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            IActionResult response = _taskManagementController.UpdateRemainder(id, remainderDTO);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_GetAssigneeList()
        {
            IActionResult response = _taskManagementController.GetAssigneeList();
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
