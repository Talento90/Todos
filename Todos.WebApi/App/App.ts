module Todos {
    'use strict';

    angular.module('todos', [])
        .controller('TaskController', TaskController)
        .service('TaskService', TaskService);
}