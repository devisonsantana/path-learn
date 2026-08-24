# Slider

A simple React application that displays a set of reviews using a sliding carousel interface.

## About

The application displays one review at a time and allows the user to navigate between reviews using the **Previous** and **Next** buttons.

The slider also changes automatically every five seconds using **`useEffect`** and **`setInterval`**.

The project was initially developed with all the functionality inside the **`App`** component. After the main features were completed, the code was refactored by separating the application into reusable **`Slider`** and **`Card`** components while maintaining the same functionality.

The slider uses CSS classes to control the position and visibility of each review, creating the sliding animation between the current, previous, and next slides.

## Features

### Review Slider

The **`Slider`** component renders the reviews from the local dataset using the **`map()`** method.

Each review is passed to the reusable **`Card`** component through props.

The current review is tracked using the **`index`** state.

### Previous and Next Navigation

The **Previous** and **Next** buttons update the current index and allow the user to navigate through the reviews.

When reaching the beginning or end of the dataset, the index is automatically adjusted to create a circular navigation.

### Automatic Sliding

The slider automatically changes to the next review every five seconds using **`setInterval`**.

The interval is recreated whenever the current index changes and is cleared when the component is unmounted to avoid leaving active timers.

### Component Refactoring

After implementing the functionality in the **`App`** component, the application was refactored into smaller components:

- **`App`** manages the main state and slider behavior.
- **`Slider`** handles the review list, slide positions, and navigation buttons.
- **`Card`** displays the information for each review.

This refactoring helped practice component organization and passing data and functions through props.

## Concepts Practiced
- React components
- **`useState`** hook
- **`useEffect`** hook
- Props
- Rendering lists with `map()`
- Event handling
- Conditional logic
- Automatic state updates
- **`setInterval`**
- Cleanup functions
- Component refactoring
- Component organization
- CSS transitions and animations
- Managing component state

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