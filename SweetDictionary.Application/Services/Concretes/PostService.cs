using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Services.Concretes;

public class PostService : IPostService
{
	private readonly IPostRepository _postRepository;
	private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
		_postRepository = postRepository;
        _mapper = mapper;
    }

    public DataResult<PostResponseDto> Create(CreatePostRequestDto dto)
	{
		Post created = _mapper.Map<Post>(dto);
		created.Id = Guid.NewGuid();
		var post = _postRepository.Create(created);
		PostResponseDto response = _mapper.Map<PostResponseDto>(post);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.Created);
	}

	public DataResult<PostResponseDto> Delete(DeletePostRequestDto dto)
	{
		if (IsNull(dto.Id)) return ResultFactory.Failure<PostResponseDto>(
					null,
					statusCode: System.Net.HttpStatusCode.NotFound,
					message: "Post not found.");

		Post deleted = _mapper.Map<Post>(dto);
		var post = _postRepository.Delete(deleted);
		PostResponseDto response = _mapper.Map<PostResponseDto>(post);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<PostResponseDto>> GetAll()
	{
		var posts = _postRepository.GetAll();
		List<PostResponseDto> response = _mapper.Map<List<PostResponseDto>>(posts);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<PostResponseDto> GetById(Guid id)
	{
		if (IsNull(id))	return ResultFactory.Failure<PostResponseDto>(
							null,
							statusCode: System.Net.HttpStatusCode.NotFound,
							message: "Post not found.");

		var post = _postRepository.Get(p => p.Id == id);
		PostResponseDto response = _mapper.Map<PostResponseDto>(post);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<PostDetailResponseDto>> GetDetailAll()
	{
		var posts = _postRepository.GetAll();
		List<PostDetailResponseDto> response = _mapper.Map<List<PostDetailResponseDto>>(posts);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<PostDetailResponseDto> GetDetailById(Guid id)
	{
		if (IsNull(id)) return ResultFactory.Failure<PostDetailResponseDto>(
					null,
					statusCode: System.Net.HttpStatusCode.NotFound,
					message: "Post not found.");

		var post = _postRepository.Get(p => p.Id == id);
		PostDetailResponseDto response = _mapper.Map<PostDetailResponseDto>(post);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<PostResponseDto> Update(UpdatePostRequestDto dto)
	{
		if (IsNull(dto.Id)) return ResultFactory.Failure<PostResponseDto>(
					null,
					statusCode: System.Net.HttpStatusCode.NotFound,
					message: "Post not found.");

		Post updated = _mapper.Map<Post>(dto);
		var post = _postRepository.Update(updated);
		PostResponseDto response = _mapper.Map<PostResponseDto>(post);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	private bool IsNull(Guid id)
	{
		var post = _postRepository.Get(p => p.Id == id);
		if (post == null) return true;
		return false;
	}
}
