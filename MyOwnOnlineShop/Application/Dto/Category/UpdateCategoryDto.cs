﻿using Application.Mappings;
using AutoMapper;

namespace Application.Dto.Category;

public class UpdateCategoryDto : IMap
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDto, Domain.Entities.Category>();
    }
}