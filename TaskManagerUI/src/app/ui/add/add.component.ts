import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
 pageTitle:string="Add Task";
 errorMessage:string='';
 item:any;
  constructor(private addTaskService: SharedService) { }

  ngOnInit() {

  }
  addNewTask(formData){
    this.addTaskService.AddNewTask(formData.value).subscribe(
      task=>{this.item=task},
      error => this.errorMessage = <any>error)
  }
  
}
