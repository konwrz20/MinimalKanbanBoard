import {Action, Reducer} from 'redux';
import {AppThunkAction} from './';

export interface TasksState {
    tasksFromBacklog: Task[];
    tasksSelectedToDevelopment: Task[];
}

export interface Task {
    id: string;
    name: string;
    projectId: string;
    deadlineDate: Date;
    description: string;
    priority: Priority;
    status: Status;
}

export enum Priority { Low, Medium, High }

export enum Status { Backlog, ToDo, InProgress, Done }

interface FetchTasksAction {
    type: 'FETCH_TASKS';
    tasks: Task[];
}

type KnownAction = FetchTasksAction;

export const actionCreators = {
    fetchTasks: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        const appState = getState();
        if (appState && appState.projects && appState.projects.selectedProject) {
            const selectedProjectId = appState.projects.selectedProject.id;
            
            fetch(`api/tasks/${selectedProjectId}`)
                .then(response => response.json() as Promise<Task[]>)
                .then(tasks => {
                    dispatch(({type: 'FETCH_TASKS', tasks: tasks}));
                });
        }
    }
};

const unloadedState: TasksState = {tasksFromBacklog: [], tasksSelectedToDevelopment: []};

export const reducer: Reducer<TasksState> = (state: TasksState | undefined, incomingAction: Action): TasksState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    if (action.type === 'FETCH_TASKS') {
        const backlogTasks = action.tasks.filter(task => task.status === Status.Backlog);

        return {
            tasksFromBacklog: backlogTasks,
            tasksSelectedToDevelopment: action.tasks.filter(task => !backlogTasks.includes(task))
        }
    }

    return state;
};
