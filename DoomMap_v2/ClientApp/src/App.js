import React, { Component, useState } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home/Home';
import Nav from './components/Nav/NavMenu';
import Map from './components/Map/Map';
import AppContextProvider from './context/AppContext';
;

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
        <div>
              <Nav />
              <Route exact path='/' component={Home} />
              <AppContextProvider>
                  <Route exact path='/map' component={Map} />
               </AppContextProvider>
        </div>

    );
  }
}
