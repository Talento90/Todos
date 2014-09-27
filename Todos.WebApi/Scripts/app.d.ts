declare module Todos {
}
declare module Todos {
    interface ITaskScope {
        Events: TaskController;
    }
}
declare module Todos {
    class TaskController {
        private tasks;
        private taskService;
        static $inject: string[];
        constructor($scope: ITaskScope, taskService: ITaskService);
    }
}
declare module Todos {
    class Task {
        public Id: string;
        public Description: string;
        public Completed: boolean;
        public Created: Date;
        public Updated: Date;
    }
}
declare module Todos {
    interface ITaskService {
        GetTasks(callback: void): any;
        DeleteTask(idTask: string, callback: void): any;
        CreateTask(task: Task, callback: void): any;
    }
}
declare module Todos {
    class TaskService implements ITaskService {
        private tasks;
        public $http: ng.IHttpService;
        static $inject: string[];
        constructor($http: ng.IHttpService);
        public GetTasks(callback: void): void;
        public DeleteTask(idTask: string, callback: void): void;
        public CreateTask(task: Task, callback: void): void;
    }
}
