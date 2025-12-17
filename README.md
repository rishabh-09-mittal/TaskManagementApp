# Task Management Application

## Overview
This is a Task Management application built using ASP.NET Core MVC and SQL Server.
It allows users to create, read, update, delete and search tasks.

## Technology Stack
- ASP.NET Core MVC
- C#
- SQL Server
- Entity Framework Core
- Bootstrap
- GitHub

## Database Design
### Tables
- Users
- Tasks

### ER Diagram
Users (1) → (M) Tasks

### Indexes
- Primary Key on TaskId
- Index on Status for faster search

### Approach
Code First approach using Entity Framework Core was used to allow faster development and easier schema evolution.

## Application Structure
- MVC server side rendering
- Razor views for UI
- Controllers handle CRUD operations

## Build & Run
1. Clone repository
2. Update connection string
3. Run migrations
4. `dotnet run`
