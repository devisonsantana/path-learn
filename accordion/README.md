# Accordion

A simple React application that displays a list of frequently asked questions using an accordion interface.

## About

The application loads a list of questions from a local JavaScript dataset and renders each question through a reusable `Question` component.

Each question has its own state to control whether its answer is visible or hidden.

The project was created to practice state management, conditional rendering, props, and event handling in React.

## Features

### Question List

The `App` component renders the questions from the local dataset using the `map()` method.

Each question is passed to the reusable `Question` component using props.

### Expand and Collapse

Clicking the button next to a question toggles its answer.

The **plus** icon is displayed when the answer is hidden, while the **minus** icon is displayed when the answer is visible.

Multiple questions can be expanded at the same time.

## Concepts Practiced

* React components
* `useState` hook
* Props
* Rendering lists with `map()`
* Conditional rendering
* Event handling
* Spread props
* Component organization
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
