import { Injectable } from '@angular/core';
import { ITask } from '../model/ITask';
import { Observable } from 'rxjs';
import { Task } from '../model/task';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private tasksUrl = 'api/tasks';
  constructor(private http: HttpClient) { }
  getProducts(): Observable<ITask[]> {
    // return this.http.get<ITask[]>(this.productsUrl)
    //   .pipe(
    //     tap(data => console.log(JSON.stringify(data))),
    //     catchError(this.handleError)
    //   );
    return;
  }

  getTask(id: number): Observable<Task> {
    if (id === 0) {
      return ;
    }
    const url = `${this.tasksUrl}/${id}`;
    // return this.http.get<Product>(url)
    //   .pipe(
    //     tap(data => console.log('getProduct: ' + JSON.stringify(data))),
    //     catchError(this.handleError)
    //   );
  }
}
