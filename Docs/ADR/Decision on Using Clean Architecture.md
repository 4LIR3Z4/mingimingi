# ADR: Adoption of Clean Architecture

**Date**: January 11, 2025  
**Status**: Accepted

## Context

The Cooperative Banking system requires a scalable and maintainable architecture with a clear separation of concerns. The goal is to keep business logic independent of external systems such as databases, third-party services, and the user interface. **Clean Architecture** was chosen to achieve this separation and allow flexibility for future changes, especially as the system grows in complexity.

## Decision

We adopted **Clean Architecture** and organized the solution into the following layers:

### 1. **Core Layer**

This layer contains the essential business logic and is divided into two main projects:
- **LanguageLearning.Core.Domain**: 
  - Contains **Domain Entities**, **Value Objects**, **Aggregates**, and **Domain Events**.
  - The business rules and logic reside here. Entities represent the core data models, and aggregates serve as boundaries for consistency and transactional behavior.
  - **Value Objects**: Represent immutable types such as money, currency, and account numbers.
  - **Domain Events**: Capture significant business events and are raised when something important occurs in the domain.

- **LanguageLearning.Core.Application**:
  - Contains **Use Cases** (Application Services) in the form of **Commands**, **Queries**, and **Handlers**.
  - The application layer is responsible for coordinating the execution of business rules (from the domain layer) and system interactions (infrastructure).
  - **Contracts** (interfaces) are placed here to define dependencies like repositories, external services, and other required services.
  - We use **MediatR** for handling **Commands** and **Queries**, ensuring decoupling between the application logic and its execution.
    - **Commands**: Represent state-changing operations, such as updating an account balance.
    - **Queries**: Retrieve data without changing the system state, like fetching transaction history.
    - **MediatR Pipelines**: Used for **validation**, **logging**, and **performance monitoring**. The validation logic is handled via **FluentValidation**, and all commands and queries are validated before being processed.

### 2. **Infrastructure Layer**

This layer provides implementations for external dependencies and services. Each concern is broken into separate projects to keep the infrastructure code modular and clean:
- **LanguageLearning.Infrastructure.Persistence**: Implements repository interfaces defined in the application layer, managing database interactions (e.g., using SQL Server).
- **LanguageLearning.Infrastructure.Caching**: Provides caching mechanisms to optimize performance (e.g., using Redis or an in-memory cache).
- **LanguageLearning.Infrastructure.IdGenerator**: Handles unique ID generation (e.g., for accounts, transactions).
- **LanguageLearning.Infrastructure.DateTime**: Provides a centralized service for handling date and time operations in the system.
- **LanguageLearning.Infrastructure.Email**: Manages email sending functionality, integrating with external email providers as necessary.
- **LanguageLearning.Infrastructure.HealthChecks**: Implements system and service health checks to ensure availability and operational health of the system.
- **LanguageLearning.Infrastructure.MessagingBroker**: Integrates with messaging brokers (e.g., RabbitMQ, Kafka) for event-driven communication between services.
- **LanguageLearning.Infrastructure.Observability**: Handles logging, monitoring, and tracing to ensure visibility and performance tracking of the system.
- **LanguageLearning.Infrastructure.Security**: Implements security concerns like authentication, authorization, and encryption.
- **LanguageLearning.Infrastructure.ThirdPartyServices**: Manages interactions with third-party services, ensuring external service dependencies are encapsulated and isolated from the core business logic.

The infrastructure layer is **dependent** on the application and domain layers, but the reverse is not true. This ensures the core logic remains independent of external systems.

### 3. **Presentation Layer**

- **LanguageLearning.Presentation.API**: This project contains the **Web API**, which handles user requests and forwards them to the application layer via MediatR commands and queries.
  - The API does not contain any business logic; its role is simply to validate HTTP requests, map them to application commands/queries, and return the response.

### Contracts and Dependency Inversion

- **Dependency Inversion**: Contracts (interfaces) for infrastructure concerns (e.g., repositories, external services) are defined in the **Application Layer** and implemented in the **Infrastructure Layer**. This ensures the core remains independent of external details.
  
### MediatR Usage in Application Layer

1. **Command and Query Handlers**: 
   - Commands (write operations) and Queries (read operations) are handled by separate **Handlers**, ensuring separation of concerns.
   - These handlers are registered with **MediatR** and are invoked automatically based on the request type.
   
2. **Validation**: 
   - **FluentValidation** is integrated with MediatR pipelines to validate input data before executing any commands or queries.
   - Validation rules are defined in the application layer, allowing centralized validation logic that can be reused across different handlers.
   
3. **Cross-Cutting Concerns**: 
   - Logging, performance tracking, and exception handling are handled via custom MediatR **Pipeline Behaviors**, ensuring these concerns are applied uniformly without polluting the business logic.

### 4. **Tests Layer**

The **Tests Layer** is structured into three folders, each focusing on different aspects of testing:

1. **Architecture**:
   - **LanguageLearning.Architecture.Tests**: This project focuses on architectural tests, ensuring that the solution adheres to the intended architecture. Tests in this project enforce architectural constraints and validate that dependencies between layers are consistent with the Clean Architecture principles.

2. **Behaviour**:
   - **LanguageLearning.AcceptanceTests**: Implements **Behaviour-Driven Development (BDD)** style tests to verify the system’s behavior from an end-user perspective. These acceptance tests are written in a human-readable format, ensuring that the system meets business requirements.
   - **LanguageLearning.Core.Tests**: Contains **unit tests** for core domain logic. These tests focus on validating individual components in isolation, ensuring that the business logic behaves correctly according to the specifications.

3. **EndToEnd**:
   - **Robustness and Stress Testing**: Includes tools like **K6** for **stress testing**, ensuring the system can handle high loads, detect bottlenecks, and maintain performance under stress. These tests validate the robustness of the entire system, simulating real-world load conditions.

This layered testing approach ensures comprehensive coverage across different aspects of the system, from architecture validation and core logic testing to behavior verification and system-wide stress testing.

## Consequences

- **Positive**:
  - **Separation of Concerns**: Clear separation between business logic, infrastructure, and presentation.
  - **Maintainability**: Isolated business logic in the Core layer makes the system easier to maintain and extend.
  - **Testability**: The Core and Application layers are easily testable in isolation from the infrastructure.
  - **Framework Independence**: Changes to external frameworks or infrastructure do not affect the core business logic.
  - **Reusability**: Contracts, validation, and logic are reusable across different features.

- **Negative**:
  - **Initial Complexity**: The architecture introduces complexity, especially for smaller projects or simple features.
  - **Learning Curve**: Developers need to understand the roles of each layer, DDD patterns, and how to use MediatR pipelines effectively.
