using FastBox.SaaS.Core.Entities;
using FastBox.SaaS.Core.Interfaces.Tenant;
using FastBox.SaaS.Core.Models;
using FastBox.SaaS.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FastBox.SaaS.Data.Context;

public sealed class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	private readonly TenantContext? _tenantContext;

	public DbSet<Tenant> Tenants => Set<Tenant>();
	public DbSet<UserTenant> UserTenants => Set<UserTenant>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
								ITenantContextAccessor? tenantContextAccessor = null) 
								: base(options)
	{
		_tenantContext = tenantContextAccessor?.TenantContext;
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());														
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

		if (_tenantContext is not null && String.IsNullOrEmpty(_tenantContext.SchemaName) is false)
		{
			optionsBuilder.UseDefaultSchema(_tenantContext.SchemaName);
		}
	}

	public override int SaveChanges()
	{
		return SaveChanges(true);
	}

	public override int SaveChanges(bool acceptAllChangesOnSuccess)
	{
		ApplyTenantFilters();
		return base.SaveChanges(acceptAllChangesOnSuccess);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return SaveChangesAsync(true, cancellationToken);
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	{
		ApplyTenantFilters();
		return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

	private void ApplyTenantFilters()
	{
		if (_tenantContext is null || _tenantContext.TenantId == Guid.Empty)
			return;

		//TODO: Implement tenant filtering logic
		// Apply tenant filtering logic to entities with tenant IDs
		// You would need to implement this for your tenant-specific entities
	}
}
