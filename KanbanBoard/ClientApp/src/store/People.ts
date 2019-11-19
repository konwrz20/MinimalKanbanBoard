import {Action, Reducer} from 'redux';
import {AppThunkAction} from './';

export interface PeopleState {
    people: Person[];
}

export interface Person {
    id: string;
    name: string;
    image: string;
}

interface FetchAllPeopleAction {
    type: 'FETCH_ALL_PEOPLE';
    people: Person[];
}

type KnownAction = FetchAllPeopleAction;

export const actionCreators = {
    fetchAllPeople: (): AppThunkAction<KnownAction> => (dispatch) => {
        fetch(`api/people`)
            .then(response => response.json() as Promise<Person[]>)
            .then(data => {
                dispatch(({type: 'FETCH_ALL_PEOPLE', people: data}));
            });
    }
};

const unloadedState: PeopleState = {people: []};

export const reducer: Reducer<PeopleState> = (state: PeopleState | undefined, incomingAction: Action): PeopleState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    if (action.type === 'FETCH_ALL_PEOPLE') {
        return {
            people: action.people
        }
    }

    return state;
};
