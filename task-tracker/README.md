# Task Tracker

- TODO: Description about Task Tracker

## Guide for Development

| features                                | done |
| --------------------------------------- | ---- |
| readme description about project        | no   |
| user interactivity within console       | yes  |
| **`list`** command                      | yes  |
| **`add`** command                       | yes  |
| **`edit`** command                      | yes  |
| **`del`** command                       | yes  |
| **`exit`** command                      | yes  |
| **`help`** command showing all commands | yes  |

### Models

| Tasks Table  |             |                   |
| ------------ | ----------- | ----------------- |
| **Id**       | **INTEGER** | **`PRIMARY KEY`** |
| **Title**    | **VARCHAR** | **NOT NULL**      |
| **Position** | **INTEGER** | **NOT NULL**      |
| **Done**     | **BIT**     | **NOT NULL**      |

| Logs Table      |              |                   |
| --------------- | ------------ | ----------------- |
| **Id**          | **INTEGER**  | **`PRIMARY KEY`** |
| **TaskId**      | **INTEGER**  | **NOT NULL**      |
| **Description** | **VARCHAR**  | **NOT NULL**      |
| **ActionType**  | **ENUM**     | **NOT NULL**      |
| **ActionTime**  | **DATETIME** | **NOT NULL**      |
