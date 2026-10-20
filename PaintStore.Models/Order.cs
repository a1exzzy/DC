using System;

namespace PaintStore.Models;

public class Order
{
    public int Id { get; set; }
    public List<PaintProduct> PaintProducts { get; set; }
    public DateTime CreatAt { get; set; }

    // public decimal TotalPrice{ get
    //     {
    //         decimal totalPrice = PaintProducts.Sum(p=>p.Price);
    //         return totalPrice;
    //     }
    // }

    //只有get没有set的属性
    //Computed Value只读的值
    public decimal TotalPrice {get => PaintProducts.Sum(p=>p.Price);} 

    public Order(int id, List<PaintProduct> paintProducts)
    {
        Id = id;
        PaintProducts = paintProducts;
        CreatAt = DateTime.Now;
    }
}
