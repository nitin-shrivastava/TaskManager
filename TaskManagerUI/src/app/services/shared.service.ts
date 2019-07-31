import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ITask } from '../model/ITask';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, tap } from 'rxjs/operators';
import { Task } from '../model/task';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private tasksUrl = 'https://taskmanagerserviceapi20190703040240.azurewebsites.net/api/taskoperation';
  constructor(private http: HttpClient) { }
  getAllTasks(): Observable<ITask[]> {
    return this.http.get<ITask[]>(this.tasksUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );   
  }
  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }



  getTaskById(id: number):  Observable<ITask[]> {
    return this.http.get<ITask[]>(this.tasksUrl+'/'+id)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );
  }
  deleteTask(id:number):Observable<ITask[]>{

    return this.http.get<ITask[]>(this.tasksUrl+'/'+id)
    .pipe(
      tap(data => console.log(JSON.stringify(data))),
      retry(1),
      catchError(this.handleError)
    );
  }
}
