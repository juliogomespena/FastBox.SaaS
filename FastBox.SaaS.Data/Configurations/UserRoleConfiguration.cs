using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
	{
		builder.ToTable("UserRole", "public");
	}
}
