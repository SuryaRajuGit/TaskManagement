using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManagement.Contracts;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Models;

namespace TaskManagement.Controllers
{
   
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class TaskManagementController : ControllerBase
    {
        private readonly ITaskManagementService _taskManagementService;
        private readonly ILogger _logger;

        public TaskManagementController(ITaskManagementService taskManagementService, ILogger logger)
        {
            _taskManagementService = taskManagementService;
            _logger = logger;
        }

        ///<summary>
        /// Verifies user login details and returns JWT token 
        ///</summary>
        ///<param name="loginDTO"></param>
        ///<returns>LogInResponseDTO</returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/signin")]
        public IActionResult VerifyUser([FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation("Verifying user started");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Entered wrong log in data");
                ErrorDTO badRequest = _taskManagementService.ModelStateInvalid(ModelState);
                return BadRequest(badRequest);
            }
            LogInResponseDTO isUserValid = _taskManagementService.VerifyUser(loginDTO);
            if(isUserValid == null)
            {
                _logger.LogError("Invalid login details");
                return StatusCode(401,new ErrorDTO() {type="User",description="Invalid log in details" });
            }
            _logger.LogInformation("User verified successfully");
            return Ok(isUserValid);
        }

        ///<summary>
        /// Gets all the meta-data linked to the key 
        ///</summary>
        ///<param name="key"></param>
        ///<returns>List<MetaDataResponse> </returns>
        [HttpGet]
        [Route("api/meta-data/ref-set/{key}")]
        public IActionResult GetMetaDataList([FromRoute]string key)
        {
            _logger.LogInformation("Getting refset data started");
            List<MetaDataResponse> response = _taskManagementService.GetRefSetData(key);
            if (response == null)
            {
                _logger.LogError("key not found");
                return NotFound(new ErrorDTO{type = "key",description = key + " key not exists in database"});
            }
            if (response.Count == 0)
            {
                _logger.LogError("No content");
                return NoContent();
            }
            _logger.LogInformation("Fetched list of meta-data successfully");
            return Ok(response);
        }

        ///<summary>
        /// Creates new Task 
        ///</summary>
        ///<param name="task"></param>
        ///<returns>Guid</returns>
        [HttpPost]
        [Route("api/Task")]
        public IActionResult CreateTask([FromBody] CreateTaskDTO task )
        {
            ErrorDTO response = _taskManagementService.IsDateInvalid(task.DueDate,task.StartDate);
            if (response != null)
            {
                return BadRequest(response);
            }
            if (!ModelState.IsValid )
            {
                _logger.LogError("Entered wrong Task data");
                ErrorDTO badRequest = _taskManagementService.ModelStateInvalid(ModelState);
                return BadRequest(badRequest);
            }
            ErrorDTO isMetdaDataValid = _taskManagementService.CheckMetadata(task);
            if(isMetdaDataValid != null)
            {
                return NotFound(isMetdaDataValid);
            }
            ErrorDTO isParentTaskDateVaid = _taskManagementService.CheckParentTaskDateDetails(task);
            if (isParentTaskDateVaid != null)
            {
                return BadRequest(isParentTaskDateVaid);
            }
            Guid? id = _taskManagementService.CreateTask(task); 
            if(id == null)
            {
                _logger.LogError("Task name already exits");
                return StatusCode(409, new ErrorDTO() { type = "Task", description = "Task with the name already exist" });
            }
            _logger.LogInformation("Created Task successfully");
            return StatusCode(201,id);
        }

        ///<summary>
        /// Gets list of Task details
        ///</summary>
        ///<returns>List<GetTaskDTO></returns>
        [HttpGet]
        [Route("api/Task")]
        public IActionResult GetTaskDetails([FromQuery(Name = Constants.userId)] Guid userId, [FromQuery(Name = Constants.sortby)] string sortBy, [FromQuery(Name = Constants.sortorder)] string sortOrder =Constants.ASC,
             [FromQuery] int size = Constants.pageSize, [FromQuery(Name = Constants.pageno)] int pageNo = Constants.pageNo )
        {
            _logger.LogInformation("Getting list of task started");
            ErrorDTO isUserIdExist = _taskManagementService.IsUserIdExist(userId);
            if(isUserIdExist != null)
            {
                _logger.LogError("User id not found");
                return StatusCode(404, isUserIdExist);
            }
            List<GetTaskDTO> task = _taskManagementService.GetTaskList(userId, size, pageNo, sortOrder, sortBy  );
            if(task == null)
            {
                _logger.LogError("No Conent");
                return StatusCode(204,"No Content");
            }
            _logger.LogInformation("List of task details fetched successfully");
            return Ok(task);
        }

        ///<summary>
        /// Creates new Task 
        ///</summary>
        ///<param name="id"></param>
        ///<returns>GetSingleTaskDTO</returns>
        [HttpGet]
        [Route("api/task/{id}")]
        public IActionResult GetSingleTask([FromRoute] Guid id)
        {
            _logger.LogInformation("Getting single task started");
            GetSingleTaskDTO response = _taskManagementService.GetSingleTask(id);
            if(response == null)
            {
                _logger.LogError("Task id not found");
                return StatusCode(404, new ErrorDTO() {type="Task",description="Task id not found" });
            }
            _logger.LogInformation("Fetched single task successfully");
            return Ok(response);
        }

        ///<summary>
        /// Updates Task details
        /// <param name="id"></param>
        /// <param name="task"></param>
        ///</summary>
        [HttpPut]
        [Route("api/task/{id}")]
        public IActionResult UpdateTask([FromRoute] Guid id,[FromBody] UpdateTaskDTO task)
        {
            _logger.LogInformation("Updated Task started");
            ErrorDTO isDateValid = _taskManagementService.IsDateInvalid(task.DueDate, task.StartDate);
            if (isDateValid != null)
            {
                return BadRequest(isDateValid);
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Entered wrong Task data");
                ErrorDTO badRequest = _taskManagementService.ModelStateInvalid(ModelState);
                return BadRequest(badRequest);
            }
            ErrorDTO isTaskExist = _taskManagementService.IsTaskExist(id,task);
            if(isTaskExist != null)
            {
                _logger.LogError("Task id not found");
                return StatusCode(404,isTaskExist);
            }
            ErrorDTO checkParentTask = _taskManagementService.CheckParentTaskDate(task,id);
            if(checkParentTask != null)
            {
                return StatusCode(400,checkParentTask);
            }
            ErrorDTO response = _taskManagementService.UpdateTask(id,task);
            if(response != null)
            {
                _logger.LogError("Task name already exist");
                return StatusCode(409,response);
            }
            _logger.LogInformation("Task has been updated successfully");
            return Ok("Task has been updated successfully");
        }

        ///<summary>
        /// Deletes Task 
        ///<param name="id"></param>
        ///</summary>
        [HttpDelete]
        [Route("api/task/{id}")]
        public IActionResult DeleteTask([FromRoute] Guid id)
        {
            _logger.LogInformation("Delete Task started");
            ErrorDTO response = _taskManagementService.DeleteTask(id);
            if(response != null)
            {
                _logger.LogError("Task id not found");
                return StatusCode(404,response);
            }
            _logger.LogInformation("Task has been deleted successfully");
            return Ok("Task has been deleted successfully");
        }

        ///<summary>
        /// Updates Task Status
        /// <param name="statusDTO"></param>
        ///</summary>
        [HttpPut] 
        [Route("api/task/{id}/status")]
        public IActionResult UpdateStatus([FromRoute]Guid id ,[FromBody]StatusDTO statusDTO)
        {
            _logger.LogInformation("Update Task status started");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Entered wrong status data");
                ErrorDTO badRequest = _taskManagementService.ModelStateInvalid(ModelState);
                return BadRequest(badRequest);
            }
            ErrorDTO response = _taskManagementService.IsUpdateTaskStatusExist(id, statusDTO.Status);
            if(response != null)
            {
                _logger.LogError("Task id not found");
                return StatusCode(404,response);
            }
            _taskManagementService.UpdateStatus(id,statusDTO.Status);
            _logger.LogInformation("Task status updated successfully");
            return Ok("Task status updated successfully");
        }

        ///<summary>
        /// Updates Task remainder
        /// <param name="id"></param>
        /// <param name="remainderDTO"></param>
        ///</summary>
        [HttpPut]
        [Route("api/task/{id}/remainder")]
        public IActionResult UpdateRemainder([FromRoute]Guid id,[FromBody] RemainderDTO remainderDTO )
        {
            _logger.LogInformation("Update task remainder started");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Entered wrong remainder data");
                ErrorDTO badRequest = _taskManagementService.ModelStateInvalid(ModelState);
                return BadRequest(badRequest);
            }
            ErrorDTO response = _taskManagementService.IsUpdateRemainder(id, remainderDTO.RemainderPeriodId);
            if(response != null)
            {
                _logger.LogError("Task id not found");
                return StatusCode(404,response);
            }
            _taskManagementService.UpdateRemainder(id, remainderDTO.RemainderPeriodId);
            _logger.LogInformation("Task remainder added successfully");
            return Ok("Task remainder added successfully");
        }

        ///<summary>
        /// Gets list of all Assignee
        ///</summary>
        [HttpGet]
        [Route("api/assignee")]
        public IActionResult GetAssigneeList()
        {
            _logger.LogInformation("Getting list of assignee started");
            List<Assignee> assignees = _taskManagementService.GetAssigneeList();
            if (assignees == null)
            {
                _logger.LogError("No Content");
                return StatusCode(201, "No Content");
            }
            _logger.LogInformation("Fetched list of assignee successfully");
            return Ok(assignees);
        }

    }
}
