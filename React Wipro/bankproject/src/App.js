import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import CreateAccount from './components/createAccount/createAccount';
import SearchAccount from './components/searchAccount/searchAccount';
import ShowAccount from './components/showAccount/showAccount';
import Deposit from './components/depositAmount/depositAmount';
import Withdraw from './components/withdrawAmount/withdrawAmount';

function App() {
  const [currentPage, setCurrentPage] = useState('menu');

  const renderCurrentPage = () => {
    switch(currentPage) {
      case 'create':
        return <CreateAccount />;
      case 'search':
        return <SearchAccount />;
      case 'showAll':
        return <ShowAccount />;
      case 'deposit':
        return <Deposit />;
      case 'withdraw':
        return <Withdraw />;
      default:
        return (
          <div className="menu-container">
            <h1 className="welcome-title">Welcome to SecureBank Pro</h1>
            <p className="welcome-subtitle">Choose from our banking services below</p>
            
            <div className="menu-grid">
              <div className="menu-card" onClick={() => setCurrentPage('create')}>
                <div className="menu-icon">🏦</div>
                <h3 className="menu-title">Create Account</h3>
                <p className="menu-description">Open a new bank account with us. Quick and secure registration process.</p>
                <button className="menu-btn">Create New Account</button>
              </div>
              
              <div className="menu-card" onClick={() => setCurrentPage('search')}>
                <div className="menu-icon">🔍</div>
                <h3 className="menu-title">Search Account</h3>
                <p className="menu-description">Find and view details of a specific account by account number.</p>
                <button className="menu-btn">Search Account</button>
              </div>
              
              <div className="menu-card" onClick={() => setCurrentPage('showAll')}>
                <div className="menu-icon">📋</div>
                <h3 className="menu-title">All Accounts</h3>
                <p className="menu-description">View all registered accounts in our banking system.</p>
                <button className="menu-btn">View All Accounts</button>
              </div>
              
              <div className="menu-card" onClick={() => setCurrentPage('deposit')}>
                <div className="menu-icon">💰</div>
                <h3 className="menu-title">Deposit Money</h3>
                <p className="menu-description">Add funds to your account safely and instantly.</p>
                <button className="menu-btn">Deposit Amount</button>
              </div>
              
              <div className="menu-card" onClick={() => setCurrentPage('withdraw')}>
                <div className="menu-icon">💳</div>
                <h3 className="menu-title">Withdraw Money</h3>
                <p className="menu-description">Withdraw funds from your account securely.</p>
                <button className="menu-btn">Withdraw Amount</button>
              </div>
            </div>
          </div>
        );
    }
  };

  return (
    <div className="App">
      {/* Bank Header */}
      <header className="bank-header">
        <div className="bank-header-content">
          <div className="bank-logo" onClick={() => setCurrentPage('menu')} style={{cursor: 'pointer'}}>
            <div className="logo-icon">₹B</div>
            <div>
              <h1 className="bank-name">SecureBank Pro</h1>
              <p className="bank-tagline">Your Trust, Our Priority</p>
            </div>
          </div>
          <nav className="bank-nav">
            <a href="#" className="nav-item" onClick={() => setCurrentPage('menu')}>Home</a>
            <a href="#" className="nav-item" onClick={() => setCurrentPage('showAll')}>Accounts</a>
            <a href="#" className="nav-item">Services</a>
            <a href="#" className="nav-item">Support</a>
          </nav>
        </div>
      </header>

      {/* Main Content */}
      <div className="main-content">
        {currentPage !== 'menu' && (
          <button className="back-btn" onClick={() => setCurrentPage('menu')}>
            ← Back to Menu
          </button>
        )}
        {renderCurrentPage()}
      </div>
    </div>
  );
}

export default App;
