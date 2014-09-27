var Todos;
(function (Todos) {
    'use strict';

    var TaskService = (function () {
        function TaskService($http) {
            this.$http = $http;
        }
        TaskService.$inject = ['$http'];
        return TaskService;
    })();
    Todos.TaskService = TaskService;
})(Todos || (Todos = {}));
//# sourceMappingURL=TaskService.js.map
