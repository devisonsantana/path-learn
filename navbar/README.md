# Navbar

A simple React application that creates a responsive navigation bar with a mobile menu toggle, navigation links, and social media icons.

## About

The app displays a navigation bar with a logo, a list of page links, and a set of social icons positioned on the right side of the header.

When the screen is narrow, the navigation links collapse behind a hamburger button and expand or shrink dynamically based on the current state.

This project was created to practice responsive UI design, conditional rendering, hooks, refs, and dynamic sizing in React.

## Features

### Responsive Navigation

The navbar contains a header area with a logo and a toggle button for smaller screens.

The mobile menu is controlled with the `useState` hook, allowing links to expand and collapse when the user clicks the menu button.

### Dynamic Link Container

The menu container uses a `ref` to calculate the height of the links list and updates the container style based on whether the menu is open or closed.

This creates a smooth expandable effect without manually hardcoding the menu height.

### Social Media Icons

The navigation bar includes social icons imported from `react-icons`.

These icons are stored in a data array and rendered dynamically using `map()`, making the component easier to maintain and extend.

### Reusable Data Structure

The app organizes the navigation items and social links in a `data.jsx` file, keeping the component clean and separating the content from the logic.

## Concepts Practiced

* React components
* `useState` hook
* `useRef` hook
* `useEffect` hook
* Props
* Rendering lists with `map()`
* Conditional rendering
* Dynamic styles
* Responsive design
* Reusable data-driven UI
* Component organization
* Icon integration

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

