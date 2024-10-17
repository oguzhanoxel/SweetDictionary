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
				statusCode: System.Net.HttpStatusCode.Created,
				message: "Post Created."
			);
	}

	public DataResult<PostResponseDto> Delete(DeletePostRequestDto dto)
	{
		throw new NotImplementedException();
	}

	public DataResult<List<PostResponseDto>> GetAll()
	{
		var posts = _postRepository.GetAll();
		List<PostResponseDto> response = _mapper.Map<List<PostResponseDto>>(posts);
		return ResultFactory.Success(
				response,
				statusCode: System.Net.HttpStatusCode.OK
			);
	}

	public DataResult<PostResponseDto> GetById(Guid id)
	{
		var post = _postRepository.Get(p => p.Id == id);
		PostResponseDto response = _mapper.Map<PostResponseDto>(post);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK

			);
	}

	public DataResult<PostResponseDto> Update(UpdatePostRequestDto dto)
	{
		throw new NotImplementedException();
	}
}
