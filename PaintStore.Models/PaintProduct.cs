using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintStore.Models;

public class PaintProduct
{
    public int Id { get; set; }
    
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public int Idd { get; set; }

    //[MaxLength(50)]//名字最长
    public string Name { get; set; }
    [Required] //不能null
    public decimal Price { get; set; }

    //PaintProduct ----- Order N : 1
    //Navigation Property
    public List<Order> Orders { get; set; } 
    //Convention based Foreign Key
    public int OrderId { get; set; }



    public PaintProduct(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
