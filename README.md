# SweetDictionary

SweetDictionary is a .NET-based web application designed for managing blog-like data, including posts, categories, comments, and user authentication. This project is implemented in C# and leverages a modular architecture, including Core, Application, Domain, Persistence, and WebAPI layers.

## Features

- **Comprehensive API Endpoints**: Manage authentication, posts, categories, and comments with a RESTful interface.
- **Modular Architecture**: Clear separation of concerns across layers.
- **Scalable Design**: Suitable for enterprise-level applications.
- **Extensibility**: Easily extend the functionality to fit specific use cases.

## Getting Started

### Prerequisites

- .NET 8.0
- Visual Studio 2022 or equivalent IDE
- SQL Server

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/oguzhanoxel/SweetDictionary.git
   cd SweetDictionary
   ```

2. Open the `SweetDictionary.sln` solution file in Visual Studio.

3. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

4. Build the solution:

   ```bash
   dotnet build
   ```

5. Run the application:

   ```bash
   dotnet run --project SweetDictionary.WebApi
   ```

### Configuration

- Modify the `appsettings.json` file in the WebAPI project to configure database connections or other settings.

## Usage

Once the WebAPI is running, you can interact with it using tools like Postman or cURL. Below are some of the key API endpoints:

### Authentication Endpoints

- **POST /api/Auths/register**: Register a new user.
- **POST /api/Auths/createadmin**: Register a new admin.
- **POST /api/Auths/login**: Log in with email and password.

### Category Management

- **POST /api/Categories**: Create a new category.
- **GET /api/Categories**: Retrieve all categories.
- **GET /api/Categories/{id}**: Get details of a specific category by ID.
- **PUT /api/Categories/{id}**: Update a category by ID.
- **DELETE /api/Categories/{id}**: Delete a category by ID.

### Post Management

- **POST /api/Posts**: Create a new post.
- **GET /api/Posts**: Retrieve all posts.
- **GET /api/Posts/{id}**: Get details of a specific post by ID.
- **PUT /api/Posts/{id}**: Update a post by ID.
- **DELETE /api/Posts/{id}**: Delete a post by ID.

### Comment Management

- **POST /api/Comments**: Add a new comment.
- **GET /api/Comments**: Retrieve all comments.
- **GET /api/Comments/{id}**: Get details of a specific comment by ID.
- **PUT /api/Comments/{id}**: Update a comment by ID.
- **DELETE /api/Comments/{id}**: Delete a comment by ID.

### User Management

- **GET /api/Users**: Retrieve all users.
- **GET /api/Users/{id}**: Get details of a specific user by ID.

## Project Structure

- **Core**: Contains shared logic and domain entities.
- **Application**: Implements application-level services and use cases.
- **Domain**: Defines the core business logic and domain models.
- **Persistence**: Handles database interactions using Entity Framework Core.
- **WebApi**: Exposes RESTful endpoints for client interaction.
