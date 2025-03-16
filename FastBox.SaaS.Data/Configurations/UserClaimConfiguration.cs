﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBox.SaaS.Data.Configurations;

internal sealed class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
	{
		builder.ToTable("UserClaim", "public");
	}
}
