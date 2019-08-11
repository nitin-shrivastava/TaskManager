using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerService.BusinessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.API.Controllers
{
    public class TaskOperationController : ApiController, IDisposable
    {

        // GET api/values
        public HttpResponseMessage GetTaskDetails()
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    var abc = task.GetTaskDetails();
                    return Request.CreateResponse(HttpStatusCode.OK, abc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/values/5
        //[Route("GetTaskDetailsById/{id}")]

        public UserTaskModel GetTaskDetailsById(int id)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    return task.GetTaskDetailsById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        public void Post([FromBody]UserTaskModel record)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                   
                    var opSuccess = task.InsertTask(record);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpGet]
        [Route("api/taskoperation/delete/{id}")]
        
        public HttpResponseMessage Delete(int id)
        {
            var task = new TaskManagerOperations();
            var result = task.DeleteTask(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        } 
        
        // End task api/values/5
        [HttpGet]
        [Route("api/taskoperation/endtask/{id}")]
        
        public HttpResponseMessage EndTask(int id)
        {
            var task = new TaskManagerOperations();
            var result = task.EndTask(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
