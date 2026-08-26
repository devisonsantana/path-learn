# Lorem Ipsum Generator

A simple React application that generates a customizable amount of lorem ipsum paragraphs.

## About

The application loads a list of predefined paragraphs from a local JavaScript dataset (`data.js`).

The user can choose how many paragraphs to generate by typing a number into the input field. Submitting the form slices the dataset and displays the selected paragraphs on the screen.

The project was created to practice controlled inputs, form handling, state management, and input validation in React.

## Features

### Paragraph Amount Input

The number input is controlled by the `count` state.

The `handleChange` function validates the value typed by the user:

* If the amount is greater than the total number of paragraphs available in the dataset, it is capped at the dataset's length.
* If the amount is zero or negative, it defaults back to `1`.

### Generate Paragraphs

Submitting the form triggers the `handleSubmit` function, which prevents the default form behavior and updates the `text` state with a slice of the dataset based on the selected amount.

The resulting paragraphs are rendered using the `map()` method.

## Concepts Practiced

* React components
* `useState` hook
* Controlled inputs
* Form handling
* Event handling
* Input validation
* Rendering lists with `map()`
* Array manipulation with `slice()`
* State management

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
