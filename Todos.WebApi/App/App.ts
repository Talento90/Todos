/// <reference path='./Refs.ts' />

module Todos {
    'use strict';

  toastr.options.backgroundpositionClass = "toast-top-full-width";

  var todos =  angular.module('todos', [])
                .controller('TaskController', TaskController)
                .service('TaskService', TaskService);


    
}