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
  selectedProject: any;
  item: any;
  projectSearch:string;
  constructor(private addTaskService: SharedService) { }

  ngOnInit() {

  }
  addNewTask(formData) {
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
  }
  
  selectedItem: any = { id: '', name: '' };
  selectedProjectName: string;
  onSelect(proj): void {
    this.selectedProject = proj;
  }
  onSelectedProject() {
    if (this.selectedProject) {
      this.selectedProjectName = this.selectedProject.Project;
      this.display = 'none';
    }
  }
  onReset(form) {
    form.reset();
  }
  onSearchProject() {
    this.display = 'block';
    this.fetchProjects();

  }
  fetchProjects() {
    this.addTaskService.getAllProjects().subscribe(
      projectList => {
        this.Projects = projectList;       
      },
      error => this.errorMessage = <any>error
    );
  }
  
}
