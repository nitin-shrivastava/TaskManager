import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router'

import { AppComponent } from './app.component';
import { AddComponent } from './ui/add/add.component';
import { ViewComponent } from './ui/view/view.component';
import { UpdateComponent } from './ui/update/update.component';

@NgModule({
  declarations: [
    AppComponent,
    AddComponent,
    ViewComponent,
    UpdateComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([{ path: 'add', component: AddComponent },
    { path: 'view', component: ViewComponent },
    { path: '',redirectTo:'add', pathMatch:'full' }
  ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
