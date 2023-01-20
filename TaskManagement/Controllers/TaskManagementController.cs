using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Contracts;
using TaskManagement.Dtos;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly ITaskManagementService _taskManagementService;

        public TaskManagementController(ITaskManagementService taskManagementService)
        {
            _taskManagementService = taskManagementService;
        }

        ///<summary>
        /// Verifies user login details and returns JWT token 
        ///</summary>
        ///<param name="loginDTO"></param>
        ///<returns>LogInResponseDTO</returns>
        [HttpPost]
        [Route("api/auth/signin")]
        public IActionResult VerifyUser([FromBody] LoginDTO loginDTO)
        {
            ErrorDTO isUserExist = _taskManagementService.IsUserExist(loginDTO.UserName);
            if(isUserExist != null)
            {
                return StatusCode(404, isUserExist);
            }
            LogInResponseDTO isUserValid = _taskManagementService.VerifyUser(loginDTO);
            if(isUserValid == null)
            {
                return StatusCode(401,isUserValid);
            }
            return Ok(isUserValid);
        }

        ///<summary>
        /// Gets all the meta-data linked to the key 
        ///</summary>
        ///<param name="key"></param>
        ///<returns>List<MetaDataResponse> </returns>
        [HttpPost]
        [Route("api/meta-data/ref-set/{key}")]
        public IActionResult GetMetaDataList(string key)
        {
           // _logger.LogInformation("geting refset data started");
            List<MetaDataResponse> response = _taskManagementService.GetRefSetData(key);
            if (response == null)
            {
                return NotFound(new ErrorDTO
                {
                    type = "key",
                    description = key + " key not exists in database"
                });
            }
            if (response.Count == 0)
            {
                return NoContent();
            }
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
            if (!ModelState.IsValid)
            {
               // _logger.LogError("Entered wrong login data");
                ErrorDTO badRequest = _taskManagementService.ModelStateInvalid(ModelState);
                return BadRequest(badRequest);
            }
            Guid? id = _taskManagementService.CreateTask(task); 
            if(id == null)
            {
                return StatusCode(409, new ErrorDTO() { type = "Task", description = "Task with the name already exist" });
            }
            return Ok(id);
        }

        ///<summary>
        /// Gets list of Task details
        ///</summary>
        ///<returns>List<GetTaskDTO></returns>
        [HttpGet]
        [Route("api/Task")]
        public IActionResult GetTaskDetails([FromQuery(Name = Constants.userId)] Guid userId,[FromQuery] int size =Constants.pageSize, [FromQuery(Name = Constants.pageno)] int pageNo = Constants.pageNo, 
            [FromQuery(Name = Constants.sortby)] string sortBy = Constants.firstName, [FromQuery(Name = Constants.sortorder)] string sortOrder = Constants.ASC )
        {
            ErrorDTO isUserIdExist = _taskManagementService.IsUserIdExist(userId);
            if(isUserIdExist != null)
            {
                return StatusCode(404, isUserIdExist);
            }
            List<GetTaskDTO> task = _taskManagementService.GetTaskList(userId, size, pageNo, sortBy, sortOrder);
            if(task == null)
            {
                return StatusCode(201,"No Content");
            }
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
            GetSingleTaskDTO response = _taskManagementService.GetSingleTask(id);
            if(response == null)
            {
                return StatusCode(404, new ErrorDTO() {type="Task",description="Task id not found" });
            }
            return Ok(response);
        }

        ///<summary>
        /// Updates Task details
        ///</summary>
        [HttpPut]
        [Route("api/task/{id}")]
        public IActionResult UpdateTask([FromBody] Guid id,[FromBody] UpdateTaskDTO task)
        {
            ErrorDTO isTaskExist = _taskManagementService.IsTaskExist(id,task);
            if(isTaskExist != null)
            {
                return StatusCode(404,isTaskExist);
            }
            ErrorDTO response = _taskManagementService.UpdateTask(id,task);
            if(response != null)
            {
                return StatusCode(409,response);
            }
            return Ok("Task has been updated successfully");
        }

        ///<summary>
        /// Deletes Task 
        ///</summary>
        [HttpDelete]
        [Route("api/task/{id}")]
        public IActionResult DeleteTask([FromRoute] Guid id)
        {
            ErrorDTO response = _taskManagementService.DeleteTask(id);
            if(response != null)
            {
                return StatusCode(404,response);
            }
            return Ok("Task has been deleted successfully");
        }

        ///<summary>
        /// Updates Task Status
        ///</summary>
        [HttpPut] 
        [Route("api/task/{id}/status")]
        public IActionResult UpdateStatus([FromRoute]Guid id ,[FromBody]Guid statusId)
        {
            ErrorDTO response = _taskManagementService.IsUpdateTaskStatusExist(id, statusId);
            if(response != null)
            {
                return StatusCode(404,response);
            }
            _taskManagementService.UpdateStatus(id,statusId);
            return Ok("Task status updated successfully");
        }

        ///<summary>
        /// Updates Task remainder
        ///</summary>
        [HttpPut]
        [Route("api/task/{id}/reminder")]
        public IActionResult UpdateRemainder([FromRoute]Guid id,[FromBody]Guid remainderId )
        {
            ErrorDTO response = _taskManagementService.IsUpdateRemainder(id,remainderId);
            if(response != null)
            {
                return StatusCode(404,response);
            }
            _taskManagementService.UpdateRemainder(id,remainderId);
            return Ok("Task remainder added successfully");
        }

        ///<summary>
        /// Gets list of all Assignee
        ///</summary>
        [HttpGet]
        [Route("api/assignee")]
        public IActionResult GetAssigneeList()
        {
            List<Assignee> assignees = _taskManagementService.GetAssigneeList();
            if (assignees == null)
            {
                return StatusCode(201, "No Content");
            }
            return Ok(assignees);
        }

    }
}
