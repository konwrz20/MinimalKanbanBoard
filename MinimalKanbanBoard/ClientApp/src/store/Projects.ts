import {Action, Reducer} from 'redux';
import {AppThunkAction} from './';

export interface ProjectsState {
    projects: Project[];
    selectedProject: Project | null;
}

export interface Project {
    id: string;
    name: string;
    deadlineDate: Date;
    description: string;
}

interface FetchProjectsAction {
    type: 'FETCH_PROJECTS';
    projects: Project[];
    selectedProject: Project | null;
}

interface SelectProjectAction {
    type: 'SELECT_PROJECT';
    selectedProject: Project;
}

type KnownAction = FetchProjectsAction | SelectProjectAction;

export const actionCreators = {
    fetchProjects: (): AppThunkAction<KnownAction> => (dispatch) => {
        fetch(`api/projects`)
            .then(response => response.json() as Promise<Project[]>)
            .then(projects => {
                const firstProject = projects[0] ? projects[0] : null;
                dispatch(({type: 'FETCH_PROJECTS', projects: projects, selectedProject: firstProject}));
            });
    },
    selectProject: (project: Project) => ({ type: 'SELECT_PROJECT', selectedProject: project } as SelectProjectAction)
};

const unloadedState: ProjectsState = {projects: [], selectedProject: null};

export const reducer: Reducer<ProjectsState> = (state: ProjectsState | undefined, incomingAction: Action): ProjectsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'FETCH_PROJECTS':
            return {
                projects: action.projects,
                selectedProject: action.selectedProject
            };
        case 'SELECT_PROJECT':
            return {
                projects: state.projects,
                selectedProject: action.selectedProject
            };
    }

    return state;
};
