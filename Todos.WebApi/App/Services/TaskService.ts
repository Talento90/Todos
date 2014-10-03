/// <reference path='../Refs.ts' />

module Todos {
    'use strict';

    export class TaskService implements ITaskService {
        private serviceUrl: string = "http://localhost:6883/api/Task";
        private tasks: Task[];
        public $http: ng.IHttpService;

        public static $inject = ['$http'];

        constructor($http: ng.IHttpService) {
            this.$http = $http;
        }


        public GetTasks(callback: Function) {
            this.$http.get<Task>(this.serviceUrl)
                .success((tasks) => {
                    toastr.success("Get all messages with success.");
                    callback(tasks);
                })
                .error((error) => {
                    toastr.error("Error getting the messages!");
                });
        }

        public DeleteTask(idTask: string, callback: Function) {
            this.$http.delete(this.serviceUrl + "/"+idTask)
                .success((task) => {
                    toastr.success("Task deleted with success!");
                    callback(task);
                })
                .error(() => {
                    toastr.error("Error trying to delete a task!");
                    callback(null);
                });
        }

        public CreateTask(task: Task, callback: Function) {
            this.$http.post(this.serviceUrl, task)
                .success((task) => {                
                    toastr.success("Task created with success!");
                    callback(task);
                })
                .error(() => {              
                    toastr.error("Error trying to create a task!");
                    callback(null);
                });
        }

        public UpdateTask(task: Task, callback: Function) {
            this.$http.put(this.serviceUrl + "/" + task.Id , task)
                .success((task) => {
                    toastr.success("Task updated with success!");
                    if(callback)
                        callback(task);
                })
                .error(() => {
                    toastr.error("Error trying to update a task!");
                    if (callback)
                        callback(null);
                });
        }
    }
}