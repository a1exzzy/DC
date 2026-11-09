using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.Data;
using PaintStore.Models;

namespace PaintStore.API.Repositories;

public class UserRepository
{
    //只有在repository
    private PaintStoreDbContext _dbContext;

    public UserRepository(PaintStoreDbContext paintStoreDb)
    {
        _dbContext = paintStoreDb;
    }

    public User AddUserToDb(User user)
    {
        _dbContext.Users.Add(user);

        int changes = _dbContext.SaveChanges();
        //看看是否生效
        if (changes > 0)
        {
            return user;
        }
        //不然一条都没加上
        else
        {
            throw new DbUpdateException("Add User Failed");
        }
    }
}
