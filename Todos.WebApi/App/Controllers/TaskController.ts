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
            this.$scope.NewTask = "";

            taskService.GetTasks((tasks: Task[]) => {
                this.$scope.Tasks = tasks;
            });
        }


        public CreateTask() {

            var newTask: Task = new Task(this.$scope.NewTask);

            this.taskService.CreateTask(newTask, (task: Task) => {
                if (task) {
                    this.$scope.Tasks.push(task);
                    this.$scope.NewTask = "";
                }
            });
        }

        public DeleteTask(idTask: string) {
            this.taskService.DeleteTask(idTask, (task: Task) => {
                if (task) {
                    var t: Task = this.$scope.Tasks.filter(t => t.Id == idTask)[0];
                    this.$scope.Tasks.splice(this.$scope.Tasks.indexOf(t), 1);
                }
            });
        }

        public CheckTask(task: Task) {
            task.Completed = !task.Completed;
            this.taskService.UpdateTask(task, null);
        }
    }
}