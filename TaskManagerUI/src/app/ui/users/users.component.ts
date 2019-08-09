import { Component, OnInit, PipeTransform, Pipe } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { IUsers } from 'src/app/model/IUsers';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private userService: SharedService) { }
  users: IUsers[];
  errorMessage: string;
  searchText: string = "";
  ngOnInit() {
    this.fetchUsers();
  }
  fetchUsers() {
    this.userService.getAllUsers().subscribe(
      UserList => {
        this.users = UserList;
        console.log(UserList);
      },
      error => this.errorMessage = <any>error
    );
  }
  addUserDetails(formData) {
    console.log(formData.value);
    this.userService.AddUser(formData.value).subscribe(
      UserList => {
        this.users = UserList;
        this.fetchUsers();
      },
      error => this.errorMessage = <any>error
    );
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
}
