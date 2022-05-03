import React from 'react';
import logo from './logo.svg';
import './App.css';
import { CandidateList } from './candidate/components/candidate-list';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <CandidateList />
      </header>
    </div>
  );
}

export default App;
