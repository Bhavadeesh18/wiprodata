import React, { useState } from 'react';
import './App.css';
import First from './components/first/first';
import Second from './components/second/second';
import Third from './components/third/third';
import BottonEx from './components/buttonex/buttonex';
import Four from './components/four/four';
import Five from './components/five/five';
import Six from './components/six/six';
import Seven from './components/seven/seven';
import Eight from './components/eight/eight';
import Menu from './components/menu/menu';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/login/login';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div className="App">
      <p>Welcome to React Programming!</p>
      <BrowserRouter>
        {!isLoggedIn ? (
          <Routes>
            <Route path="*" element={<Login onLogin={() => setIsLoggedIn(true)} />} />
          </Routes>
        ) : (
          <>
            <Menu />
            <Routes>
              <Route path="/" element={<Navigate to="/first" />} />
              <Route path="/first" element={<First />} />
              <Route path="/second" element={<Second />} />
              <Route path="/third" element={<Third />} />
              <Route path="/four" element={<Four />} />
              <Route path="/five" element={<Five />} />
              <Route path="/six" element={<Six />} />
              <Route path="/seven" element={<Seven />} />
              <Route path="/eight" element={<Eight />} />
              <Route path="/buttonex" element={<BottonEx />} />
            </Routes>
          </>
        )}
      </BrowserRouter>
    </div>
  );
}

export default App;