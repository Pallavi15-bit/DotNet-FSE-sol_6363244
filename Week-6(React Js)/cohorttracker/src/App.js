import React from 'react';
import CohortDetails from './CohortDetails';

function App() {
  return (
    <div className="App">
      <h1>My Academy - Cohort Dashboard</h1>

      <CohortDetails
        name="React Bootcamp"
        startDate="2025-07-01"
        endDate="2025-08-15"
        status="ongoing"
      />

      <CohortDetails
        name="DevOps Essentials"
        startDate="2025-06-01"
        endDate="2025-07-10"
        status="completed"
      />
    </div>
  );
}

export default App;
