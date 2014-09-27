declare module Todos {
    class TaskService implements ITaskService {
        private tasks;
        public $http: ng.IHttpService;
        static $inject: string[];
        constructor($http: ng.IHttpService);
    }
}
