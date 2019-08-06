export interface ITask {
    TaskId:number;
    ParentTaskId:number;
    ParentTaskDetail:string;
    ProjectID:string;
    Task:string;
    StartDate:Date;
    EndDate:Date;
    Priority:number;
    Status:string;  
  }