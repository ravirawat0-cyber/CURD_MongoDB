# UserInfoController API Documentation

## Description
This API provides endpoints to manage user information. It supports operations such as retrieving all users, retrieving a user by ID, creating a new user, updating an existing user, and deleting a user.

## Endpoints

### GET /api/UserInfo
- **Description**: Retrieves all users.
- **Response**: Returns a list of all users.
- **Possible HTTP Status Codes**:
  - 200 OK: Successful operation.
  - 500 Internal Server Error: If there's a server-side issue.

### GET /api/UserInfo/{id}
- **Description**: Retrieves a user by ID.
- **Parameters**:
  - `id` (string, required): The ID of the user to retrieve. Must be 24 characters long.
- **Response**: Returns the user with the specified ID.
- **Possible HTTP Status Codes**:
  - 200 OK: Successful operation.
  - 404 Not Found: If the user with the specified ID does not exist.
  - 500 Internal Server Error: If there's a server-side issue.

### POST /api/UserInfo
- **Description**: Creates a new user.
- **Request Body**:
  ```json
  {
    "Name": "string",
    "Age": 0,
    "Address": "string"
  }
