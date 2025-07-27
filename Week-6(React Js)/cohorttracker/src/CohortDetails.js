import React from 'react';
import styles from './CohortDetails.module.css';

function CohortDetails(props) {
  const titleStyle = {
    color: props.status === 'ongoing' ? 'green' : 'blue'
  };

  return (
    <div className={styles.box}>
      <h3 style={titleStyle}>Cohort Status: {props.status}</h3>
      <dl>
        <dt>Cohort Name:</dt>
        <dd>{props.name}</dd>

        <dt>Start Date:</dt>
        <dd>{props.startDate}</dd>

        <dt>End Date:</dt>
        <dd>{props.endDate}</dd>
      </dl>
    </div>
  );
}

export default CohortDetails;
