using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.Models;

namespace PaintStore.API.Data;

public class PaintStoreDbContext : DbContext
{
    //Dbset
    //数据库里有哪些table
    public DbSet<PaintProduct> PaintProducts { get; set; }

    //加入order user
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }


    //理解就好
    public PaintStoreDbContext(DbContextOptions<PaintStoreDbContext> options) : base(options)
    {
    }

}
