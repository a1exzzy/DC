using System;
using PaintStore.API.Repositories;
using PaintStore.Models;

namespace PaintStore.API.Services;

public class UserService
{
    private UserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }
    public User CreateUser(User user)
    {
        if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name))
        {
            throw new ArgumentException("Email and Name can not be null or empty");
        }

        User newUSer = _userRepository.AddUserToDb(user);
        return newUSer;
    }
}
