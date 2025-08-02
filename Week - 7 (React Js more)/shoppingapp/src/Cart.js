// src/Cart.js
import React, { Component } from 'react';

class Cart extends Component {
  render() {
    const { itemname, price } = this.props;
    return (
      <div style={{ border: '1px solid black', margin: '10px', padding: '10px' }}>
        <h3>Item: {itemname}</h3>
        <p>Price: ₹{price}</p>
      </div>
    );
  }
}

export default Cart;
