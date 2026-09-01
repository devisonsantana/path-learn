# Expense Tracker

A simple React application that tracks income and expenses using global state management and local storage persistence.

## About

The application allows the user to add and delete transactions, automatically calculating the total balance, income, and expenses.

The transaction data is managed globally using React's **Context API** combined with the **`useReducer`** hook, so any component in the app can access or update the transactions without passing props manually through multiple levels.

The state is also persisted to **`localStorage`**, so transactions remain saved even after refreshing the page.

## Features

### Global State Management

The **`GlobalContext`** and **`GlobalProvider`** (created with `createContext` and `useReducer`) hold the application's state and expose `addTransaction` and `deleteTransaction` functions to any component wrapped by the provider.

The **`AppReducer`** function defines how the state changes in response to dispatched actions:

- `ADD_TRANSACTION` adds a new transaction to the list.
- `DELETE_TRANSACTION` removes a transaction by its `id`.

Both actions update `localStorage` to keep the saved data in sync with the current state.

### Balance, Income and Expenses

The **`Balance`** component calculates the total balance by summing all transaction amounts.

The **`IncomeExpenses`** component separates positive and negative amounts using `reduce()`, displaying the total income and total expenses independently.

### Add Transaction

The **`AddTransaction`** component uses controlled inputs to capture a transaction's text and amount.

On submit, a new transaction object is created with a unique `id` (using `crypto.randomUUID()`) and passed to `addTransaction` through the global context.

### Transaction List

The **`TransactionList`** component renders each transaction using the reusable **`Transaction`** component, iterating through the data with `map()`.

Each transaction displays its amount with a `+` or `-` sign depending on whether it's income or an expense, along with a delete button to remove it from the list.

## Concepts Practiced

- React components
- Context API
- `useReducer` hook
- `useContext` hook
- `useState` hook
- Controlled inputs
- Form handling
- Event handling
- Rendering lists with `map()`
- Array manipulation with `reduce()` and `filter()`
- State management
- `localStorage` persistence
- Component organization
- Props

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
