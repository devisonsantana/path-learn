# Tour Website

A simple React application that displays a list of tourist destinations fetched from an external API.

## About

The application fetches tour data from the [React Tours API](https://course-api.com/react-tours-project) when the page is loaded.

If the API request fails, the application falls back to a local dataset located at `src/assets/data.js`, allowing the application to continue working even when the external API is unavailable.

The application uses React state to manage the loading state, tour data, and user interactions.

## Features

### Tour List

The `Tours` component receives the list of tours and the `removeTour` function from the `App` component and passes the necessary data down to each `Tour` component.

Prop drilling between these components is intentional, as this project was created to practice passing data and functions through component props.

### Read More / Show Less

Tour descriptions are initially truncated to 200 characters using `substring(0, 200)`.

The **Read More** button expands the description, while **Show Less** restores the truncated version.

### Remove Tours

Each tour has a **Not Interested** button that removes the selected tour from the list.

When there are no tours remaining, the application displays a **No Tours Left** message along with a **Refresh** button.

Clicking **Refresh** fetches the tour data again using the same `fetchTours` function used by the `useEffect` hook.

### Loading State

While the application is fetching the data, the `Loading` component is displayed using the `isLoading` state.

## Concepts Practiced

* React components
* `useState`
* `useEffect`
* Props and prop drilling
* Conditional rendering
* Fetching data from an API
* Error handling and fallback data
* Loading states
* Array manipulation
* Event handling
* Component composition

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
