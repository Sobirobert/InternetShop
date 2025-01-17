using Application.Dto;
using MediatR;

namespace WebAPI.Queries.Picture;

public class GetPicrtureByProductIdQuery : IRequest<IEnumerable<PictureDto>>
{
    public int ProductId { get; set; }
    public GetPicrtureByProductIdQuery(int productId)
    {
        ProductId = productId;
    }
}
