using System.Text;
using Core.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using SweetDictionary.Application;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Contexts;
using SweetDictionary.Persistence.Repositories.Abstracts;
using SweetDictionary.Persistence.Repositories.Concretes;

namespace SweetDictionary.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddApplicationServices();

			builder.Services.AddScoped<IPostRepository, EfPostRepository>();
			builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
			builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
			builder.Services.AddDbContext<EfCoreDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
			
			builder.Services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<EfCoreDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = builder.Configuration["JWT:ValidAudience"],
					ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
					ClockSkew = TimeSpan.Zero,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
				};
			});
			
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(opt =>
			{
				opt.AddSecurityDefinition(
					name: "Bearer",
					securityScheme: new OpenApiSecurityScheme
					{
						Name = "Authorization",
						Type = SecuritySchemeType.Http,
						Scheme = "Bearer",
						BearerFormat = "JWT",
						In = ParameterLocation.Header,
						Description =
							"JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer YOUR_TOKEN\". \r\n\r\n"
							+ "`Enter your token in the text input below.`"
					}
				);
				opt.OperationFilter<BearerSecurityRequirementOperationFilter>();
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCustomExceptionMiddleware(); // ExceptionMiddleware

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}

public class BearerSecurityRequirementOperationFilter : IOperationFilter
{
	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		const string openApiSecurityScheme = "oauth2",
			openApiSecurityName = "Bearer";
		OpenApiSecurityRequirement openApiSecurityRequirement =
			new()
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = openApiSecurityName },
						Scheme = openApiSecurityScheme,
						Name = openApiSecurityName,
						In = ParameterLocation.Header,
					},
					Array.Empty<string>()
				}
			};
		operation.Security.Add(openApiSecurityRequirement);
	}
}
