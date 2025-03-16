using FastBox.SaaS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class UserTenantConfiguration : IEntityTypeConfiguration<UserTenant>
{
	public void Configure(EntityTypeBuilder<UserTenant> builder)
	{
		builder.ToTable("UserTenant", "public");

		builder.HasKey(x => new { x.UserId, x.TenantId });

		builder.HasOne(x => x.User)
			.WithMany(x => x.UserTenants)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Tenant)
			.WithMany(x => x.UserTenants)
			.HasForeignKey(x => x.TenantId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
