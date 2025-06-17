using Application.Dto.AttachmentsDto;
using MediatR;

namespace WebAPI.Functions.Queries.AttachmentQueries;

public record DownloadAttachmentQuery(int Id, int ProductId) : IRequest<DownloadAttachmentDto>;