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

    //ModelBuilder modelBuilder是上面EF框架DbContext这个parrent自带的
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelbuilder能做什么？ignore啊 entity啊 什么的
        //entity其实就是上面的PaintProducts，Orders，Users这些
        //当我们选中一张表比如paintproduct的时候我们就能做更多的事情了 比如规定 HasKey必须有id（里面用lambda写）
        modelBuilder.Entity<PaintProduct>().HasKey(p => p.Id);
        modelBuilder.Entity<PaintProduct>().Property(p => p.Name).IsRequired().HasMaxLength(50);

        base.OnModelCreating(modelBuilder);



    }

}
