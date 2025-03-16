namespace FastBox.SaaS.Core.Entities;

public sealed class UserTenant
{
	public Guid UserId { get; set; }
	public User User { get; set; } = null!;
	public Guid TenantId { get; set; }
	public Tenant Tenant { get; set; } = null!;
	public bool IsDefault { get; set; }
}