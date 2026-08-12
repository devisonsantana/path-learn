# Birthday Reminder

A simple React application that displays a list of birthdays using data from a local JavaScript file.

## About

The application loads the birthday data from `src/data/data.js` and uses React's `useState` hook to manage and display the list on the screen.

The birthday entries are rendered through a reusable `List` component. The data is iterated using the `map()` method, displaying properties such as:

* `id`
* `name`
* `age`
* `image`

The **Clear All** button removes all birthday entries by updating the state to an empty array.

## Concepts Practiced

* React components
* `useState` hook
* Rendering lists with `map()`
* Props
* Event handling
* State management
* Array manipulation
* Component organization

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
