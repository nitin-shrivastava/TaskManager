using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.Entities;

namespace TaskManagerService.DataAccessLayer
{
    public class ProjectRepository
    {
        TaskDataContext context;
        public ProjectRepository()
        {
            context = new TaskDataContext();
        }

        public List<ProjectModel> GetProjectDetails()
        {
            try
            {
                List<ProjectModel> projectList = new List<ProjectModel>();
                var projList = context.Projects.ToList();
                foreach (var project in projList)
                {
                    var proj = new ProjectModel();
                    proj.Project = project.Project;
                    proj.Priority = project.Priority;
                    proj.StartDate = project.StartDate;
                    proj.EndDate = project.EndDate;
                    //TODO This needs to be fetched
                    proj.Manager = project.Manager;
                    projectList.Add(proj);
                }
                return projectList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool AddProjectDetails(ProjectModel projectModel)
        {
            try
            {
                Projects project = new Projects();
                project.Project = projectModel.Project;
                project.Priority = projectModel.Priority;
                project.StartDate = projectModel.StartDate;
                project.Manager = projectModel.Manager;
                project.EndDate = projectModel.EndDate;
                context.Projects.Add(project);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
