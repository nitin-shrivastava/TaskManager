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
  private projectUrl='https://taskmanagerserviceapi20190703040240.azurewebsites.net/api/project';
  private usersUrl='https://taskmanagerserviceapi20190703040240.azurewebsites.net/api/users';
  constructor(private http: HttpClient) { }
  getAllTasks(): Observable<ITask[]> {
    return this.http.get<ITask[]>(this.tasksUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );
  }
  AddNewTask(formData): Observable<ITask[]> {
    return this.http.post<ITask[]>(this.tasksUrl,formData)//"http://localhost:52240/api/taskoperation"
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );
  }
  getAllProjects(): Observable<ITask[]> {
    return this.http.get<ITask[]>(this.projectUrl)//"http://localhost:52240/api/project"
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );
  }
  AddProject(formData): Observable<ITask[]> {
    return this.http.post<any[]>(this.projectUrl,formData)//"http://localhost:52240/api/project"
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );
  }
  getAllUsers(): Observable<ITask[]> {
    return this.http.get<any[]>(this.usersUrl)//"http://localhost:52240/api/users"
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        retry(1),
        catchError(this.handleError)
      );
  }
  AddUser(formData): Observable<ITask[]> {
    return this.http.post<any[]>(this.usersUrl,formData)
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
