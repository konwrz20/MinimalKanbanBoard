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

interface FetchPeopleAction {
    type: 'FETCH_PEOPLE';
    people: Person[];
}

type KnownAction = FetchPeopleAction;

export const actionCreators = {
    fetchPeople: (): AppThunkAction<KnownAction> => (dispatch) => {
        fetch(`api/people`)
            .then(response => response.json() as Promise<Person[]>)
            .then(people => {
                dispatch(({type: 'FETCH_PEOPLE', people: people}));
            });
    }
};

const unloadedState: PeopleState = {people: []};

export const reducer: Reducer<PeopleState> = (state: PeopleState | undefined, incomingAction: Action): PeopleState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    if (action.type === 'FETCH_PEOPLE') {
        return {
            people: action.people
        }
    }

    return state;
};
