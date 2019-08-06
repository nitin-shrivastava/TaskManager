using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.DataAccessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.BusinessLayer
{
    public class ProjectOperations : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProjectModel> GetProjectDetails()
        {
            try
            {
                List<ProjectModel> projectList = null;
                var repository = new ProjectRepository();
                projectList = repository.GetProjectDetails();
                return projectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool InsertProjectDetails(ProjectModel projectModel)
        {
            try
            {
                List<ProjectModel> projectList = null;
                var repository = new ProjectRepository();
                return repository.AddProjectDetails(projectModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
