import * as People from './People';
import * as Projects from './Projects';
import * as Tasks from './Tasks';

export interface ApplicationState {
    people: People.PeopleState | undefined;
    projects: Projects.ProjectsState | undefined;
    tasks: Tasks.TasksState | undefined;
}

export const reducers = {
    people: People.reducer,
    projects: Projects.reducer,
    tasks: Tasks.reducer
};

export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
