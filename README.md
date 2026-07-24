# Student Management System

## Project Description

The Student Management System is a simple ASP.NET Core Web API project that performs CRUD (Create, Read, Update, Delete) operations on student records. It also includes JWT Authentication and Authorization to secure the APIs.

## Features

- Register User
- User Login with JWT Authentication
- Get All Students
- Get Student By Id
- Add New Student
- Update Student Details
- Delete Student
- Input Validation
- Unique Email Validation
- Exception Handling
- Swagger API Documentation

## Technologies Used

- ASP.NET Core Web API
- C#
- .NET 8
- JWT Authentication
- Swagger (OpenAPI)

## Project Structure

```
Zest_Project
│
├── Controllers
│   ├── AuthController.cs
│   └── StudentController.cs
│
├── Models
│   ├── Student.cs
│   ├── LoginModel.cs
│   └── RegisterModel.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

## API Endpoints

### Authentication

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/auth/register | Register a new user |
| POST | /api/auth/login | Login and generate JWT Token |

### Student APIs

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/student | Get all students |
| GET | /api/student/{id} | Get student by Id |
| POST | /api/student | Add new student |
| PUT | /api/student/{id} | Update student |
| DELETE | /api/student/{id} | Delete student |

## Validation

- Required Fields
- Email Format Validation
- Unique Email Validation
- Age Validation
- Password Validation

## Exception Handling

- Invalid Login
- Student Not Found
- Duplicate Email
- Duplicate Student Id
- Internal Server Error

## How to Run

1. Clone the repository.
2. Open the project in Visual Studio.
3. Restore NuGet packages.
4. Build the solution.
5. Run the project.
6. Open Swagger:
   ```
   https://localhost:<port>/swagger
   ```
7. Register a user.
8. Login to get the JWT token.
9. Click **Authorize** in Swagger and enter:
   ```
   Bearer <your_token>
   ```
10. Test the Student CRUD APIs.
