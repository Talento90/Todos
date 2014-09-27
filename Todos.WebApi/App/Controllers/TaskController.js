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
//# sourceMappingURL=TaskController.js.map
