using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using TaskManagement;
using TaskManagement.Controllers;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
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
        private readonly ILogger _logger;
        private readonly ApiBehaviorOptions _option;
        public UnitTest1() 
        {

            ServiceCollection services = new ServiceCollection();
            services.AddOptions();
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.SuppressModelStateInvalidFilter = true;
            });
            ServiceProvider serviceProvider = services.BuildServiceProvider();

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
            Claim claim1 = new Claim("userId", "9dc4391c-6967-43c0-93dd-cfb0ac6efb46", "", "LOCAL AUTHORITY");

            ClaimsIdentity identity = new ClaimsIdentity(new[] { claim1 }, "BasicAuthentication");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            GenericIdentity identityy = new GenericIdentity("some name", "test");
            ClaimsPrincipal contextUser = new ClaimsPrincipal(identity);
            DefaultHttpContext httpContext = new DefaultHttpContext()
            {
                User = contextUser
            };

            HttpContextAccessor _httpContextAccessor = new HttpContextAccessor()
            {
                HttpContext = httpContext
            };
            DbContextOptions<TaskManagementContext> options = new DbContextOptionsBuilder<TaskManagementContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new TaskManagementContext(options);
            AddData();
            _context.Database.EnsureCreated();
            _repository = new TaskManagementRepository(_context);
            _taskManagementServices = new TaskManagementService(_repository, _httpContextAccessor);
            _taskManagementController = new TaskManagementController(_taskManagementServices,_logger);
         
        }
        public void AddData()
        {

            string refTermPath = @"..\..\..\..\TaskManagement\Entities\Migrations\Files\RefTermData.csv";
            string refTermCSV = File.ReadAllText(refTermPath);
            string[] RefTermdata = refTermCSV.Split('\r');
            List<RefTerm> list = new List<RefTerm>();
            foreach (string item in RefTermdata)
            {
                string[] row = item.Split(",");
                RefTerm refObj = new RefTerm { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString(), IsActive = true };
                list.Add(refObj);
            }
            _context.RefTerm.AddRange(list);

            string refSetTermPath = @"..\..\..\..\TaskManagement\Entities\Migrations\Files\RefSetTerm.csv";
            string refSetTermCSV = File.ReadAllText(refSetTermPath);
            string[] RefSetTermdata = refSetTermCSV.Split('\r');
            List<SetRefTerm> SetRefTermlist = new List<SetRefTerm>();
            foreach (string item in RefSetTermdata)
            {
                string[] row = item.Split(",");
                SetRefTerm refObj = new SetRefTerm() { Id = Guid.NewGuid(), RefSetId = Guid.Parse(row[0]), RefTermId = Guid.Parse(row[1]), IsActive = true };
                SetRefTermlist.Add(refObj);
            }
            _context.AddRange(SetRefTermlist);



            string refSetPath = @"..\..\..\..\TaskManagement\Entities\Migrations\Files\RefSetData.csv";
            string refSetCSV = File.ReadAllText(refSetPath);
            string[] refSetdata = refSetCSV.Split('\r');
            List<RefSet> refSetList = new List<RefSet>();
            foreach (string item in refSetdata)
            {
                string[] row = item.Split(",");
                RefSet refObj = new RefSet { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString(), IsActive = true };
                refSetList.Add(refObj);
            }
            _context.RefSet.AddRange(refSetList);
            string path = @"..\..\..\..\TaskManagement\Entities\Migrations\Files\LoginData.csv";
            string loginCSV = File.ReadAllText(path);
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
                    Id = Guid.Parse(row[2]),
                    Email = row[0],
                    Password = EncryptPassword,
                    Name = row[0],
                    Phone = row[3],
                    IsActive = true
                };
                LoginList.Add(user);
            }
            _context.User.AddRange(LoginList);

            string taskDatePath = @"..\..\..\..\TaskManagement\Entities\Migrations\Files\TaskData.csv";
            string taskCSV = File.ReadAllText(taskDatePath);
            string[] taskData = taskCSV.Split('\r');
            int c = 0;
            foreach (string item in taskData)
            {

                string[] row = item.Split(",");
                List<TaskAssigneeMapping> listAssignee = new List<TaskAssigneeMapping>();
                TaskAssigneeMapping assignee = new TaskAssigneeMapping()
                {
                    Id = Guid.Parse(row[9]),
                    AssigneeId = Guid.Parse(row[10]),
                    TaskId = Guid.Parse(row[0]),
                    IsActive = true
                };
                listAssignee.Add(assignee);
                Tasks tasks = new Tasks()
                {
                    Id = Guid.Parse(row[0]),
                    Name = row[1],
                    Description = row[2],
                    StartDate = DateTime.Parse(row[3]),
                    DueDate = DateTime.Parse(row[4]),
                    Status = Guid.Parse(row[5]),
                    Assigner = Guid.Parse(row[10]),
                    Priority = Guid.Parse(row[8]),
                    TaskMapAssignee = listAssignee,
                    ReminderPeriodId = row[11] != "" ? Guid.Parse(row[11]) : Guid.Empty,
                    IsActive = true
                };
                if (row[11] != "")
                {
                    DateTime datetime = DateTime.Now;
                    tasks.DueDate = datetime.AddDays(1);

                    tasks.StartDate = datetime.AddDays(-1);
                }
                if (c == 0)
                {
                    tasks.ParentTaskId = Guid.Parse("931714f8-da93-42ec-85fe-bf5175bd30f5");
                }
                c = c + 1;
                _context.Tasks.Add(tasks);
            }
            _context.SaveChanges();
        }
        public ILogger<TaskManagementController> GetLogger()
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
            return host.Services.GetRequiredService<ILogger<TaskManagementController>>();
        }

        [Fact]
        public void Test_VerifyUser()
        {
            ILogger<TaskManagementController> _logger = GetLogger();
            TaskManagementController controller = new TaskManagementController(_taskManagementServices ,_logger);
            controller.ModelState.AddModelError("error", "some error");
            LoginDTO login = new LoginDTO()
            {
                Password = "passworD@123",
                Email = "psurya@gmail.com"
            };
            LoginDTO inValidlogin = new LoginDTO()
            {
                Email = "surya1@gamil.com",
                Password = "password@123",

            };
            LoginDTO login1 = new LoginDTO()
            {
                Password = "passworD@123",
               
            };
            
            IActionResult response = _taskManagementController.VerifyUser(login);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);

            IActionResult response2 = controller.VerifyUser(login1);
            BadRequestObjectResult result2 = Assert.IsType<BadRequestObjectResult>(response2);


            IActionResult response1 = _taskManagementController.VerifyUser(inValidlogin);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);

            Assert.Equal(401, result1.StatusCode);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(400, result2.StatusCode);

        }

        [Fact]
        public void Test_CreateTask()
        {
            ILogger<TaskManagementController> _logger = GetLogger();
            TaskManagementController controller = new TaskManagementController(_taskManagementServices, _logger);
            controller.ModelState.AddModelError("error", "some error");

            List<Guid> guids = new List<Guid>();
            guids.Add(Guid.Parse("9dc4391c-6967-43c0-93dd-cfb0ac6efb46"));
            CreateTaskDTO createTaskDTO = new CreateTaskDTO()
            {
                Name = "test",
                Description = "test",
                DueDate =DateTime.Parse( "09/02/2023 03:00:00"),
                StartDate =DateTime.Parse( "08/02/2023 03:00:00"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),

                Assignee = guids,
            };
            CreateTaskDTO createTaskDTO1 = new CreateTaskDTO()
            {
                Name = "name",
                Description = "test",
                DueDate =DateTime.Parse( "09/02/2023 03:00:00"),
                StartDate =DateTime.Parse( "08/02/2023 03:00:00"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),

                Assignee = guids,
            };
            CreateTaskDTO createTaskDTO2 = new CreateTaskDTO()
            {
                Description = "test",
                DueDate = DateTime.Parse("09/02/2023 03:00:00"),
                StartDate = DateTime.Parse("08/02/2023 03:00:00"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),

                Assignee = guids,
            };
            IActionResult response = _taskManagementController.CreateTask(createTaskDTO);
            IActionResult response1 = _taskManagementController.CreateTask(createTaskDTO);
            IActionResult response2 = controller.CreateTask(createTaskDTO2);

            ObjectResult result = Assert.IsType<ObjectResult>(response);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);
            BadRequestObjectResult result2 = Assert.IsType<BadRequestObjectResult>(response2);

            Assert.Equal(201, result.StatusCode);
            Assert.Equal(409, result1.StatusCode);
            Assert.Equal(400, result2.StatusCode);
        }

        [Fact]
        public void Test_GetMetaDataList()
        {
            string key = "STATUS";
            string key1 = "STATU";
            IActionResult response = _taskManagementController.GetMetaDataList(key);
            IActionResult response1 = _taskManagementController.GetMetaDataList(key1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            NotFoundObjectResult result1 = Assert.IsType<NotFoundObjectResult>(response1);

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(404, result1.StatusCode);
        }

        [Fact]
        public void Test_GetTaskDetails()
        {
            IActionResult response = _taskManagementController.GetTaskDetails(Guid.Parse("9dc4391c-6967-43c0-93dd-cfb0ac6efb46"), "Name", "ASC", 5, 1);
            IActionResult response1 = _taskManagementController.GetTaskDetails(Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1"), "Name", "DSC", 5, 1);
            IActionResult response2 = _taskManagementController.GetTaskDetails(Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c2"), "Name", "DSC", 5, 1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);
            ObjectResult result2 = Assert.IsType<ObjectResult>(response2);

            Assert.Equal(404, result2.StatusCode);
            Assert.Equal(204, result1.StatusCode);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_GetSingleTask()
        {
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            Guid id2 = Guid.Parse("931714f8-da93-42ec-85fe-bf5175bd30f9");
            IActionResult response = _taskManagementController.GetSingleTask(id);
            IActionResult response2 = _taskManagementController.GetSingleTask(id2);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            ObjectResult result2 = Assert.IsType<ObjectResult>(response2);

            Assert.Equal(404, result2.StatusCode);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_UpdateTask()
        {
            List<Guid> guids = new List<Guid>();
            guids.Add(Guid.Parse("9dc4391c-6967-43c0-93dd-cfb0ac6efb46"));
            UpdateTaskDTO updateTaskDTO = new UpdateTaskDTO()
            {
                Name = "Suryaraju",
                Description = "test up",
                DueDate = DateTime.Parse("04/03/2023 15:32:00"),
                StartDate =DateTime.Parse( "03/02/2023 06:32:00"),
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),
                Assignee = guids,
            };
            UpdateTaskDTO updateTaskDTO1 = new UpdateTaskDTO()
            {
                Name = "Suryaraju",
                Description = "test up",
                DueDate = DateTime.Parse("03/03/2023 15:32:00"),
                StartDate =DateTime.Parse( "05/02/2009 06:32:00"),
                Priority = Guid.Parse("246B7C06-F7B8-49E6-873C-FCC337C2056A"),
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844"),

                Assignee = guids,
            };
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            Guid id1 = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2f2");

            IActionResult response = _taskManagementController.UpdateTask(id, updateTaskDTO);
            IActionResult response1 = _taskManagementController.UpdateTask(id, updateTaskDTO1);
            IActionResult response2 = _taskManagementController.UpdateTask(id1, updateTaskDTO);

            ObjectResult result2 = Assert.IsType<ObjectResult>(response2);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            BadRequestObjectResult result1 = Assert.IsType<BadRequestObjectResult>(response1);

            Assert.Equal(404, result2.StatusCode);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(400, result1.StatusCode);
        }
        [Fact]
        public void Test_DeleteTask()
        {
            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            Guid id1 = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c2");


            IActionResult response = _taskManagementController.DeleteTask(id);
            IActionResult response1 = _taskManagementController.DeleteTask(id1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);
  

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(404, result1.StatusCode);

        }
        [Fact]
        public void Test_UpdateStatus()
        {
            StatusDTO statusDTO = new StatusDTO()
            {
                Status = Guid.Parse("5443D3E4-1CC2-49F9-AF36-EC46C00C8844")
            };

            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            Guid id1 = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c2");
            
            IActionResult response = _taskManagementController.UpdateStatus(id, statusDTO);
            IActionResult response1 = _taskManagementController.UpdateStatus(id1, statusDTO);


            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);


            Assert.Equal(200, result.StatusCode);
            Assert.Equal(404, result1.StatusCode);

        }
        [Fact]
        public void Test_GetAssigneeList()
        {
            IActionResult response = _taskManagementController.GetAssigneeList();

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_SignUp()
        {
            ILogger<TaskManagementController> _logger = GetLogger();
            TaskManagementController controller = new TaskManagementController(_taskManagementServices, _logger);
            controller.ModelState.AddModelError("error", "some error");
            SignUpDTO signUpDTO = new SignUpDTO()
            {
                Name = "Test Signup",
                Password = "Psr@964",
                Email = "Test User",
                Phone = "8142255760"
            };
            SignUpDTO signUpDTO1 = new SignUpDTO()
            {
                Name = "Test Signup",
                Password = "Psr@964",
                Email = "Test User",
                Phone = "8142255769"
            };
            SignUpDTO signUpDTO2 = new SignUpDTO()
            {
               
                Password = "Psr@964",

                Phone = "8142255769"
            };
            IActionResult response = _taskManagementController.SignUp(signUpDTO);
            IActionResult response1 = _taskManagementController.SignUp(signUpDTO1);
            IActionResult response2 = controller.SignUp(signUpDTO2);

            ObjectResult result = Assert.IsType<ObjectResult>(response);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);
            BadRequestObjectResult result2 = Assert.IsType<BadRequestObjectResult>(response2);

            Assert.Equal(201, result.StatusCode);
            Assert.Equal(409, result1.StatusCode);
            Assert.Equal(400, result2.StatusCode);
        }
        [Fact]
        public void Test_GetRemainders()
        {
            IActionResult response = _taskManagementController.GetReminder();
            ObjectResult result = Assert.IsType<ObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void Test_UpdateRemainder()
        {

            ReminderDTO reminderDTO = new ReminderDTO()
            {
                ReminderPeriodId = Guid.Parse("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2")
            };
            ReminderDTO reminderDTO1 = new ReminderDTO()
            {
                ReminderPeriodId = Guid.Parse("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2")
            };

            Guid id = Guid.Parse("0518ba7b-ec3b-4636-a347-0fe07e03e2c1");
            Guid id1 = Guid.Parse("931714f8-da93-42ec-85fe-bf5175bd30f5");
            IActionResult response = _taskManagementController.UpdateReminder(id1, reminderDTO);
            IActionResult response1 = _taskManagementController.UpdateReminder(id, reminderDTO1);

            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            ObjectResult result1 = Assert.IsType<ObjectResult>(response1);

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(400, result1.StatusCode);
        }
    }
}
