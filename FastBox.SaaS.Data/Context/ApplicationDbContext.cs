using FastBox.SaaS.Core.Entities;
using FastBox.SaaS.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastBox.SaaS.Data.Context;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfiguration(new UserConfiguration());

		builder.Entity<IdentityRole<Guid>>().ToTable("Role", "public");
		builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole", "public");
		builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim", "public");
		builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin", "public");
		builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim", "public");
		builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken", "public");
	}
}
