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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]UserTask record)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    var entity = new UserTask();
                    entity.TaskDetail = record.TaskDetail;
                    entity.StartDate = record.StartDate;
                    entity.EndDate = record.EndDate;
                    entity.Priority = record.Priority;
                    entity.Status = record.Status;
                    entity.ParentTask_ID = record.ParentTask_ID;
                    var opSuccess = task.InsertTask(entity);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally {

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
