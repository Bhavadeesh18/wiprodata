import logo from './logo.svg';
import './App.css';
import Login from "./components/login/login"
import Protected from './components/login/protected';

function App() {
  return (
    <div className="App">
      <Login /> <br/><hr/>
      <Protected />
    </div>
  );
}

export default App;