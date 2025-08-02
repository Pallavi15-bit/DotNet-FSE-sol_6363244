// src/IndianPlayers.js
import React from 'react';

const IndianPlayers = () => {
  const players = ['Virat', 'Rohit', 'Dhoni', 'Hardik', 'KL Rahul', 'Jadeja'];

  // Destructuring to separate odd and even indexed players
  const oddTeam = players.filter((_, i) => i % 2 !== 0);
  const evenTeam = players.filter((_, i) => i % 2 === 0);

  // Merge arrays using ES6 spread operator
  const T20players = ['Bumrah', 'Surya', 'Pant'];
  const RanjiTrophyPlayers = ['Pujara', 'Iyer', 'Unadkat'];
  const mergedPlayers = [...T20players, ...RanjiTrophyPlayers];

  return (
    <div>
      <h2>Odd Team</h2>
      {oddTeam.map((p, i) => <p key={i}>{p}</p>)}

      <h2>Even Team</h2>
      {evenTeam.map((p, i) => <p key={i}>{p}</p>)}

      <h2>Merged Players</h2>
      {mergedPlayers.map((p, i) => <p key={i}>{p}</p>)}
    </div>
  );
};

export default IndianPlayers;
