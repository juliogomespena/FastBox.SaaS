# Architecture Decisions

## Frontend
- **Platform**: Blazor WebAssembly
- **UI Framework**: MudBlazor
  - **Tenant-specific UI**: Dynamic component loading based on tenant context
  - **Tenant Selection**: Interface for users with multiple tenant access

## Backend
- **API Architecture**: ASP.NET Minimal APIs
- **Framework Version**: .NET 9
- **Multitenancy Implementation**: Session-based tenant context with middleware propagation

## Data Access
- **ORM**: Entity Framework Core
  - Selected for seamless integration with Minimal APIs
  - Better development velocity with reduced boilerplate
  - Built-in migration management for PostgreSQL schema evolution
  - Improved performance in .NET 9
  - Strong LINQ support and entity relationship handling
  - **Tenant Isolation**: Schema-based separation with dynamic context configuration
  - **Multitenant Support**: Runtime schema selection and tenant context filtering

## Database
- **Database System**: PostgreSQL
- **Schema Architecture**:
  - Main schema (`public`) for system-wide features and tenant management
  - Per-tenant schemas for car repair shop-specific data
  - Cross-schema relationships for shared reference data

## Tenant Identification Strategy
1. **Single URL Approach**
   - All tenants access the application through the same URL
   - No subdomain-based tenant identification
   - Simplified DNS management and SSL certificate requirements
   - Reduced infrastructure complexity and cost

2. **Session-Based Tenant Context**
   - User's current tenant stored in session after login
   - Tenant selection screen for users with access to multiple shops
   - Middleware sets correct tenant context for each request
   - JWT claims include current tenant context for API authorization

3. **Tenant Model Design**
   - Focus on essential properties: Id, Name, SchemaName
   - No Subdomain property required
   - Simplified tenant registration and management

4. **Benefits of this Approach**
   - Lower infrastructure costs
   - Simpler deployment in Azure
   - Easier maintenance and development
   - Streamlined user experience
   - Maintains proper data isolation between tenants

## Implementation Strategy
1. **Configure EF Core as the data access mechanism with tenant awareness**
   - Implement tenant-aware DbContext factory
   - Apply tenant-specific connection strings or schema selection
   - Implement automatic tenant filtering for data isolation

2. **Set up EF Core migrations for schema management**
   - Base migrations for main schema
   - Tenant-specific migration scripts for per-tenant schemas
   - Automated tenant provisioning workflow for new shop onboarding

3. **Leverage EF Core's LINQ provider for type-safe queries**
   - Apply global query filters for tenant data isolation
   - Implement tenant context for query scoping
   - Optimize cross-tenant queries for reporting scenarios

4. **Utilize EF Core's relationship management for entity associations**
   - Configure tenant boundaries for relationships using Fluent API
   - Apply proper cascade behaviors considering tenant isolation
   - Manage cross-schema references where appropriate

5. **Implement proper DbContext configuration with dependency injection**
   - Scoped DbContext with tenant resolution
   - Tenant context propagation through request pipeline
   - Tenant-specific configuration injection

6. **Design tenant identity and authorization system**
   - Shared authentication with tenant-specific authorization
   - Role-based access control within tenant boundaries
   - Cross-tenant access controls for administrative functions
   - Tenant selection for users with multiple tenant access

This approach prioritizes developer productivity and modern architecture patterns while providing a solid foundation for the application's multitenant data access needs. The schema-based isolation strategy in PostgreSQL offers strong separation between car repair shop data while maintaining the efficiency of a single database instance. The session-based tenant context simplifies user experience and reduces infrastructure complexity.
