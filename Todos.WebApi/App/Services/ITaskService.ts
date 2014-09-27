module Todos {
    'use strict';

    export interface ITaskService {
        GetTasks(callback: void);
        DeleteTask(idTask: string, callback: void);
        CreateTask(task: Task, callback: void);
    }
}