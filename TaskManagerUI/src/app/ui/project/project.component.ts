import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { IUsers } from 'src/app/model/IUsers';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  constructor(private projectService: SharedService) { }
  projects: any[];
  managerlist:IUsers[];
  errorMessage: string;
  mgsearchText: string; 
  project: string;

  ngOnInit() {
    this.fetchProjects();
  }
  fetchProjects() {
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
  disabledDuration: Boolean = true;
  changeCheck(event) {
    this.disabledDuration = !event.target.checked;
  }
  display = 'none';
  openModal() {
    this.display = 'block';
    this.fetchUsers();
  }
  fetchUsers() {
    this.projectService.getAllUsers().subscribe(
      UserList => {
        this.managerlist = UserList;
        this.Users=[];
        UserList.filter(it=>{
         
          return this.Users.push({'name':it.FirstName + ' '+ it.LastName ,'id':it.Employee_Id});
      });
      },
      error => this.errorMessage = <any>error
    );
  }
  onCloseHandled() {
    this.display = 'none';
  }
  Users: any[] = [{ id: '', name: '' }];
  selectedItem: any={id:'',name:''};
  selectedmanager:string;
  onSelect(manager): void {
    this.selectedItem = manager;
  }
  onSelectedManager() {
    if (this.selectedItem) {
      this.selectedmanager=this.selectedItem.name;
      this.display = 'none';
    }
  }
  onReset(form)
  {
    form.reset();
  }
}
