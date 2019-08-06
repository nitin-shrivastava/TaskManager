import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  constructor(private projectService: SharedService) { }
  projects: any[];
  errorMessage: string;
  ngOnInit() {
    this.fetchProjects();
  }
  fetchProjects(){
    this.projectService.getAllProjects().subscribe(
      projectList => {
        this.projects = projectList;
      },
      error => this.errorMessage = <any>error
    );
  }
  saveProjectDetails(form) {
    console.log(form.value);
    this.projectService.AddProject(form.value).subscribe(
      projectList => {
        this.projects = projectList;
        this.fetchProjects();
      },
      error => this.errorMessage = <any>error
    );

  }
}
