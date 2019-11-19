import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as PeopleStore from '../store/People';

type PeopleProps =
    PeopleStore.PeopleState &
    typeof PeopleStore.actionCreators &
    RouteComponentProps<{}>;

class People extends React.PureComponent<PeopleProps> {
    public render() {
        return (
            <React.Fragment>
                <h1>Backlog</h1>

                <p aria-live="polite">People: <strong></strong></p>

                <button type="button"
                    className="btn btn-primary btn-lg"
                    onClick={() => { this.props.fetchAllPeople(); }}>
                    Fetch people
                </button>
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.people,
    PeopleStore.actionCreators
)(People as any);
