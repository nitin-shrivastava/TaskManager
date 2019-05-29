import { Component, OnInit, Input, ViewChild, EventEmitter, Output } from '@angular/core';
import { ITask } from 'src/app/model/ITask';
import * as moment from 'moment';

@Component({
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor() { }
  @Input() editView;
  //@ViewChild(UpdateComponent) child;

  ngOnInit() {
    // add this 2 of 4
    //this.editView = new UpdateComponent();
  }
  // @Output() mySelected = new EventEmitter<string>()
  openEditPopup() {
    //this.mySelected.emit("open");
    //this.child.openModalDialog();
   // this.editView.openModalDialog();
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
      EndDate: new Date('12/04/1996'),
      Priority: 6,
      StartDate: new Date('11/04/1996'),
      Status: 'open',
      Task: 'This is my second task'
    }
  ];
  deleteEmployee(index) {
    var filtered = this.tasks.filter(function(item) { 
      return item.TaskId === index;  
   });
   // this.tasks.filter({TaskId:index});
  }
  // closeResult: string;



  // open(content) {
  //   this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
  //     this.closeResult = `Closed with: ${result}`;
  //   }, (reason) => {
  //     this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
  //   });
  // }

  // private getDismissReason(reason: any): string {
  //   if (reason === ModalDismissReasons.ESC) {
  //     return 'by pressing ESC';
  //   } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
  //     return 'by clicking on a backdrop';
  //   } else {
  //     return  `with: ${reason}`;
  //   }
  // }
}
