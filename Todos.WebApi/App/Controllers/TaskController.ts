/// <reference path='../Refs.ts' />

module Todos {
    'use strict';

    export class TaskController {

        private tasks: Task[];
        private taskService: TaskService;

        public static $inject = ['$scope', 'TaskService'];

        constructor($scope: ITaskScope, taskService: ITaskService) {

        }
    }
}