﻿using Application.Dto;
using Application.Interfaces;
using MediatR;
using WebAPI.Queries.Picture;

namespace WebAPI.Handlers.Picture;

public class GetPictureByIdHandler : IRequestHandler<GetPictureByIdQuery, PictureDto>
{
    private readonly IPictureService _pictureService;
    public GetPictureByIdHandler(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }

    public async Task<PictureDto> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
    {
        var picture = await _pictureService.GetPictureById(request.PictureId);
        return picture == null ? null : picture;
    }
}