using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerService.BusinessLayer;
using TaskManagerService.DataAccessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.API.Controllers
{
    public class UsersController : ApiController
    {
        TaskDataContext _taskDataContext;
        public UsersController()
        {
            this._taskDataContext = new TaskDataContext();
        }
        [HttpPost]
        public HttpResponseMessage InsertUserDetails([FromBody]UsersModel record)
        {
            try
            {
                using (var users = new UserOperations(_taskDataContext))
                {
                    var abc = users.InsertUserDetails(record);
                    return Request.CreateResponse(HttpStatusCode.OK, abc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public HttpResponseMessage GetUserDetails()
        {
            try
            {
                using (var user = new UserOperations(_taskDataContext))
                {
                    var abc = user.GetUserDetails();
                    return Request.CreateResponse(HttpStatusCode.OK, abc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage DeleteUserDetails(int id)
        {
            try
            {
                using (var user = new UserOperations(_taskDataContext))
                {
                    var abc = user.DeleteUserDetails(id);
                    return Request.CreateResponse(HttpStatusCode.OK, abc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
