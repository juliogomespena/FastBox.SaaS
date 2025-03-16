namespace FastBox.SaaS.Core.Models;

public sealed class TenantContext
{
	public Guid TenantId { get; set; }
	public string SchemaName { get; set; } = String.Empty;
	public string TenantName { get; set; } = String.Empty;
}
