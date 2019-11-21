import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as ProjectsStore from '../store/Projects';

type ProjectsProps =
    ProjectsStore.ProjectsState &
    typeof ProjectsStore.actionCreators &
    RouteComponentProps<{}>;


class Projects extends React.PureComponent<ProjectsProps> {
  public componentDidMount() {
    this.props.fetchProjects();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Projects</h1>
        <p>List of projects</p>
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
            <th>Deadline Date</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {this.props.projects.map((project: ProjectsStore.Project) =>
            <tr key={project.id}>
              <td>{project.name}</td>
              <td>{project.deadlineDate}</td>
              <td>{project.description}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
}

export default connect(
  (state: ApplicationState) => state.projects,
  ProjectsStore.actionCreators
)(Projects as any);
