import { Component, OnInit, Output, EventEmitter, Input, ViewChild, ElementRef } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ViewComponent } from '../view/view.component'
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  state$: Observable<object>;
  task: any;

  constructor(private route: ActivatedRoute, private taskService: SharedService) {
    console.log(this.route.snapshot.paramMap.get('Task_ID'));
  }

  display = 'none';
  sub = '';
  taskId: number;
  @ViewChild('editModalForm') myId: ElementRef;
  ngOnInit() {
    this.display = 'block';
    this.route.paramMap.subscribe(params => {
      this.taskId = Number(params.get('id'));
      this.fetchTaskByID(this.taskId);
    });

  }
  fetchTaskByID(id) {
    this.taskService.getTaskById(id).subscribe(
      tasks => {
        this.task = tasks;
      }
    );
  }
  openModalDialog() {
    this.display = 'block'; //Set block css
    // this.myId.nativeElement.style.display="block";
  }

  public closeModalDialog() {
    this.display = 'none'; //set none css after close dialog
    // this.myId.nativeElement.style.display="none";
  }
  ngOnDestroy() {
    // this.sub.unsubscribe();
  }
  updateTaskDetail(formData) {
    console.log(formData.value);
  }
}
