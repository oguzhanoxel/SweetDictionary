using System.Text;
using Core.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SweetDictionary.Application.Mappings;
using SweetDictionary.Application.Rules;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Application.Services.Concretes;
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

			builder.Services.AddScoped<IPostService, PostService>();
			builder.Services.AddScoped<IAuthService, AuthService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ICommentService, CommentService>();

			builder.Services.AddScoped<IPostRepository, EfPostRepository>();
			builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
			builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();

			builder.Services.AddScoped<PostBusinessRules>();
			builder.Services.AddScoped<CategoryBusinessRules>();
			builder.Services.AddScoped<CommentBusinessRules>();
			builder.Services.AddScoped<UserBusinessRules>();

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

			builder.Services.AddAutoMapper(typeof(MappingProfiles));

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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
