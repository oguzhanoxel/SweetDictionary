using AutoMapper;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Application.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto, Post>().ReverseMap();
        CreateMap<Post, PostResponseDto>();
    }
}
