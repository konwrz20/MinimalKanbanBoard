import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as TasksStore from '../store/Tasks';

type BacklogProps =
    TasksStore.TasksState &
    typeof TasksStore.actionCreators &
    RouteComponentProps<{}>;


class Backlog extends React.PureComponent<BacklogProps> {
    public componentDidMount() {
        this.props.fetchTasks();
    }

    public render() {
        return (
            <React.Fragment>
                <h1 id="tabelLabel">Board</h1>
                <p>List of tasks selected for development</p>
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
                    <th>Priority</th>
                    <th>Status</th>
                </tr>
                </thead>
                <tbody>
                {this.props.tasksSelectedToDevelopment.map((task: TasksStore.Task) =>
                    <tr key={task.id}>
                        <td>{task.name}</td>
                        <td>{task.deadlineDate}</td>
                        <td>{task.description}</td>
                        <td>{task.priority}</td>
                        <td>{task.status}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.tasks,
    TasksStore.actionCreators
)(Backlog as any);
