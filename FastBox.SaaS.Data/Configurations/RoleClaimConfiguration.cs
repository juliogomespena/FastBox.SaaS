﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
	{
		builder.ToTable("RoleClaim", "public");
	}
}
