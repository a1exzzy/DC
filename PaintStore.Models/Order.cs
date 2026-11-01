using System;

namespace PaintStore.Models;

public class Order
{
    public int Id { get; set; }

    //Order to PaintProduct 1:N
    //EF will apply relation based on list
    public List<PaintProduct> PaintProducts { get; set; }

    //User 的key
    public User User  { get; set; }
    public int UserId { get; set; }
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

    public Order()
    {
        PaintProducts = new List<PaintProduct>();
        CreatAt = DateTime.Now;
    }
}
