using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Category
{
    public class CategoryShowAllDto : IMap
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int CountProductsInCategory {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryShowAllDto, Domain.Entities.Category>();
        }
    }
}
