import React from 'react'
import { render } from 'react-dom'
import { Router, Route, hashHistory, IndexRoute,transitionTo } from 'react-router'
import Main from 'Main'
import Dashboard from 'Dashboard'
render((
  <Router history={hashHistory}>
    <Route path="/" component={Main}>
    <IndexRoute component={Dashboard}/>
    </Route>
  </Router>
), document.getElementById('app'))