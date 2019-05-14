export interface ITask {
    TaskId:number;
    ParentTaskId:number;
    ParentTask:string;
    Task:string;
    StartDate:Date;
    EndDate:Date;
    Priority:number;
    Status:string;  
  }