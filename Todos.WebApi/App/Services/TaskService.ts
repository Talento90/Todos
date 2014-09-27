module Todos {
    'use strict';

    export class TaskService implements ITaskService {

        private tasks: Task[];
        public $http: ng.IHttpService;

        public static $inject = ['$http'];

        constructor($http: ng.IHttpService) {
            this.$http = $http;
        }


        public GetTasks(callback:void) {
            this.$http.get("")
                .success((tasks) => {

                })
                .error(() => {

                });
        }

        public DeleteTask(idTask: string, callback: void) {
            this.$http.get("")
                .success((tasks) => {

                })
                .error(() => {

                });
        }

        public CreateTask(task: Task, callback: void) {
            this.$http.get("")
                .success((tasks) => {

                })
                .error(() => {

                });
        }
    }
}