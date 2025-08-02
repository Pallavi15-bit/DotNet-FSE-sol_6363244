// src/App.js
import React, { useState } from 'react';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';

function App() {
  const [selected, setSelected] = useState('book');
  const [showCourse, setShowCourse] = useState(false);

  // Element variable
  let detailComponent;
  if (selected === 'book') {
    detailComponent = <BookDetails />;
  } else if (selected === 'blog') {
    detailComponent = <BlogDetails />;
  }

  // Array mapping (with keys)
  const topics = [
    { id: 1, name: 'React Basics' },
    { id: 2, name: 'JSX and Props' },
    { id: 3, name: 'Hooks and State' }
  ];

  return (
    <div style={{ padding: '20px' }}>
      <h1>🧠 Blogger App</h1>

      <div>
        <button onClick={() => setSelected('book')}>Show Book</button>
        <button onClick={() => setSelected('blog')}>Show Blog</button>
        <button onClick={() => setShowCourse(!showCourse)}>
          {showCourse ? 'Hide' : 'Show'} Course
        </button>
      </div>

      <hr />

      {/* if-else via element variable */}
      {detailComponent}

      {/* Conditional using && operator */}
      {showCourse && <CourseDetails />}

      <hr />

      {/* Conditional Rendering with ternary operator */}
      <h3>{selected === 'book' ? '📘 You selected a Book' : '📰 You selected a Blog'}</h3>

      {/* Using map() with keys */}
      <h4>📌 Topics Covered</h4>
      <ul>
        {topics.map(topic => (
          <li key={topic.id}>{topic.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
