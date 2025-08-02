// src/OnlineShopping.js
import React, { Component } from 'react';
import Cart from './Cart';

class OnlineShopping extends Component {
  render() {
    const cartItems = [
      { itemname: 'T-shirt', price: 500 },
      { itemname: 'Jeans', price: 1200 },
      { itemname: 'Shoes', price: 2500 },
      { itemname: 'Cap', price: 300 },
      { itemname: 'Watch', price: 1500 },
    ];

    return (
      <div>
        <h2>Online Shopping Cart</h2>
        {cartItems.map((item, index) => (
          <Cart key={index} itemname={item.itemname} price={item.price} />
        ))}
      </div>
    );
  }
}

export default OnlineShopping;
