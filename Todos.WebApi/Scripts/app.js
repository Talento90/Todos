var Todos;
(function (Todos) {
    'use strict';

    var Task = (function () {
        function Task(description) {
            this.Description = description;
        }
        return Task;
    })();
    Todos.Task = Task;
})(Todos || (Todos = {}));
/// <reference path='../Refs.ts' />
var Todos;
(function (Todos) {
    'use strict';
})(Todos || (Todos = {}));
/// <reference path='../Refs.ts' />
var Todos;
(function (Todos) {
    'use strict';

    var TaskController = (function () {
        function TaskController($scope, taskService) {
            var _this = this;
            this.$scope = $scope;
            this.$scope.Events = this;
            this.taskService = taskService;
            this.$scope.NewTask = "";

            taskService.GetTasks(function (tasks) {
                _this.$scope.Tasks = tasks;
            });
        }
        TaskController.prototype.CreateTask = function () {
            var _this = this;
            var newTask = new Todos.Task(this.$scope.NewTask);

            this.taskService.CreateTask(newTask, function (task) {
                if (task) {
                    _this.$scope.Tasks.push(task);
                    _this.$scope.NewTask = "";
                }
            });
        };

        TaskController.prototype.DeleteTask = function (idTask) {
            var _this = this;
            this.taskService.DeleteTask(idTask, function (task) {
                if (task) {
                    var t = _this.$scope.Tasks.filter(function (t) {
                        return t.Id == idTask;
                    })[0];
                    _this.$scope.Tasks.splice(_this.$scope.Tasks.indexOf(t), 1);
                }
            });
        };

        TaskController.prototype.CheckTask = function (task) {
            this.taskService.UpdateTask(task, function (task) {
            });
        };
        TaskController.$inject = ['$scope', 'TaskService'];
        return TaskController;
    })();
    Todos.TaskController = TaskController;
})(Todos || (Todos = {}));
/// <reference path='../Refs.ts' />
var Todos;
(function (Todos) {
    'use strict';
})(Todos || (Todos = {}));
/// <reference path='../Refs.ts' />
var Todos;
(function (Todos) {
    'use strict';

    var TaskService = (function () {
        function TaskService($http) {
            this.serviceUrl = "http://localhost:6883/api/Task";
            this.$http = $http;
        }
        TaskService.prototype.GetTasks = function (callback) {
            this.$http.get(this.serviceUrl).success(function (tasks) {
                toastr.success("Get all messages with success.");
                callback(tasks);
            }).error(function (error) {
                toastr.error("Error getting the messages!");
            });
        };

        TaskService.prototype.DeleteTask = function (idTask, callback) {
            this.$http.delete(this.serviceUrl + "/" + idTask).success(function (task) {
                toastr.success("Task deleted with success!");
                callback(task);
            }).error(function () {
                toastr.error("Error trying to delete a task!");
                callback(null);
            });
        };

        TaskService.prototype.CreateTask = function (task, callback) {
            this.$http.post(this.serviceUrl, task).success(function (task) {
                toastr.success("Task created with success!");
                callback(task);
            }).error(function () {
                toastr.error("Error trying to create a task!");
                callback(null);
            });
        };

        TaskService.prototype.UpdateTask = function (task, callback) {
            this.$http.put(this.serviceUrl + "/" + task.Id, task).success(function (task) {
                toastr.success("Task updated with success!");
                callback(task);
            }).error(function () {
                toastr.error("Error trying to update a task!");
                callback(null);
            });
        };
        TaskService.$inject = ['$http'];
        return TaskService;
    })();
    Todos.TaskService = TaskService;
})(Todos || (Todos = {}));
/// <reference path='../Scripts/typings/angularjs/angular.d.ts' />
/// <reference path='../Scripts/typings/toastr/toastr.d.ts' />
/// <reference path='Models/Task.ts' />
/// <reference path='Controllers/ITaskScope.ts' />
/// <reference path='Controllers/TaskController.ts' />
/// <reference path='Services/ITaskService.ts' />
/// <reference path='Services/TaskService.ts' />
/// <reference path='App.ts' />
/// <reference path='./Refs.ts' />
var Todos;
(function (Todos) {
    'use strict';

    toastr.options.backgroundpositionClass = "toast-top-full-width";

    var todos = angular.module('todos', []).controller('TaskController', Todos.TaskController).service('TaskService', Todos.TaskService);
})(Todos || (Todos = {}));
//# sourceMappingURL=app.js.map
