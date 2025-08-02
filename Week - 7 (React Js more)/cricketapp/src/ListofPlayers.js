// src/ListofPlayers.js
import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: 'Virat', score: 85 },
    { name: 'Rohit', score: 92 },
    { name: 'Dhoni', score: 45 },
    { name: 'Hardik', score: 74 },
    { name: 'KL Rahul', score: 66 },
    { name: 'Jadeja', score: 55 },
    { name: 'Shami', score: 30 },
    { name: 'Bumrah', score: 77 },
    { name: 'Ashwin', score: 59 },
    { name: 'Pant', score: 88 },
    { name: 'Surya', score: 98 }
  ];

  // Filter players with score below 70 using arrow function
  const filteredPlayers = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>All Players</h2>
      {players.map((player, index) => (
        <p key={index}>{player.name} - {player.score}</p>
      ))}

      <h2>Players with Score below 70</h2>
      {filteredPlayers.map((player, index) => (
        <p key={index}>{player.name} - {player.score}</p>
      ))}
    </div>
  );
};

export default ListofPlayers;
