using System;
using System.ComponentModel;

namespace PaintStore.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<Category> Categories { get; set; } = new List<Category>();

}
