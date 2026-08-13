# Reviews

A simple React application that displays reviews from a local JavaScript dataset.

## About

The application displays one review at a time, showing the person's image, name, job, and review text.

The review data is imported from `src/data.js`, and React's `useState` hook is used to keep track of the currently displayed review.

The application allows the user to navigate between reviews or select a random review.

## Features

### Review Navigation

The **Previous** and **Next** buttons allow the user to navigate through the available reviews.

The navigation is circular, meaning that going past the last review returns to the first one, and going before the first review returns to the last one.

### Random Review

The **Surprise Me** button selects a random review from the dataset.

The current review is excluded from the random selection so that clicking the button results in a different review.

## Concepts Practiced

- React components
- `useState` hook
- Rendering data dynamically
- Destructuring
- Props and component organization
- Array manipulation
- Event handling
- Conditional logic

## Getting Started

Clone the repository and install the dependencies:

```bash
npm install
```

Start the development server:

```bash
npm run dev
```

The application will then be available at the local development URL provided by Vite.
