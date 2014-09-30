module Todos {
    'use strict';

  var todos =  angular.module('todos', [])
                .controller('TaskController', TaskController)
                .service('TaskService', TaskService);

}