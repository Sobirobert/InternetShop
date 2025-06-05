using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.AttachmentsDto;
public record AttachmentDto(int Id, string Name, int UserId) : IMap
{
    public record DownloadAttachmentDto( byte[] Content);
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Attachment, AttachmentDto>();
    }
}