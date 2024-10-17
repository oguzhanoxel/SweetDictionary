﻿using Core.Results;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IPostService
{
	DataResult<PostResponseDto> Create(CreatePostRequestDto dto);
	DataResult<PostResponseDto> Update(UpdatePostRequestDto dto);
	DataResult<PostResponseDto> Delete(DeletePostRequestDto dto);
	DataResult<List<PostResponseDto>> GetAll();
	DataResult<PostResponseDto> GetById(Guid id);
}