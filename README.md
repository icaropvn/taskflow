# TaskFlow – .NET Study Project

TaskFlow is a **.NET 9 (C#)** study project built to improve my abilities and familiarity with backend development, REST APIs, messaging with Amazon SQS, logging & monitoring (Serilog + CloudWatch), Docker containerization, and cloud deployment on AWS App Runner.

## 🚀 How to Run

Clone the repository and run the API locally:

```bash
# restore dependencies
dotnet restore

# run the API (port 5000)
ASPNETCORE_URLS=http://localhost:5000 dotnet run --project TaskFlow.Api
```

Once running, open Swagger UI at: [http://localhost:5000/swagger](http://localhost:5000/swagger)

## 📌 Available Routes

| Method | Endpoint           | Description             | Response Codes                        |
|--------|-------------------|-------------------------|---------------------------------------|
| GET    | `/api/tasks`      | Get all tasks           | 200 OK                                |
| GET    | `/api/tasks/{id}` | Get task by ID          | 200 OK, 404 Not Found                 |
| POST   | `/api/tasks`      | Create a new task       | 201 Created, 400 Bad Request          |
| PUT    | `/api/tasks/{id}` | Update an existing task | 200 OK, 400 Bad Request, 404 Not Found |
| DELETE | `/api/tasks/{id}` | Delete a task by ID     | 204 No Content, 404 Not Found         |

## 📂 DTOs

### TaskCreateDto (Request – POST)
```json
{
  "title": "Study .NET",
  "description": "Practice CRUD operations"
}
```

### TaskUpdateDto (Request – PUT)
```json
{
  "title": "Study .NET",
  "description": "Practice validation rules",
  "status": "InProgress"
}
```

⚠️ status must be one of: Pending, InProgress, Done.

### TaskViewDto (Response)
```json
{
  "id": 1,
  "title": "Study .NET",
  "description": "Practice CRUD operations",
  "status": "Pending",
  "createdAt": "2025-09-02T14:30:00Z",
  "updatedAt": null
}
```