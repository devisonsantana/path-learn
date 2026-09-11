# Grocery Bud

A simple React application that helps users manage a grocery shopping list.

## About

The app allows users to add items to a shopping list, edit existing entries, remove individual items, or clear the entire list.

The project uses React state to manage the list and form input, and it persists the data in `localStorage` so the items remain available even after refreshing the page.

This project was created to practice form handling, state management, conditional rendering, event handling, and local persistence in React.

## Features

### Add Items

Users can type a grocery item into the input field and submit it to add it to the list.

The form includes validation so an empty value cannot be submitted, and a success or error message is displayed through an alert component.

### Edit Items

Each item in the list includes an Edit button.

When the user clicks edit, the item text is loaded back into the form, allowing them to update the value and save the changes.

### Delete and Clear

Each grocery item has a Delete button to remove it individually.

If the list contains items, a Clear Items button is displayed to remove the entire list at once.

### Alerts

The app shows temporary alert messages for actions such as:

* item added
* item removed
* value changed
* empty list
* invalid input

These alerts automatically disappear after a short delay.

### Local Storage Persistence

The shopping list is stored in `localStorage` using the `useEffect` hook.

This means the list persists between page reloads and continues to reflect the most recent user changes.

## Concepts Practiced

* React components
* `useState` hook
* `useEffect` hook
* Controlled inputs
* Form handling
* Event handling
* Conditional rendering
* Array methods (`map`, `filter`)
* State updates
* Local storage persistence
* UI feedback with alerts
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

