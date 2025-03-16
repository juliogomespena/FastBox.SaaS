using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
	{
		builder.ToTable("UserToken", "public");
	}
}
