import { Component, OnInit, PipeTransform, Pipe, Output, EventEmitter, Inject } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { IUsers } from 'src/app/model/IUsers';
import { DOCUMENT } from '@angular/common';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  document: any;
  constructor(@Inject(DOCUMENT) document, private userService: SharedService) {
    this.document = document;

  }
  users: IUsers[];
  errorMessage: string;
  searchText: string = "";
  userid: number;
  firstName: string;
  lastName: string;
  employee_id: number;
  isDisabled: boolean;
  @Output() valueUpdate = new EventEmitter();

  getUpdatedvalue($event) {
    console.log($event.User_Id);
    this.userid = $event.User_Id
    this.firstName = $event.FirstName;
    this.lastName = $event.LastName;
    this.employee_id = $event.Employee_Id
    this.isDisabled = true;
    document.getElementById('btnadduser').innerHTML = "Update";
  }
  ngOnInit() {
    this.fetchUsers();
  }
  fetchUsers() {
    this.userService.getAllUsers().subscribe(
      UserList => {
        this.users = UserList;
        this.isDisabled = false;
      },
      error => this.errorMessage = <any>error
    );
  }
  addUserDetails(formData) {
    if (document.getElementById('btnadduser').innerHTML == "Update") {
      var user = {
        User_Id: this.userid, FirstName: formData.value.firstname, LastName: formData.value.lastname,
        Employee_Id: (this.employee_id)
      };
      this.userService.AddUser(user).subscribe(
        UserList => {
          this.users = UserList;
          this.fetchUsers();
          document.getElementById('btnadduser').innerHTML="Add";
          formData.reset();
        },
        error => this.errorMessage = <any>error
      );
    }
    else {
      this.userService.AddUser(formData.value).subscribe(
        UserList => {
          this.users = UserList;
          this.fetchUsers();
        },
        error => this.errorMessage = <any>error
      );
    }
  }
  onReset(form) {
    form.reset();
  }
  deleteUserDetail(userId) {
    this.userService.DeleteUser(userId).subscribe(
      UserList => {
        this.users = UserList;
        this.fetchUsers();
      },
      error => this.errorMessage = <any>error
    );
  }
  onUpdateUser(formData) {
    this.getUpdatedvalue(formData);
  }
}
