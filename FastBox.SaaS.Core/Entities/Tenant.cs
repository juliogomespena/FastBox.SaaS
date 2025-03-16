namespace FastBox.SaaS.Core.Entities;

public sealed class Tenant
{
	public Guid Id { get; set; }
	public string Name { get; set; } = null!;
	public string SchemaName { get; set; } = null!;
	public bool IsActive { get; set; } = true;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public virtual ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();
}
