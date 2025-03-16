using FastBox.SaaS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
	public void Configure(EntityTypeBuilder<Tenant> builder)
	{
		builder.ToTable("Tenant", "public");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(x => x.SchemaName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(x => x.IsActive)
			.HasDefaultValue(true);

		builder.Property(x => x.CreatedAt)
			.HasDefaultValueSql("now()");

		builder.HasMany(x => x.UserTenants)
			.WithOne(x => x.Tenant)
			.HasForeignKey(x => x.TenantId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasIndex(x => x.SchemaName)
			.IsUnique();
	}
}
