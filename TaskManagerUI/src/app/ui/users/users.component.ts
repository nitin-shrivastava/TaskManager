import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private userService:SharedService) { }
  users:any[];
  errorMessage: string;
  ngOnInit() {
    this.fetchUsers();
  }
  fetchUsers() {
    this.userService.getAllUsers().subscribe(
      UserList => {
        this.users = UserList;
      },
      error => this.errorMessage = <any>error
    );
  }
  addUserDetails(formData){
console.log(formData.value);

  }
}
