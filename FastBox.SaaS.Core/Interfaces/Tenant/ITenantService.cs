using FastBox.SaaS.Core.Models;

namespace FastBox.SaaS.Core.Interfaces.Tenant;

public interface ITenantService
{
	Task<TenantContext?> GetTenantContextAsync(Guid tenantId);
	Task<IEnumerable<TenantContext>> GetUserTenantsAsync(string userId);
	Task<bool> UserHasTenantAccessAsync(string userId, Guid tenantId);
	Task<TenantContext?> GetDefaultTenantForUserAsync(string userId);
	Task<bool> SetDefaultTenantForUserAsync(string userId, Guid tenantId);
}
