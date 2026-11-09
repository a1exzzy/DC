using System;
using PaintStore.API.Repositories;
using PaintStore.Models;

namespace PaintStore.API.Services;

public class UserService
{
    private UserRepository _userRepository;
    //加上configuration
    private IConfiguration _configuration;

    public UserService(UserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        //2
        _configuration = configuration;
    }
    public User CreateUser(User user)
    {
        if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name))
        {
            throw new ArgumentException("Email and Name can not be null or empty");
        }

        var key = _configuration.GetSection("ApiKeys:OpenAI");

        User newUSer = _userRepository.AddUserToDb(user);
        return newUSer;
    }
}
