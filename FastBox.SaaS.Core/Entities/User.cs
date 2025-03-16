using Microsoft.AspNetCore.Identity;

namespace FastBox.SaaS.Core.Entities;

public sealed class User : IdentityUser<Guid>
{
	public ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();
}
