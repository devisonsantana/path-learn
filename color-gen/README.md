# Color Generator

A simple React application that generates a palette of tints and shades from a selected color using the `values.js` library.

## About

The app allows the user to enter a hexadecimal color and instantly generate a collection of related shades and tones around that base value.

The generated colors are displayed as individual cards, each showing its percentage, hex value, and a copy action.

This project was created to practice working with external packages, form handling, state management, dynamic rendering, and UI interactions in React.

## Features

### Color Input

The `App` component includes a controlled input where the user can type a color value such as `#3ae6cc`.

When the form is submitted, the app validates the value and generates a new palette of colors.

### Palette Generation

The application uses the `Values` class from the `values.js` package to generate a list of related colors based on the chosen base color.

Each palette is calculated using a defined step size, resulting in multiple shades around the original color.

### Copy to Clipboard

Each color card includes a copy icon that triggers a `navigator.clipboard.writeText()` action.

After copying, a temporary alert message is shown to confirm that the color code was successfully copied.

### Dynamic Color Cards

The palette is rendered with `map()`, and each item is passed to the reusable `SingleColor` component.

Each card displays the color weight, the resulting hex code, and the corresponding background color.

## Concepts Practiced

* React components
* `useState` hook
* `useEffect` hook
* Controlled inputs
* Form handling
* Event handling
* Rendering lists with `map()`
* Dynamic styling
* Clipboard API integration
* External library usage
* Conditional rendering
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

