using Core.Results;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IPostService
{
	DataResult<PostResponseDto> Create(CreatePostRequestDto dto);
	DataResult<PostResponseDto> Update(Guid id, UpdatePostRequestDto dto);
	DataResult<PostResponseDto> Delete(Guid id);
	DataResult<List<PostResponseDto>> GetAll();
	DataResult<List<PostDetailResponseDto>> GetDetailAll();
	DataResult<PostResponseDto> GetById(Guid id);
	DataResult<PostDetailResponseDto> GetDetailById(Guid id);
}
