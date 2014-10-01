/// <reference path='../Refs.ts' />

module Todos {
    'use strict';

    export class TaskService implements ITaskService {

        private tasks: Task[];
        public $http: ng.IHttpService;

        public static $inject = ['$http'];

        constructor($http: ng.IHttpService) {
            this.$http = $http;
        }


        public GetTasks(callback: Function) {
            this.$http.get<Task>("http://localhost:6883/api/Task")
                .success((tasks) => {
                    callback(tasks);
                    toastr.success("Get all messages with success.");
                })
                .error((error) => {
                    toastr.error("Error getting the messages!");
                });
        }

        public DeleteTask(idTask: string, callback: Function) {
            this.$http.delete("")
                .success((tasks) => {

                })
                .error(() => {

                });
        }

        public CreateTask(task: Task, callback: Function) {
            this.$http.post("", task)
                .success((tasks) => {

                })
                .error(() => {

                });
        }
    }
}