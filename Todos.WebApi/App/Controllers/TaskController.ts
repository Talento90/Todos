/// <reference path='../Refs.ts' />

module Todos {
    'use strict';

    export class TaskController {

        private $scope: ITaskScope;
        private taskService: ITaskService;

        public static $inject = ['$scope', 'TaskService'];

        constructor($scope: ITaskScope, taskService: ITaskService) {
            this.$scope = $scope;
            this.$scope.Events = this;
            this.taskService = taskService;
            this.$scope.NewTask = new Task();

            taskService.GetTasks((tasks) => {
                this.$scope.Tasks = tasks;
            });
        }


        public CreateTask() {     

            console.log(this.$scope.NewTask);

            this.taskService.CreateTask(this.$scope.NewTask, (success: boolean) => {
                if (success) {
                    this.$scope.Tasks.push(this.$scope.NewTask);
                    this.$scope.NewTask = new Task();
                }
            });           
        }

        public DeleteTask(idTask: string) {
            this.taskService.DeleteTask(idTask, (task: Task) => {
                if (task) {
                    this.$scope.Tasks.splice(0, 1, task);                
                }
            });
        }
    }
}