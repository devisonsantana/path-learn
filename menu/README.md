# Menu

A simple React application that displays a restaurant menu with category-based filtering.

## About

The application initially displays all menu items from a local JavaScript dataset.

The available categories are generated dynamically from the menu data using `map()` and `Set`, with an **All** category added to display the complete menu.

When a category button is clicked, the application filters the menu items based on their category and updates the displayed list.

The menu items are rendered through a reusable `Menu` component, while the category buttons are handled by a separate `Categories` component.

## Features

### Menu List

The `Menu` component receives the current list of items through props and renders each menu item using the `map()` method.

Each item displays:

* image
* title
* price
* description

### Category Filtering

The `Categories` component renders a button for each available category.

Clicking a category calls the `filterItems` function from the `App` component, which filters the original dataset and updates the menu items displayed on the screen.

Selecting **All** resets the menu and displays every item.

### Active Category

The selected category is tracked using the `useState` hook in the `Categories` component.

The active button receives an additional CSS class, allowing the selected category to have a different visual style.

## Concepts Practiced

* React components
* `useState` hook
* Props
* Rendering lists with `map()`
* Conditional rendering with dynamic classes
* Event handling
* Array filtering with `filter()`
* Creating unique values with `Set`
* Dynamic category generation
* State management
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
