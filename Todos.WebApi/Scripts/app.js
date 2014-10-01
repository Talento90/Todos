var Todos;
(function (Todos) {
    'use strict';

    var Task = (function () {
        function Task() {
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
            this.$scope.NewTask = new Todos.Task();

            taskService.GetTasks(function (tasks) {
                _this.$scope.Tasks = tasks;
            });
        }
        TaskController.prototype.CreateTask = function () {
            var _this = this;
            console.log(this.$scope.NewTask);

            this.taskService.CreateTask(this.$scope.NewTask, function (success) {
                if (success) {
                    _this.$scope.Tasks.push(_this.$scope.NewTask);
                    _this.$scope.NewTask = new Todos.Task();
                }
            });
        };

        TaskController.prototype.DeleteTask = function (idTask) {
            var _this = this;
            this.taskService.DeleteTask(idTask, function (task) {
                if (task) {
                    _this.$scope.Tasks.splice(0, 1, task);
                }
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
            this.$http = $http;
        }
        TaskService.prototype.GetTasks = function (callback) {
            this.$http.get("http://localhost:6883/api/Task").success(function (tasks) {
                callback(tasks);
                toastr.success("Get all messages with success.");
            }).error(function (error) {
                toastr.error("Error getting the messages!");
            });
        };

        TaskService.prototype.DeleteTask = function (idTask, callback) {
            this.$http.delete("").success(function (tasks) {
            }).error(function () {
            });
        };

        TaskService.prototype.CreateTask = function (task, callback) {
            this.$http.post("", task).success(function (tasks) {
            }).error(function () {
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

    var todos = angular.module('todos', []).controller('TaskController', Todos.TaskController).service('TaskService', Todos.TaskService);
})(Todos || (Todos = {}));
//# sourceMappingURL=app.js.map
