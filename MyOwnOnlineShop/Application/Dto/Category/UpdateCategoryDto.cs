using Application.Mappings;
using AutoMapper;

namespace Application.Dto.Category;

public class UpdateCategoryDto : IMap
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDto, Domain.Entities.Category.Category>();
    }
}