# .NET Core Web API – CRUD with JWT Authentication and Authorization

This project is a secure .NET 8 Web API application that enables CRUD operations on Employee data, protected with JWT-based authentication and authorization. It demonstrates how to build a real-world API with secure login, token revocation, and MySQL database integration.

---
# Project Description

This project implements a RESTful API in .NET 8 that demonstrates:

User authentication with JWT tokens

Role-based API authorization

Secure token validation and revocation using the jti claim

Database access via Entity Framework Core with MySQL

Clean service registration using IDbContextFactory

Developer-friendly API testing using Swagger with JWT support

This makes the project an ideal boilerplate for secure backend applications.
---

## 🔐 Features

✅ JWT Authentication and Role-based Authorization

✅ MySQL Database Integration using Entity Framework Core

✅ Secure Login and Token Revocation via jti claim

✅ Swagger UI with Bearer Token Support

✅ RESTful CRUD Endpoints for Employee Management

✅ Clean Architecture using IDbContextFactory to resolve scoped lifetime issues

---

## 🏗️ Tech Stack

- .NET 8
- Entity Framework Core
- MySQL 8+
- JWT (JSON Web Token)
- Swagger / Swashbuckle
- Visual Studio or VS Code

---

## 📁 Project Structure

DotNetCoreWebAPIAuthJWT/
├── Controllers/
│ ├── AuthController.cs
│ └── EmployeeController.cs
├── Models/
│ ├── AppDbContext.cs
│ ├── Employee.cs
│ ├── User.cs
│ └── RevokedToken.cs
├── Services/
│ ├── ITokenValidator.cs
│ └── TokenValidator.cs
├── Program.cs
├── appsettings.json
└── README.md

## 1. Clone the Repository

git clone https://github.com/yourusername/DotNetCoreWebAPIAuthJWT.git
cd DotNetCoreWebAPIAuthJWT

---

## 2. Configure Database

Update the MySQL connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=jwt_demo;user=root;password=;"
}

---

## 3. Apply Migrations and Create Database

dotnet ef migrations add InitialCreate
dotnet ef database update

---

## 4. Run the Application

dotnet run

---


## 5. Access Swagger UI

Navigate to: https://localhost:{port}/swagger

---

## 6. JWT Authentication Flow

Register a user manually in the Users table with a hashed password
Use /api/auth/login to get a JWT token

Click Authorize in Swagger and enter:
Bearer <your-token-here>

---

## 7. Notes

Users must be registered manually in the Users table.

Passwords should be securely hashed (e.g., using BCrypt).

JWT tokens include a jti claim to support token revocation.

Swagger UI is secured and supports Bearer tokens for testing authenticated endpoints.

---