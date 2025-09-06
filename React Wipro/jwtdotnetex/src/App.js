import logo from './logo.svg';
import './App.css';
import Login from './components/login/login';
import Protected from './components/protected/protected';

function App() {
  return (
    <div className="App">
      <Login /> <hr/>
      <Protected />
    </div>
  );
}

export default App;