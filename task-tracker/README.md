# Task Tracker

A simple console application built with C# and raw ADO.NET that manages a list of tasks, allowing them to be created, edited, reordered, completed, and deleted, while keeping a full history of every action performed.

## About

The application stores tasks in a local SQLite database, accessed directly through `Microsoft.Data.Sqlite` using raw SQL commands instead of an ORM like Entity Framework.

Each task has a title, a position, and a completion status. Tasks can be reordered by position, and every action performed on a task (creation, edit, move, completion, deletion) is recorded in a `Logs` table, creating a full history of changes.

The project follows a layered architecture, separating the application into `Models`, `Repositories`, and `Services`, with interfaces used to abstract each layer and enable dependency injection through constructor parameters.

The project was created to practice writing raw SQL in C# with ADO.NET, implement reordering logic based on numeric positions, and apply dependency injection and abstraction through interfaces.

## Features

### Task Management

The application supports adding, editing, completing/reopening, and deleting tasks through simple console commands.

Each task is identified by an auto-incremented `Id` and displayed along with its current position and completion status.

### Reordering by Position

Tasks can be moved to a new position using the `mv` command.

When a task is moved, all tasks between its old and new position are shifted up or down accordingly, keeping the position values sequential and consistent.

The `Move` method returns a distinct result for three possible outcomes: task not found, task moved successfully, or task already in the requested position, without needing to introduce an extra type just to represent that.

### Action History (Logs)

Every action performed on a task (created, edited, moved, completed, reopened, deleted) generates a log entry with a description, an action type, and a timestamp.

Logs can be listed globally or filtered by task ID using the `logs` command.

### Raw SQL with ADO.NET

All database access is done through `SqliteCommand` objects with parameterized queries, without using an ORM.

Operations that involve multiple related updates, such as inserting a task and shifting positions, or moving a task and updating the affected range, are wrapped in transactions to keep the data consistent.

### Database Migration

On startup, the application ensures the required tables (`Tasks` and `Logs`) exist by running a migration method that creates them if they don't already exist.

### Layered Architecture and Dependency Injection

The application is split into `Repositories` (data access) and `Services` (business logic), each defined behind an interface (`ITaskRepository`, `ILogRepository`, `ITaskService`, `ILogService`).

Dependencies are injected through constructors, so the `TaskService` depends on `ITaskRepository` and `ILogService` without knowing their concrete implementations.

## Concepts Practiced

- ADO.NET with `Microsoft.Data.Sqlite`
- Raw SQL queries (no ORM)
- Parameterized queries
- Transactions
- Reordering logic based on numeric positions
- Dependency injection through constructors
- Interfaces and abstraction
- Layered architecture (Models, Repositories, Services)
- Enums for categorizing actions
- Database migrations
- Console application input handling
- Error handling and input validation

## Getting Started

Clone the repository and restore the dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

Once running, type `help` to see the list of available commands.