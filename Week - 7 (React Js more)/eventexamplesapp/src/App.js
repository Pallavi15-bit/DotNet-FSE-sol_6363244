// src/App.js
import React, { Component } from 'react';
import CurrencyConvertor from './CurrencyConvertor';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      counter: 0,
      clickedMessage: '',
    };
  }

  incrementCounter = () => {
    this.setState({ counter: this.state.counter + 1 });
  };

  sayHello = () => {
    alert("Hello! Have a nice day!");
  };

  incrementAndGreet = () => {
    this.incrementCounter();
    this.sayHello();
  };

  decrementCounter = () => {
    this.setState({ counter: this.state.counter - 1 });
  };

  sayWelcome = (message) => {
    alert(message);
  };

  handleSyntheticClick = (e) => {
    e.preventDefault(); // Synthetic event
    this.setState({ clickedMessage: 'I was clicked' });
  };

  render() {
    return (
      <div style={{ padding: '20px' }}>
        <h1>Event Handling in React</h1>

        <h2>Counter: {this.state.counter}</h2>

        <button onClick={this.incrementAndGreet}>Increment</button>{' '}
        <button onClick={this.decrementCounter}>Decrement</button>

        <br /><br />
        <button onClick={() => this.sayWelcome('Welcome to React Event Handling!')}>Say Welcome</button>

        <br /><br />
        <button onClick={this.handleSyntheticClick}>Synthetic Event Button</button>
        <p>{this.state.clickedMessage}</p>

        <hr />

        <CurrencyConvertor />
      </div>
    );
  }
}

export default App;
