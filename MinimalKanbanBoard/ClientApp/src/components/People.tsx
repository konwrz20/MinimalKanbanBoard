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
  public componentDidMount() {
    this.props.fetchPeople();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">People</h1>
        <p>List of working people</p>
        {this.renderTable()}
      </React.Fragment>
    );
  }

  private renderTable() {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Image</th>
          </tr>
        </thead>
        <tbody>
          {this.props.people.map((person: PeopleStore.Person) =>
            <tr key={person.id}>
              <td>{person.name}</td>
              <td>{person.image}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
}

export default connect(
  (state: ApplicationState) => state.people,
  PeopleStore.actionCreators
)(People as any);
