using FastBox.SaaS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("User", "public");

		builder.HasMany(x => x.UserTenants)
			.WithOne(x => x.User)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
