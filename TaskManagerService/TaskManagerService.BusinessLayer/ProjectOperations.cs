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
        TaskDataContext _context;
        public ProjectOperations(TaskDataContext taskDataContext)
        {
            this._context = taskDataContext;
        }
        public List<ProjectModel> GetProjectDetails()
        {
            try
            {
                List<ProjectModel> projectList = null;
                var repository = new ProjectRepository(_context);
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
                var repository = new ProjectRepository(_context);
                return repository.AddProjectDetails(projectModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
