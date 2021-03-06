﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.Entities;

namespace TaskManagerService.DataAccessLayer
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext() : base("name=TaskDBConnectionString")
        {

            Database.SetInitializer<TaskDataContext>(new TaskInitializer());
        }

        public DbSet<Projects> Projects { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Users> Users { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>().HasKey<int>(x => x.Task_ID);
           
            modelBuilder.Entity<Users>().HasKey<int>(x => x.User_Id)
                .HasOptional(x => x.Task)
                .WithMany()
                .HasForeignKey(m=>m.Task_Id);

            modelBuilder.Entity<Users>()
                .HasOptional(x => x.Projects)
                .WithMany()
                .HasForeignKey(m=>m.Project_Id);

            modelBuilder.Entity<Projects>().HasKey<int>(x => x.Project_Id);
      
            modelBuilder.Entity<UserTask>()
                .HasOptional(m => m.Parent)
                .WithMany()
                .HasForeignKey(m => m.ParentTask_ID);

            modelBuilder.Entity<UserTask>()
                .HasOptional(m => m.Project)
                .WithMany()
                .HasForeignKey(m => m.Project_ID);


        }
    }
    public class TaskInitializer : DropCreateDatabaseIfModelChanges<TaskDataContext>
    {
        #region Methods

        protected override void Seed(TaskDataContext context)
        {

            var task1 = new UserTask
            {
                TaskDetail = "This is task1",
                Status = "Open",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 1
            };
            var task2 = new UserTask
            {
                TaskDetail = "This is task 2",
                Status = "Open",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 10
            };

            context.UserTasks.Add(task1);
            context.UserTasks.Add(task2);
            context.SaveChanges();
        }

        #endregion
    }
}
