using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
	{
		builder.ToTable("Role", "public");
	}
}
