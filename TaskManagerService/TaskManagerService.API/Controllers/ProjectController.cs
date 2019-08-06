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
    public class ProjectController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertProjectDetails([FromBody]ProjectModel record)
        {
            try
            {
                using (var project = new ProjectOperations())
                {
                    var abc = project.InsertProjectDetails(record);
                    return Request.CreateResponse(HttpStatusCode.OK, abc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public HttpResponseMessage GetProjectDetails()
        {
            try
            {
                using (var project = new ProjectOperations())
                {
                    var abc = project.GetProjectDetails();
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
