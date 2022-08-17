import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

import { Provider } from 'react-redux';
import store from './store';

import HomeScreen from './screens/HomeScreen';
import ProductScreen from './screens/ProductScreen';

import './index.css';
import App from './App';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Provider store = {store}>
    <React.StrictMode>
      <BrowserRouter>
        <Routes>
          <Route element={<App />} >
            <Route path="/" element={<HomeScreen />} exact/>
            <Route path="product/:id" element={<ProductScreen />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </React.StrictMode>
  </Provider>
);
