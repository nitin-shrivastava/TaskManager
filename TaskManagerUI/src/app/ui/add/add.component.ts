import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { IProject } from 'src/app/model/IProject';

@Component({
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  pageTitle: string = "Add Task";
  errorMessage: string = '';
  Projects: any[];
  Users: any[];
  tasks: any[];
  selectedProject: any;
  selectedTask: any;
  item: any;
  projectSearch: string;
  selectedUserName: string = '';
  selectedParentTask: any;
  selectedTaskName: any;
  taskdisplay = 'none';
  taskSearch: string = '';
  //User modal
  userdisplay = 'none';
  usersearchText: string = '';
  onSelectUser(user) {
    this.selectedItem = user;
  }
  onSelectedUserName() {
    if (this.selectedItem) {
      this.selectedUserName = this.selectedItem.FirstName + ' ' + this.selectedItem.LastName;
      this.userdisplay = 'none';
    }
  }
  constructor(private addTaskService: SharedService) { }

  ngOnInit() {

  }
  addNewTask(formData) {
    //formData.value[pr]
    formData.value["Project_Id"]=this.selectedProject.Project_Id;
    formData.value["ParentTask_ID"]=this.selectedTask.Task_ID;
    this.addTaskService.AddNewTask(formData.value).subscribe(
      task => { this.item = task },
      error => this.errorMessage = <any>error)
  }

  display = 'none';
  openModal() {
    this.display = 'block';
  }
  onCloseHandled() {
    this.display = 'none';
    this.taskdisplay = 'none';
    this.userdisplay = 'none';
  }

  selectedItem: any;
  selectedProjectName: string;
  onSelect(proj): void {
    this.selectedProject = proj;
  }
  onTaskSelect(task): void {
    this.selectedTask = task;
  }
  onSelectedProject() {
    if (this.selectedProject) {
      this.selectedProjectName = this.selectedProject.Project;
      this.display = 'none';
    }
  }
  onSelectedTask() {
    if (this.selectedTask) {
      this.selectedParentTask = this.selectedTask.TaskDetail;
      this.display = 'none';
      this.taskdisplay = 'none';
    }
  }
  onReset(form) {
    form.reset();
  }
  onSearchProject() {
    this.display = 'block';
    this.fetchProjects();
  }
  onSearchTaskList() {
    this.display = 'none';
    this.taskdisplay = 'block';
    this.fetchAllTasks();
  }
  onSearchUserList() {
    this.userdisplay = 'block';
    this.fetchUsers();
  }
  fetchProjects() {
    this.addTaskService.getAllProjects().subscribe(
      projectList => {
        this.Projects = projectList;
      },
      error => this.errorMessage = <any>error
    );
  }
  fetchUsers() {
    this.addTaskService.getAllUsers().subscribe(
      UserList => {
        this.Users = UserList;
      },
      error => this.errorMessage = <any>error
    );
  }
  fetchAllTasks() {
    this.addTaskService.getAllTasks().subscribe(
      tasks => {
        this.tasks = tasks;
        this.display = 'block';
      },
      error => this.errorMessage = <any>error
    );
  }

}
