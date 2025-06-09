using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.AttachmentsDto;

public record DownloadAttachmentDto(string Name, byte[] Content) : IMap
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Attachment, DownloadAttachmentDto>();
    }
}
