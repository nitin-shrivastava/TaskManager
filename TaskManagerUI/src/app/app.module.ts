import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router'

import { AppComponent } from './app.component';
import { AddComponent } from './ui/add/add.component';
import { ViewComponent } from './ui/view/view.component';
import { UpdateComponent } from './ui/update/update.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectComponent } from './ui/project/project.component';
import { UsersComponent } from './ui/users/users.component';



@NgModule({
  declarations: [
    AppComponent,
    AddComponent,
    ViewComponent,
    UpdateComponent,
    ProjectComponent,
    UsersComponent    
  ],
  imports: [
    BrowserModule,HttpClientModule,
    RouterModule.forRoot([
    { path: 'project', component: ProjectComponent },
    { path: 'users', component: UsersComponent },
    { path: 'add', component: AddComponent },
    { path: 'view', component: ViewComponent, children:[{ path: ':id/update', component: UpdateComponent }]},
    { path: '',redirectTo:'add', pathMatch:'full' }
  ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
