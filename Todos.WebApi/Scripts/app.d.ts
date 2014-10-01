declare module Todos {
    class Task {
        public Id: string;
        public Description: string;
        public Completed: boolean;
        public Created: Date;
        public Updated: Date;
        constructor(description: string);
    }
}
declare module Todos {
    interface ITaskScope {
        Events: TaskController;
        Tasks: Task[];
        NewTask: string;
    }
}
declare module Todos {
    class TaskController {
        private $scope;
        private taskService;
        static $inject: string[];
        constructor($scope: ITaskScope, taskService: ITaskService);
        public CreateTask(): void;
        public DeleteTask(idTask: string): void;
    }
}
declare module Todos {
    interface ITaskService {
        GetTasks(callback: Function): any;
        DeleteTask(idTask: string, callback: Function): any;
        CreateTask(task: Task, callback: Function): any;
    }
}
declare module Todos {
    class TaskService implements ITaskService {
        private serviceUrl;
        private tasks;
        public $http: ng.IHttpService;
        static $inject: string[];
        constructor($http: ng.IHttpService);
        public GetTasks(callback: Function): void;
        public DeleteTask(idTask: string, callback: Function): void;
        public CreateTask(task: Task, callback: Function): void;
    }
}
declare module Todos {
}
