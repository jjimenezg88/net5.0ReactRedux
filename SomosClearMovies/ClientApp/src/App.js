import React from 'react';
import { Route } from 'react-router-dom';
import Layout from './components/Layout';
import MoviePage from './pages/movies/movies.page';

import './custom.css'

const App = ()=>(
  <Layout>
    <Route exact path='/' component={MoviePage} />
  </Layout>
);

export default App;
