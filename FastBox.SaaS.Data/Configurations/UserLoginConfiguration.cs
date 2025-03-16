using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class UserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
	{
		builder.ToTable("UserLogin", "public");
	}
}
