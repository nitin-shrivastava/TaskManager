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
  onSearchProject(){
    console.log('new hit');
  }
  display = 'none';
  openModal() {
    this.display = 'block';
  }
  onCloseHandled() {
    this.display = 'none';
  }
  Users: any[] = [{ id: 456788, name: 'Sachin' }, { id: 49888, name: 'Vikas' }];
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
}
