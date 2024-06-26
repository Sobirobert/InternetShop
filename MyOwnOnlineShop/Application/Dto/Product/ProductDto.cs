﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto;

public class ProductDto : IMap
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string DescriptionOfProduct { get; set; }
    public int YearOfProduction { get; set; }
    public double Price { get; set; }
    public string UserId { get; set; }
    public Domain.Enums.Type Type { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Created));
    }
}