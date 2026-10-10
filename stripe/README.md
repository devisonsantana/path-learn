# Stripe Navigation

A React and TypeScript application featuring a responsive, Stripe-inspired navigation bar with interactive mega-menu and sidebar navigation.

## About

The application presents a landing page for an online payments platform, with a navigation bar organized into **Products**, **Developers**, and **Company** sections.

Hovering over a category opens a contextual submenu positioned beneath the selected navigation item. On smaller screens, a menu button opens a sidebar containing the available categories and links.

Navigation state is shared across the components through React Context, while the menu content is defined in a local data module.

This project was created to practice responsive navigation patterns, shared state management, event handling, refs, and TypeScript with React.

## Features

### Interactive Mega Menu

Hovering over a top-level navigation category displays its related links in a submenu.

The submenu is positioned relative to the selected category and adjusts its column layout based on the number of links in that section. Moving away from the navigation closes the submenu.

### Responsive Sidebar

A menu button opens a sidebar containing the navigation categories and their links. A close button dismisses the sidebar.

### Data-Driven Navigation

Category names, link labels, URLs, and icons are stored in a local data module and rendered dynamically in both the submenu and sidebar.

### Shared UI State

The `AppProvider` manages sidebar and submenu visibility, the selected category, and submenu positioning. Components access these values and actions through a custom `useGlobalContext` hook.

### Landing Page Hero

The page includes a hero section with introductory text, a call-to-action button, and an accompanying illustration.

## Concepts Practiced

* React components
* TypeScript with React
* Context API
* Custom hooks
* `useState`, `useEffect`, and `useRef` hooks
* Event handling
* Conditional rendering and dynamic classes
* Data-driven rendering with `map()`
* Responsive navigation patterns
* Dynamic positioning and layout
* Component organization

## Getting Started

Install the dependencies:

```bash
npm install
```

Start the development server:

```bash
npm run dev
```

The application will then be available at the local development URL provided by Vite.
