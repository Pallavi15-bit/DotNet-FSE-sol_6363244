import React, { Component } from 'react';
import './Posts.css';

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false
    };
  }

  componentDidMount() {
    this.loadPosts();
  }

  loadPosts() {
    const posts = [
      {
        id: 1,
        title: 'Why React Lifecycle Methods Matter',
        body: 'Lifecycle methods help React components manage setup (like API calls), updates, and clean-up. They give fine control over what happens before and after a component renders.'
      },
      {
        id: 2,
        title: 'Overview of React Lifecycle Hooks',
        body: 'React class components include lifecycle methods like constructor, render, componentDidMount, shouldComponentUpdate, componentDidUpdate, and componentWillUnmount. Error handling is done using componentDidCatch.'
      },
      {
        id: 3,
        title: 'React Component Render Flow: Step-by-Step',
        body: '1. constructor() → 2. render() → 3. componentDidMount() → [State/Props change] → 4. shouldComponentUpdate() → 5. render() → 6. componentDidUpdate() → 7. componentWillUnmount()'
      },
      {
        id: 4,
        title: 'How componentDidMount Works in React',
        body: 'componentDidMount() is called once after the component is added to the DOM. It’s commonly used for fetching data from an API or initializing DOM-dependent logic.'
      },
      {
        id: 5,
        title: 'React Error Handling with componentDidCatch()',
        body: 'componentDidCatch(error, info) is used to handle runtime errors in child components. It prevents the app from crashing and allows you to show fallback UIs or alert messages.'
      }
    ];

    this.setState({ posts });
  }

  componentDidCatch(error, info) {
    alert("An error occurred in the Posts component!");
    this.setState({ hasError: true });
  }

  render() {
    if (this.state.hasError) {
      return <h2>Something went wrong while loading posts.</h2>;
    }

    return (
      <div className="posts-container">
        <h1>📘 React Lifecycle Blog</h1>
        {this.state.posts.map(post => (
          <div key={post.id} className="post-card">
            <h2>{post.title}</h2>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;
