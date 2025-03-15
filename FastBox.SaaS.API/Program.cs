using FastBox.SaaS.Core.Entities;
using FastBox.SaaS.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FastBox.SaaS.API;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		/* Add services to the container */
		//Configure DbContext
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("dev")));

		//Configure Identity
		builder.Services.AddIdentity<User,IdentityRole<Guid>>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();

		//Add Authentication and Authorization
		builder.Services.AddAuthentication();
		builder.Services.AddAuthorization();

		//Add CORS
		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowBlazorApp", policy =>
			{
				policy.WithOrigins("http://localhost:5001")
					.AllowAnyHeader()
					.AllowAnyMethod();
			});
		});

		//Add OpenAPI
		builder.Services.AddOpenApi();

		/*Configure the HTTP request pipeline. */
		var app = builder.Build();

		//Configure development
		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
		}

		app.UseHttpsRedirection();
		app.UseCors();

		app.UseAuthentication();
		app.UseAuthorization();

		app.Run();
	}
}
