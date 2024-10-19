using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SweetDictionary.Application.Mappings;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Application.Services.Concretes;
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
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ICommentService, CommentService>();

			builder.Services.AddScoped<IPostRepository, EfPostRepository>();
			builder.Services.AddScoped<IUserRepository, EfUserRepository>();
			builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
			builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();

			builder.Services.AddDbContext<EfCoreDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

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

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
