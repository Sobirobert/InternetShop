using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.CategoryDto;
public class UpdateCategoryDto : IMap
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCategoryDto, Category>();
    }
}