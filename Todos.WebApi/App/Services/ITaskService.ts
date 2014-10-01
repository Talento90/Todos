/// <reference path='../Refs.ts' />

module Todos {
    'use strict';

    export interface ITaskService {
        GetTasks(callback: Function);
        DeleteTask(idTask: string, callback: Function);
        CreateTask(task: Task, callback: Function);
    }
}