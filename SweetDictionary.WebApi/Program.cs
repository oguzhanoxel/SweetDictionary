using Core.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

			builder.Services.AddAuthorization();

			builder.Services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<EfCoreDbContext>()
				.AddDefaultTokenProviders();

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

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
