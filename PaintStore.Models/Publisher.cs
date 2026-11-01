using System;

namespace PaintStore.Models;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }

    //Navigation
    public ICollection<Book> Books = new List<Book>();
}
