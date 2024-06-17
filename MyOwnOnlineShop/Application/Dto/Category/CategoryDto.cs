using Application.Mappings;
using AutoMapper;

namespace Application.Dto.Category;

internal class CategoryDto : IMap
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreateDateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category.Category, CategoryDto>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.CreateDateTime));
    }
}