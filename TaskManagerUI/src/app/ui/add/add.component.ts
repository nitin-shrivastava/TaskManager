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
  users: any[];
  tasks: any[];
  selectedProject: any;
  selectedTask:any;
  item: any;
  projectSearch: string;
  selectedUserName: string='';
  selectedParentTask: any;
  selectedTaskName:any;
  taskdisplay='none';
  constructor(private addTaskService: SharedService) { }

  ngOnInit() {

  }
  addNewTask(formData) {
    //formData.value[pr]
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
  }

  selectedItem: any = { id: '', name: '' };
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
    this.display = 'block';
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
        this.users = UserList;

      },
      error => this.errorMessage = <any>error
    );
  }
  fetchAllTasks() {
    this.addTaskService.getAllTasks().subscribe(
      tasks => {
        this.tasks = tasks;
        this.display='block';
      },
      error => this.errorMessage = <any>error
    );
  }

}
