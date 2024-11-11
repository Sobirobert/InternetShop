﻿using MyOwnOnlineShop.Contracts.Enums;

namespace MyOwnOnlineShop.Contracts.Request;

public class CreateProductDto
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Details { get; set; }
    public int YearOfProduction { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public bool IsProductOfTheWeek { get; set; }
    public TypeProduct TypeProduct { get; set; }
    public int CategoryId { get; set; }
}