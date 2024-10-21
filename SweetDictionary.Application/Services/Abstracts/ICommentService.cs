using Core.Results;
using SweetDictionary.Domain.Dtos.Comment.RequestDtos;
using SweetDictionary.Domain.Dtos.Comment.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface ICommentService
{
	DataResult<CommentResponseDto> Create(CreateCommentRequestDto dto);
	DataResult<CommentResponseDto> Update(Guid id, UpdateCommentRequestDto dto);
	DataResult<CommentResponseDto> Delete(Guid id);
	DataResult<List<CommentResponseDto>> GetAll();
	DataResult<List<CommentDetailResponseDto>> GetDetailAll();
	DataResult<CommentResponseDto> GetById(Guid id);
	DataResult<CommentDetailResponseDto> GetDetailById(Guid id);
}
