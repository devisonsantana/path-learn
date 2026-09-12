# File Uploader

A simple full-stack file upload application with a Node.js and Express API and a React client.

## About

The application allows users to select a file in the React interface and upload it to a local Express server.

The client sends the file as `multipart/form-data` using Axios, while the server processes the upload with the `express-fileupload` middleware and stores the file in the client's public uploads directory.

After a successful upload, the application displays the uploaded file name and renders the uploaded image in the interface.

This project was created to practice building a simple API, handling file uploads, connecting a React frontend to an Express backend, and displaying upload progress.

## Features

### File Selection

The React client provides a file input that allows the user to select a file from their device.

The selected file name is displayed in the form before the upload begins.

### File Upload API

The Express server exposes a `POST /upload` endpoint that receives the file from the client.

The endpoint returns a bad request response when no file is provided, moves valid files to `client/public/uploads`, and returns the file name and public path after a successful upload.

### Upload Progress

The client uses Axios upload progress events to calculate and display the current upload percentage with a Bootstrap progress bar.

### Status Messages

The interface displays feedback messages for successful uploads, missing files, and server errors through a reusable `Message` component.

### Uploaded File Preview

After the server responds successfully, the uploaded file name and image are rendered in the React application using the returned file path.

### Client and Server Separation

The project separates the application into a Node.js server at the project root and a Vite-powered React client inside the `client` directory.

During development, Vite proxies requests from `/upload` to the Express server running on port `8000`.

## Concepts Practiced

* Node.js and Express
* REST API endpoints
* File uploads with `express-fileupload`
* React components
* `useState` hook
* Controlled UI state
* Form handling
* `FormData` and multipart requests
* Axios HTTP requests
* Upload progress events
* Conditional rendering
* Error handling
* Vite proxy configuration
* Bootstrap styling
* Client and server organization

## Getting Started

Install the server dependencies from the project root:

```bash
npm install
```

Install the client dependencies:

```bash
cd client
npm install
```

Start the Express server from the project root:

```bash
npm start
```

In a second terminal, start the React development server:

```bash
cd client
npm run dev
```

The React application will be available at `http://localhost:5000`, while the Express API runs on port `8000`.
