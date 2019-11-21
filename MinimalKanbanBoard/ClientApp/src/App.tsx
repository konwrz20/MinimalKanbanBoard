import * as React from 'react';
import {Route} from 'react-router';
import Layout from './components/Layout';
import Board from './components/Board';
import Backlog from './components/Backlog';
import People from './components/People';
import Projects from './components/Projects';


import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Projects}/>
        <Route path='/board' component={Board}/>
        <Route path='/backlog' component={Backlog}/>
        <Route path='/people' component={People}/>
    </Layout>
);
