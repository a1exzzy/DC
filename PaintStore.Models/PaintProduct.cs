using System;

namespace PaintStore.Models;

public class PaintProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public PaintProduct(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}
