using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Comment.RequestDtos;
using SweetDictionary.Domain.Dtos.Comment.ResponseDtos;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Services.Concretes;

public class CommentService : ICommentService
{
	private readonly ICommentRepository _commentRepository;
	private readonly IMapper _mapper;

	public CommentService(ICommentRepository commentRepository, IMapper mapper)
	{
		_commentRepository = commentRepository;
		_mapper = mapper;
	}

	public DataResult<CommentResponseDto> Create(CreateCommentRequestDto dto)
	{
		Comment created = _mapper.Map<Comment>(dto);
		created.Id = Guid.NewGuid();
		var comment = _commentRepository.Create(created);
		CommentResponseDto response = _mapper.Map<CommentResponseDto>(comment);

		return ResultFactory.Success(
			response,
		statusCode: System.Net.HttpStatusCode.Created);
	}

	public DataResult<CommentResponseDto> Delete(Guid id)
	{
		Comment? comment = _commentRepository.Get(x => x.Id == id);

		if (comment is null) return ResultFactory.Failure<CommentResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		var deleted = _commentRepository.Delete(comment);
		CommentResponseDto response = _mapper.Map<CommentResponseDto>(deleted);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<CommentResponseDto>> GetAll()
	{
		var comments = _commentRepository.GetAll();
		List<CommentResponseDto> response = _mapper.Map<List<CommentResponseDto>>(comments);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CommentResponseDto> GetById(Guid id)
	{
		Comment? comment = _commentRepository.Get(x => x.Id == id);

		if (comment is null) return ResultFactory.Failure<CommentResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		CommentResponseDto response = _mapper.Map<CommentResponseDto>(comment);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<CommentDetailResponseDto>> GetDetailAll()
	{
		var comments = _commentRepository.GetAll();
		List<CommentDetailResponseDto> response = _mapper.Map<List<CommentDetailResponseDto>>(comments);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CommentDetailResponseDto> GetDetailById(Guid id)
	{
		Comment? comment = _commentRepository.Get(x => x.Id == id);

		if (comment is null) return ResultFactory.Failure<CommentDetailResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		CommentDetailResponseDto response = _mapper.Map<CommentDetailResponseDto>(comment);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CommentResponseDto> Update(Guid id, UpdateCommentRequestDto dto)
	{
		Comment? comment = _commentRepository.Get(x => x.Id == id);

		if (comment is null) return ResultFactory.Failure<CommentResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		_mapper.Map(dto, comment);
		var updated = _commentRepository.Update(comment);
		CommentResponseDto response = _mapper.Map<CommentResponseDto>(updated);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
