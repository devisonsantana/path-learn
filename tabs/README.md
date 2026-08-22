# Tabs

A simple React application that displays professional experience through an interactive tab-based interface.

## About

The application fetches job experience data from an external API and displays the information dynamically.

Each company is represented by a button that allows the user to switch between different experiences. The selected company determines which job title, dates, company name, and responsibilities are displayed.

If the API request fails, the application uses a local JavaScript dataset as a fallback, ensuring that the content can still be displayed.

The project was created to practice state management, API requests, conditional rendering, event handling, and dynamic content rendering in React.

## Features

### Experience Tabs

The application renders a button for each company using the data returned by the API.

Clicking a company button updates the selected experience and displays its corresponding information.

The currently selected company receives an active CSS class to provide visual feedback.

### Job Information

The selected experience displays:

- job title
- company name
- employment dates
- list of responsibilities

Each responsibility is rendered dynamically using the `map()` method and includes an arrow icon from `react-icons`.

### API Integration

The application uses the `fetch()` API to retrieve the job experience data from an external endpoint.

The `useEffect` hook is used to make the request when the component is mounted.

If the request fails, the application falls back to a local dataset, providing a reliable alternative to the external API.

### Loading State

While the application is fetching the data, a loading message is displayed.

The loading state is controlled using the `useState` hook and is updated after the API request finishes, whether it succeeds or fails.

## Concepts Practiced

- React components
- `useState` hook
- `useEffect` hook
- Props and dynamic data
- Rendering lists with `map()`
- Conditional rendering
- Dynamic CSS classes
- Event handling
- API requests with `fetch()`
- Async/await
- Error handling with `try/catch`
- Loading states
- Fallback data
- State management
- Working with external APIs
- Using `react-icons`

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