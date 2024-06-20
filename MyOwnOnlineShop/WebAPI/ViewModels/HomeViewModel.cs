namespace WebAPI.ViewModels
{
    using System.Collections.Generic;
    using Domain.Entities;

    public class HomeViewModel
    {
        public IEnumerable<Product> ProductsOfTheWeek { get; set; }
    }
}
