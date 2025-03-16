using Microsoft.EntityFrameworkCore;

namespace FastBox.SaaS.Data.Extensions;

internal static class DbContextOptionsExtensions
{
	public static DbContextOptionsBuilder UseDefaultSchema(this DbContextOptionsBuilder optionsBuilder, string schemaName)
	{
		return optionsBuilder.UseNpgsql(npgsqlOptionsBuilder =>
			npgsqlOptionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", schemaName));
	}
}
