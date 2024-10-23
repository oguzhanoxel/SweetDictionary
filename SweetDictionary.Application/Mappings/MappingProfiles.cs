using AutoMapper;
using SweetDictionary.Domain.Dtos.Category.RequestDtos;
using SweetDictionary.Domain.Dtos.Category.ResponseDtos;
using SweetDictionary.Domain.Dtos.Comment.RequestDtos;
using SweetDictionary.Domain.Dtos.Comment.ResponseDtos;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Application.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
		// Post
        CreateMap<CreatePostRequestDto, Post>().ReverseMap();
        CreateMap<UpdatePostRequestDto, Post>().ReverseMap();

		CreateMap<Post, PostResponseDto>();
		CreateMap<Post, PostDetailResponseDto>();

		// Category
		CreateMap<CreateCategoryRequestDto, Category>().ReverseMap();
		CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();

		CreateMap<Category, CategoryResponseDto>();

		// Comment
		CreateMap<CreateCommentRequestDto, Comment>().ReverseMap();
		CreateMap<UpdateCommentRequestDto, Comment>().ReverseMap();

		CreateMap<Comment, CommentResponseDto>();
		CreateMap<Comment, CommentDetailResponseDto>();

		// User And Auth
		CreateMap<RegisterRequestDto, User>().ReverseMap();

		CreateMap<User, UserResponseDto>();
	}
}
