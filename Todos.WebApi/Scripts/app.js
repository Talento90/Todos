var Todos;
(function (Todos) {
    'use strict';

    angular.module('todos', []).controller('TaskController', Todos.TaskController).service('TaskService', Todos.TaskService);
})(Todos || (Todos = {}));
/// <reference path='../Scripts/typings/angularjs/angular.d.ts' />
/// <reference path='../Scripts/typings/toastr/toastr.d.ts' />
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
        }
        TaskController.$inject = ['$scope', 'TaskService'];
        return TaskController;
    })();
    Todos.TaskController = TaskController;
})(Todos || (Todos = {}));
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
var Todos;
(function (Todos) {
    'use strict';
})(Todos || (Todos = {}));
var Todos;
(function (Todos) {
    'use strict';

    var TaskService = (function () {
        function TaskService($http) {
            this.$http = $http;
        }
        TaskService.prototype.GetTasks = function (callback) {
            this.$http.get("").success(function (tasks) {
            }).error(function () {
            });
        };

        TaskService.prototype.DeleteTask = function (idTask, callback) {
            this.$http.get("").success(function (tasks) {
            }).error(function () {
            });
        };

        TaskService.prototype.CreateTask = function (task, callback) {
            this.$http.get("").success(function (tasks) {
            }).error(function () {
            });
        };
        TaskService.$inject = ['$http'];
        return TaskService;
    })();
    Todos.TaskService = TaskService;
})(Todos || (Todos = {}));
//# sourceMappingURL=app.js.map
