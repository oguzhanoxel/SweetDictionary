using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Rules;
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
	private readonly PostBusinessRules _businessRules;

    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
		_postRepository = postRepository;
        _mapper = mapper;
		_businessRules = businessRules;
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

	public DataResult<PostResponseDto> Delete(Guid id)
	{
		_businessRules.PostShouldExistWhenRequested(id);
		Post? post = _postRepository.Get(x => x.Id == id);
		var deleted = _postRepository.Delete(post);
		PostResponseDto response = _mapper.Map<PostResponseDto>(deleted);

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
		_businessRules.PostShouldExistWhenRequested(id);
		Post? post = _postRepository.Get(x => x.Id == id);
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
		_businessRules.PostShouldExistWhenRequested(id);
		Post? post = _postRepository.Get(x => x.Id == id);
		PostDetailResponseDto response = _mapper.Map<PostDetailResponseDto>(post);
		
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<PostResponseDto> Update(Guid id, UpdatePostRequestDto dto)
	{
		_businessRules.PostShouldExistWhenRequested(id);
		Post? post = _postRepository.Get(x => x.Id == id);
		_mapper.Map(dto, post);
		var updated = _postRepository.Update(post);
		PostResponseDto response = _mapper.Map<PostResponseDto>(updated);
		
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
