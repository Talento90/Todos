/// <reference path="../Refs.d.ts" />
declare module Todos {
    class TaskController {
        private tasks;
        private taskService;
        static $inject: string[];
        constructor($scope: ITaskScope, taskService: ITaskService);
    }
}
