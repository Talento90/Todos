/// <reference path='../Refs.ts' />

module Todos {
    'use strict';

    export interface ITaskScope {
        Events: TaskController;
        Tasks: Array<Task>;
        NewTask: string;
    }
}