// src/App.js
import React from 'react';

function App() {
  // Office space object
  const office = {
    name: 'Skyline Tech Park',
    rent: 55000,
    address: 'HSR Layout, Bangalore'
  };

  // Array of office spaces
  const officeSpaces = [
    {
      name: 'Skyline Tech Park',
      rent: 55000,
      address: 'HSR Layout, Bangalore',
      image: 'https://via.placeholder.com/200x100?text=Skyline'
    },
    {
      name: 'Eco Space',
      rent: 65000,
      address: 'Bellandur, Bangalore',
      image: 'https://via.placeholder.com/200x100?text=Eco+Space'
    },
    {
      name: 'Manyata Tech Park',
      rent: 70000,
      address: 'Hebbal, Bangalore',
      image: 'https://via.placeholder.com/200x100?text=Manyata'
    }
  ];

  return (
    <div style={{ textAlign: 'center', fontFamily: 'Arial' }}>
      {/* JSX Heading */}
      <h1>🏢 Office Space Rental</h1>

      {/* Office image and single office object */}
      <h2>Featured Office</h2>
      <img
        src="https://via.placeholder.com/300x150?text=Featured+Office"
        alt="Featured Office"
        style={{ border: '2px solid #ccc' }}
      />
      <p><strong>Name:</strong> {office.name}</p>
      <p><strong>Rent:</strong> ₹{office.rent}</p>
      <p><strong>Address:</strong> {office.address}</p>

      <hr />

      {/* List of Offices */}
      <h2>Available Offices</h2>
      {officeSpaces.map((space, index) => (
        <div
          key={index}
          style={{
            border: '1px solid #ddd',
            margin: '10px auto',
            width: '300px',
            padding: '10px'
          }}
        >
          <img src={space.image} alt={space.name} style={{ width: '100%' }} />
          <h3>{space.name}</h3>
          <p><strong>Address:</strong> {space.address}</p>
          <p
            style={{
              color: space.rent < 60000 ? 'red' : 'green',
              fontWeight: 'bold'
            }}
          >
            Rent: ₹{space.rent}
          </p>
        </div>
      ))}
    </div>
  );
}

export default App;
