namespace SweetDictionary.Domain.Dtos.Post.RequestDtos;

public sealed record CreatePostRequestDto(string Title, string Content, Guid CategoryId, Guid AuthorId);
