namespace SweetDictionary.Domain.Dtos.Post.RequestDtos;

public sealed record UpdatePostRequestDto(Guid Id, string Title, string Content);
