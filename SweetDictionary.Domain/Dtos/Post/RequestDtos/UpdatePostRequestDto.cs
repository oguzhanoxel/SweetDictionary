namespace SweetDictionary.Domain.Dtos.Post.RequestDtos;

public sealed record UpdatePostRequestDto(Guid id, string Title, string Content);
