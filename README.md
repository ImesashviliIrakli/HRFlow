# HRFlow

This HR Management System is a scalable, modular, and high-performance application built using **Clean Architecture**, **Domain-Driven Design (DDD)**, **CQRS**, and **.NET 8**. It leverages both **SQL** for writes and **MongoDB** for reads, while employing **MediatR** to handle domain events and synchronize data. The application also includes a **RESTful Web API** with **JWT** authentication and **Identity** for authorization.

## Features

- **Clean Architecture**: Separation of concerns into layers (Domain, Application, Infrastructure, and API), ensuring maintainability and scalability.
- **Domain-Driven Design (DDD)**: Business logic is encapsulated in domain models with rich behavior, promoting a clear focus on core business concepts.
- **CQRS (Command Query Responsibility Segregation)**: Commands (writes) and Queries (reads) are handled separately, optimizing data handling and performance.
- **Dual Database Strategy**: 
  - **SQL Database**: For write operations (commands).
  - **MongoDB**: For read operations (queries) to ensure fast read access.
- **Domain Events**: Entities raise events that are handled asynchronously with MediatR to synchronize data across both SQL and MongoDB.
- **JWT Authentication**: Secure authorization using **JSON Web Tokens** (JWT) and **ASP.NET Identity** for user management and authentication.
- **RESTful Web API**: A scalable API with endpoints following REST principles, handling business logic via commands and queries.
- **MediatR**: Used to dispatch commands, queries, and domain events across the application, promoting decoupled business logic.
  
## Technologies Used

- **.NET 8**: The latest version of the .NET platform, providing high performance and cutting-edge features.
- **ASP.NET Core**: For building the RESTful Web API.
- **Entity Framework Core**: For data access with SQL, leveraging the repository pattern.
- **MongoDB**: For handling read operations, ensuring low-latency queries.
- **MediatR**: For command, query, and event dispatching.
- **Identity**: For user authentication and authorization management.
- **JWT (JSON Web Tokens)**: Secure token-based authentication.
  
## Architecture Overview

The HR Management System follows the **Clean Architecture** pattern with distinct layers:

1. **Domain Layer**: Contains business logic, domain entities, and value objects. It also includes domain events that notify the system of changes in the domain model.
2. **Application Layer**: Holds the use cases of the system, including commands, queries, and their handlers. This layer interacts with the domain layer through interfaces.
3. **Infrastructure Layer**: Contains external services such as data access (SQL and MongoDB), authentication, and message brokers. It is where the concrete implementations of repositories are located.
4. **API Layer**: Exposes the RESTful API, handling HTTP requests and mapping them to the appropriate commands and queries.

### CQRS Implementation

- **Commands**: Used for write operations, interacting with the SQL database via **Entity Framework Core**. Domain events are raised and handled by event handlers to sync MongoDB.
- **Queries**: Optimized for read operations, using **MongoDB** to quickly return data.

### Domain Events & Synchronization

- When a command modifies the state of an entity (e.g., employee data or leave requests), domain events are raised.
- These events are published via **MediatR**, triggering event handlers that update MongoDB for fast read access.

