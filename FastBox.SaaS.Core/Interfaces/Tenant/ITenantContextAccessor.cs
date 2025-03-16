using FastBox.SaaS.Core.Models;

namespace FastBox.SaaS.Core.Interfaces.Tenant;

public interface ITenantContextAccessor
{
	TenantContext? TenantContext { get; set; }
}
