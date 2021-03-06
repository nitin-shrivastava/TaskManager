import { Component, OnInit, Input, ViewChild, EventEmitter, Output, Inject } from '@angular/core';
import { ITask } from 'src/app/model/ITask';
import * as moment from 'moment';

import { SharedService } from 'src/app/services/shared.service';
import { DOCUMENT } from '@angular/common';

@Component({
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor(private taskService: SharedService, @Inject(DOCUMENT) document, ) { }
  @Input() editView;
  tasks: ITask[];
  errorMessage: string;
  ngOnInit() {

    this.fetchAllTasks();
  }
  fetchAllTasks() {
    this.taskService.getAllTasks().subscribe(
      tasks => {
        this.tasks = tasks;
      },
      error => this.errorMessage = <any>error
    );
  }
  // @Output() mySelected = new EventEmitter<string>()
  openEditPopup() {
    //this.mySelected.emit("open");
    //this.child.openModalDialog();
    // this.editView.openModalDialog();
  }
  momentInstance = moment();
  deleteTask(task) {
    this.taskService
      .deleteTask(task.Task_ID)
      .subscribe(
        complete => {
          this.fetchAllTasks();
        });
  }
 
  endTask(task) {
    this.taskService
      .endTask(task.Task_ID)
      .subscribe(
        complete => {
          this.fetchAllTasks();

        });
  }

}


