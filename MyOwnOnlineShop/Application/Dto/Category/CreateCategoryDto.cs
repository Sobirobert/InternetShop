using Application.Mappings;
using AutoMapper;

namespace Application.Dto.Category;

public class CreateCategoryDto : IMap
{
    public string CategoryName { get; set; }
    public int DisplayOrder { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDto, Domain.Entities.Category>();
    }
}