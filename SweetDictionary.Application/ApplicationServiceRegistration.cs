using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SweetDictionary.Application.Mappings;
using SweetDictionary.Application.Rules;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Application.Services.Concretes;


namespace SweetDictionary.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<PostBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<CommentBusinessRules>();
        services.AddScoped<UserBusinessRules>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(typeof(MappingProfiles));

        return services;
    }
}