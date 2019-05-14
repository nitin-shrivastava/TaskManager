import { Component, OnInit } from '@angular/core';
import { ITask } from 'src/app/model/ITask';
import * as moment from 'moment';
@Component({
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    // add this 2 of 4

  }
  momentInstance = moment();
  tasks: ITask[] = [
    {
      TaskId: 1,
      ParentTaskId: 1,
      ParentTask: 'Parent task 1',
      EndDate: new Date('12/04/1996'),
      Priority: 5,
      StartDate: new Date('12/04/1996'),
      Status: 'open',
      Task: 'This is my sample task'
    },
    {
      TaskId: 2,
      ParentTaskId: 1,
      ParentTask: 'parent task 2',
      EndDate: new Date('16/04/1996'),
      Priority: 6,
      StartDate: new Date('11/04/1996'),
      Status: 'open',
      Task: 'This is my second task'
    }
  ];

}
