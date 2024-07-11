using Application.Mappings;
using AutoMapper;

namespace Application.Dto.CategoryDto;

public class CreateCategoryDto : IMap
{
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDto, Domain.Entities.Category>();
    }
}