import { Component, OnInit, Output, EventEmitter, Input, ViewChild, ElementRef } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import  { ViewComponent } from '../view/view.component'

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  state$: Observable<object>;
  task:any;
  
  constructor( private route: ActivatedRoute) {    
  }

display='none'; 
sub='';
@ViewChild('editModalForm') myId: ElementRef;
  ngOnInit() {
    this.display='block';
    this.route.paramMap.subscribe(params => {
      this.task = params;
    });
    
  }
 openModalDialog(){
    this.display='block'; //Set block css
   // this.myId.nativeElement.style.display="block";
 }

 public closeModalDialog(){
  this.display='none'; //set none css after close dialog
 // this.myId.nativeElement.style.display="none";
 }
 ngOnDestroy() {
 // this.sub.unsubscribe();
}
}
