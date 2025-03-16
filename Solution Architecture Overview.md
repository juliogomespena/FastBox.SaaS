# Solution Architecture Overview - Multitenant Car Repair Shop Application

## Project Structure
The solution consists of these projects:

1. **FastBox.SaaS.UI (Blazor WebAssembly)**
   - Client-side application with MudBlazor components
   - Contains pages, components, and services for API communication
   - User authentication and profile management interfaces
   - Tenant context management for UI state
   - Tenant-specific UI components and layouts

2. **FastBox.SaaS.API (ASP.NET Minimal APIs)**
   - REST API endpoints using Minimal API syntax
   - Request handling and business logic orchestration
   - ASP.NET Core Identity integration for authentication and authorization
   - Tenant resolution middleware
   - Schema selection based on tenant context

3. **FastBox.SaaS.Core**
   - Domain entities, interfaces, and DTOs
   - Business logic and validation rules
   - Application services and domain models
   - Custom identity models extending standard ASP.NET Identity entities
   - Tenant-specific and shared domain models
   - Tenant context abstractions and interfaces

4. **FastBox.SaaS.Data**
   - Multitenancy-aware EF Core DbContext implementation with Identity integration
   - Entity configurations using Fluent API
   - Repository implementations with tenant isolation
   - PostgreSQL-specific database concerns including schema management
   - Data migrations management for both main and tenant-specific schemas
   - Schema creation and tenant provisioning services

5. **FastBox.SaaS.Infrastructure**
   - Cross-cutting concerns like logging, caching, messaging
   - External service integrations
   - Email services for account management workflows
   - File storage with tenant isolation
   - Tenant resolution and context management services
   - Tenant-specific configuration providers

## Dependencies Flow
```
UI → API → Core ← Data
      ↑             ↑
       Infrastructure
```

## Multitenancy Implementation

1. **Single URL Approach**
   - All tenants access the application through the same URL (e.g., `fastbox.com`)
   - No subdomain-based tenant identification
   - Session-based tenant context after login
   - Tenant selection screen for users with access to multiple shops

2. **Database Schema Architecture**
   - Main schema (`public`) for shared functionality:
     - Tenant registration and management
     - Global user accounts and authentication
     - Cross-tenant reporting capabilities
     - System-wide configuration
   - Per-tenant schemas (e.g., `tenant_abc`, `tenant_xyz`):
     - Tenant-specific business data
     - Repair orders, customers, vehicles, services
     - Tenant-specific configurations and customizations
     - Tenant-specific reporting data

3. **Tenant Resolution and Context**
   - Tenant identification via session state
   - Tenant context propagation through request pipeline
   - Runtime schema selection based on resolved tenant
   - Tenant-specific connection management

4. **Data Isolation Strategy**
   - Schema-based isolation using PostgreSQL schemas
   - EF Core query filters for additional tenant isolation
   - DbContext factory pattern for tenant-specific contexts
   - Filtered navigation properties for cross-schema relations

5. **Tenant Provisioning**
   - New tenant onboarding workflow
   - Automated schema creation and initialization
   - Tenant-specific seed data population
   - Schema versioning and upgrade management

## Key Architectural Features

1. **Clean Architecture with Multitenancy**
   - Core domain remains independent of infrastructure concerns
   - Tenant-aware abstractions at appropriate layers
   - Dependency inversion with interfaces defined in Core
   - Business logic isolated from UI and database implementation details

2. **Modern Multitenant Data Access**
   - Entity Framework Core for PostgreSQL data operations across schemas
   - Structured migration approach for schema evolution (main and tenant schemas)
   - Tenant-aware DbContext with dynamic schema selection
   - Schema creation and management utilities

3. **Security Implementation**
   - ASP.NET Core Identity providing user and role management
   - JWT-based authentication for Blazor WebAssembly
   - Tenant-specific authorization policies
   - Cross-tenant access controls and permissions

4. **Maintainability Focus**
   - Clear separation of concerns
   - Standardized project organization
   - Consistent patterns across the solution
   - Testable components with minimal dependencies
   - Tenant context isolation for easier debugging

5. **Scalability Considerations**
   - Independent layers allow for component scaling
   - Clear boundaries support team collaboration
   - Infrastructure separation enables cloud-native approaches
   - Tenant-based data partitioning for improved performance
   - Potential for tenant-specific deployment options

This architecture provides a solid foundation for building a modern multitenant .NET 9 application with Blazor WebAssembly and PostgreSQL, incorporating ASP.NET Core Identity for security while maintaining clean architecture principles. The multitenant design allows for efficient management of multiple car repair shops through a single application instance while maintaining data isolation between tenants.
