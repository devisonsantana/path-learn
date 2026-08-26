# Task Tracker

- TODO: Description about Task Tracker

## Guide for Development

| features                                | done |
| --------------------------------------- | ---- |
| readme description about project        | no   |
| user interactivity within console       | yes  |
| **`list`** command                      | no   |
| **`add`** command                       | no   |
| **`edit`** command                      | no   |
| **`del`** command                       | no   |
| **`exit`** command                      | yes  |
| **`help`** command showing all commands | no   |

### Models

| Tasks Table     |             |                   |
| --------------- | ----------- | ----------------- |
| **Id**          | **INTEGER** | **`PRIMARY KEY`** |
| **Title**       | **VARCHAR** | **NOT NULL**      |
| **Description** | **TEXT**    | **NULL**          |
| **Position**    | **INTEGER** | **NOT NULL**      |
| **Done**        | **BIT**     | **NOT NULL**      |

| Logs Table      |              |                   |
| --------------- | ------------ | ----------------- |
| **Id**          | **INTEGER**  | **`PRIMARY KEY`** |
| **TaskId**      | **INTEGER**  | **NOT NULL**      |
| **Description** | **VARCHAR**  | **NOT NULL**      |
| **ActionType**  | **ENUM**     | **NOT NULL**      |
| **ActionTime**  | **DATETIME** | **NOT NULL**      |
