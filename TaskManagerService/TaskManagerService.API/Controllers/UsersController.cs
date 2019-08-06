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
    public class UsersController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertUserDetails([FromBody]UsersModel record)
        {
            try
            {
                using (var users = new UserOperations())
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
                using (var user = new UserOperations())
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
    }
}
